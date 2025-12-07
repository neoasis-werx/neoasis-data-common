using System;

namespace Neoasis.Data.Common;

/// <summary>
/// Represents a composite key consisting of a single value of type <typeparamref name="T1"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
public readonly struct CompositeKey<T1> : IEquatable<CompositeKey<T1>>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 1;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1}"/> struct.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    public CompositeKey(T1 item1)
    {
        Item1 = item1;
        _hash = CKComparer.HashField(item1!);
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKey{T1}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1> other)
        => _hash == other._hash && CKComparer.EqualsField(Item1, other.Item1);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKey<T1> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1> a, CompositeKey<T1> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1> a, CompositeKey<T1> b) => !a.Equals(b);
}

/// <summary>
/// Represents a composite key consisting of two values of types <typeparamref name="T1"/> and <typeparamref name="T2"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
public readonly struct CompositeKey<T1,T2> : IEquatable<CompositeKey<T1,T2>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1,T2}"/> struct.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    public CompositeKey(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;

        int h = 17;
        unchecked {
            h = h * 31 + CKComparer.HashField(item1!);
            h = h * 31 + CKComparer.HashField(item2!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKey{T1,T2}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1,T2> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1,T2> a, CompositeKey<T1,T2> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1,T2> a, CompositeKey<T1,T2> b) => !a.Equals(b);
}

/// <summary>
/// Represents a composite key consisting of three values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, and <typeparamref name="T3"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
public readonly struct CompositeKey<T1,T2,T3> : IEquatable<CompositeKey<T1,T2,T3>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1,T2,T3}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    public CompositeKey(T1 a, T2 b, T3 c)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        int h = 17;
        unchecked {
            h = h * 31 + CKComparer.HashField(a!);
            h = h * 31 + CKComparer.HashField(b!);
            h = h * 31 + CKComparer.HashField(c!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKey{T1,T2,T3}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1,T2,T3> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1,T2,T3> a, CompositeKey<T1,T2,T3> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1,T2,T3> a, CompositeKey<T1,T2,T3> b) => !a.Equals(b);
}

/// <summary>
/// Represents a composite key consisting of four values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, and <typeparamref name="T4"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
public readonly struct CompositeKey<T1,T2,T3,T4> : IEquatable<CompositeKey<T1,T2,T3,T4>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1,T2,T3,T4}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    public CompositeKey(T1 a, T2 b, T3 c, T4 d)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        int h = 17;
        unchecked {
            h = h * 31 + CKComparer.HashField(a!);
            h = h * 31 + CKComparer.HashField(b!);
            h = h * 31 + CKComparer.HashField(c!);
            h = h * 31 + CKComparer.HashField(d!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKey{T1,T2,T3,T4}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1,T2,T3,T4> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3,T4> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1,T2,T3,T4> a, CompositeKey<T1,T2,T3,T4> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1,T2,T3,T4> a, CompositeKey<T1,T2,T3,T4> b) => !a.Equals(b);
}

/// <summary>
/// Represents a composite key consisting of five values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, <typeparamref name="T4"/>, and <typeparamref name="T5"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
/// <typeparam name="T5">The type of the fifth key component.</typeparam>
public readonly struct CompositeKey<T1,T2,T3,T4,T5> : IEquatable<CompositeKey<T1,T2,T3,T4,T5>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1,T2,T3,T4,T5}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    public CompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        int h = 17;
        unchecked {
            h = h * 31 + CKComparer.HashField(a!);
            h = h * 31 + CKComparer.HashField(b!);
            h = h * 31 + CKComparer.HashField(c!);
            h = h * 31 + CKComparer.HashField(d!);
            h = h * 31 + CKComparer.HashField(e!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKey{T1,T2,T3,T4,T5}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1,T2,T3,T4,T5> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3,T4,T5> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5> a, CompositeKey<T1,T2,T3,T4,T5> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5> a, CompositeKey<T1,T2,T3,T4,T5> b) => !a.Equals(b);
}

