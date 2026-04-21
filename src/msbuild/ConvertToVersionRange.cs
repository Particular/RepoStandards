using System;
using System.Text.RegularExpressions;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

public class ConvertToVersionRange : Task
{
    [Required]
    public ITaskItem[] References { get; set; } = [];

    [Required]
    public string VersionProperty { get; set; } = string.Empty;

    [Output]
    public ITaskItem[] ReferencesWithVersionRanges { get; private set; } = [];

    public override bool Execute()
    {
        var success = true;

        foreach (var reference in References)
        {
            var automaticVersionRange = reference.GetMetadata("AutomaticVersionRange");

            if (automaticVersionRange.Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var privateAssets = reference.GetMetadata("PrivateAssets");

            if (privateAssets.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var version = reference.GetMetadata(VersionProperty);
            // Strip any prerelease suffix (e.g. "1.0.0-alpha.2") before extracting segments.
            var versionCore = Regex.Match(version, @"^[\d.]+").Value;
            var segments = Regex.Matches(versionCore, @"\d+");

            if (segments.Count == 0)
            {
                Log.LogError("Reference '{0}' with version '{1}' is not valid for automatic version range conversion. Fix the version or exclude the reference from conversion by setting 'AutomaticVersionRange=\"false\"' on the reference.", reference.ItemSpec, version);
                success = false;
                continue;
            }

            // AutomaticVersionRangeSegments controls which segment is bumped to form the upper bound.
            // Default 1 (SemVer: bump major). For vendors that don't follow SemVer and introduce
            // breaking changes in 2nd, or 3rd segment of versions numbers (e.g. IBM MQ, RavenDB)
            var segmentsMetadata = reference.GetMetadata("AutomaticVersionRangeSegments");
            var segmentCount = 1;
            if (!string.IsNullOrEmpty(segmentsMetadata) && (!int.TryParse(segmentsMetadata, out segmentCount) || segmentCount < 1))
            {
                Log.LogError("Reference '{0}' has invalid AutomaticVersionRangeSegments value '{1}'. Must be a positive integer.", reference.ItemSpec, segmentsMetadata);
                success = false;
                continue;
            }

            var effectiveCount = Math.Min(segmentCount, segments.Count);
            var parts = new string[effectiveCount];
            for (var i = 0; i < effectiveCount; i++)
            {
                parts[i] = segments[i].Value;
            }
            parts[effectiveCount - 1] = (Convert.ToInt32(parts[effectiveCount - 1]) + 1).ToString();

            var versionRange = $"[{version}, {string.Join(".", parts)})";
            reference.SetMetadata(VersionProperty, versionRange);
        }

        ReferencesWithVersionRanges = References;

        return success;
    }
}
