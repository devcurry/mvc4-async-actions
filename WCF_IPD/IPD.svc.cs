
namespace WCF_IPD
{
    public class IPD : IIPD
    {
        IPDDetails[] ipdDetails;
        public IPD()
        {
            ipdDetails = new IPDDetails[]{
             new IPDDetails() {PatientId=1,IPDCheckDetails="B.P. Check",IPDBill=200},
             new IPDDetails() {PatientId=2,IPDCheckDetails="Tempreture Check",IPDBill=300},
             new IPDDetails() {PatientId=3,IPDCheckDetails="Injection",IPDBill=130},
             new IPDDetails() {PatientId=4,IPDCheckDetails="General Checkup",IPDBill=400},
             new IPDDetails() {PatientId=5,IPDCheckDetails="Saline",IPDBill=200}
            };
        }
        public IPDDetails[] GetDetails()
        {
            return ipdDetails;
        }
    }
}
