using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]
    public class SignInResponse: BaseResponse
    {
        [DataMember]
        public Client client { get; set; }
    }
}