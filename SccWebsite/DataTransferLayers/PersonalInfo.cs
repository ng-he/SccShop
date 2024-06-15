using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DTO
{
    public class PersonalInfo
    {   
        DateTime _birthDay;

        public string AccountId { get; set; }   
        public string FullName { get; set; }
        public string BirthDay
        {
            get { return _birthDay.ToString("yyyy-MM-dd"); }
            set { _birthDay = DateTime.Parse(value); }
        }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }

        public PersonalInfo() { }

        public PersonalInfo(string AccountId, string FullName, string BirthDay, string PhoneNumber, string Gender)
        {
            this.AccountId = AccountId;
            this.FullName = FullName;
            this.BirthDay = BirthDay;
            this.PhoneNumber = PhoneNumber;
            this.Gender = Gender;
        }
    }
}
