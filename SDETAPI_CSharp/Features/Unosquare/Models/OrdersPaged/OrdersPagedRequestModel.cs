using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.Unosquare.Models.OrdersPaged
{
    public class OrdersPagedRequestModel
    {
        public List<Column> columns { get; set; }
        public string searchText { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public int counter { get; set; }
        public int timezoneOffset { get; set; }
    }

}
