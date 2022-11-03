using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Reddit.Models.DAL;

namespace Reddit.Models.Entities
{
    public class Lien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public byte[]? image { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int? userid { get; set; }
        public DateTime? date { get; set; }

        public virtual IList<Vote>? votes   { get; set; }
        public virtual IList<Commentaire>? comments { get; set; }
        public virtual Utilisateur? User { get; set; }


        public override string ToString()
        {
            return $"id: {id} image: {image} title: {title} description: {description} userid: {userid}";
        }

        public string ConvertIMG()
        {
            return $"data:{"png"};base64,{Convert.ToBase64String(image)}";
        }

        public int getvotes()
        {
            int cpt = 0;
            foreach(Vote? v in votes)
            {
                if ((bool) v.upvote)
                {
                    cpt++;
                }
                else
                {
                    cpt--;
                }
            }
            return cpt;
        }

        public int voted(string username)
        {
            foreach(Vote v in votes)
            {
                if (v.User.username.Equals(username) && v.upvote == true)
                {
                    return 1;
                }
                if (v.User.username.Equals(username) && v.upvote == false)
                {
                    return 0;
                }
            }
            return -1;
        }

        public string getDate()
        {
            DateTime now = DateTime.Now;
            DateTime ComDate = (DateTime)date;
            string value;
            TimeSpan test = now - ComDate;
            if (test.Days > 365)
            {
                value = "Il y a " + (test.Days % 365).ToString() + " années";
                return value;
            }
            else
            {
                if (test.Days > 0)
                {
                    value = "Il y a " + (test.Days).ToString() + " jours";
                    return value;
                }
                else
                {
                    if (test.Hours > 0)
                    {
                        value = "Il y a " + (test.Hours).ToString() + " heures";
                        return value;
                    }
                    else
                    {
                        if (test.Minutes > 0)
                        {
                            value = "Il y a " + (test.Minutes).ToString() + " minutes";
                            return value;
                        }
                        else
                        {
                            if (test.Seconds >= 0)
                            {
                                value = "Il y a " + (test.Seconds).ToString() + " secondes";
                                return value;
                            }
                        }
                    }
                }
            }
            return "-1";
        }
    }
}
