# Neoasis.Data.Common

High-performance, strongly-typed, immutable composite key library for .NET.

## Features

- Strongly-typed composite keys (case-sensitive and case-insensitive)
- Variable-length composite keys (`CompositeKeyN`, `CompositeKeyNCI`)
- Pre-computed hash codes for fast dictionary lookups
- Optimized string comparison (ordinal and case-insensitive)
- Factory methods for easy creation
- Immutable struct-based implementation

## Installation

```bash
 dotnet add package Neoasis.Data.Common
```

## Usage

```csharp
using Neoasis.Data.Common;

// Case-sensitive composite key
var key1 = new CompositeKey<string, int>("UserID", 42);
var key2 = CompositeKeys.Create("UserID", 42);

// Case-insensitive composite key
var keyCI1 = new CompositeKeyCI<string, string>("John", "Doe");
var keyCI2 = CompositeKeys.CreateCI("john", "doe"); // Equals keyCI1

// Variable-length keys
var keyN = new CompositeKeyN("part1", "part2", 123);
var keyNCI = new CompositeKeyNCI("Part1", "PART2", 123);

// Using as dictionary keys
var cache = new Dictionary<CompositeKey<string, int, DateTime>, UserData>();
cache[CompositeKeys.Create("tenant1", 123, date)] = userData;

var lookup = new Dictionary<CompositeKeyCI<string, string>, Record>();
lookup[CompositeKeys.CreateCI("Product", "Widget")] = record;
var result = lookup[CompositeKeys.CreateCI("PRODUCT", "WIDGET")]; // Found!
```

## Build Instructions

### Build the Code

```bash
 dotnet build
```

### Run Unit Tests

```bash
 dotnet test
```

### Build API Documentation (DocFX)

```bash
 cd docs
 docfx metadata docfx.json
 docfx build docfx.json
```

### Serve Documentation Locally

```bash
 cd docs
 docfx serve _site
```

## API Reference

See [docs/api](docs/api) for full API documentation.


## Authors

Deerwood McCord, Jr / Neoasis
