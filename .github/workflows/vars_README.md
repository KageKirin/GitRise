# Repository-wide Variables to set up

In order to be DRY-compliant, the following variables must be set.
Each variable is a **JSON**-representation of the regular YAML arrays/dicts
and must be converted back using the intrinsic `fromJson()` method.

## Variables used by build actions/macros

These are the variables to set up to be passed to build actions/macros, i.e.

- `build-branch`
- `build-pr`
- `build-tag`
- `build-ci`
- `build-cron`

```yaml
BUILD_CONFIGURATIONS: ["Debug", "Release"]
BUILD_FRAMEWORKS: ["net9.0"]
BUILD_MATRIX: |-
  [
    {
      "framework": "net9.0",
      "projects": "GitRise.sln"
    }
  ]
```

## Variables used by unittest actions/macros

These are the variables to set up to be passed to unit test actions/macros, i.e.

- `build-branch`
- `build-pr`
- `build-tag`
- `build-ci`

```yaml
TEST_CONFIGURATIONS: ["Debug"]
TEST_FRAMEWORKS: ["net9.0"]
TEST_MATRIX: |-
  [
    {
      "framework": "net9.0",
      "projects": "GitRise.sln"
    }
  ]
```

## Variables used by nuget-pack and nuget-publish actions/macros

These are the variables to set up to be passed to nuget-pack and nuget-publish actions/macros, i.e.

- `build-branch`
- `build-pr`
- `build-tag`
- `build-ci`
- `publish-nuget`

```yaml
DEPLOY_PROJECTS: ["GitRise.sln"]
DEPLOY_CONFIGURATIONS: ["Release"]
DEPLOY_FRAMEWORKS: [""] ## yes, left empty
```

## Variables used by nuget-publish actions/macros

These are the variables to set up to be passed to nuget-publish actions/macros, i.e.

- `publish-nuget`

```yaml
DEPLOY_SOURCES: ["github", "nuget"]
DEPLOY_MATRIX: |-
  [
    {
      "source": "github",
      "registry": "https://nuget.pkg.github.com/KageKirin/index.json",
      "username": "KageKirin",
      "token": "GH_PACKAGE_TOKEN"
    },
    {
      "source": "nuget",
      "registry": "https://api.nuget.org/v3/index.json",
      "username": "KageKirin",
      "token": "NUGET_ORG_TOKEN"
    }
  ]
```
