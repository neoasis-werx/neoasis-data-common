using System;

namespace Neoasis.Data.Common;

public readonly struct CompositeKey<T1> : IEquatable<CompositeKey<T1>>
{
    public static int ItemCount => 1;
    public readonly T1 Item1;
    private readonly int _hash;

    public CompositeKey(T1 item1)
    {
        Item1 = item1;
        _hash = CKComparer.HashField(item1!);
    }

    public bool Equals(CompositeKey<T1> other)
        => _hash == other._hash && CKComparer.EqualsField(Item1, other.Item1);

    public override bool Equals(object? obj)
        => obj is CompositeKey<T1> other && Equals(other);

    public override int GetHashCode() => _hash;

    public static bool operator ==(CompositeKey<T1> a, CompositeKey<T1> b) => a.Equals(b);
    public static bool operator !=(CompositeKey<T1> a, CompositeKey<T1> b) => !a.Equals(b);
}

public readonly struct CompositeKey<T1,T2> : IEquatable<CompositeKey<T1,T2>>
{
    public static int ItemCount => 2;
    public readonly T1 Item1;
    public readonly T2 Item2;
    private readonly int _hash;

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

    public bool Equals(CompositeKey<T1,T2> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2);

    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    public static bool operator ==(CompositeKey<T1,T2> a, CompositeKey<T1,T2> b) => a.Equals(b);
    public static bool operator !=(CompositeKey<T1,T2> a, CompositeKey<T1,T2> b) => !a.Equals(b);
}


public readonly struct CompositeKey<T1,T2,T3> : IEquatable<CompositeKey<T1,T2,T3>>
{
    public static int ItemCount => 3;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    private readonly int _hash;

    public CompositeKey(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;

        int h = 17;
        unchecked {
            h = h * 31 + CKComparer.HashField(item1!);
            h = h * 31 + CKComparer.HashField(item2!);
            h = h * 31 + CKComparer.HashField(item3!);
        }
        _hash = h;
    }

    public bool Equals(CompositeKey<T1,T2,T3> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3);

    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
    }

    public static bool operator ==(CompositeKey<T1,T2,T3> a, CompositeKey<T1,T2,T3> b) => a.Equals(b);
    public static bool operator !=(CompositeKey<T1,T2,T3> a, CompositeKey<T1,T2,T3> b) => !a.Equals(b);
}


public readonly struct CompositeKey<T1,T2,T3,T4> 
    : IEquatable<CompositeKey<T1,T2,T3,T4>>
{
    public static int ItemCount => 4;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;

    private readonly int _hash;

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

    public bool Equals(CompositeKey<T1,T2,T3,T4> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4);

    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3,T4> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
    }

    public static bool operator ==(CompositeKey<T1,T2,T3,T4> a, CompositeKey<T1,T2,T3,T4> b) => a.Equals(b);
    public static bool operator !=(CompositeKey<T1,T2,T3,T4> a, CompositeKey<T1,T2,T3,T4> b) => !a.Equals(b);
}


public readonly struct CompositeKey<T1,T2,T3,T4,T5> 
    : IEquatable<CompositeKey<T1,T2,T3,T4,T5>>
{
    public static int ItemCount => 5;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;
    public readonly T5 Item5;

    private readonly int _hash;

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

    public bool Equals(CompositeKey<T1,T2,T3,T4,T5> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5);

    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3,T4,T5> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
    }

    public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5> a, CompositeKey<T1,T2,T3,T4,T5> b) => a.Equals(b);
    public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5> a, CompositeKey<T1,T2,T3,T4,T5> b) => !a.Equals(b);
}

public readonly struct CompositeKey<T1,T2,T3,T4,T5,T6> 
    : IEquatable<CompositeKey<T1,T2,T3,T4,T5,T6>>
{
    public static int ItemCount => 6;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;
    public readonly T5 Item5;
    public readonly T6 Item6;

    private readonly int _hash;

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

    public bool Equals(CompositeKey<T1,T2,T3,T4,T5,T6> other)
        => _hash == other._hash
        && CKComparer.EqualsField(Item1, other.Item1)
        && CKComparer.EqualsField(Item2, other.Item2)
        && CKComparer.EqualsField(Item3, other.Item3)
        && CKComparer.EqualsField(Item4, other.Item4)
        && CKComparer.EqualsField(Item5, other.Item5)
        && CKComparer.EqualsField(Item6, other.Item6);

    public override bool Equals(object? obj)
        => obj is CompositeKey<T1,T2,T3,T4,T5,T6> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
    }

    public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5,T6> a, CompositeKey<T1,T2,T3,T4,T5,T6> b) => a.Equals(b);
    public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5,T6> a, CompositeKey<T1,T2,T3,T4,T5,T6> b) => !a.Equals(b);
}

    public readonly struct CompositeKey<T1,T2,T3,T4,T5,T6,T7> 
        : IEquatable<CompositeKey<T1,T2,T3,T4,T5,T6,T7>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;
        public readonly T7 Item7;

        private readonly int _hash;

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

        public bool Equals(CompositeKey<T1,T2,T3,T4,T5,T6,T7> other)
            => _hash == other._hash
            && CKComparer.EqualsField(Item1, other.Item1)
            && CKComparer.EqualsField(Item2, other.Item2)
            && CKComparer.EqualsField(Item3, other.Item3)
            && CKComparer.EqualsField(Item4, other.Item4)
            && CKComparer.EqualsField(Item5, other.Item5)
            && CKComparer.EqualsField(Item6, other.Item6)
            && CKComparer.EqualsField(Item7, other.Item7);

        public override bool Equals(object? obj)
            => obj is CompositeKey<T1,T2,T3,T4,T5,T6,T7> other && Equals(other);

    public override int GetHashCode() => _hash;

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

    public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5,T6,T7> a, CompositeKey<T1,T2,T3,T4,T5,T6,T7> b) => a.Equals(b);
    public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5,T6,T7> a, CompositeKey<T1,T2,T3,T4,T5,T6,T7> b) => !a.Equals(b);
}    public readonly struct CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> 
        : IEquatable<CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;
        public readonly T7 Item7;
        public readonly T8 Item8;

        private readonly int _hash;

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

        public override bool Equals(object? obj)
            => obj is CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> other && Equals(other);

        public override int GetHashCode() => _hash;

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

        public static bool operator ==(CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> b) => a.Equals(b);
        public static bool operator !=(CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKey<T1,T2,T3,T4,T5,T6,T7,T8> b) => !a.Equals(b);
    }

