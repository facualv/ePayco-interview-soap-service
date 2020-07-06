using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]
    public class CurrentBalanceResponse : BaseResponse
    {
        [DataMember]
        public decimal CurrentBalance { get; set; }
    }
}