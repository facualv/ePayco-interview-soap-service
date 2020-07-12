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
        public String message { get; set; }

        [DataMember]
        public int status { get; set; }

        [DataMember]
        public bool error { get; set; }


    }
}