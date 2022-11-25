namespace SDETAPI_CSharp.Features.Unosquare.Models.OrdersPaged
{
    public class Column
    {
        public string aggregate { get; set; }
        public string dataType { get; set; }
        public string dateDisplayFormat { get; set; }
        public string dateOriginFormat { get; set; }
        public string dateTimeDisplayFormat { get; set; }
        public string dateTimeOriginFormat { get; set; }
        public bool isKey { get; set; }
        public bool isComputed { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public string sortDirection { get; set; }
        public int sortOrder { get; set; }
        public bool sortable { get; set; }
        public bool visible { get; set; }
        public bool filterable { get; set; }
        public bool exportable { get; set; }
    }
}