// Case-Insensitive Composite Keys

public readonly struct CompositeKeyCI<T1> : IEquatable<CompositeKeyCI<T1>>
{
    public static int ItemCount => 1;
    public readonly T1 Item1;
    private readonly int _hash;

    public CompositeKeyCI(T1 item1)
    {
        Item1 = item1;
        _hash = CKComparerCI.HashField(item1!);
    }

    public bool Equals(CompositeKeyCI<T1> other)
        => _hash == other._hash && CKComparerCI.EqualsField(Item1, other.Item1);

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1> other && Equals(other);

    public override int GetHashCode() => _hash;


    public static bool operator ==(CompositeKeyCI<T1> a, CompositeKeyCI<T1> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1> a, CompositeKeyCI<T1> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2> : IEquatable<CompositeKeyCI<T1,T2>>
{
    public static int ItemCount => 2;
    public readonly T1 Item1;
    public readonly T2 Item2;
    private readonly int _hash;

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

    public bool Equals(CompositeKeyCI<T1,T2> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2);

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    public static bool operator ==(CompositeKeyCI<T1,T2> a, CompositeKeyCI<T1,T2> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1,T2> a, CompositeKeyCI<T1,T2> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3> : IEquatable<CompositeKeyCI<T1,T2,T3>>
{
    public static int ItemCount => 3;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    private readonly int _hash;

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

    public bool Equals(CompositeKeyCI<T1,T2,T3> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3);

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
    }

    public static bool operator ==(CompositeKeyCI<T1,T2,T3> a, CompositeKeyCI<T1,T2,T3> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1,T2,T3> a, CompositeKeyCI<T1,T2,T3> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3,T4> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4>>
{
    public static int ItemCount => 4;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;

    private readonly int _hash;

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

    public bool Equals(CompositeKeyCI<T1,T2,T3,T4> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4);

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
    }

    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4> a, CompositeKeyCI<T1,T2,T3,T4> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4> a, CompositeKeyCI<T1,T2,T3,T4> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5>>
{
    public static int ItemCount => 5;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;
    public readonly T5 Item5;

    private readonly int _hash;

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

    public bool Equals(CompositeKeyCI<T1,T2,T3,T4,T5> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5);

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
    }

    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5> a, CompositeKeyCI<T1,T2,T3,T4,T5> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5> a, CompositeKeyCI<T1,T2,T3,T4,T5> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5,T6> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5,T6>>
{
    public static int ItemCount => 6;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;
    public readonly T5 Item5;
    public readonly T6 Item6;

    private readonly int _hash;

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

    public bool Equals(CompositeKeyCI<T1,T2,T3,T4,T5,T6> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5)
        && CKComparerCI.EqualsField(Item6, other.Item6);

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5,T6> other && Equals(other);

    public override int GetHashCode() => _hash;

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
        item4 = Item4;
        item5 = Item5;
        item6 = Item6;
    }

    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5,T6> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5,T6> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7>>
{
    public static int ItemCount => 7;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;
    public readonly T5 Item5;
    public readonly T6 Item6;
    public readonly T7 Item7;

    private readonly int _hash;

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

    public bool Equals(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> other)
        => _hash == other._hash
        && CKComparerCI.EqualsField(Item1, other.Item1)
        && CKComparerCI.EqualsField(Item2, other.Item2)
        && CKComparerCI.EqualsField(Item3, other.Item3)
        && CKComparerCI.EqualsField(Item4, other.Item4)
        && CKComparerCI.EqualsField(Item5, other.Item5)
        && CKComparerCI.EqualsField(Item6, other.Item6)
        && CKComparerCI.EqualsField(Item7, other.Item7);

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> other && Equals(other);

    public override int GetHashCode() => _hash;

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

    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7> b) => !a.Equals(b);
}

public readonly struct CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> 
    : IEquatable<CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8>>
{
    public static int ItemCount => 8;
    public readonly T1 Item1;
    public readonly T2 Item2;
    public readonly T3 Item3;
    public readonly T4 Item4;
    public readonly T5 Item5;
    public readonly T6 Item6;
    public readonly T7 Item7;
    public readonly T8 Item8;

    private readonly int _hash;

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

    public override bool Equals(object? obj)
        => obj is CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> other && Equals(other);

    public override int GetHashCode() => _hash;

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

    public static bool operator ==(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> b) => a.Equals(b);
    public static bool operator !=(CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> a, CompositeKeyCI<T1,T2,T3,T4,T5,T6,T7,T8> b) => !a.Equals(b);
} 