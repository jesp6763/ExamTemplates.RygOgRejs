using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
