using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RygOgRejs.Entities.Enums;

namespace RygOgRejs.Entities
{
    public struct PriceDetails
    {
        //private double taxRate;

        /// <summary>
        /// Initializes a new instance of the PriceDetails class
        /// </summary>
        /// <param name="destination">The desired destination</param>
        /// <param name="adults">How many adults</param>
        /// <param name="children">How many children</param>
        /// <param name="isFirstClass">Is it first class</param>
        /// <param name="extraLuggage">Extra luggage more than 25kg</param>
        public PriceDetails(Destination destination, int adults, int children, bool isFirstClass, double extraLuggage)
        {
            
        }

        public decimal GetTaxAmount()
        {
            return 0;
        }

        public decimal GetTotalWithoutTax()
        {
            return 0;
        }

        public decimal GetTotalWithTax()
        {
            return 0;
        }
    }
}
