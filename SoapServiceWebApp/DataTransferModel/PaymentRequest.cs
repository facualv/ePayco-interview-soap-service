using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]
    public class PaymentRequest
    {
        [DataMember]
        public string WalletId { get; set; }
        [DataMember]
        public decimal Ammount { get; set; }
        [DataMember]
        public string Detail { get; set; }

    }
}