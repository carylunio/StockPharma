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
        public void OnGet()
        {
            ListeMedicaments = InterfaceServiceStockPharma.getAll().ToList();

            //return this.Page();
        }

        public void OnPostOuvrirAjout()
        {

            action = "AJOUT";
            OnGet();
        }

        public void OnPostAjouterMedicament() {

            if (medoc != null) {
               
                if(InterfaceServiceStockPharma.add(medoc))
                    message = medoc.designation+" Ajouté";
                else
                    message = "Ce Medicament existe déja";
            }
            else
                message = "Médicament Error";


            OnGet();
        }


        public void OnPostOuvrirSuppression(int Id)
        {

            action = "SUPPRESSION";

            medoc = InterfaceServiceStockPharma.getByID(Id);

             OnGet();
        }

        public void OnPostOuvrirModification(int Id)
        {

            action = "MODIFICATION";

            medoc = InterfaceServiceStockPharma.getByID(Id);

             OnGet();
        }

        public void OnPostSupprimerMedicament(int id)
        {
            InterfaceServiceStockPharma.delete(id);

            message = "Medicament Supprimé";

             OnGet();
        }


        public void OnPostModifierMedicament(int Id) {

            medoc.Id = Id;
            if (InterfaceServiceStockPharma.update(medoc)) {

                message = medoc.designation + "Modifié";
            }else
                message = "Ce medicament existe déja";

            OnGet();
        }


    }
}
