using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace firstwebapp.ViewModel
{
    public class QuestionViewModel
    {
         
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [Display(Name = "Fragensteller")]
        public string Submitter { get; set; }


        [RegularExpression(@"[a-zäöüA-ZÄÖÜ]+[a-zäüöA-ZÄÜÖß\d""'\s-]+[?]*$")]
        [Required]
        [Display(Name = "Frage")]
        public string dumbQuestion { get; set; }

        [Display(Name = "Facepalms")]
        public int VoteCount { get; set; }
    }

}
