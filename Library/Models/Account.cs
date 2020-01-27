using System.Collections.Generic;

namespace Library.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Character> Characters { get; set; }
        public Account()
        {

        }
        public Account(string Username, string Password, string Email)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
        }
    }
}
