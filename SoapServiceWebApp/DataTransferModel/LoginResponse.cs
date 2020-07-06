using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]
    public class LoginResponse: BaseResponse
    {
        [DataMember]
        public Client Client { get; set; }
    }
}