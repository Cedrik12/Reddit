using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reddit.Models.Entities
{
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public bool? upvote { get; set; }
        public int? userid { get; set; }
        public int? lienid { get; set; }

        public virtual Utilisateur? User { get; set; }

        public override string ToString()
        {
            return $"id: {id} upvote: {upvote} userid: {userid} lienid: {lienid}";
        }
    }
}
