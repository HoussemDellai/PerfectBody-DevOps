using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfectBody.ViewModels;

namespace PerfectBody.UnitTests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void IfWeight66_Height170_Return22()
        {
            // Arrange
            var vm = new MainViewModel
            {
                Height = 1.70,
                Weight = 66
            };

            // Act
            vm.CalculateImcCommand.Execute(null);
            double expectedImc = 22.84;
            var expectedCategory = "Normal weight";

            // Assert
            Assert.AreEqual(expectedImc, vm.Bmi, 0.1);
            Assert.AreEqual(expectedCategory, vm.Category);
        }

        [TestMethod]
        public void IfWeight134_Height174_Return44()
        {
            // Arrange
            var vm = new MainViewModel
            {
                Height = 1.74,
                Weight = 134
            };

            // Act
            vm.CalculateImcCommand.Execute(null);
            double expectedImc = 44.26;
            var expectedCategory = "Obesity";

            // Assert
            Assert.AreEqual(expectedImc, vm.Bmi, 0.1);
            Assert.AreEqual(expectedCategory, vm.Category);
        }
    }
}
