using System.Drawing;
using CalendarView.Core.Models;

namespace CalendarView.Core.Tests.Models;

[TestClass]
public class CalendarTests
{
    [TestMethod]
    public void TestColor()
    {
        var calendar = new Calendar
        {
            Name = "test",
            Color = Color.Magenta
        };

        Assert.AreEqual(Color.Magenta, calendar.Color);
    }

    [TestMethod]
    public void TestName()
    {
        var calendar = new Calendar
        {
            Name = "test",
            Color = Color.Magenta
        };

        Assert.AreEqual("test", calendar.Name);
    }
}
