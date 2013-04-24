using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC40_Medical_App.Models
{
    public class RadiologyDetails
    {
        public int PatientId { get; set; }
        public string PatientRdiologyDetails { get; set; }
        public int RadiologyBill { get; set; }
    }
    public class PathologyDetils
    {
        public int PatientId { get; set; }
        public string PathologyDetails { get; set; }
        public int PathologyBill { get; set; }
    }
    public class IPDDetails
    {
        public int PatientId { get; set; }
        public string IPDCheckDetails { get; set; }
        public int IPDBill { get; set; }
    }
}   