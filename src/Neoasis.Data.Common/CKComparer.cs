using System;
using System.Runtime.CompilerServices;

namespace Neoasis.Data.Common;

/// <summary>
/// Provides optimized equality and hash code operations for composite key fields.
/// Uses <see cref="StringComparer.Ordinal"/> for string comparison and hashing.
/// </summary>
internal static class CKComparer
{
    /// <summary>
    /// Ordinal string comparer for case-sensitive operations.
    /// </summary>
    public static readonly StringComparer Ordinal = StringComparer.Ordinal;

    /// <summary>
    /// OrdinalIgnoreCase string comparer for case-insensitive operations.
    /// </summary>
    public static readonly StringComparer OrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;

    /// <summary>
    /// Determines equality between two fields, using ordinal string comparison for strings.
    /// </summary>
    /// <typeparam name="T">Type of the field.</typeparam>
    /// <param name="x">First value.</param>
    /// <param name="y">Second value.</param>
    /// <returns>True if equal, otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsField<T>(T x, T y)
    {
        return x switch
        {
            string xs when y is string ys => Ordinal.Equals(xs, ys),
            _ => EqualityComparer<T>.Default.Equals(x, y)
        };
    }

    /// <summary>
    /// Computes a hash code for a field, using ordinal string hashing for strings.
    /// </summary>
    /// <typeparam name="T">Type of the field.</typeparam>
    /// <param name="value">Value to hash.</param>
    /// <returns>Hash code for the value.</returns>
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

/// <summary>
/// Provides optimized case-insensitive equality and hash code operations for composite key fields.
/// Uses <see cref="StringComparer.OrdinalIgnoreCase"/> for string comparison and hashing.
/// </summary>
internal static class CKComparerCI
{
    /// <summary>
    /// OrdinalIgnoreCase string comparer for case-insensitive operations.
    /// </summary>
    public static readonly StringComparer OrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;

    /// <summary>
    /// Determines equality between two fields, using ordinal ignore-case string comparison for strings.
    /// </summary>
    /// <typeparam name="T">Type of the field.</typeparam>
    /// <param name="x">First value.</param>
    /// <param name="y">Second value.</param>
    /// <returns>True if equal, otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsField<T>(T x, T y)
    {
        return x switch
        {
            string xs when y is string ys => OrdinalIgnoreCase.Equals(xs, ys),
            _ => EqualityComparer<T>.Default.Equals(x, y)
        };
    }

    /// <summary>
    /// Computes a hash code for a field, using ordinal ignore-case string hashing for strings.
    /// </summary>
    /// <typeparam name="T">Type of the field.</typeparam>
    /// <param name="value">Value to hash.</param>
    /// <returns>Hash code for the value.</returns>
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
