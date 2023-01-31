using ModelLibrary.Models.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models.DTO.Candidates
{
    public class PhotoIdTypeDto
    {
        public int Id { get; set; }
        public PhotoIdTypeEnum? IdType { get; set; }
    }
}
