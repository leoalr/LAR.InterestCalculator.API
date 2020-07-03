using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAR.InterestCalculator.API.Response
{
    /// <summary>
    /// Base class for every API Response
    /// </summary>
    public class ResponseBase : IActionResult
    {
        public ResponseBase(
            int statusCode = default
        )
        {
            StatusCode = statusCode;
            ErrorMessages = new List<string>();
        }

        public ResponseBase(
            int statusCode,
            string errorMessage
        )
        {
            StatusCode = statusCode;
            ErrorMessages = new List<string>()
            {
                errorMessage
            };
        }

        public ResponseBase(
            int statusCode,
            List<string> errorMessages
        )
        {
            StatusCode = statusCode;
            ErrorMessages = errorMessages;
        }

        /// <summary>
        /// A boolean property representing the success of the operation
        /// </summary>
        public bool Success => ErrorMessages.Count() == 0;

        /// <summary>
        /// An array of string messages representing possible errors ocurred during the operation
        /// </summary>
        public IEnumerable<string> ErrorMessages { get; set; }

        /// <summary>
        /// The Status Code of the Http Response
        /// </summary>
        private int StatusCode { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(this);

            if (StatusCode != default)
            {
                objectResult.StatusCode = StatusCode;
            }

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
