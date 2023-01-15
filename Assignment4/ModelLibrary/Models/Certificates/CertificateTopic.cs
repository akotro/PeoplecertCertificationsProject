using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models.Certificates
{
    public class CertificateTopic
    {
        public int CertificateId { get; set; }
        public virtual Certificate? Certificate { get; set; }  
        public int TopicId { get; set; }
        public virtual Topic? Topic{ get; set; }

    }
}
