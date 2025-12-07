# The `eng` Folder

In Microsoft repositories, particularly in those related to development and open source projects, the `eng` folder is commonly used to store engineering infrastructure scripts, tools, and configuration files. This folder typically contains various resources that help manage the build, testing, and CI/CD processes for the project.

## Common Contents of the `eng` Folder

1. **Build Scripts**: These scripts automate the build process, ensuring consistency and reproducibility.
    
    - `build.ps1` or `build.sh`: PowerShell or shell scripts for building the project.
    - `build.yaml`: YAML configuration files for defining build pipelines.
2. **CI/CD Configuration**: Configuration files for continuous integration and continuous deployment.
    
    - `azure-pipelines.yml`: Azure Pipelines configuration files.
    - `github-actions.yml`: GitHub Actions workflows.
3. **Tooling and Dependencies**: Scripts and configuration files to install and manage tools and dependencies required for the project.
    
    - `tools.ps1` or `tools.sh`: Scripts to install necessary tools.
    - `.config` files: Configuration files for various tools.
4. **Quality and Compliance**: Scripts and tools to ensure code quality and compliance with coding standards.
    
    - `stylecop.json`: Configuration for StyleCop, a static analysis tool.
    - `code-analysis.yml`: Configuration for code analysis tasks.
5. **Versioning and Release Management**: Scripts and tools to manage versioning and releases.
    
    - `versioning.ps1`: PowerShell script to handle versioning.
    - `release-notes.md`: Release notes and changelog.

## Example Structure

Here is an example of what the `eng` folder might look like in a Microsoft repository:

```
eng/
├── common/
│   ├── tools.ps1
│   └── tools.sh
├── pipeline/
│   ├── azure-pipelines.yml
│   └── github-actions.yml
├── build.ps1
├── build.sh
├── versioning.ps1
├── stylecop.json
└── README.md

```

## Purpose and Benefits

1. **Consistency**: Centralizing build and tooling scripts ensures all developers and CI systems use the same processes.
2. **Modularity**: Separating engineering infrastructure from application code keeps the repository organized and maintainable.
3. **Reusability**: Common scripts and configurations can be reused across multiple projects, reducing duplication and effort.
4. **Automation**: Facilitates automation of repetitive tasks, improving efficiency and reducing errors.

### Example 1: .NET Runtime Repository

The [.NET Runtime repository](https://github.com/dotnet/runtime) is the core runtime for .NET applications. The `eng` folder in this repository contains various scripts and configuration files for building, testing, and managing the project.

**Structure:**

```
eng/
├── common/
│   ├── build.ps1
│   ├── build.sh
│   ├── tool-runtime/
│   └── ...
├── config.json
├── dotnet-tools.json
├── global.json
├── pipelines/
│   ├── azure-pipelines.yml
│   └── ...
└── scripts/
    ├── ci/
    ├── install-dependencies.sh
    ├── ...
```


**Highlights:**

- `common/`: Contains common build scripts and tools used across the repository.
- `pipelines/`: Configuration files for Azure Pipelines.
- `scripts/`: Additional scripts for CI, dependency installation, and other tasks.

### Example 2: Azure SDK for .NET

The [Azure SDK for .NET repository](https://github.com/Azure/azure-sdk-for-net) provides libraries for interacting with Azure services. The `eng` folder here includes scripts and configurations for consistent building, testing, and release processes.

**Structure:**

```
eng/
├── common/
│   ├── azure-pipelines/
│   ├── build.ps1
│   ├── build.sh
│   └── ...
├── tools/
│   ├── sdk-propagation/
│   ├── tools.sh
│   └── ...
├── Build.props
├── CodeAnalysis.props
├── Directory.Build.props
├── README.md
└── Versioning.props
```

**Highlights:**

- `common/`: Shared build scripts and pipeline configurations.
- `tools/`: Scripts and tools for managing SDK propagation and other tasks.
- `props` files: Configuration files for MSBuild, code analysis, and versioning.

### Example 3: Roslyn (C# Compiler)

The [Roslyn repository](https://github.com/dotnet/roslyn) contains the code for the C# and VB.NET compilers. The `eng` folder is used for build orchestration, CI setup, and other engineering tasks.

**Structure:**

```
eng/
├── common/
│   ├── build.ps1
│   ├── build.sh
│   ├── ...
├── Build.ps1
├── Build.sh
├── Versions.props
├── global.json
├── toolset.json
└── ...
```

**Highlights:**

- `common/`: Common build scripts used throughout the repository.
- `Versions.props`: Defines versioning for dependencies.
- `global.json` and `toolset.json`: Configuration files for the .NET SDK and tools.

### Example 4: ASP.NET Core

The [ASP.NET Core repository](https://github.com/dotnet/aspnetcore) contains the framework for building web applications and services. The `eng` folder is structured to support its complex build and CI requirements.

**Structure:**

```
eng/
├── common/
│   ├── build.ps1
│   ├── build.sh
│   ├── ...
├── targets/
│   ├── Project.targets
│   └── ...
├── scripts/
│   ├── install-tools.ps1
│   ├── install-tools.sh
│   └── ...
├── Build.props
├── CodeAnalysis.ruleset
├── Directory.Build.props
├── global.json
└── toolset.json

```

**Highlights:**

- `common/`: Common scripts for building and managing the project.
- `targets/`: MSBuild target files.
- `scripts/`: Additional scripts for installing tools and other tasks.
- `props` and `.ruleset` files: Configuration for build and code analysis.
