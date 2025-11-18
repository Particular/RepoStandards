# RepoStandards

This repository contains mandatory files that all repositories should have. 

## Workflow

> _**IMPORTANT**: Because changes to this repository creates many PRs in many repositories, PRs in this repository should not be merged lightly. If possible, try to stage multiple PRs and merge them as a group to limit the amount of PRs that must go through the CI pipeline._

* Changes to this repository are made via PRs. 
* Automation detects changes to this repository on a schedule and opens PRs against other repositories.
* Changes will be applied to the default branch plus any `release-*` branches of a target repository containing a `.reposync.yml` marker file.
* Only new or updated files are supported. Removing a previously synchronized file must be done manually.
* This `README.md` file is not synchronized.
* The `.config.yml` file is not synchronized. See [Centralized configuration](#centralized-configuration) below.

## Customization of synchronized files

The files managed by the synchronization tool cannot be customized in individual code repositories because any customizations will be overwritten (via a PR) when the scheduled sync runs.

The following files have an extension point that allow for customization:

* `Directory.Build.props`: Include any custom settings in a `Custom.Build.props` file located next to the `Directory.Build.props` file.
* `.gitignore`: Use [nested ignore files](https://git-scm.com/docs/gitignore#_description) to ignore custom files and folders.

## Centralized configuration

Some broad-based configuration can be accomplished through the `.config.yml` file in this repository.

### Public vs. private repos

Some files are not needed in private repos, which are used for internal tools, and are not part of the Particular Service Platform.

```yml
excludeOnPrivateRepo:
  - LICENSE.md
  - CONTRIBUTING.md
```

Files can also be excluded from syncing to public repos:

```yml
excludeOnPublicRepo:
  - private/OnlyPrivateRepos.md
```

### Default vs. release branches

Some files are only valid on the repo's default branch. This is especially true for GitHub-related configuration files like for Dependabot. We accept that these files will no longer be synchronized and fall out-of-date once a release branch is created, and we make no effort to edit or remove these files from release branches.

```yml
excludeOnReleaseBranch:
  - .github/dependabot.yml
  - .github/workflows/workflow-with-cron-trigger.yml
```

Files can also be limited to release branches only. When a new release branch is made, it would get a PR to add these files the next time synchronization is run:

```yml
excludeOnDefaultBranch:
  - directory/release-branch-only.ext
```

## Target repository configuration

Finer-grained configuration can be accomplished at the level of the target repository using the `.reposync.yml` file in each target repository.

## Ignoring

If a branch of a repository should not be synchronized, an ignore flag can be added to that branch's `.reposync.yml` configuration file.

```yml
ignore: true
```

## Exclusions

If a file included in the RepoStandards repository is not appropriate for a repository, an exclusion can be defined in the `.reposync.yml` configuration file to prevent the file from being synchronized.

```yml
exclusions:
- src/NServiceBus.snk
- LICENSE.md
```

## Code style and .editorconfig

The `.editorconfig` file in this repository defines the shared code style for synchronized repositories. Changes to coding standards, including `.editorconfig`, should be treated as larger/impactful decisions and follow a careful review process.

### General principles

- Coding standards should remain stable and not change often, but they are not frozen. Challenging existing rules is acceptable, yet changes must come with strong justification.
- The exact standard matters less than having a consistent one that everyone follows. Consistency is valuable in its own because it reduces cognitive overhead when working across repositories.
- Changing standards is expensive because updates ripple through downstream repositories.
- A standard can still be a good standard even if not everyone is happy with it.
- Different rules impose different levels of friction; this should be considered when proposing changes.

### Decision making

Some changes are more impactful than others. For example, this is the case when the proposed changes are more restrictive than the current settings. When this is the case:
- Changes to standards should require more than a simple majority. Fifty percent is too low; around eighty percent agreement that a rule causes friction was mentioned as a rough benchmark.
- The cost and impact of changing a rule should always be part of the argument, including the effect on existing repositories and branches.
- Some improvements may not require new or changed coding standards at all, depending on the nature of the change.

### Batching and cadence

- Batching changes is beneficial to reduce repeated breakage and churn across repositories.
- A good rollout cadence can be to align larger batches of code style changes with STS releases.
