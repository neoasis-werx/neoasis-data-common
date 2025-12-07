using System;

namespace Neoasis.Data.Common;

/// <summary>
/// Represents a sortable composite key with one item. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
public readonly struct SortableCompositeKey<T1> : IEquatable<SortableCompositeKey<T1>>, IComparable<SortableCompositeKey<T1>>
    where T1 : IComparable<T1>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 1;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1}"/> struct.
    /// </summary>
    /// <param name="item1">The first item.</param>
    public SortableCompositeKey(T1 item1)
    {
        Item1 = item1;
        _hash = CKComparer.HashField(item1!);
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1> other)
        => _hash == other._hash && CKComparer.EqualsField(Item1, other.Item1);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1> other)
        => Item1.CompareTo(other.Item1);

    /// <summary>
    /// Deconstructs the composite key into its item.
    /// </summary>
    /// <param name="item1">The first item.</param>
    public void Deconstruct(out T1 item1)
    {
        item1 = Item1;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1> a, SortableCompositeKey<T1> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1> a, SortableCompositeKey<T1> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1> a, SortableCompositeKey<T1> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1> a, SortableCompositeKey<T1> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1> a, SortableCompositeKey<T1> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1> a, SortableCompositeKey<T1> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a sortable composite key with two items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
public readonly struct SortableCompositeKey<T1, T2> : IEquatable<SortableCompositeKey<T1, T2>>, IComparable<SortableCompositeKey<T1, T2>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 2;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1, T2}"/> struct.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    public SortableCompositeKey(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparer.HashField(item1!);
            h = h * 31 + CKComparer.HashField(item2!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1, T2> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1, T2> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1, T2> other)
    {
        int cmp = Item1.CompareTo(other.Item1);
        if (cmp != 0) return cmp;
        return Item2.CompareTo(other.Item2);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    public void Deconstruct(out T1 item1, out T2 item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1, T2> a, SortableCompositeKey<T1, T2> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1, T2> a, SortableCompositeKey<T1, T2> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1, T2> a, SortableCompositeKey<T1, T2> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1, T2> a, SortableCompositeKey<T1, T2> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1, T2> a, SortableCompositeKey<T1, T2> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1, T2> a, SortableCompositeKey<T1, T2> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a sortable composite key with three items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
public readonly struct SortableCompositeKey<T1, T2, T3> : IEquatable<SortableCompositeKey<T1, T2, T3>>, IComparable<SortableCompositeKey<T1, T2, T3>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 3;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1, T2, T3}"/> struct.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    public SortableCompositeKey(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparer.HashField(item1!);
            h = h * 31 + CKComparer.HashField(item2!);
            h = h * 31 + CKComparer.HashField(item3!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1, T2, T3> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1, T2, T3> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1, T2, T3> other)
    {
        int cmp = Item1.CompareTo(other.Item1);
        if (cmp != 0) return cmp;
        cmp = Item2.CompareTo(other.Item2);
        if (cmp != 0) return cmp;
        return Item3.CompareTo(other.Item3);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1, T2, T3> a, SortableCompositeKey<T1, T2, T3> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1, T2, T3> a, SortableCompositeKey<T1, T2, T3> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1, T2, T3> a, SortableCompositeKey<T1, T2, T3> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1, T2, T3> a, SortableCompositeKey<T1, T2, T3> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1, T2, T3> a, SortableCompositeKey<T1, T2, T3> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1, T2, T3> a, SortableCompositeKey<T1, T2, T3> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a sortable composite key with four items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
public readonly struct SortableCompositeKey<T1, T2, T3, T4> : IEquatable<SortableCompositeKey<T1, T2, T3, T4>>, IComparable<SortableCompositeKey<T1, T2, T3, T4>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 4;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1, T2, T3, T4}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    public SortableCompositeKey(T1 a, T2 b, T3 c, T4 d)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparer.HashField(a!);
            h = h * 31 + CKComparer.HashField(b!);
            h = h * 31 + CKComparer.HashField(c!);
            h = h * 31 + CKComparer.HashField(d!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1, T2, T3, T4> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1, T2, T3, T4> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1, T2, T3, T4> other)
    {
        int cmp = Item1.CompareTo(other.Item1);
        if (cmp != 0) return cmp;
        cmp = Item2.CompareTo(other.Item2);
        if (cmp != 0) return cmp;
        cmp = Item3.CompareTo(other.Item3);
        if (cmp != 0) return cmp;
        return Item4.CompareTo(other.Item4);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1, T2, T3, T4> a, SortableCompositeKey<T1, T2, T3, T4> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1, T2, T3, T4> a, SortableCompositeKey<T1, T2, T3, T4> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1, T2, T3, T4> a, SortableCompositeKey<T1, T2, T3, T4> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1, T2, T3, T4> a, SortableCompositeKey<T1, T2, T3, T4> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1, T2, T3, T4> a, SortableCompositeKey<T1, T2, T3, T4> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1, T2, T3, T4> a, SortableCompositeKey<T1, T2, T3, T4> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a sortable composite key with five items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
public readonly struct SortableCompositeKey<T1, T2, T3, T4, T5> : IEquatable<SortableCompositeKey<T1, T2, T3, T4, T5>>, IComparable<SortableCompositeKey<T1, T2, T3, T4, T5>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 5;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1, T2, T3, T4, T5}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    public SortableCompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparer.HashField(a!);
            h = h * 31 + CKComparer.HashField(b!);
            h = h * 31 + CKComparer.HashField(c!);
            h = h * 31 + CKComparer.HashField(d!);
            h = h * 31 + CKComparer.HashField(e!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1, T2, T3, T4, T5> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1, T2, T3, T4, T5> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1, T2, T3, T4, T5> other)
    {
        int cmp = Item1.CompareTo(other.Item1);
        if (cmp != 0) return cmp;
        cmp = Item2.CompareTo(other.Item2);
        if (cmp != 0) return cmp;
        cmp = Item3.CompareTo(other.Item3);
        if (cmp != 0) return cmp;
        cmp = Item4.CompareTo(other.Item4);
        if (cmp != 0) return cmp;
        return Item5.CompareTo(other.Item5);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1, T2, T3, T4, T5> a, SortableCompositeKey<T1, T2, T3, T4, T5> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1, T2, T3, T4, T5> a, SortableCompositeKey<T1, T2, T3, T4, T5> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1, T2, T3, T4, T5> a, SortableCompositeKey<T1, T2, T3, T4, T5> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1, T2, T3, T4, T5> a, SortableCompositeKey<T1, T2, T3, T4, T5> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1, T2, T3, T4, T5> a, SortableCompositeKey<T1, T2, T3, T4, T5> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1, T2, T3, T4, T5> a, SortableCompositeKey<T1, T2, T3, T4, T5> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a sortable composite key with six items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
/// <typeparam name="T6">The type of the sixth item.</typeparam>
public readonly struct SortableCompositeKey<T1, T2, T3, T4, T5, T6> : IEquatable<SortableCompositeKey<T1, T2, T3, T4, T5, T6>>, IComparable<SortableCompositeKey<T1, T2, T3, T4, T5, T6>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
    where T6 : IComparable<T6>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 6;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Gets the sixth item of the composite key.
    /// </summary>
    public readonly T6 Item6;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1, T2, T3, T4, T5, T6}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    /// <param name="f">The sixth item.</param>
    public SortableCompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparer.HashField(a!);
            h = h * 31 + CKComparer.HashField(b!);
            h = h * 31 + CKComparer.HashField(c!);
            h = h * 31 + CKComparer.HashField(d!);
            h = h * 31 + CKComparer.HashField(e!);
            h = h * 31 + CKComparer.HashField(f!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1, T2, T3, T4, T5, T6> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5)
        && CKComparer.EqualsField(Item6, other.Item6);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1, T2, T3, T4, T5, T6> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1, T2, T3, T4, T5, T6> other)
    {
        int cmp = Item1.CompareTo(other.Item1);
        if (cmp != 0) return cmp;
        cmp = Item2.CompareTo(other.Item2);
        if (cmp != 0) return cmp;
        cmp = Item3.CompareTo(other.Item3);
        if (cmp != 0) return cmp;
        cmp = Item4.CompareTo(other.Item4);
        if (cmp != 0) return cmp;
        cmp = Item5.CompareTo(other.Item5);
        if (cmp != 0) return cmp;
        return Item6.CompareTo(other.Item6);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    /// <param name="item6">The sixth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1, T2, T3, T4, T5, T6> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1, T2, T3, T4, T5, T6> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1, T2, T3, T4, T5, T6> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1, T2, T3, T4, T5, T6> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1, T2, T3, T4, T5, T6> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1, T2, T3, T4, T5, T6> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a sortable composite key with seven items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
/// <typeparam name="T6">The type of the sixth item.</typeparam>
/// <typeparam name="T7">The type of the seventh item.</typeparam>
public readonly struct SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> : IEquatable<SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7>>, IComparable<SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
    where T6 : IComparable<T6>
    where T7 : IComparable<T7>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 7;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Gets the sixth item of the composite key.
    /// </summary>
    public readonly T6 Item6;
    /// <summary>
    /// Gets the seventh item of the composite key.
    /// </summary>
    public readonly T7 Item7;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1, T2, T3, T4, T5, T6, T7}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    /// <param name="f">The sixth item.</param>
    /// <param name="g">The seventh item.</param>
    public SortableCompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        Item7 = g;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparer.HashField(a!);
            h = h * 31 + CKComparer.HashField(b!);
            h = h * 31 + CKComparer.HashField(c!);
            h = h * 31 + CKComparer.HashField(d!);
            h = h * 31 + CKComparer.HashField(e!);
            h = h * 31 + CKComparer.HashField(f!);
            h = h * 31 + CKComparer.HashField(g!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5)
        && CKComparer.EqualsField(Item6, other.Item6)
        && CKComparer.EqualsField(Item7, other.Item7);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> other)
    {
        int cmp = Item1.CompareTo(other.Item1);
        if (cmp != 0) return cmp;
        cmp = Item2.CompareTo(other.Item2);
        if (cmp != 0) return cmp;
        cmp = Item3.CompareTo(other.Item3);
        if (cmp != 0) return cmp;
        cmp = Item4.CompareTo(other.Item4);
        if (cmp != 0) return cmp;
        cmp = Item5.CompareTo(other.Item5);
        if (cmp != 0) return cmp;
        cmp = Item6.CompareTo(other.Item6);
        if (cmp != 0) return cmp;
        return Item7.CompareTo(other.Item7);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    /// <param name="item6">The sixth item.</param>
    /// <param name="item7">The seventh item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
        item7 = Item7;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a sortable composite key with eight items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
/// <typeparam name="T6">The type of the sixth item.</typeparam>
/// <typeparam name="T7">The type of the seventh item.</typeparam>
/// <typeparam name="T8">The type of the eighth item.</typeparam>
public readonly struct SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> : IEquatable<SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8>>, IComparable<SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
    where T6 : IComparable<T6>
    where T7 : IComparable<T7>
    where T8 : IComparable<T8>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 8;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Gets the sixth item of the composite key.
    /// </summary>
    public readonly T6 Item6;
    /// <summary>
    /// Gets the seventh item of the composite key.
    /// </summary>
    public readonly T7 Item7;
    /// <summary>
    /// Gets the eighth item of the composite key.
    /// </summary>
    public readonly T8 Item8;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKey{T1, T2, T3, T4, T5, T6, T7, T8}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    /// <param name="f">The sixth item.</param>
    /// <param name="g">The seventh item.</param>
    /// <param name="h">The eighth item.</param>
    public SortableCompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g, T8 h)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        Item7 = g;
        Item8 = h;

        int hash = 17;
        unchecked
        {
            hash = hash * 31 + CKComparer.HashField(a!);
            hash = hash * 31 + CKComparer.HashField(b!);
            hash = hash * 31 + CKComparer.HashField(c!);
            hash = hash * 31 + CKComparer.HashField(d!);
            hash = hash * 31 + CKComparer.HashField(e!);
            hash = hash * 31 + CKComparer.HashField(f!);
            hash = hash * 31 + CKComparer.HashField(g!);
            hash = hash * 31 + CKComparer.HashField(h!);
        }
        _hash = hash;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5)
        && CKComparer.EqualsField(Item6, other.Item6)
        && CKComparer.EqualsField(Item7, other.Item7)
        && CKComparer.EqualsField(Item8, other.Item8);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> other)
    {
        int cmp = Item1.CompareTo(other.Item1);
        if (cmp != 0) return cmp;
        cmp = Item2.CompareTo(other.Item2);
        if (cmp != 0) return cmp;
        cmp = Item3.CompareTo(other.Item3);
        if (cmp != 0) return cmp;
        cmp = Item4.CompareTo(other.Item4);
        if (cmp != 0) return cmp;
        cmp = Item5.CompareTo(other.Item5);
        if (cmp != 0) return cmp;
        cmp = Item6.CompareTo(other.Item6);
        if (cmp != 0) return cmp;
        cmp = Item7.CompareTo(other.Item7);
        if (cmp != 0) return cmp;
        return Item8.CompareTo(other.Item8);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    /// <param name="item6">The sixth item.</param>
    /// <param name="item7">The seventh item.</param>
    /// <param name="item8">The eighth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7, out T8 item8)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
        item7 = Item7;
        item8 = Item8;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) >= 0;
}

