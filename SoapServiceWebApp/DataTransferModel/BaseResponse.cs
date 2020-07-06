using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{   
    [DataContract]
    public class BaseResponse
    {

        [DataMember]
        public String Messagge { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public bool IsError { get; set; }


    }
}