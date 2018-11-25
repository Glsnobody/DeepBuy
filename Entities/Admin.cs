using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Admin()
        {
            AdminId = 0;
            Username = string.Empty;
            Password = string.Empty;
        }

        public Admin(int adminId, string username, string password)
        {
            AdminId = adminId;
            Username = username;
            Password = password;
        }
    }
}
