using NUnit.Framework;
using Neoasis.Data.Common;

namespace Neoasis.Data.Common.Tests;

[TestFixture]
public class CompositeKeysTests
{
    [Test]
    public void CompositeKey1_Equality_Works()
    {
        var a = new CompositeKey<string>("foo");
        var b = new CompositeKey<string>("foo");
        var c = new CompositeKey<string>("bar");
        Assert.That(a, Is.EqualTo(b));
        Assert.That(a, Is.Not.EqualTo(c));
        Assert.That(a == b, Is.True);
        Assert.That(a != c, Is.True);
    }

    [Test]
    public void CompositeKey2_Equality_Works()
    {
        var a = new CompositeKey<string, int>("foo", 1);
        var b = new CompositeKey<string, int>("foo", 1);
        var c = new CompositeKey<string, int>("foo", 2);
        Assert.That(a, Is.EqualTo(b));
        Assert.That(a, Is.Not.EqualTo(c));
        Assert.That(a == b, Is.True);
        Assert.That(a != c, Is.True);
    }

    [Test]
    public void CompositeKey3_Equality_Works()
    {
        var a = new CompositeKey<string, int, double>("foo", 1, 2.0);
        var b = new CompositeKey<string, int, double>("foo", 1, 2.0);
        var c = new CompositeKey<string, int, double>("foo", 1, 3.0);
        Assert.That(a, Is.EqualTo(b));
        Assert.That(a, Is.Not.EqualTo(c));
        Assert.That(a == b, Is.True);
        Assert.That(a != c, Is.True);
    }

    [Test]
    public void CompositeKeyCI1_Equality_Works()
    {
        var a = new CompositeKeyCI<string>("foo");
        var b = new CompositeKeyCI<string>("FOO");
        var c = new CompositeKeyCI<string>("bar");
        Assert.That(a, Is.EqualTo(b));
        Assert.That(a, Is.Not.EqualTo(c));
        Assert.That(a == b, Is.True);
        Assert.That(a != c, Is.True);
    }

    [Test]
    public void CompositeKeyCI2_Equality_Works()
    {
        var a = new CompositeKeyCI<string, int>("foo", 1);
        var b = new CompositeKeyCI<string, int>("FOO", 1);
        var c = new CompositeKeyCI<string, int>("foo", 2);
        Assert.That(a, Is.EqualTo(b));
        Assert.That(a, Is.Not.EqualTo(c));
        Assert.That(a == b, Is.True);
        Assert.That(a != c, Is.True);
    }

    [Test]
    public void CompositeKeyCI3_Equality_Works()
    {
        var a = new CompositeKeyCI<string, int, double>("foo", 1, 2.0);
        var b = new CompositeKeyCI<string, int, double>("FOO", 1, 2.0);
        var c = new CompositeKeyCI<string, int, double>("foo", 1, 3.0);
        Assert.That(a, Is.EqualTo(b));
        Assert.That(a, Is.Not.EqualTo(c));
        Assert.That(a == b, Is.True);
        Assert.That(a != c, Is.True);
    }


    [Test]
    public void CompositeKey2_Deconstruct_Works()
    {
        var key = new CompositeKey<string, int>("foo", 42);
        var (item1, item2) = key;
        Assert.That(item1, Is.EqualTo("foo"));
        Assert.That(item2, Is.EqualTo(42));
    }

    [Test]
    public void CompositeKey3_Deconstruct_Works()
    {
        var key = new CompositeKey<string, int, double>("foo", 42, 3.14);
        var (item1, item2, item3) = key;
        Assert.That(item1, Is.EqualTo("foo"));
        Assert.That(item2, Is.EqualTo(42));
        Assert.That(item3, Is.EqualTo(3.14));
    }

    [Test]
    public void CompositeKeyCI2_Deconstruct_Works()
    {
        var key = new CompositeKeyCI<string, int>("FOO", 42);
        var (item1, item2) = key;
        Assert.That(item1, Is.EqualTo("FOO"));
        Assert.That(item2, Is.EqualTo(42));
    }

    [Test]
    public void CompositeKeyCI3_Deconstruct_Works()
    {
        var key = new CompositeKeyCI<string, int, double>("FOO", 42, 3.14);
        var (item1, item2, item3) = key;
        Assert.That(item1, Is.EqualTo("FOO"));
        Assert.That(item2, Is.EqualTo(42));
        Assert.That(item3, Is.EqualTo(3.14));
    }
}
