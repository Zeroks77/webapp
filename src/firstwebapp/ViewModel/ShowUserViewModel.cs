using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace firstwebapp.ViewModel
{
    public class ShowUserViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "EMail")]
        public string EMail { get; set; }

        [Display(Name = "Eingereichte Fragen")]
        public int FragenEingereicht { get; set; }

        [Display(Name = "Votes Gegeben")]
        public int VotesGegeben { get; set; }
    }
}
