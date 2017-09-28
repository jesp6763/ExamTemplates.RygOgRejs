using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RygOgRejs.Entities;

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
            return new List<Journey>();
        }

        /// <summary>
        /// Get a journey by full name
        /// </summary>
        /// <param name="payerFullName">The payer's fullname</param>
        /// <returns>A journey</returns>
        public Journey GetJourneyBy(string payerFullName)
        {
            return null;
        }
    }
}