// Case-Insensitive Sortable Composite Keys

/// <summary>
/// Represents a case-insensitive sortable composite key with one item. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1> : IEquatable<SortableCompositeKeyCI<T1>>, IComparable<SortableCompositeKeyCI<T1>>
    where T1 : IComparable<T1>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 1;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1}"/> struct.
    /// </summary>
    /// <param name="item1">The first item.</param>
    public SortableCompositeKeyCI(T1 item1)
    {
        Item1 = item1;
        _hash = CKComparerCI.HashField(item1!);
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1> other)
        => _hash == other._hash && CKComparerCI.EqualsField(Item1, other.Item1);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1> other)
        => CKComparerSortable.CompareField(Item1, other.Item1);

    /// <summary>
    /// Deconstructs the composite key into its item.
    /// </summary>
    /// <param name="item1">The first item.</param>
    public void Deconstruct(out T1 item1)
    {
        item1 = Item1;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1> a, SortableCompositeKeyCI<T1> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1> a, SortableCompositeKeyCI<T1> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1> a, SortableCompositeKeyCI<T1> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1> a, SortableCompositeKeyCI<T1> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1> a, SortableCompositeKeyCI<T1> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1> a, SortableCompositeKeyCI<T1> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a case-insensitive sortable composite key with two items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1, T2> : IEquatable<SortableCompositeKeyCI<T1, T2>>, IComparable<SortableCompositeKeyCI<T1, T2>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 2;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1, T2}"/> struct.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    public SortableCompositeKeyCI(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparerCI.HashField(item1!);
            h = h * 31 + CKComparerCI.HashField(item2!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1, T2> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1, T2> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1, T2> other)
    {
        int cmp = CKComparerSortable.CompareField(Item1, other.Item1);
        if (cmp != 0) return cmp;
        return CKComparerSortable.CompareField(Item2, other.Item2);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    public void Deconstruct(out T1 item1, out T2 item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1, T2> a, SortableCompositeKeyCI<T1, T2> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1, T2> a, SortableCompositeKeyCI<T1, T2> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1, T2> a, SortableCompositeKeyCI<T1, T2> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1, T2> a, SortableCompositeKeyCI<T1, T2> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1, T2> a, SortableCompositeKeyCI<T1, T2> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1, T2> a, SortableCompositeKeyCI<T1, T2> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a case-insensitive sortable composite key with three items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1, T2, T3> : IEquatable<SortableCompositeKeyCI<T1, T2, T3>>, IComparable<SortableCompositeKeyCI<T1, T2, T3>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 3;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1, T2, T3}"/> struct.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    public SortableCompositeKeyCI(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparerCI.HashField(item1!);
            h = h * 31 + CKComparerCI.HashField(item2!);
            h = h * 31 + CKComparerCI.HashField(item3!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1, T2, T3> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1, T2, T3> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1, T2, T3> other)
    {
        int cmp = CKComparerSortable.CompareField(Item1, other.Item1);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item2, other.Item2);
        if (cmp != 0) return cmp;
        return CKComparerSortable.CompareField(Item3, other.Item3);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1, T2, T3> a, SortableCompositeKeyCI<T1, T2, T3> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1, T2, T3> a, SortableCompositeKeyCI<T1, T2, T3> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1, T2, T3> a, SortableCompositeKeyCI<T1, T2, T3> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1, T2, T3> a, SortableCompositeKeyCI<T1, T2, T3> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1, T2, T3> a, SortableCompositeKeyCI<T1, T2, T3> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1, T2, T3> a, SortableCompositeKeyCI<T1, T2, T3> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a case-insensitive sortable composite key with four items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1, T2, T3, T4> : IEquatable<SortableCompositeKeyCI<T1, T2, T3, T4>>, IComparable<SortableCompositeKeyCI<T1, T2, T3, T4>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 4;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1, T2, T3, T4}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    public SortableCompositeKeyCI(T1 a, T2 b, T3 c, T4 d)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparerCI.HashField(a!);
            h = h * 31 + CKComparerCI.HashField(b!);
            h = h * 31 + CKComparerCI.HashField(c!);
            h = h * 31 + CKComparerCI.HashField(d!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1, T2, T3, T4> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1, T2, T3, T4> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1, T2, T3, T4> other)
    {
        int cmp = CKComparerSortable.CompareField(Item1, other.Item1);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item2, other.Item2);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item3, other.Item3);
        if (cmp != 0) return cmp;
        return CKComparerSortable.CompareField(Item4, other.Item4);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1, T2, T3, T4> a, SortableCompositeKeyCI<T1, T2, T3, T4> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1, T2, T3, T4> a, SortableCompositeKeyCI<T1, T2, T3, T4> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1, T2, T3, T4> a, SortableCompositeKeyCI<T1, T2, T3, T4> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1, T2, T3, T4> a, SortableCompositeKeyCI<T1, T2, T3, T4> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1, T2, T3, T4> a, SortableCompositeKeyCI<T1, T2, T3, T4> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1, T2, T3, T4> a, SortableCompositeKeyCI<T1, T2, T3, T4> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a case-insensitive sortable composite key with five items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1, T2, T3, T4, T5> : IEquatable<SortableCompositeKeyCI<T1, T2, T3, T4, T5>>, IComparable<SortableCompositeKeyCI<T1, T2, T3, T4, T5>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 5;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1, T2, T3, T4, T5}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    public SortableCompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparerCI.HashField(a!);
            h = h * 31 + CKComparerCI.HashField(b!);
            h = h * 31 + CKComparerCI.HashField(c!);
            h = h * 31 + CKComparerCI.HashField(d!);
            h = h * 31 + CKComparerCI.HashField(e!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1, T2, T3, T4, T5> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1, T2, T3, T4, T5> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1, T2, T3, T4, T5> other)
    {
        int cmp = CKComparerSortable.CompareField(Item1, other.Item1);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item2, other.Item2);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item3, other.Item3);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item4, other.Item4);
        if (cmp != 0) return cmp;
        return CKComparerSortable.CompareField(Item5, other.Item5);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1, T2, T3, T4, T5> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1, T2, T3, T4, T5> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1, T2, T3, T4, T5> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1, T2, T3, T4, T5> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1, T2, T3, T4, T5> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1, T2, T3, T4, T5> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a case-insensitive sortable composite key with six items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
