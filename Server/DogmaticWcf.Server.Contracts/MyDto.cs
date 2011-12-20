using System.Runtime.Serialization;

namespace DogmaticWcf.Server.Contracts
{
    [DataContract]
    public class MyDto
    {
        [DataMember]
        public string MyProperty { get; set; }
    }
}