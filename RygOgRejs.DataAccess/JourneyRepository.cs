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
                DataRow row = journeys.Tables[0].Rows[i];
                journeyList.Add(new Journey(row.Field<Destination>("Destination"), row.Field<DateTime>("DepartureTime"), row.Field<bool>("IsFirstClass"), row.Field<int>("Adults"), row.Field<int>("Children"), row.Field<double>("LuggageAmount")));
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
            DataSet dataSet = executor.Execute($"SELECT * FROM dbo.Payers WHERE Firstname + ' ' + Lastname LIKE '{payerFullName}%'");
            DataRow row = dataSet.Tables[0].Rows[0];
            return new Journey(row.Field<Destination>("Destination"), row.Field<DateTime>("DepartureTime"), row.Field<bool>("IsFirstClass"), row.Field<int>("Adults"), row.Field<int>("Children"), row.Field<double>("LuggageAmount"));
        }
    }
}