/// <typeparam name="T6">The type of the sixth item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> : IEquatable<SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6>>, IComparable<SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
    where T6 : IComparable<T6>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 6;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Gets the sixth item of the composite key.
    /// </summary>
    public readonly T6 Item6;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1, T2, T3, T4, T5, T6}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    /// <param name="f">The sixth item.</param>
    public SortableCompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparerCI.HashField(a!);
            h = h * 31 + CKComparerCI.HashField(b!);
            h = h * 31 + CKComparerCI.HashField(c!);
            h = h * 31 + CKComparerCI.HashField(d!);
            h = h * 31 + CKComparerCI.HashField(e!);
            h = h * 31 + CKComparerCI.HashField(f!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5)
        && CKComparerCI.EqualsField(Item6, other.Item6);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> other)
    {
        int cmp = CKComparerSortable.CompareField(Item1, other.Item1);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item2, other.Item2);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item3, other.Item3);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item4, other.Item4);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item5, other.Item5);
        if (cmp != 0) return cmp;
        return CKComparerSortable.CompareField(Item6, other.Item6);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    /// <param name="item6">The sixth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a case-insensitive sortable composite key with seven items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
/// <typeparam name="T6">The type of the sixth item.</typeparam>
/// <typeparam name="T7">The type of the seventh item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> : IEquatable<SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7>>, IComparable<SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
    where T6 : IComparable<T6>
    where T7 : IComparable<T7>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 7;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Gets the sixth item of the composite key.
    /// </summary>
    public readonly T6 Item6;
    /// <summary>
    /// Gets the seventh item of the composite key.
    /// </summary>
    public readonly T7 Item7;
        /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;
    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1, T2, T3, T4, T5, T6, T7}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    /// <param name="f">The sixth item.</param>
    /// <param name="g">The seventh item.</param>
    public SortableCompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        Item7 = g;

        int h = 17;
        unchecked
        {
            h = h * 31 + CKComparerCI.HashField(a!);
            h = h * 31 + CKComparerCI.HashField(b!);
            h = h * 31 + CKComparerCI.HashField(c!);
            h = h * 31 + CKComparerCI.HashField(d!);
            h = h * 31 + CKComparerCI.HashField(e!);
            h = h * 31 + CKComparerCI.HashField(f!);
            h = h * 31 + CKComparerCI.HashField(g!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5)
        && CKComparerCI.EqualsField(Item6, other.Item6)
        && CKComparerCI.EqualsField(Item7, other.Item7);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> other && Equals(other);
    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> other)
    {
        int cmp = CKComparerSortable.CompareField(Item1, other.Item1);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item2, other.Item2);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item3, other.Item3);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item4, other.Item4);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item5, other.Item5);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item6, other.Item6);
        if (cmp != 0) return cmp;
        return CKComparerSortable.CompareField(Item7, other.Item7);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    /// <param name="item6">The sixth item.</param>
    /// <param name="item7">The seventh item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
        item7 = Item7;
    }

  /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> b) => a.Equals(b);
      /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal to operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) <= 0;
