using System;
using RygOgRejs.Entities;
using RygOgRejs.Entities.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RygOgRejs.Test
{
    [TestClass]
    public class PriceDetailsTests
    {
        /// <summary>
        /// Tests if the calculation without tax is correct
        /// </summary>
        [TestMethod]
        public void CorrectPriceCalculationWithoutTax()
        {
            // Arrange
            decimal expected = 2784m;
            decimal actual;
            PriceDetails priceDetails = new PriceDetails(Destination.Billund, 2, 1, true, 0);

            // Act
            actual = priceDetails.GetTotalWithoutTax();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests if the calculation with tax is correct
        /// </summary>
        [TestMethod]
        public void CorrectPriceCalculationWithTax()
        {
            // Arrange
            decimal expected = 3480m;
            decimal actual;
            PriceDetails priceDetails = new PriceDetails(Destination.Billund, 2, 1, true, 0);

            // Act
            actual = priceDetails.GetTotalWithTax();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
