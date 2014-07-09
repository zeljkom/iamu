using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba {    
    [DataContract]
    public class MojaKlasa {
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public PodKlasa Data { get; set; } 

        [DataContract]
        public class PodKlasa {
            [DataMember]
            public int MyProperty { get; set; }

        }
    }
}
