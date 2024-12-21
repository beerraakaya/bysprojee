using System.ComponentModel.DataAnnotations;

namespace bysprojee.Model
{
    public class Login
    {
        public int Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } 

    }
}


