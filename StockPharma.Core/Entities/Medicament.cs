using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockPharma.Core.Entities
{
    public class Medicament
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        [Display(Name = "Numéro de référence")]
        public string reference { get; set; }
        [Display(Name = "Désignation")]
        public string designation { get; set; }
        [Display(Name = "Dosage")]
        public string dose { get; set; }

        [Display(Name = "Forme du médicament")]
        public string type { get; set; }

        [Display(Name = "Quantité diponible")]
        public int quantite { get; set; }

    }
}
