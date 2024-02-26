using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meals
{
    [TestClass]
    public class PriceCheck
    {
        [TestMethod]
        public void TenCharsOrLess()
        {
            //Arrange
            Meal testMeal = new Meal();
            string entree = "1234567890";//10 chars
            testMeal.Entree = entree;
            double testMealEntreeLength = testMeal.Entree.Length;
            double expected = 12.00;

            //Act
            double actual = testMeal.PayForMeal(testMealEntreeLength);

            //Assert
            Assert.AreEqual(expected, actual, "Values should have been equal but weren't. Expected: {0}, but got: {1}", expected, actual);
        }

        [TestMethod]
        public void MoreThanTenChars()
        {
            //Arrange
            Meal testMeal = new Meal();
            string entree = "12345678901";//11 chars
            testMeal.Entree = entree;
            double testMealEntreeLength = testMeal.Entree.Length;
            double expected = 11.00;

            //Act
            double actual = testMeal.PayForMeal(testMealEntreeLength);

            //Assert
            Assert.AreEqual(expected, actual, "Values should have been equal but weren't. Expected: {0}, but got: {1}", expected, actual);
        }
    }
}