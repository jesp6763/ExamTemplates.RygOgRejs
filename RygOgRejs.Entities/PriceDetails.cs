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
        private decimal taxRate;
        private decimal totalPrice;

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
            taxRate = 1.25m;

            decimal childDestinationPrice = 0;
            decimal adultDestinationPrice = 0;
            double extraLuggagePrice = 290;

            switch(destination){
                case Destination.Billund:
                    adultDestinationPrice = 395;
                    childDestinationPrice = 295;
                    break;
                case Destination.Copenhagen:
                    adultDestinationPrice = 1595;
                    childDestinationPrice = 1395;
                    break;
                case Destination.PalmaDeMallorca:
                    adultDestinationPrice = 4995;
                    childDestinationPrice = 3099;
                    break;
            }

            totalPrice = childDestinationPrice + adultDestinationPrice + (decimal)(extraLuggagePrice * extraLuggage);
            if(isFirstClass)
            {
                totalPrice += 1699;
            }
        }

        public decimal GetTaxAmount()
        {
            return GetTotalWithTax() - GetTotalWithoutTax();
        }

        public decimal GetTotalWithoutTax()
        {
            return totalPrice;
        }

        public decimal GetTotalWithTax()
        {
            return totalPrice * GetTaxAmount();
        }
    }
}
