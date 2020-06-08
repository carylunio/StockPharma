using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using StockPharma.Core.Entities;
using StockPharma.Core.Interfaces;

namespace StockPharma.Web.Pages
{
    public class OperationModel : PageModel
    {
        IGestionStockService<Medicament> InterfaceServiceStockPharma;

        public OperationModel(IGestionStockService<Medicament> interfaceServiceStockPharma)
        {
             InterfaceServiceStockPharma = interfaceServiceStockPharma;
        }


        public void OnGet()
        {
        }

       public IActionResult OnGetMedicamentResearch( string value) {

            string test = JsonConvert.DeserializeObject<string>(value);

            return new JsonResult(InterfaceServiceStockPharma.rechercherMedicament(test).ToList());
        }
    } 
}
