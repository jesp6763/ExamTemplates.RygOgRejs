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
    public class Journey : IPersistable
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
            RefreshPriceDetails();
        }

        /// <summary>
        /// Initializes a new instance of the Journey class
        /// </summary>
        /// <param name="destination">The desired destination</param>
        /// <param name="departureDate">The departure date</param>
        /// <param name="isFirstClass">If it is first class</param>
        /// <param name="adults">The amount of adults</param>
        /// <param name="children">The amount of children</param>
        /// <param name="luggageAmount">The luggage amount in kg</param>
        public Journey(int id, Destination destination, DateTime departureDate, bool isFirstClass, int adults, int children, double luggageAmount)
        {
            Id = id;
            this.destination = destination;
            this.departureDate = departureDate;
            this.isFirstClass = isFirstClass;
            this.adults = adults;
            this.children = children;
            this.luggageAmount = luggageAmount;
            RefreshPriceDetails();
        }

        /// <summary>
        /// Gets the id
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Gets or sets adults
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set the value below 0</exception>
        public int Adults
        {
            get => adults;
            private set
            {
                if(value >= 0)
                {
                    adults = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int Children => children;

        public Destination Destination => destination;
        public DateTime DepartureDate => departureDate;
        public bool IsFirstClass => isFirstClass;
        public double LuggageAmount => luggageAmount;

        /// <summary>
        /// Adds luggage
        /// </summary>
        /// <param name="amount">The amount of luggage in kg</param>
        public void AddLuggage(double amount)
        {
            luggageAmount += amount;
            RefreshPriceDetails();
        }

        /// <summary>
        /// Removes luggage
        /// </summary>
        /// <param name="amount">The amount of luggage in kg to remove</param>
        public void RemoveLuggage(double amount)
        {
            luggageAmount -= amount;
            RefreshPriceDetails();
        }

        /// <summary>
        /// Adds persons to journey
        /// </summary>
        /// <param name="adults">How many adults to add</param>
        /// <param name="children">How many children to add</param>
        public void AddPersons(int adults, int children)
        {
            this.adults += adults;
            this.children += children;
            RefreshPriceDetails();
        }

        /// <summary>
        /// Removes persons from journey
        /// </summary>
        /// <param name="adults">How many adults to remove</param>
        /// <param name="children">How many children to remove</param>
        public void RemovePersons(int adults, int children)
        {
            this.adults -= adults;
            this.children -= children;
            RefreshPriceDetails();
        }

        /// <summary>
        /// Changes the destination
        /// </summary>
        /// <param name="newDestination">The new destination</param>
        public void ChangeDestinationTo(Destination newDestination)
        {
            destination = newDestination;
            RefreshPriceDetails();
        }

        /// <summary>
        /// Gets the current total cost
        /// </summary>
        /// <returns>The current total cost</returns>
        public decimal GetCurrentTotal()
        {
            return currentPriceDetails.GetTotalWithTax();
        }

        private void RefreshPriceDetails()
        {
            double extraLuggage = luggageAmount > 25 ? luggageAmount : 0;
            currentPriceDetails = new PriceDetails(destination, adults, children, isFirstClass, extraLuggage);
        }

        public static Destination GetDestinationFromText(string destination)
        {
            switch(destination.Replace(" ", string.Empty))
            {
                case "Billund":
                    return Destination.Billund;
                case "Copenhagen":
                    return Destination.Copenhagen;
                case "PalmaDeMallorca":
                    return Destination.PalmaDeMallorca;
            }

            return Destination.Billund;
        }
    }
}
