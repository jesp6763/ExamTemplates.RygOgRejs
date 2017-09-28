using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Entities
{
    public class Payer : IPersistable
    {
        /// <summary>
        /// The payer's firstname
        /// </summary>
        protected string firstname;
        /// <summary>
        /// The payer's lastname
        /// </summary>
        protected string lastname;
        /// <summary>
        /// The payer's social security number
        /// </summary>
        protected string ssn;

        /// <summary>
        /// Initializes a new instance of the Payer class
        /// </summary>
        /// <param name="firstname">The payer's firstname</param>
        /// <param name="lastname">The payer's lastname</param>
        /// <param name="ssn">The payer's social security number</param>
        public Payer(string firstname, string lastname, string ssn)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.ssn = ssn;
        }

        public int Id { get; }
    }
}
