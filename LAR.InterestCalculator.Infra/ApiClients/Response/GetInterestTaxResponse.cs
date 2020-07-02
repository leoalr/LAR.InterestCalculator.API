using System;
using System.Collections.Generic;
using System.Text;

namespace LAR.InterestCalculator.Infra.ApiClients.Response
{
    public class GetInterestTaxResponse : ApiResponseBase
    {
        public decimal InterestTax { get; set; }
    }
}
