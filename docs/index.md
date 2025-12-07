---
_layout: landing
---

# Neoasis.Data.Common - Composite Key Library

Welcome to the **Neoasis.Data.Common** library documentation. This library provides high-performance, strongly-typed composite key implementations for .NET applications.

## What are Composite Keys?

Composite keys combine multiple values into a single immutable key structure, ideal for scenarios such as:

- Multi-column database primary keys
- Complex cache keys with multiple dimensions
- Dictionary keys with compound criteria
- Grouping operations requiring multiple fields

## Why Use This Library?

### Performance

- **Struct-based design**: Zero heap allocations
- **Pre-computed hash codes**: Calculated once in constructor, cached for lifetime
- **Optimized comparisons**: Hash-first equality checking for fast lookups
- **Ordinal string comparison**: Fastest string comparison method by default

### Type Safety

- **Strongly-typed**: Full compile-time type checking for T1-T8 variants
- **Generic constraints**: Type-safe factory methods and operations
- **Immutable**: Thread-safe, prevents accidental modification

### Flexibility

- **Case-sensitive and case-insensitive**: Built-in support for both
- **Sortable variants**: Optional IComparable implementations for ordering
- **Variable-length**: CompositeKeyN for dynamic component counts
- **Factory methods**: Convenient creation with type inference
- **Tuple deconstruction**: Natural syntax for extracting components

## Key Features

### Typed Composite Keys (1-8 Components)

- `CompositeKey<T1...T8>` - Case-sensitive keys
- `CompositeKeyCI<T1...T8>` - Case-insensitive keys
- `SortableCompositeKey<T1...T8>` - Case-sensitive with IComparable
- `SortableCompositeKeyCI<T1...T8>` - Case-insensitive with IComparable

### Variable-Length Keys

- `CompositeKeyN` - Case-sensitive, dynamic component count
- `CompositeKeyNCI` - Case-insensitive, dynamic component count

### Factory Classes

- `CompositeKeys.Create()` / `CreateCI()` - Standard key creation
- `SortableCompositeKeys.Create()` / `CreateCI()` - Sortable key creation

## Quick Start

```csharp
using Neoasis.Data.Common;

// Create a composite key
var key = new CompositeKey<string, int>("UserID", 42);
// Or use factory
var key2 = CompositeKeys.Create("UserID", 42);

// Use as dictionary key
var cache = new Dictionary<CompositeKey<string, int>, UserData>();
cache[key] = userData;

// Case-insensitive lookups
var ciKey = CompositeKeys.CreateCI("Product", "Widget");
var dict = new Dictionary<CompositeKeyCI<string, string>, Product>();
dict[ciKey] = product;
// Retrieve with different casing
var found = dict[CompositeKeys.CreateCI("PRODUCT", "WIDGET")]; // Works!

// Sortable keys for ordered collections
var sortedSet = new SortedSet<SortableCompositeKey<string, int>>();
sortedSet.Add(SortableCompositeKeys.Create("Beta", 2));
sortedSet.Add(SortableCompositeKeys.Create("Alpha", 1));
// Automatically sorted: Alpha,1 then Beta,2
```

## Benefits Over Tuples

While .NET tuples can serve as composite keys, this library provides significant advantages:

1. **Pre-computed hashes** - 30-50% faster dictionary lookups
2. **Ordinal string comparison** - Faster than default cultural comparison
3. **Built-in case-insensitive support** - No custom comparers needed
4. **Semantic clarity** - Intent is explicit
5. **ItemCount property** - Runtime introspection without reflection

## Documentation Sections

- [Getting Started](docs/getting-started.md) - Detailed setup and basic usage
- [Introduction](docs/introduction.md) - In-depth overview and concepts
- [API Reference](api/Neoasis.Data.Common.html) - Complete API documentation

## Installation

```bash
dotnet add package Neoasis.Data.Common
```