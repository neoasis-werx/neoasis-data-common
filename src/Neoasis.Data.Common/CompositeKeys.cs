using System;

namespace Neoasis.Data.Common;

/// <summary>
/// Provides factory methods for creating strongly-typed composite keys.
/// Supports both case-sensitive and case-insensitive key creation for 1-8 components.
/// </summary>
public static class CompositeKeys
{
    /// <summary>
    /// Creates a case-sensitive composite key with one component.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <returns>A <see cref="CompositeKey{T1}"/> instance.</returns>
    public static CompositeKey<T1> Create<T1>(T1 item1) => new(item1);

    /// <summary>
    /// Creates a case-sensitive composite key with two components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <returns>A <see cref="CompositeKey{T1, T2}"/> instance.</returns>
    public static CompositeKey<T1, T2> Create<T1, T2>(T1 item1, T2 item2) => new(item1, item2);

    /// <summary>
    /// Creates a case-sensitive composite key with three components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <returns>A <see cref="CompositeKey{T1, T2, T3}"/> instance.</returns>
    public static CompositeKey<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3) => new(item1, item2, item3);

    /// <summary>
    /// Creates a case-sensitive composite key with four components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <returns>A <see cref="CompositeKey{T1, T2, T3, T4}"/> instance.</returns>
    public static CompositeKey<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4) => new(item1, item2, item3, item4);

    /// <summary>
    /// Creates a case-sensitive composite key with five components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <returns>A <see cref="CompositeKey{T1, T2, T3, T4, T5}"/> instance.</returns>
    public static CompositeKey<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) => new(item1, item2, item3, item4, item5);

    /// <summary>
    /// Creates a case-sensitive composite key with six components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <typeparam name="T6">Type of the sixth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <param name="item6">Sixth key component.</param>
    /// <returns>A <see cref="CompositeKey{T1, T2, T3, T4, T5, T6}"/> instance.</returns>
    public static CompositeKey<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) => new(item1, item2, item3, item4, item5, item6);

    /// <summary>
    /// Creates a case-sensitive composite key with seven components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <typeparam name="T6">Type of the sixth component.</typeparam>
    /// <typeparam name="T7">Type of the seventh component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <param name="item6">Sixth key component.</param>
    /// <param name="item7">Seventh key component.</param>
    /// <returns>A <see cref="CompositeKey{T1, T2, T3, T4, T5, T6, T7}"/> instance.</returns>
    public static CompositeKey<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) => new(item1, item2, item3, item4, item5, item6, item7);

    /// <summary>
    /// Creates a case-sensitive composite key with eight components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <typeparam name="T6">Type of the sixth component.</typeparam>
    /// <typeparam name="T7">Type of the seventh component.</typeparam>
    /// <typeparam name="T8">Type of the eighth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <param name="item6">Sixth key component.</param>
    /// <param name="item7">Seventh key component.</param>
    /// <param name="item8">Eighth key component.</param>
    /// <returns>A <see cref="CompositeKey{T1, T2, T3, T4, T5, T6, T7, T8}"/> instance.</returns>
    public static CompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) => new(item1, item2, item3, item4, item5, item6, item7, item8);

    /// <summary>
    /// Creates a case-insensitive composite key with one component.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1}"/> instance.</returns>
    public static CompositeKeyCI<T1> CreateCI<T1>(T1 item1) => new(item1);

    /// <summary>
    /// Creates a case-insensitive composite key with two components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1, T2}"/> instance.</returns>
    public static CompositeKeyCI<T1, T2> CreateCI<T1, T2>(T1 item1, T2 item2) => new(item1, item2);

    /// <summary>
    /// Creates a case-insensitive composite key with three components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1, T2, T3}"/> instance.</returns>
    public static CompositeKeyCI<T1, T2, T3> CreateCI<T1, T2, T3>(T1 item1, T2 item2, T3 item3) => new(item1, item2, item3);

    /// <summary>
    /// Creates a case-insensitive composite key with four components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1, T2, T3, T4}"/> instance.</returns>
    public static CompositeKeyCI<T1, T2, T3, T4> CreateCI<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4) => new(item1, item2, item3, item4);

    /// <summary>
    /// Creates a case-insensitive composite key with five components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1, T2, T3, T4, T5}"/> instance.</returns>
    public static CompositeKeyCI<T1, T2, T3, T4, T5> CreateCI<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) => new(item1, item2, item3, item4, item5);

    /// <summary>
    /// Creates a case-insensitive composite key with six components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <typeparam name="T6">Type of the sixth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <param name="item6">Sixth key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1, T2, T3, T4, T5, T6}"/> instance.</returns>
    public static CompositeKeyCI<T1, T2, T3, T4, T5, T6> CreateCI<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) => new(item1, item2, item3, item4, item5, item6);

    /// <summary>
    /// Creates a case-insensitive composite key with seven components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <typeparam name="T6">Type of the sixth component.</typeparam>
    /// <typeparam name="T7">Type of the seventh component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <param name="item6">Sixth key component.</param>
    /// <param name="item7">Seventh key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1, T2, T3, T4, T5, T6, T7}"/> instance.</returns>
    public static CompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> CreateCI<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) => new(item1, item2, item3, item4, item5, item6, item7);

    /// <summary>
    /// Creates a case-insensitive composite key with eight components.
    /// </summary>
    /// <typeparam name="T1">Type of the first component.</typeparam>
    /// <typeparam name="T2">Type of the second component.</typeparam>
    /// <typeparam name="T3">Type of the third component.</typeparam>
    /// <typeparam name="T4">Type of the fourth component.</typeparam>
    /// <typeparam name="T5">Type of the fifth component.</typeparam>
    /// <typeparam name="T6">Type of the sixth component.</typeparam>
    /// <typeparam name="T7">Type of the seventh component.</typeparam>
    /// <typeparam name="T8">Type of the eighth component.</typeparam>
    /// <param name="item1">First key component.</param>
    /// <param name="item2">Second key component.</param>
    /// <param name="item3">Third key component.</param>
    /// <param name="item4">Fourth key component.</param>
    /// <param name="item5">Fifth key component.</param>
    /// <param name="item6">Sixth key component.</param>
    /// <param name="item7">Seventh key component.</param>
    /// <param name="item8">Eighth key component.</param>
    /// <returns>A <see cref="CompositeKeyCI{T1, T2, T3, T4, T5, T6, T7, T8}"/> instance.</returns>
    public static CompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> CreateCI<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) => new(item1, item2, item3, item4, item5, item6, item7, item8);
}
