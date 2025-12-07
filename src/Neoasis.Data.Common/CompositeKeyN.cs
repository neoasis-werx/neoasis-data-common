namespace Neoasis.Data.Common;

/// <summary>
/// Represents a variable-length, case-sensitive composite key for use in dictionaries, sets, and equality comparisons.
/// Stores an array of values and pre-computes a hash code for efficient lookups.
/// </summary>
public readonly struct CompositeKeyN : IEquatable<CompositeKeyN>
{
    /// <summary>
    /// The array of key component values.
    /// </summary>
    private readonly object?[] _values;

    /// <summary>
    /// The pre-computed hash code for this key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Gets the number of components in this composite key.
    /// </summary>
    public int ItemCount => _values?.Length ?? 0;

    /// <summary>
    /// Initializes a new instance of <see cref="CompositeKeyN"/> with the specified values.
    /// </summary>
    /// <param name="values">The key component values.</param>
    public CompositeKeyN(params object?[] values)
    {
        _values = new object?[values.Length];
        Array.Copy(values, _values, values.Length);

        int h = 17;
        unchecked
        {
            for (int i = 0; i < values.Length; i++)
                h = h * 31 + CKComparer.HashField(values[i]);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether this key is equal to another <see cref="CompositeKeyN"/>.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(CompositeKeyN other)
    {
        if (_hash != other._hash) return false;
        if (_values.Length != other._values.Length) return false;

        for (int i = 0; i < _values.Length; i++)
            if (!CKComparer.EqualsField(_values[i], other._values[i]))
                return false;

        return true;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyN other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Equality operator for <see cref="CompositeKeyN"/>.
    /// </summary>
    public static bool operator ==(CompositeKeyN a, CompositeKeyN b) => a.Equals(b);
    /// <summary>
    /// Inequality operator for <see cref="CompositeKeyN"/>.
    /// </summary>
    public static bool operator !=(CompositeKeyN a, CompositeKeyN b) => !a.Equals(b);
}

/// <summary>
/// Represents a variable-length, case-insensitive composite key for use in dictionaries, sets, and equality comparisons.
/// Uses ordinal ignore-case string comparison and hashing for string fields.
/// Stores an array of values and pre-computes a hash code for efficient lookups.
/// </summary>
public readonly struct CompositeKeyNCI : IEquatable<CompositeKeyNCI>
{
    /// <summary>
    /// The array of key component values.
    /// </summary>
    private readonly object?[] _values;

    /// <summary>
    /// The pre-computed hash code for this key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Gets the number of components in this composite key.
    /// </summary>
    public int ItemCount => _values?.Length ?? 0;

    /// <summary>
    /// Initializes a new instance of <see cref="CompositeKeyNCI"/> with the specified values.
    /// </summary>
    /// <param name="values">The key component values.</param>
    public CompositeKeyNCI(params object?[] values)
    {
        _values = new object?[values.Length];
        Array.Copy(values, _values, values.Length);

        int h = 17;
        unchecked
        {
            for (int i = 0; i < values.Length; i++)
                h = h * 31 + CKComparerCI.HashField(values[i]);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether this key is equal to another <see cref="CompositeKeyNCI"/>.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(CompositeKeyNCI other)
    {
        if (_hash != other._hash) return false;
        if (_values.Length != other._values.Length) return false;

        for (int i = 0; i < _values.Length; i++)
            if (!CKComparerCI.EqualsField(_values[i], other._values[i]))
                return false;

        return true;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyNCI other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Equality operator for <see cref="CompositeKeyNCI"/>.
    /// </summary>
    public static bool operator ==(CompositeKeyNCI a, CompositeKeyNCI b) => a.Equals(b);
    /// <summary>
    /// Inequality operator for <see cref="CompositeKeyNCI"/>.
    /// </summary>
    public static bool operator !=(CompositeKeyNCI a, CompositeKeyNCI b) => !a.Equals(b);
}
