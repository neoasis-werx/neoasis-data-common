using NUnit.Framework;
using Neoasis.Data.Common;

namespace Neoasis.Data.Common.Tests;

[TestFixture]
public class CompositeKeysFactoryTests
{
    [Test]
    public void Factory1_Works()
    {
        var direct = new CompositeKey<string>("foo");
        var factory = CompositeKeys.Create("foo");
        Assert.That(factory, Is.EqualTo(direct));

        var directCI = new CompositeKeyCI<string>("foo");
        var factoryCI = CompositeKeys.CreateCI("FOO");
        Assert.That(factoryCI, Is.EqualTo(directCI));
    }

    [Test]
    public void Factory2_Works()
    {
        var direct = new CompositeKey<string, int>("foo", 1);
        var factory = CompositeKeys.Create("foo", 1);
        Assert.That(factory, Is.EqualTo(direct));

        var directCI = new CompositeKeyCI<string, int>("foo", 1);
        var factoryCI = CompositeKeys.CreateCI("FOO", 1);
        Assert.That(factoryCI, Is.EqualTo(directCI));
    }

    [Test]
    public void Factory3_Works()
    {
        var direct = new CompositeKey<string, int, double>("foo", 1, 2.0);
        var factory = CompositeKeys.Create("foo", 1, 2.0);
        Assert.That(factory, Is.EqualTo(direct));

        var directCI = new CompositeKeyCI<string, int, double>("foo", 1, 2.0);
        var factoryCI = CompositeKeys.CreateCI("FOO", 1, 2.0);
        Assert.That(factoryCI, Is.EqualTo(directCI));
    }
}
