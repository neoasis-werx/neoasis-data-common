using System;

namespace Neoasis.Data.Common
{
    /// <summary>
    /// Factory class for creating sortable composite keys with N items (case-sensitive).
    /// </summary>
    public static class SortableCompositeKeysN
    {
        /// <summary>
        /// Creates a sortable composite key with N items (case-sensitive).
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="items">The items to include in the key.</param>
        /// <returns>A sortable composite key instance.</returns>
        public static SortableCompositeKeyN<T> Create<T>(params T[] items) where T : IComparable<T>
        {
            return new SortableCompositeKeyN<T>(items);
        }
    }

    /// <summary>
    /// Factory class for creating sortable composite keys with N items (case-insensitive).
    /// </summary>
    public static class SortableCompositeKeysNCI
    {
        /// <summary>
        /// Creates a sortable composite key with N items (case-insensitive).
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="items">The items to include in the key.</param>
        /// <returns>A sortable composite key instance.</returns>
        public static SortableCompositeKeyNCI<T> Create<T>(params T[] items) where T : IComparable<T>
        {
            return new SortableCompositeKeyNCI<T>(items);
        }
    }

    /// <summary>
    /// Represents a sortable composite key with N items (case-sensitive).
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    public readonly struct SortableCompositeKeyN<T> : IEquatable<SortableCompositeKeyN<T>>, IComparable<SortableCompositeKeyN<T>> where T : IComparable<T>
    {
        /// <summary>
        /// Gets the items in the composite key as a read-only array.
        /// </summary>
        private readonly T[] _items;
        private readonly int _hash;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableCompositeKeyN{T}"/> struct.
        /// </summary>
        /// <param name="items">The items to include in the key.</param>
        public SortableCompositeKeyN(T[] items)
        {
            _items = (T[])items.Clone();
            int h = 17;
            unchecked
            {
                foreach (var item in _items)
                {
                    h = h * 31 + CKComparer.HashField(item!);
                }
            }
            _hash = h;
        }

        /// <summary>
        /// Determines whether the specified key is equal to the current key.
        /// </summary>
        /// <param name="other">The other key to compare.</param>
        /// <returns>True if equal; otherwise, false.</returns>
        public bool Equals(SortableCompositeKeyN<T> other)
        {
            if (_hash != other._hash || _items.Length != other._items.Length)
                return false;
            for (int i = 0; i < _items.Length; i++)
            {
                if (!CKComparer.EqualsField(_items[i], other._items[i]))
                    return false;
            }
            return true;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
            => obj is SortableCompositeKeyN<T> other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _hash;

        /// <summary>
        /// Compares this key to another key.
        /// </summary>
        /// <param name="other">The other key to compare.</param>
        /// <returns>A value indicating the relative order.</returns>
        public int CompareTo(SortableCompositeKeyN<T> other)
        {
            int len = Math.Min(_items.Length, other._items.Length);
            for (int i = 0; i < len; i++)
            {
                int cmp = _items[i].CompareTo(other._items[i]);
                if (cmp != 0) return cmp;
            }
            return _items.Length.CompareTo(other._items.Length);
        }

        /// <summary>
        /// Deconstructs the composite key into its items.
        /// </summary>
        /// <param name="items">The items in the key.</param>
        public void Deconstruct(out T[] items)
        {
            items = (T[])_items.Clone();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        public static bool operator ==(SortableCompositeKeyN<T> a, SortableCompositeKeyN<T> b) => a.Equals(b);
        /// <summary>
        /// Inequality operator.
        /// </summary>
        public static bool operator !=(SortableCompositeKeyN<T> a, SortableCompositeKeyN<T> b) => !a.Equals(b);
        /// <summary>
        /// Less than operator.
        /// </summary>
        public static bool operator <(SortableCompositeKeyN<T> a, SortableCompositeKeyN<T> b) => a.CompareTo(b) < 0;
        /// <summary>
        /// Greater than operator.
        /// </summary>
        public static bool operator >(SortableCompositeKeyN<T> a, SortableCompositeKeyN<T> b) => a.CompareTo(b) > 0;
        /// <summary>
        /// Less than or equal operator.
        /// </summary>
        public static bool operator <=(SortableCompositeKeyN<T> a, SortableCompositeKeyN<T> b) => a.CompareTo(b) <= 0;
        /// <summary>
        /// Greater than or equal operator.
        /// </summary>
        public static bool operator >=(SortableCompositeKeyN<T> a, SortableCompositeKeyN<T> b) => a.CompareTo(b) >= 0;
        /// <summary>
        /// Gets a copy of the items in the composite key.
        /// </summary>
        public T[] Items => (T[])_items.Clone();
    }

    /// <summary>
    /// Represents a sortable composite key with N items (case-insensitive).
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    public readonly struct SortableCompositeKeyNCI<T> : IEquatable<SortableCompositeKeyNCI<T>>, IComparable<SortableCompositeKeyNCI<T>> where T : IComparable<T>
    {
        /// <summary>
        /// Gets the items in the composite key as a read-only array.
        /// </summary>
        private readonly T[] _items;
        private readonly int _hash;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableCompositeKeyNCI{T}"/> struct.
        /// </summary>
        /// <param name="items">The items to include in the key.</param>
        public SortableCompositeKeyNCI(T[] items)
        {
            _items = (T[])items.Clone();
            int h = 17;
            unchecked
            {
                foreach (var item in _items)
                {
                    h = h * 31 + CKComparerCI.HashField(item!);
                }
            }
            _hash = h;
        }

        /// <summary>
        /// Determines whether the specified key is equal to the current key.
        /// </summary>
        /// <param name="other">The other key to compare.</param>
        /// <returns>True if equal; otherwise, false.</returns>
        public bool Equals(SortableCompositeKeyNCI<T> other)
        {
            if (_hash != other._hash || _items.Length != other._items.Length)
                return false;
            for (int i = 0; i < _items.Length; i++)
            {
                if (!CKComparerCI.EqualsField(_items[i], other._items[i]))
                    return false;
            }
            return true;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
            => obj is SortableCompositeKeyNCI<T> other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _hash;

        /// <summary>
        /// Compares this key to another key.
        /// </summary>
        /// <param name="other">The other key to compare.</param>
        /// <returns>A value indicating the relative order.</returns>
        public int CompareTo(SortableCompositeKeyNCI<T> other)
        {
            int len = Math.Min(_items.Length, other._items.Length);
            for (int i = 0; i < len; i++)
            {
                int cmp = CKComparerSortable.CompareField(_items[i], other._items[i]);
                if (cmp != 0) return cmp;
            }
            return _items.Length.CompareTo(other._items.Length);
        }

        /// <summary>
        /// Deconstructs the composite key into its items.
        /// </summary>
        /// <param name="items">The items in the key.</param>
        public void Deconstruct(out T[] items)
        {
            items = (T[])_items.Clone();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        public static bool operator ==(SortableCompositeKeyNCI<T> a, SortableCompositeKeyNCI<T> b) => a.Equals(b);
        /// <summary>
        /// Inequality operator.
        /// </summary>
        public static bool operator !=(SortableCompositeKeyNCI<T> a, SortableCompositeKeyNCI<T> b) => !a.Equals(b);
        /// <summary>
        /// Less than operator.
        /// </summary>
        public static bool operator <(SortableCompositeKeyNCI<T> a, SortableCompositeKeyNCI<T> b) => a.CompareTo(b) < 0;
        /// <summary>
        /// Greater than operator.
        /// </summary>
        public static bool operator >(SortableCompositeKeyNCI<T> a, SortableCompositeKeyNCI<T> b) => a.CompareTo(b) > 0;
        /// <summary>
        /// Less than or equal operator.
        /// </summary>
        public static bool operator <=(SortableCompositeKeyNCI<T> a, SortableCompositeKeyNCI<T> b) => a.CompareTo(b) <= 0;
        /// <summary>
        /// Greater than or equal operator.
        /// </summary>
        public static bool operator >=(SortableCompositeKeyNCI<T> a, SortableCompositeKeyNCI<T> b) => a.CompareTo(b) >= 0;
        /// <summary>
        /// Gets a copy of the items in the composite key.
        /// </summary>
        public T[] Items => (T[])_items.Clone();
    }
}
