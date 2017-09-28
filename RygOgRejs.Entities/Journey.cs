using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RygOgRejs.Entities.Enums;

namespace RygOgRejs.Entities
{
    /// <summary>
    /// Represents a journey
    /// </summary>
    public class Journey
    {
        /// <summary>
        /// The amount of adults
        /// </summary>
        protected int adults;
        /// <summary>
        /// The amount of children
        /// </summary>
        protected int children;
        /// <summary>
        /// The current price details
        /// </summary>
        protected PriceDetails currentPriceDetails;
        /// <summary>
        /// The destination
        /// </summary>
        protected Destination destination;
        /// <summary>
        /// The departure date
        /// </summary>
        protected DateTime departureDate;
        /// <summary>
        /// If it is first class
        /// </summary>
        protected bool isFirstClass;
        /// <summary>
        /// How much luggage in kg
        /// </summary>
        protected double luggageAmount;

        /// <summary>
        /// Initializes a new instance of the Journey class
        /// </summary>
        /// <param name="destination">The desired destination</param>
        /// <param name="departureDate">The departure date</param>
        /// <param name="isFirstClass">If it is first class</param>
        /// <param name="adults">The amount of adults</param>
        /// <param name="children">The amount of children</param>
        /// <param name="luggageAmount">The luggage amount in kg</param>
        public Journey(Destination destination, DateTime departureDate, bool isFirstClass, int adults, int children, double luggageAmount)
        {
            this.destination = destination;
            this.departureDate = departureDate;
            this.isFirstClass = isFirstClass;
            this.adults = adults;
            this.children = children;
            this.luggageAmount = luggageAmount;
        }

        /// <summary>
        /// Adds luggage
        /// </summary>
        /// <param name="amount">The amount of luggage in kg</param>
        public void AddLuggage(double amount)
        {

        }

        /// <summary>
        /// Removes luggage
        /// </summary>
        /// <param name="amount">The amount of luggage in kg to remove</param>
        public void RemoveLuggage(double amount)
        {

        }

        /// <summary>
        /// Adds persons to journey
        /// </summary>
        /// <param name="adults">How many adults to add</param>
        /// <param name="children">How many children to add</param>
        public void AddPersons(int adults, int children)
        {

        }

        /// <summary>
        /// Removes persons from journey
        /// </summary>
        /// <param name="adults">How many adults to remove</param>
        /// <param name="children">How many children to remove</param>
        public void RemovePersons(int adults, int children)
        {

        }

        /// <summary>
        /// Changes the destination
        /// </summary>
        /// <param name="newDestination">The new destination</param>
        public void ChangeDestinationTo(Destination newDestination)
        {
            
        }

        /// <summary>
        /// Gets the current total cost
        /// </summary>
        /// <returns>The current total cost</returns>
        public decimal GetCurrentTotal()
        {
            return 0;
        }
    }
}
