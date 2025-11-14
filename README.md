# dotnet-ci-example

[![GitHub release (latest by date)](https://img.shields.io/github/v/release/nogic1008/dotnet-ci-example)](https://github.com/nogic1008/dotnet-ci-example/releases)
[![.NET CI/CD](https://github.com/nogic1008/dotnet-ci-example/actions/workflows/dotnet.yml/badge.svg)](https://github.com/nogic1008/dotnet-ci-example/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/nogic1008/dotnet-ci-example/branch/main/graph/badge.svg?token=wkwjZuMLHC)](https://codecov.io/gh/nogic1008/dotnet-ci-example)
[![CodeFactor](https://www.codefactor.io/repository/github/nogic1008/dotnet-ci-example/badge)](https://www.codefactor.io/repository/github/nogic1008/dotnet-ci-example)
[![License](https://img.shields.io/github/license/nogic1008/dotnet-ci-example)](LICENSE)

A comprehensive template for .NET libraries with production-ready CI/CD pipelines using GitHub Actions. This template demonstrates best practices for multi-target framework support, automated testing, code coverage, and package publishing.

## How to Use This Template

### 1. Create Your Repository

Click the "Use this template" button on GitHub to create a new repository based on this template.

### 2. Customize Your Project

After creating your repository, update the following:

#### Update Namespace and Project Names

- Rename `src/Sample.Core/` directory to your library name (e.g., `src/YourLibrary/`)
- Rename `test/Sample.Test/` directory to match (e.g., `test/YourLibrary.Test/`)
- Update `.csproj` file names accordingly
- Replace namespace `Sample.Core` with your namespace in all `.cs` files
- Update the solution file `dotnet-ci-example.slnx` to reference your renamed projects

#### Update Project Metadata

Edit `Directory.Build.props`:

```xml
<Authors>Your Name</Authors>
<Copyright>©2024 Your Name</Copyright>
<PackageProjectUrl>https://github.com/yourusername/your-repo</PackageProjectUrl>
```

#### Update Package Description

In your library's `.csproj` file (e.g., `src/YourLibrary/YourLibrary.csproj`), update:

```xml
<Description>Your library description</Description>
```

#### Configure Badges

Update the README badges to point to your repository by replacing `nogic1008/dotnet-ci-example` with your repository path.

### 3. Configure CI/CD Secrets (Optional)

For automatic NuGet publishing on release:

1. Go to your repository Settings → Secrets and variables → Actions
2. Add necessary secrets:
   - `CODECOV_TOKEN` - For code coverage reports (get from [codecov.io](https://codecov.io))
3. Configure variables:
   - `NUGET_USER_NAME` - Your NuGet.org username for OIDC authentication

## Development

### Prerequisites

- **.NET SDK**: Version **10.0.100** or compatible (specified in `global.json`)
  - The SDK will automatically roll forward to newer feature versions
  - Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download)

### Development Environment Options

#### Option 1: Local Development

Install the required .NET SDK version, then:

```console
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run tests
dotnet test
```

#### Option 2: Dev Container

This repository includes a Dev Container configuration (`.devcontainer/`) with all required tools:

- .NET 10.0 SDK
- .NET 9.0 SDK
- .NET 8.0 SDK
- Mono (for .NET Framework support)
- EditorConfig support

Open the repository in Visual Studio Code with the Dev Containers extension, or use GitHub Codespaces.

## Folder Structure

```
.
├── .devcontainer/          # Dev Container configuration for VS Code
│   └── devcontainer.json   # Container setup with .NET SDKs and Mono
├── .github/
│   ├── workflows/
│   │   └── dotnet.yml      # CI/CD pipeline definition
│   ├── dependabot.yml      # Automated dependency updates
│   └── dotnet-format.json  # Problem matcher for dotnet format
├── src/
│   └── Sample.Core/        # Main library project
│       ├── Sample.Core.csproj
│       └── FizzBuzz.cs     # Example implementation
├── test/
│   └── Sample.Test/        # Test project
│       ├── Sample.Test.csproj
│       ├── FizzBuzz.Test.cs
│       └── packages.lock.json
├── Directory.Build.props   # Shared MSBuild properties (metadata, options)
├── Directory.Packages.props # Central Package Management configuration
├── global.json             # .NET SDK version pinning
├── dotnet-ci-example.slnx  # Solution file (XML format)
├── .editorconfig           # Code style and formatting rules
└── .gitignore              # Git ignore patterns
```

### Key Files Explained

- **`Directory.Build.props`**: Shared MSBuild properties applied to all projects (author, version, licensing, build options)
- **`Directory.Packages.props`**: Central Package Management (CPM) - all package versions defined in one place
- **`global.json`**: Pins the .NET SDK version for consistent builds across environments
- **`packages.lock.json`**: Lock file ensuring reproducible package restores

## Commands

### Development Commands

```console
# Restore dependencies
dotnet restore

# Restore with lock file validation (CI mode)
dotnet restore --locked-mode

# Build the solution
dotnet build

# Build without restoring
dotnet build --no-restore

# Run tests
dotnet test

# Run tests for specific framework
dotnet test --framework net10.0

# Lint code style
dotnet format --verify-no-changes

# Auto-fix code style issues
dotnet format

# Create NuGet package (Release mode)
dotnet pack --configuration Release
```

### Version Management

The version is controlled in `Directory.Build.props`:

```xml
<VersionPrefix>0.5.0</VersionPrefix>
```

During CI/CD, version suffixes are automatically added:
- Release builds: Use the tag version (e.g., `v1.0.0` → `1.0.0`)
- Nightly builds: Use commit SHA (e.g., `0.5.0-nightly-a1b2c3d`)

## CI/CD Guide

This template includes a comprehensive GitHub Actions workflow (`.github/workflows/dotnet.yml`) with the following jobs:

### Workflow Jobs

#### 1. **Lint** - Code Style Validation

- Runs `dotnet format --verify-no-changes`
- Ensures code follows `.editorconfig` rules
- Uses problem matcher for inline annotations

#### 2. **Validate** - Lock File Verification

- Validates `packages.lock.json` files
- Runs `dotnet restore --locked-mode`
- Ensures reproducible builds

#### 3. **Test** - Multi-Platform Testing

- Tests on multiple operating systems:
  - Ubuntu (x64 and ARM)
  - Windows (x64 and ARM)
  - macOS (Intel and Apple Silicon)
- Tests multiple target frameworks:
  - .NET 10.0
  - .NET 9.0
  - .NET 8.0
  - .NET Framework 4.8 (Windows only)
- Generates code coverage reports
- Uploads coverage to Codecov

#### 4. **Pack** - NuGet Package Creation

- Runs after successful lint, validate, and test jobs
- Only on `push` to main branch and `release` events
- Creates NuGet packages (`.nupkg`)
- Versions packages based on event type:
  - Release: Uses git tag version
  - Push: Uses nightly version with commit SHA
- Uploads packages as build artifacts

#### 5. **Publish** - Package Distribution

- Runs after successful pack job
- Publishes to different feeds based on event:
  - **Release**: Publishes to NuGet.org
  - **Push to main**: Publishes to GitHub Packages (nightly builds)
- Uses OIDC authentication for secure NuGet publishing
- Attaches packages to GitHub Releases

### Triggering the Pipeline

```yaml
# The workflow triggers on:
on:
  push:
    branches: [main]      # Nightly builds on main
  pull_request:           # Tests on PRs (no publish)
  release:
    types: [published]    # Production release to NuGet.org
```

### Required Secrets and Variables

Configure in **Settings → Secrets and variables → Actions**:

**Secrets:**
- `CODECOV_TOKEN`: Token from [codecov.io](https://codecov.io) for code coverage uploads

**Variables:**
- `DOTNET_SDK_VERSIONS`: (Optional) Additional .NET SDK versions for caching
- `NUGET_USER_NAME`: Your NuGet.org username for OIDC authentication

### Creating a Release

1. Create and push a git tag with version:
   ```console
   git tag v1.0.0
   git push origin v1.0.0
   ```

2. Create a GitHub Release from the tag

3. The workflow automatically:
   - Builds and tests the code
   - Creates NuGet packages with the release version
   - Publishes to NuGet.org
   - Attaches `.nupkg` files to the GitHub Release

## Contributing

Contributions are welcome! Here's how to contribute:

### Reporting Issues

- Use the GitHub Issues to report bugs or request features
- Provide detailed reproduction steps for bugs
- Include relevant environment information (.NET SDK version, OS, etc.)

### Submitting Pull Requests

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature-name`
3. Make your changes following the existing code style
4. Ensure all tests pass: `dotnet test`
5. Run code formatting: `dotnet format`
6. Commit your changes with clear commit messages
7. Push to your fork and submit a Pull Request

### Code Style

- This project follows `.editorconfig` rules
- Run `dotnet format` before committing to ensure compliance
- The CI pipeline will validate code style automatically

### Testing

- Write unit tests for new functionality
- Maintain or improve code coverage
- Tests should be clear and follow the existing pattern

## Package README

This template includes a package README (`src/Sample.Core/README.md`) that is automatically included in published NuGet packages. The README provides usage examples and documentation for package consumers.

To customize for your library:

1. Edit `src/YourLibrary/README.md` with your library's documentation
2. The `.csproj` is already configured to include the README in the package
3. The README will be automatically displayed on NuGet.org when you publish

See [Microsoft's documentation](https://learn.microsoft.com/nuget/nuget-org/package-readme-on-nuget-org) for more information about package READMEs.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
