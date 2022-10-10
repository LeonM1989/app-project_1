using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api.Entities
{
    public class AppUser
    {
        public int Id {get; set;}
        public string UserName {get; set;}

        public byte[] PasswordHash{get; set;}
        public byte[] PasswordSalt{get; set;}




          public DateTime DateOfBirth{get; set;}
          public string KnownAs {get; set;}
          public  DateTime created {get; set;} = DateTime.Now; // initial value

          public  DateTime LastActive {get; set;}



          public string Gender {get; set;}

          public string Introduction {get; set;}
          public string LokingFor {get; set;}
          public string Interests {get; set;}

          public string City {get; set;}
          public string Country {get; set;}

          public ICollection<Photo> Photos{get; set;}

          // public int GetAge()
          // {
          //   return DateOfBirth.CalculateAge();
          // }
    }
}