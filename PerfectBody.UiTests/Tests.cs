using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace PerfectBody.UiTests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        [Category("UI Tests")]
        public void Weight66_Height170_Return22()
        {
            // Arrange
            app.EnterText("EntryHeight", "66");
            app.EnterText("EntryWeight", "1.70");

            var labelBmi = app.Query("LabelBmi").FirstOrDefault();
            var labelBmiCategory = app.Query("LabelBmiCategory").FirstOrDefault();

            double expectedImc = 22.84;
            var expectedCategory = "Normal weight";

            // Act
            app.Tap("ButtonCalculateBmi");

            // Assert
            Assert.AreEqual(expectedImc, Convert.ToDouble(labelBmi?.Text), 0.1);
            Assert.AreEqual(expectedCategory, labelBmiCategory?.Text);
        }
    }
}

