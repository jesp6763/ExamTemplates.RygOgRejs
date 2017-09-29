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
        public void CorrectPriceCalculationWithoutTax1()
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
        public void CorrectPriceCalculationWithTax1()
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

        [TestMethod]
        public void CorrectPriceCalculationWithoutTax2()
        {
            // Arrange
            decimal expected = 10150m;
            decimal actual;
            PriceDetails priceDetails = new PriceDetails(Destination.Copenhagen, 4, 0, false, 13);

            // Act
            actual = priceDetails.GetTotalWithoutTax();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectPriceCalculationWithTax2()
        {
            // Arrange
            decimal expected = 12687.5m;
            decimal actual;
            PriceDetails priceDetails = new PriceDetails(Destination.Copenhagen, 4, 0, false, 13);

            // Act
            actual = priceDetails.GetTotalWithTax();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
