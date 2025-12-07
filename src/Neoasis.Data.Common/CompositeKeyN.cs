namespace Neoasis.Data.Common;

public readonly struct CompositeKeyN : IEquatable<CompositeKeyN>
{
    private readonly object?[] _values;
    private readonly int _hash;

    public int ItemCount => _values?.Length ?? 0;

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

    public bool Equals(CompositeKeyN other)
    {
        if (_hash != other._hash) return false;
        if (_values.Length != other._values.Length) return false;

        for (int i = 0; i < _values.Length; i++)
            if (!CKComparer.EqualsField(_values[i], other._values[i]))
                return false;

        return true;
    }

    public override bool Equals(object? obj)
        => obj is CompositeKeyN other && Equals(other);

    public override int GetHashCode() => _hash;

    public static bool operator ==(CompositeKeyN a, CompositeKeyN b) => a.Equals(b);
    public static bool operator !=(CompositeKeyN a, CompositeKeyN b) => !a.Equals(b);
}


public readonly struct CompositeKeyNCI : IEquatable<CompositeKeyNCI>
{
    private readonly object?[] _values;
    private readonly int _hash;

    public int ItemCount => _values?.Length ?? 0;

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

    public bool Equals(CompositeKeyNCI other)
    {
        if (_hash != other._hash) return false;
        if (_values.Length != other._values.Length) return false;

        for (int i = 0; i < _values.Length; i++)
            if (!CKComparerCI.EqualsField(_values[i], other._values[i]))
                return false;

        return true;
    }

    public override bool Equals(object? obj)
        => obj is CompositeKeyNCI other && Equals(other);

    public override int GetHashCode() => _hash;

    public static bool operator ==(CompositeKeyNCI a, CompositeKeyNCI b) => a.Equals(b);
    public static bool operator !=(CompositeKeyNCI a, CompositeKeyNCI b) => !a.Equals(b);
}
