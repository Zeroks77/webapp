using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;
using Xunit.Sdk;

namespace firstwebapp.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zäöüA-ZÄÖÜß""'\s-]*$", ErrorMessage = "Deine Eingabe ist fehlerhaft.\nBitte achte darauf das nur Buchstaben erlaubt sind und ein Name immer mit einem Großbuchstaben anfängt.")]
        [Required]
        [Display(Name = "Fragensteller")]
        public string Submitter { get; set; }
        [StringLength(1000
            ,MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-ZäöüÄÖÜß\s.?!\s\d]*$", ErrorMessage = "Deine Eingabe ist fehlerhaft.\nErlaubte Zeichen sind alle Buchstaben, Zahlen sowie Satzzeichen.\n Bitte achte darauf, eine Frage fängt mit einem Großbuchstaben an.")]
        [Required]
        [Display(Name = "Frage")]
        public string dumbQuestion { get; set; }
        [Display(Name = "Facepalms")]
        public virtual IEnumerable<Votes> Vote { get; set; }

        public string EingereichtVonID { get; set; }
    }
}