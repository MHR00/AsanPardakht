using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanPardakht.Entities.Users
{
    public class ResultUserLoginDto
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; } 
    }
}
