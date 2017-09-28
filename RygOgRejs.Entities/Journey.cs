using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RygOgRejs.Entities.Enums;

namespace RygOgRejs.Entities
{
    public class Journey
    {
        protected int adults;
        protected int children;
        protected PriceDetails currentPriceDetails;
        protected DateTime departureDate;
        protected bool isFirstClass;
        protected double luggageAmount;

        public Journey(Destination destination, DateTime departureDate, bool isFirstClass, int adults, int children, double luggageAmount)
        {

        }

        public void AddLuggage(double amount)
        {

        }

        public void RemoveLuggage(double amount)
        {

        }

        public void AddPersons(int adults)
        {

        }

        public void RemovePersons(int adults, int children)
        {

        }

        public void ChangeDestinationTo(Destination newDestination)
        {

        }

        public decimal GetCurrentTotal()
        {
            return 0;
        }
    }
}