/// <summary>
/// Represents a composite key consisting of six values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, <typeparamref name="T4"/>, <typeparamref name="T5"/>, and <typeparamref name="T6"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
/// <typeparam name="T5">The type of the fifth key component.</typeparam>
/// <typeparam name="T6">The type of the sixth key component.</typeparam>
public readonly struct CompositeKey<T1,T2,T3,T4,T5,T6> : IEquatable<CompositeKey<T1,T2,T3,T4,T5,T6>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1,T2,T3,T4,T5,T6}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    /// <param name="f">The sixth key component.</param>
    public CompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        int h = 17;
        unchecked {
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
    /// Determines whether the specified <see cref="CompositeKey{T1,T2,T3,T4,T5,T6}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1,T2,T3,T4,T5,T6> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5)
        && CKComparer.EqualsField(Item6, other.Item6);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3,T4,T5,T6> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    /// <param name="item6">The sixth key component.</param>
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
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5,T6> a, CompositeKey<T1,T2,T3,T4,T5,T6> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5,T6> a, CompositeKey<T1,T2,T3,T4,T5,T6> b) => !a.Equals(b);
}

/// <summary>
/// Represents a composite key consisting of seven values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, <typeparamref name="T4"/>, <typeparamref name="T5"/>, <typeparamref name="T6"/>, and <typeparamref name="T7"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
/// <typeparam name="T5">The type of the fifth key component.</typeparam>
/// <typeparam name="T6">The type of the sixth key component.</typeparam>
/// <typeparam name="T7">The type of the seventh key component.</typeparam>
public readonly struct CompositeKey<T1,T2,T3,T4,T5,T6,T7> : IEquatable<CompositeKey<T1,T2,T3,T4,T5,T6,T7>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1,T2,T3,T4,T5,T6,T7}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    /// <param name="f">The sixth key component.</param>
    /// <param name="g">The seventh key component.</param>
    public CompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        Item7 = g;
        int h = 17;
        unchecked {
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
    /// Determines whether the specified <see cref="CompositeKey{T1,T2,T3,T4,T5,T6,T7}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1,T2,T3,T4,T5,T6,T7> other)
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
        => obj is CompositeKey<T1,T2,T3,T4,T5,T6,T7> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    /// <param name="item6">The sixth key component.</param>
    /// <param name="item7">The seventh key component.</param>
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
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5,T6,T7> a, CompositeKey<T1,T2,T3,T4,T5,T6,T7> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5,T6,T7> a, CompositeKey<T1,T2,T3, T4,T5,T6,T7> b) => !a.Equals(b);
}

/// <summary>
/// Represents a composite key consisting of eight values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, <typeparamref name="T4"/>, <typeparamref name="T5"/>, <typeparamref name="T6"/>, <typeparamref name="T7"/>, and <typeparamref name="T8"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
/// <typeparam name="T5">The type of the fifth key component.</typeparam>
/// <typeparam name="T6">The type of the sixth key component.</typeparam>
/// <typeparam name="T7">The type of the seventh key component.</typeparam>
/// <typeparam name="T8">The type of the eighth key component.</typeparam>
public readonly struct CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> : IEquatable<CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKey{T1,T2,T3,T4,T5,T6,T7,T8}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    /// <param name="f">The sixth key component.</param>
    /// <param name="g">The seventh key component.</param>
    /// <param name="h">The eighth key component.</param>
    public CompositeKey(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g, T8 h)
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
        unchecked {
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
    /// Determines whether the specified <see cref="CompositeKey{T1,T2,T3,T4,T5,T6,T7,T8}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> other)
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
        => obj is CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    /// <param name="item6">The sixth key component.</param>
    /// <param name="item7">The seventh key component.</param>
    /// <param name="item8">The eighth key component.</param>
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
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> b) => !a.Equals(b);
}


// Case-Insensitive Composite Keys

