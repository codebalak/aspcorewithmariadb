using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aspcoremariadb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }


    }
}
