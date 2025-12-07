using NUnit.Framework;
using Neoasis.Data.Common;

namespace Neoasis.Data.Common.Tests;

[TestFixture]
public class CompositeKeyNTests
{
    [Test]
    public void CompositeKeyN_OneComponent_Works()
    {
        var key = new CompositeKeyN("foo");
        var key2 = new CompositeKeyN("foo");
        var key3 = new CompositeKeyN("bar");
        Assert.That(key, Is.EqualTo(key2));
        Assert.That(key, Is.Not.EqualTo(key3));
    }

    [Test]
    public void CompositeKeyN_TwoComponents_Works()
    {
        var key = new CompositeKeyN("foo", 1);
        var key2 = new CompositeKeyN("foo", 1);
        var key3 = new CompositeKeyN("foo", 2);
        Assert.That(key, Is.EqualTo(key2));
        Assert.That(key, Is.Not.EqualTo(key3));
    }

    [Test]
    public void CompositeKeyN_ThreeComponents_Works()
    {
        var key = new CompositeKeyN("foo", 1, 2.0);
        var key2 = new CompositeKeyN("foo", 1, 2.0);
        var key3 = new CompositeKeyN("foo", 1, 3.0);
        Assert.That(key, Is.EqualTo(key2));
        Assert.That(key, Is.Not.EqualTo(key3));
    }

    
    [Test]
    public void CompositeKeyN_NineAndTenComponents_Works()
    {
        var key9 = new CompositeKeyN("a", 1, 2, 3, 4, 5, 6, 7, 8, 9);
        var key9b = new CompositeKeyN("a", 1, 2, 3, 4, 5, 6, 7, 8, 9);
        var key9c = new CompositeKeyN("a", 1, 2, 3, 4, 5, 6, 7, 8, 10);
        Assert.That(key9, Is.EqualTo(key9b));
        Assert.That(key9, Is.Not.EqualTo(key9c));

        var key10 = new CompositeKeyN("a", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var key10b = new CompositeKeyN("a", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        var key10c = new CompositeKeyN("a", 1, 2, 3, 4, 5, 6, 7, 8, 9, 11);
        Assert.That(key10, Is.EqualTo(key10b));
        Assert.That(key10, Is.Not.EqualTo(key10c));
    }
}
