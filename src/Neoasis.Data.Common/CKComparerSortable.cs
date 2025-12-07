using System.Runtime.CompilerServices;

namespace Neoasis.Data.Common;

/// <summary>
/// Provides optimized comparison operations for sortable composite key fields.
/// Uses <see cref="StringComparer.OrdinalIgnoreCase"/> for case-insensitive string comparison.
/// </summary>
internal static class CKComparerSortable
{
    /// <summary>
    /// OrdinalIgnoreCase string comparer for case-insensitive sorting of strings.
    /// </summary>
    public static readonly StringComparer OrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;

    /// <summary>
    /// Compares two fields, using ordinal ignore-case string comparison for strings, otherwise <see cref="IComparable{T}.CompareTo"/>.
    /// </summary>
    /// <typeparam name="T">Type of the field, must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="x">First value.</param>
    /// <param name="y">Second value.</param>
    /// <returns>Negative if x &lt; y, zero if x == y, positive if x &gt; y.</returns>
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