/// <summary>
/// Represents a case-insensitive composite key consisting of a single value of type <typeparamref name="T1"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
public readonly struct CompositeKeyCI<T1> : IEquatable<CompositeKeyCI<T1>>
{
    /// <summary>
    /// Gets the number of items in the composite key.
    /// </summary>
    public static int ItemCount => 1;
    /// <summary>
    /// Gets the first item of the composite key.
    /// </summary>
    public readonly T1 Item1;
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1}"/> struct.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    public CompositeKeyCI(T1 item1)
    {
        Item1 = item1;
        _hash = CKComparerCI.HashField(item1!);
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKeyCI{T1}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1> other)
        => _hash == other._hash && CKComparerCI.EqualsField(Item1, other.Item1);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1> a, CompositeKeyCI<T1> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1> a, CompositeKeyCI<T1> b) => !a.Equals(b);
}

/// <summary>
/// Represents a case-insensitive composite key consisting of two values of types <typeparamref name="T1"/> and <typeparamref name="T2"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
public readonly struct CompositeKeyCI<T1,T2> : IEquatable<CompositeKeyCI<T1,T2>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1,T2}"/> struct.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    public CompositeKeyCI(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
        int h = 17;
        unchecked {
            h = h * 31 + CKComparerCI.HashField(item1!);
            h = h * 31 + CKComparerCI.HashField(item2!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKeyCI{T1,T2}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1,T2> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1,T2> a, CompositeKeyCI<T1,T2> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1,T2> a, CompositeKeyCI<T1,T2> b) => !a.Equals(b);
}

/// <summary>
/// Represents a case-insensitive composite key consisting of three values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, and <typeparamref name="T3"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
public readonly struct CompositeKeyCI<T1,T2,T3> : IEquatable<CompositeKeyCI<T1,T2,T3>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1,T2,T3}"/> struct.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    public CompositeKeyCI(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        int h = 17;
        unchecked {
            h = h * 31 + CKComparerCI.HashField(item1!);
            h = h * 31 + CKComparerCI.HashField(item2!);
            h = h * 31 + CKComparerCI.HashField(item3!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKeyCI{T1,T2,T3}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1,T2,T3> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1,T2,T3> a, CompositeKeyCI<T1,T2,T3> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1,T2,T3> a, CompositeKeyCI<T1,T2,T3> b) => !a.Equals(b);
}

/// <summary>
/// Represents a case-insensitive composite key consisting of four values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, and <typeparamref name="T4"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
public readonly struct CompositeKeyCI<T1,T2,T3,T4> : IEquatable<CompositeKeyCI<T1,T2,T3,T4>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1,T2,T3,T4}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    public CompositeKeyCI(T1 a, T2 b, T3 c, T4 d)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        int h = 17;
        unchecked {
            h = h * 31 + CKComparerCI.HashField(a!);
            h = h * 31 + CKComparerCI.HashField(b!);
            h = h * 31 + CKComparerCI.HashField(c!);
            h = h * 31 + CKComparerCI.HashField(d!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKeyCI{T1,T2,T3,T4}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1,T2,T3,T4> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4> a, CompositeKeyCI<T1,T2,T3,T4> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4> a, CompositeKeyCI<T1,T2,T3,T4> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1,T2,T3,T4,T5}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    public CompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        int h = 17;
        unchecked {
            h = h * 31 + CKComparerCI.HashField(a!);
            h = h * 31 + CKComparerCI.HashField(b!);
            h = h * 31 + CKComparerCI.HashField(c!);
            h = h * 31 + CKComparerCI.HashField(d!);
            h = h * 31 + CKComparerCI.HashField(e!);
        }
        _hash = h;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CompositeKeyCI{T1,T2,T3,T4,T5}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1,T2,T3,T4,T5> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
    }

    /// <summary>
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5> a, CompositeKeyCI<T1,T2,T3,T4,T5> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5> a, CompositeKeyCI<T1,T2,T3,T4,T5> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5,T6> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5,T6>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1,T2,T3,T4,T5,T6}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    /// <param name="f">The sixth key component.</param>
    public CompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        int h = 17;
        unchecked {
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
    /// Determines whether the specified <see cref="CompositeKeyCI{T1,T2,T3,T4,T5,T6}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1,T2,T3,T4,T5,T6> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5)
        && CKComparerCI.EqualsField(Item6, other.Item6);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5,T6> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    /// <param name="item6">The sixth key component.</param>
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
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5,T6> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5,T6> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6> b) => !a.Equals(b);
}

