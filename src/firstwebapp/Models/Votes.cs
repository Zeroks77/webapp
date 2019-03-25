using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstwebapp.Models
{
    public class Votes
    {
        public class Votes
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            public string UserId { get; set; }
            public virtual IdentityUser User { get; set; }
            public int QuestionId { get; set; }
            public virtual Question Question { get; set; }
        }
    }
}