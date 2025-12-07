using NUnit.Framework;
using Neoasis.Data.Common;
using System;

namespace Neoasis.Data.Common.Tests
{
    [TestFixture]
    public class SortableCompositeKeysNTests
    {
        [Test]
        public void SortableCompositeKeyN_Equality_Works_For_More_Than_8_Values()
        {
            var key1 = SortableCompositeKeysN.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var key2 = SortableCompositeKeysN.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Assert.That(key1, Is.EqualTo(key2));
        }

        [Test]
        public void SortableCompositeKeyN_Inequality_Works_For_More_Than_8_Values()
        {
            var key1 = SortableCompositeKeysN.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var key2 = SortableCompositeKeysN.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 11);
            Assert.That(key1, Is.Not.EqualTo(key2));
        }

        [Test]
        public void SortableCompositeKeyN_Comparison_Works_For_More_Than_8_Values()
        {
            var key1 = SortableCompositeKeysN.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var key2 = SortableCompositeKeysN.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 11);
            Assert.That(key1, Is.LessThan(key2));
            Assert.That(key2, Is.GreaterThan(key1));
        }

        [Test]
        public void SortableCompositeKeyNCI_Equality_Works_For_More_Than_8_Values()
        {
            var key1 = SortableCompositeKeysNCI.Create("a", "b", "c", "d", "e", "f", "g", "h", "i", "J");
            var key2 = SortableCompositeKeysNCI.Create("A", "B", "C", "D", "E", "F", "G", "H", "I", "j");
            Assert.That(key1, Is.EqualTo(key2));
        }

        [Test]
        public void SortableCompositeKeyNCI_Inequality_Works_For_More_Than_8_Values()
        {
            var key1 = SortableCompositeKeysNCI.Create("a", "b", "c", "d", "e", "f", "g", "h", "i", "J");
            var key2 = SortableCompositeKeysNCI.Create("A", "B", "C", "D", "E", "F", "G", "H", "I", "K");
            Assert.That(key1, Is.Not.EqualTo(key2));
        }

        [Test]
        public void SortableCompositeKeyNCI_Comparison_Works_For_More_Than_8_Values()
        {
            var key1 = SortableCompositeKeysNCI.Create("a", "b", "c", "d", "e", "f", "g", "h", "i", "J");
            var key2 = SortableCompositeKeysNCI.Create("A", "B", "C", "D", "E", "F", "G", "H", "I", "K");
            Assert.That(key1, Is.LessThan(key2));
            Assert.That(key2, Is.GreaterThan(key1));
        }
    }
}
