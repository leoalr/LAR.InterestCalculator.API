using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAR.InterestCalculator.API.Response
{
    /// <summary>
    /// Base class for every API Response
    /// </summary>
    public abstract class ResponseBase
    {
        public ResponseBase()
        {
            ErrorMessages = new List<string>();
        }

        /// <summary>
        /// A boolean property representing the success of the operation
        /// </summary>
        public bool Success => ErrorMessages.Count() == 0;

        /// <summary>
        /// An array of string messages representing possible errors ocurred during the operation
        /// </summary>
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
