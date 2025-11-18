using Common.UI.Extensions;
using System.Drawing;
using System.Globalization;

namespace Common.UI.Tests.Extensions;

[TestClass]
public class ColorExtensionsTests
{
    [TestMethod]
    public void TestGetForeColor()
    {
        Assert.AreEqual(Color.DimGray, Color.Aqua.GetForeColor());
        Assert.AreEqual(Color.WhiteSmoke, Color.DarkBlue.GetForeColor());
    }

    [TestMethod]
    public void TestGetDimColor()
    {
        Assert.AreEqual(ColorTranslator.FromHtml("#004c00"), ColorTranslator.FromHtml("#00ff00").GetDimColor());
        Assert.AreEqual(ColorTranslator.FromHtml("#4c2600"), ColorTranslator.FromHtml("#ff8000").GetDimColor());
    }

    [TestMethod]
    public void TestToHex()
    {
        Assert.AreEqual("#000000", Color.Black.ToHex(false));
        Assert.AreEqual("#000000FF", Color.Black.ToHex(true));
        Assert.AreEqual("#FF0000", Color.Red.ToHex(false));
        Assert.AreEqual("#FF0000FF", Color.Red.ToHex(true));
        Assert.AreEqual("#00FF00", Color.Lime.ToHex(false));
        Assert.AreEqual("#00FF00FF", Color.Lime.ToHex(true));
    }
}
