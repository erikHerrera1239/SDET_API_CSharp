using SDETAPI_CSharp.Features.Unosquare.Models.OrdersPaged;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.Unosquare.Posts.Unosquare.OrdersPaged
{
    public class OrdersPagedResponseModel
    {
        public int Counter { get; set; }
        public object[][] Payload { get; set; }
        public int TotalRecordCount { get; set; }
        public int FilteredRecordCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public Aggregationpayload AggregationPayload { get; set; }
    }
}
