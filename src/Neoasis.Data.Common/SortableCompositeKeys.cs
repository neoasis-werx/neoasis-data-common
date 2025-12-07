using System;

namespace Neoasis.Data.Common;

public static class SortableCompositeKeys
{
    // Case-sensitive
    public static SortableCompositeKey<T1> Create<T1>(T1 item1) where T1 : IComparable<T1> => new(item1);
    public static SortableCompositeKey<T1, T2> Create<T1, T2>(T1 item1, T2 item2) where T1 : IComparable<T1> where T2 : IComparable<T2> => new(item1, item2);
    public static SortableCompositeKey<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> => new(item1, item2, item3);
    public static SortableCompositeKey<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> => new(item1, item2, item3, item4);
    public static SortableCompositeKey<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> => new(item1, item2, item3, item4, item5);
    public static SortableCompositeKey<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> where T6 : IComparable<T6> => new(item1, item2, item3, item4, item5, item6);
    public static SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> where T6 : IComparable<T6> where T7 : IComparable<T7> => new(item1, item2, item3, item4, item5, item6, item7);
    public static SortableCompositeKey<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> where T6 : IComparable<T6> where T7 : IComparable<T7> where T8 : IComparable<T8> => new(item1, item2, item3, item4, item5, item6, item7, item8);

    // Case-insensitive
    public static SortableCompositeKeyCI<T1> CreateCI<T1>(T1 item1) where T1 : IComparable<T1> => new(item1);
    public static SortableCompositeKeyCI<T1, T2> CreateCI<T1, T2>(T1 item1, T2 item2) where T1 : IComparable<T1> where T2 : IComparable<T2> => new(item1, item2);
    public static SortableCompositeKeyCI<T1, T2, T3> CreateCI<T1, T2, T3>(T1 item1, T2 item2, T3 item3) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> => new(item1, item2, item3);
    public static SortableCompositeKeyCI<T1, T2, T3, T4> CreateCI<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> => new(item1, item2, item3, item4);
    public static SortableCompositeKeyCI<T1, T2, T3, T4, T5> CreateCI<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> => new(item1, item2, item3, item4, item5);
    public static SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6> CreateCI<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> where T6 : IComparable<T6> => new(item1, item2, item3, item4, item5, item6);
    public static SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7> CreateCI<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> where T6 : IComparable<T6> where T7 : IComparable<T7> => new(item1, item2, item3, item4, item5, item6, item7);
    public static SortableCompositeKeyCI<T1, T2, T3, T4, T5, T6, T7, T8> CreateCI<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) where T1 : IComparable<T1> where T2 : IComparable<T2> where T3 : IComparable<T3> where T4 : IComparable<T4> where T5 : IComparable<T5> where T6 : IComparable<T6> where T7 : IComparable<T7> where T8 : IComparable<T8> => new(item1, item2, item3, item4, item5, item6, item7, item8);
}
