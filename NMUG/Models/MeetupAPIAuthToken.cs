using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMUG.Models
{
    [NotMapped]
    [DataContract]
    public class MeetupAPIAuthToken
    {
        // must match appsettings.json config
        [DataMember]
        public string MeetupAPIKey { get; set; }
        [DataMember]
        public string MeetupBaseURL { get; set; }
        [DataMember]
        public string MeetupGroup { get; set; }
        [DataMember]
        public string MeetupGroupTEST { get; set; }
    }
}
