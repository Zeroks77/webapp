using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstwebapp.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [Display(Name = "Fragensteller")]
        public string Submitter { get; set; }
        [RegularExpression(@"^[a-zA-Z\Ä\Ö\Ü]+[a-zA-Zß\d""'\s-]+[?]*$")]
        [Required]
        [Display(Name = "Frage")]
        public string dumbQuestion { get; set; }
        [Display(Name = "Facepalms")]
        public virtual IEnumerable<Votes> Vote { get; set; }
    }
}