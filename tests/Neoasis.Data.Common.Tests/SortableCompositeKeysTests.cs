using NUnit.Framework;
using Neoasis.Data.Common;

namespace Neoasis.Data.Common.Tests;

[TestFixture]
public class SortableCompositeKeysTests
{
    [Test]
    public void SortableCompositeKey1_Sorting_Works()
    {
        var key1 = new SortableCompositeKey<string>("apple");
        var key2 = new SortableCompositeKey<string>("banana");
        var key3 = new SortableCompositeKey<string>("cherry");
        
        Assert.That(key1.CompareTo(key2), Is.LessThan(0));
        Assert.That(key2.CompareTo(key3), Is.LessThan(0));
        Assert.That(key3.CompareTo(key1), Is.GreaterThan(0));
        Assert.That(key1.CompareTo(key1), Is.EqualTo(0));
        
        Assert.That(key1 < key2, Is.True);
        Assert.That(key2 > key1, Is.True);
        Assert.That(key1 <= key2, Is.True);
        Assert.That(key2 >= key1, Is.True);
    }

    [Test]
    public void SortableCompositeKey2_Sorting_Works()
    {
        var key1 = new SortableCompositeKey<string, int>("apple", 1);
        var key2 = new SortableCompositeKey<string, int>("apple", 2);
        var key3 = new SortableCompositeKey<string, int>("banana", 1);
        
        Assert.That(key1.CompareTo(key2), Is.LessThan(0));
        Assert.That(key2.CompareTo(key3), Is.LessThan(0));
        Assert.That(key3.CompareTo(key1), Is.GreaterThan(0));
        Assert.That(key1.CompareTo(key1), Is.EqualTo(0));
        
        Assert.That(key1 < key2, Is.True);
        Assert.That(key2 < key3, Is.True);
        Assert.That(key3 > key1, Is.True);
    }

    [Test]
    public void SortableCompositeKey3_Sorting_Works()
    {
        var key1 = new SortableCompositeKey<string, int, double>("apple", 1, 2.5);
        var key2 = new SortableCompositeKey<string, int, double>("apple", 1, 3.5);
        var key3 = new SortableCompositeKey<string, int, double>("apple", 2, 1.0);
        
        Assert.That(key1.CompareTo(key2), Is.LessThan(0));
        Assert.That(key2.CompareTo(key3), Is.LessThan(0));
        Assert.That(key3.CompareTo(key1), Is.GreaterThan(0));
        Assert.That(key1.CompareTo(key1), Is.EqualTo(0));
        
        Assert.That(key1 < key2, Is.True);
        Assert.That(key2 < key3, Is.True);
    }

    [Test]
    public void SortableCompositeKeyCI1_Sorting_CaseInsensitive_Works()
    {
        var key1 = new SortableCompositeKeyCI<string>("apple");
        var key2 = new SortableCompositeKeyCI<string>("BANANA");
        var key3 = new SortableCompositeKeyCI<string>("Cherry");
        
        Assert.That(key1.CompareTo(key2), Is.LessThan(0));
        Assert.That(key2.CompareTo(key3), Is.LessThan(0));
        Assert.That(key3.CompareTo(key1), Is.GreaterThan(0));
        
        // Case insensitive equality
        var key1Upper = new SortableCompositeKeyCI<string>("APPLE");
        Assert.That(key1.CompareTo(key1Upper), Is.EqualTo(0));
        Assert.That(key1, Is.EqualTo(key1Upper));
    }

    [Test]
    public void SortableCompositeKeyCI2_Sorting_CaseInsensitive_Works()
    {
        var key1 = new SortableCompositeKeyCI<string, int>("apple", 1);
        var key2 = new SortableCompositeKeyCI<string, int>("APPLE", 2);
        var key3 = new SortableCompositeKeyCI<string, int>("Banana", 1);
        
        Assert.That(key1.CompareTo(key2), Is.LessThan(0));
        Assert.That(key2.CompareTo(key3), Is.LessThan(0));
        
        // Case insensitive equality on same values
        var key1Upper = new SortableCompositeKeyCI<string, int>("APPLE", 1);
        Assert.That(key1.CompareTo(key1Upper), Is.EqualTo(0));
        Assert.That(key1, Is.EqualTo(key1Upper));
    }

    [Test]
    public void SortableCompositeKeyCI3_Sorting_CaseInsensitive_Works()
    {
        var key1 = new SortableCompositeKeyCI<string, int, double>("apple", 1, 2.5);
        var key2 = new SortableCompositeKeyCI<string, int, double>("APPLE", 1, 3.5);
        var key3 = new SortableCompositeKeyCI<string, int, double>("Banana", 1, 1.0);
        
        Assert.That(key1.CompareTo(key2), Is.LessThan(0));
        Assert.That(key2.CompareTo(key3), Is.LessThan(0));
        
        // Case insensitive equality on same values
        var key1Upper = new SortableCompositeKeyCI<string, int, double>("APPLE", 1, 2.5);
        Assert.That(key1.CompareTo(key1Upper), Is.EqualTo(0));
        Assert.That(key1, Is.EqualTo(key1Upper));
    }
}
