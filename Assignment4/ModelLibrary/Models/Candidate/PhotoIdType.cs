using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models.Candidate
{
    public enum PhotoIdTypeEnum
    {
        None,
        Passport,
        National,
        Millitary,
        DriversLicense
    }

    public class PhotoIdType
    {
        public int Id { get; set; }
        public PhotoIdTypeEnum IdType { get; set; }
    }
}
