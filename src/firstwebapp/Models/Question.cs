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
         "Der erste Buchstabe muss ein Gro�buchstabe sein."
        , MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-z���A-Z����""'\s-]*$")]
        [Required]
        [Display(Name = "Fragensteller")]
        public string Submitter { get; set; }
        [StringLength(1000, ErrorMessage = 
            "Der erste Buchstabe muss ein Gro�buchstabe sein."
            ,MinimumLength = 3)]
        [RegularExpression(@"^[a-z���A-Z���]+[a-z���A-Z����\d""'\s-]+[?]*$")]
        [Required]
        [Display(Name = "Frage")]
        public string dumbQuestion { get; set; }
        [Display(Name = "Facepalms")]
        public virtual IEnumerable<Votes> Vote { get; set; }
    }
}