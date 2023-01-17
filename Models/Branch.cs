using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace aspcoremariadb.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Microsoft.Build.Framework.Required]
        public string branch_name { get; set; }
        [Microsoft.Build.Framework.Required]
        public DateTime created_at { get; set;}
        public DateTime? updated_at { get; set;}
    }
}
