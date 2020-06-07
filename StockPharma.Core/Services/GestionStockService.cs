using StockPharma.Core.Entities;
using StockPharma.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockPharma.Core.Services
{
    public class GestionStockService<T>:IGestionStockService<T> where T: Medicament
    {
        IGestionStockRepository<Medicament> InterfaceStockPharma;
        public GestionStockService(IGestionStockRepository<Medicament> _InterfaceStockPharma)
        {
            InterfaceStockPharma = _InterfaceStockPharma;
        }

        public Medicament getByID(int id) {

            return InterfaceStockPharma.getByID(id);
        }

        public IEnumerable<Medicament> getAll()
        {
            return InterfaceStockPharma.getAll();
        }

        public bool add(Medicament medoc) {

           return InterfaceStockPharma.add(medoc);
        }

        public  void delete(int id) {
            InterfaceStockPharma.delete(id);
        }

        public bool update(Medicament medoc) {

            return InterfaceStockPharma.update(medoc);
        }
    }
}
