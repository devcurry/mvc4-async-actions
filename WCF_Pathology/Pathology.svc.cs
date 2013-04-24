using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Pathology
{
    public class Pathology : IPathology
    {
        PathologyDetils[] pathologyDetails;
        public Pathology()
        {
            pathologyDetails = new PathologyDetils[]{
              new PathologyDetils() {PatientId=1,PathologyDetails="Cholestrol",PathologyBill=2000},
              new PathologyDetils() {PatientId=2,PathologyDetails="Sugar",PathologyBill=1500},
              new PathologyDetils() {PatientId=3,PathologyDetails="TB",PathologyBill=4000},
              new PathologyDetils() {PatientId=4,PathologyDetails="Maleria",PathologyBill=1000},
              new PathologyDetils() {PatientId=5,PathologyDetails="Swine Flue",PathologyBill=2500}
            };
        }
        public PathologyDetils[] GetDetails()
        {
            return pathologyDetails;
        }
    }
}
