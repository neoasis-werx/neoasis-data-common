using System;
using System.Runtime.CompilerServices;

namespace Neoasis.Data.Common;

internal static class CKComparerSortable
{
    public static readonly StringComparer OrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareField<T>(T x, T y) where T : IComparable<T>
    {
        return x switch
        {
            string xs when y is string ys => OrdinalIgnoreCase.Compare(xs, ys),
            _ => x.CompareTo(y)
        };
    }
}
