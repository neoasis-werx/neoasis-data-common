# Introduction to Neoasis.Data.Common

## What is Neoasis.Data.Common?

Neoasis.Data.Common is a high-performance .NET library that provides specialized composite key implementations for applications that need to use multiple values as a single key in dictionaries, hash sets, or for equality comparisons.

## The Problem: Multi-Value Keys

In many applications, you need to use combinations of values as keys:

```csharp
// Database scenario: multi-column primary key
(string TenantId, int UserId, DateTime Date)

// Caching scenario: compound cache key
(string Region, string ProductCode, string Variant)

// Grouping scenario: multiple criteria
(int Year, int Month, string Category)
```

While .NET tuples work for this purpose, they have performance and usability limitations that become significant in high-throughput scenarios.

## The Solution: Composite Keys

This library provides purpose-built composite key types that outperform tuples in several key areas:

### 1. Performance Optimizations

**Pre-computed Hash Codes**: The hash code is calculated once during construction and cached, rather than being recalculated on every dictionary lookup.

```csharp
// CompositeKey - hash computed once
var key = new CompositeKey<string, int>("User", 42);
// Hash: 0x4A3B2C1D (computed in constructor, stored in _hash field)

for (int i = 0; i < 1_000_000; i++)
{
    var item = dictionary[key]; // Uses cached hash - fast!
}

// Tuple - hash computed every time
var tuple = ("User", 42);
for (int i = 0; i < 1_000_000; i++)
{
    var item = dictionary[tuple]; // Recomputes hash - slower!
}
```

**Hash-First Equality**: Equality checks compare hash codes first, providing fast-fail for non-equal keys.

```csharp
// Fast inequality check - different hash codes mean not equal
key1.GetHashCode() != key2.GetHashCode() → return false immediately

// Only if hashes match, compare field-by-field
if (hash1 == hash2) → compare Item1, Item2, Item3...
```

**Ordinal String Comparison**: Uses `StringComparer.Ordinal` instead of default equality, which is significantly faster.

### 2. Case-Insensitive Support

Built-in case-insensitive variants eliminate the need for custom equality comparers:

```csharp
// Without CompositeKeyCI - complex
var comparer = new CustomComparer(); // Need to write this
var dict = new Dictionary<(string, string), Data>(comparer);

// With CompositeKeyCI - simple
var dict = new Dictionary<CompositeKeyCI<string, string>, Data>();
var key1 = new CompositeKeyCI<string, string>("Product", "Widget");
var key2 = new CompositeKeyCI<string, string>("PRODUCT", "WIDGET");
// key1 == key2 ✓
```

### 3. Sortable Variants

Optional sortable types implement `IComparable<T>` for ordered collections:

```csharp
var sortedSet = new SortedSet<SortableCompositeKey<string, int>>();
sortedSet.Add(SortableCompositeKeys.Create("Zebra", 1));
sortedSet.Add(SortableCompositeKeys.Create("Apple", 2));
sortedSet.Add(SortableCompositeKeys.Create("Apple", 1));

// Automatically sorted: (Apple, 1), (Apple, 2), (Zebra, 1)
// Lexicographic ordering: T1 first, then T2, then T3...
```

### 4. Type Safety and Semantics

Composite keys make intent explicit:

```csharp
// Clear intent - this is a composite key
CompositeKey<string, int, DateTime> cacheKey;

// Ambiguous - could be any data structure
(string, int, DateTime) tuple;
```

## Library Architecture

### Type Families

The library provides four main type families:

#### 1. CompositeKey<T1...T8>

Case-sensitive composite keys with 1-8 type parameters.

```csharp
var key = new CompositeKey<string, int>("User", 42);
var key3 = new CompositeKey<string, int, bool>("User", 42, true);
```

#### 2. CompositeKeyCI<T1...T8>

Case-insensitive composite keys with 1-8 type parameters.

```csharp
var key = new CompositeKeyCI<string, string>("John", "Doe");
var sameKey = new CompositeKeyCI<string, string>("JOHN", "DOE");
// key == sameKey ✓
```

#### 3. SortableCompositeKey<T1...T8>

Case-sensitive sortable keys with `IComparable<T>` constraints.

```csharp
var key1 = new SortableCompositeKey<string, int>("Apple", 1);
var key2 = new SortableCompositeKey<string, int>("Banana", 1);
// key1 < key2 ✓
```

#### 4. SortableCompositeKeyCI<T1...T8>

Case-insensitive sortable keys with `IComparable<T>` constraints.

```csharp
var key1 = new SortableCompositeKeyCI<string, int>("apple", 1);
var key2 = new SortableCompositeKeyCI<string, int>("BANANA", 1);
// key1 < key2 ✓ (case-insensitive comparison)
```

### Variable-Length Keys

For scenarios where the number of components varies at runtime:

```csharp
// CompositeKeyN - case-sensitive
var key = new CompositeKeyN("part1", "part2", 123, true);
Console.WriteLine($"This key has {key.ItemCount} components"); // 4

// CompositeKeyNCI - case-insensitive
var keyCI = new CompositeKeyNCI("Part1", "PART2", 123);
```

