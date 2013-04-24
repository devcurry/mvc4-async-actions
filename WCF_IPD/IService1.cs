using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF_IPD
{
    [ServiceContract]
    public interface IIPD
    {
        [OperationContract]
        [WebGet(UriTemplate="/IPD",ResponseFormat=WebMessageFormat.Xml)]
        IPDDetails[] GetDetails();
    }
    [DataContract(Name = "IPDDetails",Namespace="")]
    public class IPDDetails
    {
        [DataMember]
        public int PatientId { get; set; }
        [DataMember]
        public string IPDCheckDetails { get; set; }
        [DataMember]
        public int IPDBill { get; set; }
    }
}
