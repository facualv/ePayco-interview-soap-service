using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]
    public class RechargeRequest
    {
        [DataMember]
        public string ClientId { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public decimal Ammount { get; set; }

        [DataMember]
        public string Details { get; set; }

    }
}