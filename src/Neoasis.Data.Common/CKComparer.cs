using System;
using System.Runtime.CompilerServices;

namespace Neoasis.Data.Common;

internal static class CKComparer
{
    public static readonly StringComparer Ordinal = StringComparer.Ordinal;
    public static readonly StringComparer OrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsField<T>(T x, T y)
    {
        return x switch
        {
            string xs when y is string ys => Ordinal.Equals(xs, ys),
            _ => EqualityComparer<T>.Default.Equals(x, y)
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int HashField<T>(T value)
    {
        return value switch
        {
            null => 0,
            string s => Ordinal.GetHashCode(s),
            _ => value!.GetHashCode()
        };
    }
}

internal static class CKComparerCI
{
    public static readonly StringComparer OrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsField<T>(T x, T y)
    {
        return x switch
        {
            string xs when y is string ys => OrdinalIgnoreCase.Equals(xs, ys),
            _ => EqualityComparer<T>.Default.Equals(x, y)
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int HashField<T>(T value)
    {
        return value switch
        {
            null => 0,
            string s => OrdinalIgnoreCase.GetHashCode(s),
            _ => value!.GetHashCode()
        };
    }
}
