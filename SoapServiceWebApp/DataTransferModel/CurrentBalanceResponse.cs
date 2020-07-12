using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]
    public class CurrentBalanceBaseResponse : BaseResponse
    {
        [DataMember]
        public decimal balance { get; set; }

    }
}