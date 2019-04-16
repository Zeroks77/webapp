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
        [StringLength(30, ErrorMessage =
         "Der erste Buchstabe muss ein Großbuchstabe sein."
        , MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zäöüA-ZÄÖÜß""'\s-]*$")]
        [Required]
        [Display(Name = "Fragensteller")]
        public string Submitter { get; set; }
        [StringLength(1000, ErrorMessage = 
            "Der erste Buchstabe muss ein Großbuchstabe sein."
            ,MinimumLength = 3)]
        [RegularExpression(@"^[a-zäöüA-ZÄÖÜ]+[a-zäöüA-ZÄÖÜß\d""'\s-]+[?]*$")]
        [Required]
        [Display(Name = "Frage")]
        public string dumbQuestion { get; set; }
        [Display(Name = "Facepalms")]
        public virtual IEnumerable<Votes> Vote { get; set; }
    }
}