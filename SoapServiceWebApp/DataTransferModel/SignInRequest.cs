using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceWebApp.DataTransferModel
{
    [DataContract]

    public class SignInRequest
    {
            [DataMember]
            public string ClientId { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public string Phone { get; set; }

            [DataMember]
            public string Email { get; set; }

            [DataMember]
            public string Password { get; set; }
        }
  
}