using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reddit.Models.Entities
{
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }

        public override string ToString()
        {
            return $"id: {id} username: {username} email: {email} password: {password}";
        }
    }
}
