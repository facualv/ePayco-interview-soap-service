using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using DataModelLayer;
using DataModelLayer.Models;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]
    public class ClientServiceResponse : BaseResponse
    {
        [DataMember]
        public Client[] Clients { get; set; }
    }
}