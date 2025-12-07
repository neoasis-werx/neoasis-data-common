using NUnit.Framework;
using Neoasis.Data.Common;

namespace Neoasis.Data.Common.Tests;

[TestFixture]
public class SortableCompositeKeysFactoryTests
{
    [Test]
    public void SortableFactory1_Works()
    {
        var direct = new SortableCompositeKey<string>("foo");
        var factory = SortableCompositeKeys.Create("foo");
        Assert.That(factory, Is.EqualTo(direct));
        Assert.That(factory.CompareTo(direct), Is.EqualTo(0));

        var directCI = new SortableCompositeKeyCI<string>("foo");
        var factoryCI = SortableCompositeKeys.CreateCI("FOO");
        Assert.That(factoryCI, Is.EqualTo(directCI));
        Assert.That(factoryCI.CompareTo(directCI), Is.EqualTo(0));
    }

    [Test]
    public void SortableFactory2_Works()
    {
        var direct = new SortableCompositeKey<string, int>("foo", 42);
        var factory = SortableCompositeKeys.Create("foo", 42);
        Assert.That(factory, Is.EqualTo(direct));
        Assert.That(factory.CompareTo(direct), Is.EqualTo(0));

        var directCI = new SortableCompositeKeyCI<string, int>("foo", 42);
        var factoryCI = SortableCompositeKeys.CreateCI("FOO", 42);
        Assert.That(factoryCI, Is.EqualTo(directCI));
        Assert.That(factoryCI.CompareTo(directCI), Is.EqualTo(0));
    }

    [Test]
    public void SortableFactory3_Works()
    {
        var direct = new SortableCompositeKey<string, int, double>("foo", 42, 3.14);
        var factory = SortableCompositeKeys.Create("foo", 42, 3.14);
        Assert.That(factory, Is.EqualTo(direct));
        Assert.That(factory.CompareTo(direct), Is.EqualTo(0));

        var directCI = new SortableCompositeKeyCI<string, int, double>("foo", 42, 3.14);
        var factoryCI = SortableCompositeKeys.CreateCI("FOO", 42, 3.14);
        Assert.That(factoryCI, Is.EqualTo(directCI));
        Assert.That(factoryCI.CompareTo(directCI), Is.EqualTo(0));
    }

    [Test]
    public void SortableFactory_Sorting_Integration_Works()
    {
        var keys = new[]
        {
            SortableCompositeKeys.Create("banana", 2),
            SortableCompositeKeys.Create("apple", 1),
            SortableCompositeKeys.Create("cherry", 3),
            SortableCompositeKeys.Create("apple", 2)
        };

        var sorted = keys.OrderBy(k => k).ToArray();

        Assert.That(sorted[0].Item1, Is.EqualTo("apple"));
        Assert.That(sorted[0].Item2, Is.EqualTo(1));
        Assert.That(sorted[1].Item1, Is.EqualTo("apple"));
        Assert.That(sorted[1].Item2, Is.EqualTo(2));
        Assert.That(sorted[2].Item1, Is.EqualTo("banana"));
        Assert.That(sorted[3].Item1, Is.EqualTo("cherry"));
    }

    [Test]
    public void SortableFactoryCI_Sorting_Integration_Works()
    {
        var keys = new[]
        {
            SortableCompositeKeys.CreateCI("BANANA", 2),
            SortableCompositeKeys.CreateCI("apple", 1),
            SortableCompositeKeys.CreateCI("Cherry", 3),
            SortableCompositeKeys.CreateCI("APPLE", 2)
        };

        var sorted = keys.OrderBy(k => k).ToArray();

        Assert.That(sorted[0].Item1, Is.EqualTo("apple"));
        Assert.That(sorted[0].Item2, Is.EqualTo(1));
        Assert.That(sorted[1].Item1, Is.EqualTo("APPLE"));
        Assert.That(sorted[1].Item2, Is.EqualTo(2));
        Assert.That(sorted[2].Item1, Is.EqualTo("BANANA"));
        Assert.That(sorted[3].Item1, Is.EqualTo("Cherry"));
    }
}
