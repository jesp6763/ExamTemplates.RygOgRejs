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

                Journey journey = new Journey((Destination)journeyData[0], (DateTime)journeyData[1], (bool)journeyData[2], (int)journeyData[3], (int)journeyData[4], (double)journeyData[5]);
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

            return new Journey((Destination)journeyData[0], (DateTime)journeyData[1], (bool)journeyData[2], (int)journeyData[3], (int)journeyData[4], (double)journeyData[5]);
        }

        /// <summary>
        /// Extracts the row data
        /// </summary>
        /// <param name="row">The row to extract</param>
        /// <returns>An array of extracted data</returns>
        protected object[] ExtractRow(DataRow row)
        {
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

            return new object[6] { destination, departureTime, isFirstClass, adults, children, luggageAmount };
        }
    }
}