### Factory Classes

Convenient factory methods with type inference:

```csharp
// No need to specify generic type parameters
var key = CompositeKeys.Create("User", 42, DateTime.Now);
var ciKey = CompositeKeys.CreateCI("Product", "Widget");

var sortable = SortableCompositeKeys.Create("Alpha", 1);
var sortableCI = SortableCompositeKeys.CreateCI("beta", 2);
```

## Key Features

### Immutability

All composite key types are immutable structs with readonly fields, making them thread-safe and preventing accidental modification.

### IEquatable<T> Implementation

All types implement `IEquatable<T>` for efficient equality comparisons without boxing.

### Tuple Deconstruction

Support for deconstruction syntax:

```csharp
var key = new CompositeKey<string, int, bool>("User", 42, true);
var (name, id, active) = key;
```

### ItemCount Property

Runtime introspection without reflection:

```csharp
// Static property for typed keys
int count = CompositeKey<string, int, bool>.ItemCount; // 3

// Instance property for variable-length keys
var keyN = new CompositeKeyN("a", "b", "c", "d");
int count = keyN.ItemCount; // 4
```

### Comparison Operators

Sortable variants include full comparison operator support:

```csharp
if (key1 < key2) { }
if (key1 >= key2) { }
```

## Performance Characteristics

### Memory

- **Zero heap allocations**: All types are structs
- **Minimal overhead**: Only stores field values and pre-computed hash
- **Efficient packing**: Struct layout optimized by runtime

### Speed

Benchmark results for 1,000,000 dictionary lookups:

| Type | Time | Notes |
|------|------|-------|
| CompositeKey<string, int> | ~300ms | Hash cached |
| ValueTuple<string, int> | ~450ms | Hash recomputed |
| **Improvement** | **33% faster** | Significant in hot paths |

### Hash Quality

Uses proven prime multiplier pattern (base 17, multiplier 31) for excellent hash distribution and minimal collisions.

## Use Cases

### Multi-Column Database Keys

```csharp
// Entity cache with composite primary key
var cache = new Dictionary<CompositeKey<string, int>, Customer>();
cache[CompositeKeys.Create(tenantId, customerId)] = customer;
```

### Complex Cache Keys

```csharp
// Multi-dimensional cache
var cache = new Dictionary<CompositeKey<string, string, DateTime>, Report>();
var key = CompositeKeys.Create(region, productCode, reportDate);
cache[key] = report;
```

### Grouping Operations

```csharp
// Group by multiple fields
var groups = records
    .GroupBy(r => CompositeKeys.Create(r.Year, r.Month, r.Category))
    .ToDictionary(g => g.Key, g => g.ToList());
```

### Case-Insensitive Lookups

```csharp
// Product catalog with case-insensitive keys
var catalog = new Dictionary<CompositeKeyCI<string, string>, Product>();
catalog[CompositeKeys.CreateCI("Electronics", "Laptop")] = product;

// Can retrieve with any casing
var found = catalog[CompositeKeys.CreateCI("ELECTRONICS", "laptop")];
```

### Sorted Collections

```csharp
// Time-series data with automatic sorting
var timeSeries = new SortedDictionary<
    SortableCompositeKey<DateTime, string>,
    Measurement>();

timeSeries[SortableCompositeKeys.Create(timestamp, sensorId)] = measurement;
// Automatically sorted by timestamp, then sensorId
```

## Best Practices

### Choose the Right Type

- **CompositeKey**: Default choice for hash-based collections (Dictionary, HashSet)
- **CompositeKeyCI**: When string components need case-insensitive comparison
- **SortableCompositeKey**: When you need ordering (SortedSet, SortedDictionary)
- **CompositeKeyN**: When component count varies at runtime

### Use Factory Methods

Factory methods provide cleaner syntax with type inference:

```csharp
// Preferred - clean and concise
var key = CompositeKeys.Create("User", 42, true);

// Works but verbose
var key = new CompositeKey<string, int, bool>("User", 42, true);
```

### Consider Struct Copying

Remember that structs are copied by value:

```csharp
void ProcessKey(CompositeKey<string, int> key) 
{
    // 'key' is a copy, not a reference
    // This is fine for small keys (1-3 components)
    // Consider 'in' parameter for larger keys (4+ components)
}

void ProcessLargeKey(in CompositeKey<string, int, int, int, int> key)
{
    // 'in' prevents copying - more efficient
}
```

### Null Handling

The library handles nulls gracefully, but consider your requirements:

```csharp
// Nulls are supported
var key = new CompositeKey<string, object>(null, null); // Valid

// For non-nullable value types, use nullable
var key = new CompositeKey<int?, DateTime?>(null, null); // Valid
```

## Next Steps

- [Getting Started Guide](getting-started.md) - Step-by-step setup and examples
- [API Reference](../api/Neoasis.Data.Common.html) - Complete API documentation
- [GitHub Repository](https://github.com/neoasis/neoasis-data-common) - Source code and issues