/// <summary>
    /// Greater than or equal to operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> b) => a.CompareTo(b) >= 0;
}

/// <summary>
/// Represents a case-insensitive sortable composite key with eight items. Implements value equality and comparison.
/// </summary>
/// <typeparam name="T1">The type of the first item.</typeparam>
/// <typeparam name="T2">The type of the second item.</typeparam>
/// <typeparam name="T3">The type of the third item.</typeparam>
/// <typeparam name="T4">The type of the fourth item.</typeparam>
/// <typeparam name="T5">The type of the fifth item.</typeparam>
/// <typeparam name="T6">The type of the sixth item.</typeparam>
/// <typeparam name="T7">The type of the seventh item.</typeparam>
/// <typeparam name="T8">The type of the eighth item.</typeparam>
public readonly struct SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> : IEquatable<SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8>>, IComparable<SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8>>
    where T1 : IComparable<T1>
    where T2 : IComparable<T2>
    where T3 : IComparable<T3>
    where T4 : IComparable<T4>
    where T5 : IComparable<T5>
    where T6 : IComparable<T6>
    where T7 : IComparable<T7>
    where T8 : IComparable<T8>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 8;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    /// <summary>
    /// Gets the second item of the composite key.
    /// </summary>
    public readonly T2 Item2;
    /// <summary>
    /// Gets the third item of the composite key.
    /// </summary>
    public readonly T3 Item3;
    /// <summary>
    /// Gets the fourth item of the composite key.
    /// </summary>
    public readonly T4 Item4;
    /// <summary>
    /// Gets the fifth item of the composite key.
    /// </summary>
    public readonly T5 Item5;
    /// <summary>
    /// Gets the sixth item of the composite key.
    /// </summary>
    public readonly T6 Item6;
    /// <summary>
    /// Gets the seventh item of the composite key.
    /// </summary>
    public readonly T7 Item7;
    /// <summary>
    /// Gets the eighth item of the composite key.
    /// </summary>
    public readonly T8 Item8;
    /// <summary>
    /// Internal hash code for the composite key.
    /// </summary>
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableCompositeKeyCI{T1, T2, T3, T4, T5, T6, T7, T8}"/> struct.
    /// </summary>
    /// <param name="a">The first item.</param>
    /// <param name="b">The second item.</param>
    /// <param name="c">The third item.</param>
    /// <param name="d">The fourth item.</param>
    /// <param name="e">The fifth item.</param>
    /// <param name="f">The sixth item.</param>
    /// <param name="g">The seventh item.</param>
    /// <param name="h">The eighth item.</param>
    public SortableCompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g, T8 h)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        Item7 = g;
        Item8 = h;

        int hash = 17;
        unchecked
        {
            hash = hash * 31 + CKComparerCI.HashField(a!);
            hash = hash * 31 + CKComparerCI.HashField(b!);
            hash = hash * 31 + CKComparerCI.HashField(c!);
            hash = hash * 31 + CKComparerCI.HashField(d!);
            hash = hash * 31 + CKComparerCI.HashField(e!);
            hash = hash * 31 + CKComparerCI.HashField(f!);
            hash = hash * 31 + CKComparerCI.HashField(g!);
            hash = hash * 31 + CKComparerCI.HashField(h!);
        }
        _hash = hash;
    }

    /// <summary>
    /// Determines whether the specified key is equal to the current key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>True if equal; otherwise, false.</returns>
    public bool Equals(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5)
        && CKComparerCI.EqualsField(Item6, other.Item6)
        && CKComparerCI.EqualsField(Item7, other.Item7)
        && CKComparerCI.EqualsField(Item8, other.Item8);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Compares this key to another key.
    /// </summary>
    /// <param name="other">The other key to compare.</param>
    /// <returns>A value indicating the relative order.</returns>
    public int CompareTo(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> other)
    {
        int cmp = CKComparerSortable.CompareField(Item1, other.Item1);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item2, other.Item2);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item3, other.Item3);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item4, other.Item4);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item5, other.Item5);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item6, other.Item6);
        if (cmp != 0) return cmp;
        cmp = CKComparerSortable.CompareField(Item7, other.Item7);
        if (cmp != 0) return cmp;
        return CKComparerSortable.CompareField(Item8, other.Item8);
    }

    /// <summary>
    /// Deconstructs the composite key into its items.
    /// </summary>
    /// <param name="item1">The first item.</param>
    /// <param name="item2">The second item.</param>
    /// <param name="item3">The third item.</param>
    /// <param name="item4">The fourth item.</param>
    /// <param name="item5">The fifth item.</param>
    /// <param name="item6">The sixth item.</param>
    /// <param name="item7">The seventh item.</param>
    /// <param name="item8">The eighth item.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7, out T8 item8)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
        item7 = Item7;
        item8 = Item8;
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    public static bool operator ==(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.Equals(b);
    /// <summary>
    /// Inequality operator.
    /// </summary>
    public static bool operator !=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> b) => !a.Equals(b);
    /// <summary>
    /// Less than operator.
    /// </summary>
    public static bool operator <(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) < 0;
    /// <summary>
    /// Greater than operator.
    /// </summary>
    public static bool operator >(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) > 0;
    /// <summary>
    /// Less than or equal operator.
    /// </summary>
    public static bool operator <=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) <= 0;
    /// <summary>
    /// Greater than or equal operator.
    /// </summary>
    public static bool operator >=(SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> a, SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> b) => a.CompareTo(b) >= 0;
}
