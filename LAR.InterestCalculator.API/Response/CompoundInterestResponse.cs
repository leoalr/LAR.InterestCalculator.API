using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAR.InterestCalculator.API.Response
{
    /// <summary>
    /// Class to represent the response of the Compound Interest API call
    /// </summary>
    public class CompoundInterestResponse : ResponseBase
    {
        /// <summary>
        /// The expected result object of the operation
        /// </summary>
        public decimal Result { get; set; }
    }
}
