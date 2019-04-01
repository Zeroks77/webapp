using Microsoft.AspNetCore.Identity;

namespace firstwebapp.Models
{
    public class Votes
    {
        public int ID { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}