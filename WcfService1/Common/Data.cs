using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    
    [KnownType(typeof(B))]
    [KnownType(typeof(A))]
    [DataContract(Name = "IObject")]
    public class IObject
    {
    }

    [DataContract(Name="A")]
    public class A : IObject
    {
        [DataMember]
        public string s1 { get; set; } 

    }

    [DataContract(Name="B")]
    public class B : IObject
    {
        [DataMember]
        public string s2 { get; set; }         

    }
}
