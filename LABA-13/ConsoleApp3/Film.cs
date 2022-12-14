using System;
using System.Runtime.Serialization;

namespace LABA13
{
    [DataContract]
    [Serializable]
    public class Film
    {
        [DataMember]
        public string Name { get; set; }
        public string Country { get; set; }
        public double Budget { get; set; }

        public override string ToString()
        {
            return $"Фильм {Name}";
        }
    }
}