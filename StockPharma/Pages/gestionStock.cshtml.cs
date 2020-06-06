using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockPharma.Core.Entities;
using StockPharma.Core.Interfaces;

namespace StockPharma.Web.Pages
{
    public class gestionStockModel : PageModel
    {
        IGestionStockService<Medicament> InterfaceServiceStockPharma;

        public gestionStockModel(IGestionStockService<Medicament> _InterfaceServiceStockPharma)
        {
            InterfaceServiceStockPharma = _InterfaceServiceStockPharma;
        }

        public List<Medicament> ListeMedicaments;
        [BindProperty]
        public Medicament medoc { get; set; }

        public string action;

        public string message;
        public IActionResult OnGet()
        {
            ListeMedicaments = InterfaceServiceStockPharma.getAll().ToList();

            return this.Page();
        }

        public IActionResult OnPostOuvrirAjout()
        {

            action = "AJOUT";
            return OnGet();
        }

        public IActionResult OnPostAjouterMedicament() {

            if (medoc != null) {
               
                if(InterfaceServiceStockPharma.add(medoc))
                    message = medoc.designation+" Ajouté";
                else
                    message = "Ce Medicament existe déja";
            }
            else
                message = "Médicament Error";


            return OnGet();
        }


        public IActionResult OnPostOuvrirSuppression(int Id)
        {

            action = "SUPPRESSION";

            medoc = InterfaceServiceStockPharma.getByID(Id);

            return OnGet();
        }

        public IActionResult OnPostSupprimerMedicament(int id)
        {
            InterfaceServiceStockPharma.delete(id);

            message = "Medicament Supprimé";

            return OnGet();
        }


    }
}
