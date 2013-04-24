using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF_Pathology
{
    [ServiceContract]
    public interface IPathology
    {
        [OperationContract]
        [WebGet(UriTemplate="/Pathology",ResponseFormat=WebMessageFormat.Xml)]
        PathologyDetils [] GetDetails();
    }
    [DataContract(Name="PathologyDetils",Namespace="")]
    public class PathologyDetils
    {
        [DataMember]
        public int PatientId { get; set; }
        [DataMember]
        public string PathologyDetails { get; set; }
        [DataMember]
        public int PathologyBill { get; set; }
    }
}
