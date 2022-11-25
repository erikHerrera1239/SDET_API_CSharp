using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.NasaOpenAPI.Models.TechTransfer
{
    public class TechTransferResponseModel
    {
        public List<List<object>> results { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public int perpage { get; set; }
        public int page { get; set; }
    }

}
