using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Entities
{
    public class Transaction
    {
        /// <summary>
        /// The paid amount
        /// </summary>
        private decimal amount;
        /// <summary>
        /// The journey
        /// </summary>
        private Journey journey;
        /// <summary>
        /// The payer
        /// </summary>
        private Payer payer;
        /// <summary>
        /// The timestamp of the transaction
        /// </summary>
        private DateTime timeStamp;

        /// <summary>
        /// Initializes a new instance of the Transaction class
        /// </summary>
        /// <param name="amount">The paid amount</param>
        /// <param name="jouney">The journey</param>
        /// <param name="payer">The payer</param>
        public Transaction(decimal amount, Journey journey, Payer payer)
        {
            this.amount = amount;
            this.journey = journey;
            this.payer = payer;
        }
    }
}
