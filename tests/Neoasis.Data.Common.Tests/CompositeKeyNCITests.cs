using NUnit.Framework;
using Neoasis.Data.Common;

namespace Neoasis.Data.Common.Tests;

[TestFixture]
public class CompositeKeyNCITests
{
    [Test]
    public void CompositeKeyNCI_OneComponent_Works()
    {
        var key = new CompositeKeyNCI("foo");
        var key2 = new CompositeKeyNCI("FOO");
        var key3 = new CompositeKeyNCI("bar");
        Assert.That(key, Is.EqualTo(key2));
        Assert.That(key, Is.Not.EqualTo(key3));
    }

    [Test]
    public void CompositeKeyNCI_TwoComponents_Works()
    {
        var key = new CompositeKeyNCI("foo", 1);
        var key2 = new CompositeKeyNCI("FOO", 1);
        var key3 = new CompositeKeyNCI("foo", 2);
        Assert.That(key, Is.EqualTo(key2));
        Assert.That(key, Is.Not.EqualTo(key3));
    }

    [Test]
    public void CompositeKeyNCI_ThreeComponents_Works()
    {
        var key = new CompositeKeyNCI("foo", 1, 2.0);
        var key2 = new CompositeKeyNCI("FOO", 1, 2.0);
        var key3 = new CompositeKeyNCI("foo", 1, 3.0);
        Assert.That(key, Is.EqualTo(key2));
        Assert.That(key, Is.Not.EqualTo(key3));
    }

    [Test]
    public void CompositeKeyNCI_NineAndTenComponents_Works()
    {
        var key9 = new CompositeKeyNCI("a", 1, 2, 3, 4, 5, 6, 7, 8, 9);
        var key9b = new CompositeKeyNCI("A", 1, 2, 3, 4, 5, 6, 7, 8, 9);
        var key9c = new CompositeKeyNCI("a", 1, 2, 3, 4, 5, 6, 7, 8, 10);
        Assert.That(key9, Is.EqualTo(key9b));
        Assert.That(key9, Is.Not.EqualTo(key9c));

        var key10 = new CompositeKeyNCI("a", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var key10b = new CompositeKeyNCI("A", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var key10c = new CompositeKeyNCI("a", 1, 2, 3, 4, 5, 6, 7, 8, 9, 11);
        Assert.That(key10, Is.EqualTo(key10b));
        Assert.That(key10, Is.Not.EqualTo(key10c));
    }
}
