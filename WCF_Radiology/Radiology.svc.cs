
namespace WCF_Radiology
{
    public class Radiology : IRadiology
    {
        RadiologyDetails[] radiologyDetails;
        public Radiology()
        {
            radiologyDetails = new RadiologyDetails[]{
               new RadiologyDetails(){PatientId=1,PatientRdiologyDetails="X-Ray Chest",RadiologyBill=4000},
               new RadiologyDetails(){PatientId=2,PatientRdiologyDetails="MRI-SCAN",RadiologyBill=7000},
               new RadiologyDetails(){PatientId=3,PatientRdiologyDetails="Fluoroscopy",RadiologyBill=3000},
               new RadiologyDetails(){PatientId=4,PatientRdiologyDetails="Ultrasound",RadiologyBill=6000},
               new RadiologyDetails(){PatientId=5,PatientRdiologyDetails="X-Ray Legs",RadiologyBill=3000},
            };
        }
        public RadiologyDetails[] GetDetails()
        {
            return radiologyDetails;
        }
    }
}
