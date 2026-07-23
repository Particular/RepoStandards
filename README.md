# RepoStandards

This repository contains mandatory files that all repositories should have. 

> [!WARNING]
> Any change to this repository creates PRs for all branches in all synchronized repositories, so merging a PR in this repo requires approval from the [@repostandards-admins group](https://github.com/orgs/Particular/teams/repostandards-admins).

## How it works

- Automation detects changes to this repository on a schedule and opens PRs against other repositories.
- Changes will be applied to the default branch plus any `release-*` branches of any repository containing a `.reposync.yml` marker file.
  - Only new or updated files are supported. Removing a previously synchronized file must be done manually.
  - This `README.md` file is not synchronized.
  - The `.config.yml` file is not synchronized. See [Centralized configuration](#centralized-configuration) below.

## How the resulting PRs are handled

- Once the [@repostandards-admins group](https://github.com/orgs/Particular/teams/repostandards-admins) determines the open PRs have enough value to justify the work of handling all the resulting synchronization PRs, they will coordinate to merge them in a short window of time.
- After the automation that detects the changes runs and finishes opening all the PRs, they will coordinate to work on merging all the PRs.
- Given these PRs most of the times don't represent external changes, the changes won't be released.

## Configuration points

### Customization of synchronized files

The files managed by the synchronization tool cannot be customized in individual code repositories (without changes to the `.reposync.yml` file), because a PR will be raised to override any customizations when the scheduled automation runs.
That being said, the following files have an extension point that allow for customization without any extra settings:

- `Directory.Build.props`: Include any custom settings in a `Custom.Build.props` file located next to the `Directory.Build.props` file.
- `.gitignore`: Use [nested ignore files](https://git-scm.com/docs/gitignore#_description) to ignore custom files and folders.

### Centralized configuration

Some broad-based configuration can be accomplished through the `.config.yml` file in this repository.

#### Public vs. private repos

Some files are not needed in private repos, which are used for internal tools, and are not part of the Particular Service Platform.

```yml
excludeOnPrivateRepo:
  - LICENSE.md
  - CONTRIBUTING.md
```

Conversely, files can also be excluded from syncing to public repos:

```yml
excludeOnPublicRepo:
  - private/OnlyPrivateRepos.md
```

#### Default vs. release branches

Some files are only valid on the repo's default branch. This is especially true for GitHub-related configuration files like issue templates. We accept that these files will no longer be synchronized and fall out-of-date once a release branch is created, and we make no effort to edit or remove these files from release branches.

```yml
excludeOnReleaseBranch:
  - .github/dependabot.yml
  - .github/workflows/workflow-with-cron-trigger.yml
```

Files can also be limited to release branches only, so when a new release branch is made, it will get a PR to add these files the next time the automation runs:

```yml
excludeOnDefaultBranch:
  - directory/release-branch-only.ext
```

### Target repository configuration

Finer-grained configuration can be accomplished at the level of the target repository using the `.reposync.yml` file in each target repository.

#### Ignoring

If a branch of a repository should not be synchronized, an ignore flag can be added to that branch's `.reposync.yml` configuration file.

```yml
ignore: true
```

#### Exclusions

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
