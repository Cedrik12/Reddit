using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reddit.Models.Entities
{
    public class Commentaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? text { get; set; }
        public int? userid { get; set; }
        public int? lienid { get; set; }
        public DateTime? date { get; set; }

        public virtual Utilisateur? User { get; set; }

        public override string ToString()
        {
            return $"id: {id} text: {text} userid: {userid} lienid: {lienid}";
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