/// <summary>
/// Represents a case-insensitive composite key consisting of seven values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, <typeparamref name="T4"/>, <typeparamref name="T5"/>, <typeparamref name="T6"/>, and <typeparamref name="T7"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
/// <typeparam name="T5">The type of the fifth key component.</typeparam>
/// <typeparam name="T6">The type of the sixth key component.</typeparam>
/// <typeparam name="T7">The type of the seventh key component.</typeparam>
public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1,T2,T3,T4,T5,T6,T7}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    /// <param name="f">The sixth key component.</param>
    /// <param name="g">The seventh key component.</param>
    public CompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g)
    {
        Item1 = a;
        Item2 = b;
        Item3 = c;
        Item4 = d;
        Item5 = e;
        Item6 = f;
        Item7 = g;
        int h = 17;
        unchecked {
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
    /// Determines whether the specified <see cref="CompositeKeyCI{T1,T2,T3,T4,T5,T6,T7}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> other)
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
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    /// <param name="item6">The sixth key component.</param>
    /// <param name="item7">The seventh key component.</param>
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
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> b) => !a.Equals(b);
}

/// <summary>
/// Represents a case-insensitive composite key consisting of eight values of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, <typeparamref name="T4"/>, <typeparamref name="T5"/>, <typeparamref name="T6"/>, <typeparamref name="T7"/>, and <typeparamref name="T8"/>.
/// </summary>
/// <typeparam name="T1">The type of the first key component.</typeparam>
/// <typeparam name="T2">The type of the second key component.</typeparam>
/// <typeparam name="T3">The type of the third key component.</typeparam>
/// <typeparam name="T4">The type of the fourth key component.</typeparam>
/// <typeparam name="T5">The type of the fifth key component.</typeparam>
/// <typeparam name="T6">The type of the sixth key component.</typeparam>
/// <typeparam name="T7">The type of the seventh key component.</typeparam>
/// <typeparam name="T8">The type of the eighth key component.</typeparam>
public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8>>
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
    private readonly int _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeKeyCI{T1,T2,T3,T4,T5,T6,T7,T8}"/> struct.
    /// </summary>
    /// <param name="a">The first key component.</param>
    /// <param name="b">The second key component.</param>
    /// <param name="c">The third key component.</param>
    /// <param name="d">The fourth key component.</param>
    /// <param name="e">The fifth key component.</param>
    /// <param name="f">The sixth key component.</param>
    /// <param name="g">The seventh key component.</param>
    /// <param name="h">The eighth key component.</param>
    public CompositeKeyCI(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g, T8 h)
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
        unchecked {
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
    /// Determines whether the specified <see cref="CompositeKeyCI{T1,T2,T3,T4,T5,T6,T7,T8}"/> is equal to the current key.
    /// </summary>
    /// <param name="other">The other composite key to compare.</param>
    /// <returns><c>true</c> if the keys are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> other)
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
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _hash;

    /// <summary>
    /// Deconstructs the composite key into its components.
    /// </summary>
    /// <param name="item1">The first key component.</param>
    /// <param name="item2">The second key component.</param>
    /// <param name="item3">The third key component.</param>
    /// <param name="item4">The fourth key component.</param>
    /// <param name="item5">The fifth key component.</param>
    /// <param name="item6">The sixth key component.</param>
    /// <param name="item7">The seventh key component.</param>
    /// <param name="item8">The eighth key component.</param>
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
    /// Determines whether two composite keys are equal.
    /// </summary>
    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> b) => a.Equals(b);
    /// <summary>
    /// Determines whether two composite keys are not equal.
    /// </summary>
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> b) => !a.Equals(b);
}