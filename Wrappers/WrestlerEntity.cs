using System;
using System.Runtime.Serialization;

namespace Wrappers
{
    [DataContract]
    public class WrestlerEntity
    {
        [DataMember(Name = "id_wrestler")]
        public int ID { get; set; }

        [DataMember(Name = "lname")]
        public string LastName { get; set; }

        [DataMember(Name = "fname")]
        public string FirstName { get; set; }

        [DataMember(Name = "mname")]
        public string MiddleName { get; set; }

        [DataMember(Name = "dob")]
        public string DateOfBirth { get; set; }

        public string Region1name { get; set; }

        [DataMember(Name = "region1")]
        public int Region1id { get; set; }

        public string Region2name { get; set; }

        [DataMember(Name = "region2")]
        public int Region2id { get; set; }

        public string Fst1name { get; set; }

        [DataMember(Name = "fst1")]
        public int Fst1id { get; set; }

        public string Fst2name { get; set; }

        [DataMember(Name = "fst2")]
        public int Fst2id { get; set; }

        [DataMember(Name = "trainer1")]
        public string Trainer1name { get; set; }

        [DataMember(Name = "trainerid1")]
        public int Trainer1id { get; set; }

        [DataMember(Name = "trainer2")]
        public string Trainer2name { get; set; }

        [DataMember(Name = "trainerid2")]
        public int Trainer2id { get; set; }

        [DataMember(Name = "expires")]
        public int Year { get; set; }

        public string CardName { get; set; }

        [DataMember(Name = "card_state")]
        public int CardId { get; set; }

        [DataMember(Name = "stname")]
        public string StyleName { get; set; }

        [DataMember(Name = "style")]
        public int StyleId { get; set; }

        public string AgeName { get; set; }

        [DataMember(Name = "lictype")]
        public int AgeId { get; set; }

        public string FIO
        {
            get { return String.Format("{0} {1} {2}", LastName, FirstName, MiddleName); }
        }
    }
}