using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Entities
{
    public interface IPersistable
    {
        /// <summary>
        /// ID of the entity
        /// </summary>
        int Id { get; }
    }
}
