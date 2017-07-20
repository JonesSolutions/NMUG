using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMUG.Models
{
    [NotMapped]
    [DataContract]
    public class TwitterAuthAPI
    {

        public int ID { get; set; }
        [DataMember]
        public string ConsumerKey { get; set; }
        [DataMember]
        public string ConsumerSecret { get; set; }
        [DataMember]
        public string AccessToken { get; set; }
        [DataMember]
        public string AccessTokenSecret { get; set; }
        [DataMember]
        public string BaseURL { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string OwnerID { get; set; }
    }
}
