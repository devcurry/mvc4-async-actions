using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF_Radiology
{
    [ServiceContract]
    public interface IRadiology
    {
        [OperationContract]
        [WebGet(UriTemplate="/Radiology",ResponseFormat=WebMessageFormat.Xml)]
        RadiologyDetails[] GetDetails();
    }
    [DataContract(Name = "RadiologyDetails", Namespace = "")]
    public class RadiologyDetails
    {
        [DataMember]
        public int PatientId { get; set; }
        [DataMember]
        public string PatientRdiologyDetails { get; set; }
        [DataMember]
        public int RadiologyBill { get; set; }
    }
}
