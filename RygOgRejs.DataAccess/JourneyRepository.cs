using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RygOgRejs.Entities;
using RygOgRejs.Entities.Enums;

namespace RygOgRejs.DataAccess
{
    /// <summary>
    /// Represents a journey repository
    /// </summary>
    public class JourneyRepository : DataRepository
    {
        /// <summary>
        /// Gets all journeys
        /// </summary>
        /// <returns>A list of journeys</returns>
        public List<Journey> GetAll()
        {
            DataSet journeys = executor.Execute("SELECT * FROM dbo.Journeys");
            List<Journey> journeyList = new List<Journey>();
            for(int i = 0; i < journeys.Tables[0].Rows.Count; i++)
            {
                object[] journeyData = ExtractRow(journeys.Tables[0].Rows[i]);

                Journey journey = new Journey((int)journeyData[0], (Destination)journeyData[1], (DateTime)journeyData[2], (bool)journeyData[3], (int)journeyData[4], (int)journeyData[5], (double)journeyData[6]);
                journeyList.Add(journey);
            }

            return journeyList;
        }

        /// <summary>
        /// Get a journey by full name
        /// </summary>
        /// <param name="payerFullName">The payer's fullname</param>
        /// <returns>A journey</returns>
        public Journey GetJourneyBy(string payerFullName)
        {
            DataSet dataSet = executor.Execute($"SELECT JourneyId FROM dbo.Payers WHERE Firstname + ' ' + Lastname LIKE '{payerFullName}%'");
            DataRow row = dataSet.Tables[0].Rows[0];
            object[] journeyData = ExtractRow(executor.Execute($"SELECT * FROM dbo.Journeys WHERE JourneyId={row.Field<string>("JourneyId")}").Tables[0].Rows[0]);

            return new Journey((int)journeyData[0], (Destination)journeyData[1], (DateTime)journeyData[2], (bool)journeyData[3], (int)journeyData[4], (int)journeyData[4], (double)journeyData[5]);
        }

        public void Save(Journey journey)
        {
            executor.Execute($"INSERT INTO dbo.Journeys (Destination, DepartureTime, IsFirstClass, Adults, Children, LuggageAmount) VALUES('{journey.Destination.ToString()}', CAST('{journey.DepartureDate.Year}-{journey.DepartureDate.Month}-{journey.DepartureDate.Day}' AS DATETIME), {(journey.IsFirstClass ? 1 : 0)}, {journey.Adults}, {journey.Children}, {journey.LuggageAmount})");
        }

        /// <summary>
        /// Extracts the row data
        /// </summary>
        /// <param name="row">The row to extract</param>
        /// <returns>An array of extracted data</returns>
        protected object[] ExtractRow(DataRow row)
        {
            int id = row.Field<int>("JourneyId");
            Destination destination = Destination.Billund;
            DateTime departureTime = row.Field<DateTime>("DepartureTime");
            bool isFirstClass = row.Field<bool>("IsFirstClass");
            int adults = row.Field<int>("Adults"), children = row.Field<int>("Children");
            double luggageAmount = (double)row.Field<decimal>("LuggageAmount");

            switch(row.Field<string>("Destination"))
            {
                case "Copenhagen":
                    destination = Destination.Copenhagen;
                    break;
                case "PalmaDeMallorca":
                    destination = Destination.PalmaDeMallorca;
                    break;
            }

            return new object[7] { id, destination, departureTime, isFirstClass, adults, children, luggageAmount };
        }
    }
}
