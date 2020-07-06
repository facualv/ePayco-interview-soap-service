using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    public class CurrentBalanceRequest
    {
        [DataMember]
        public String ClientId { get; set; }

        [DataMember]
        public String Phone { get; set; }

    }
}