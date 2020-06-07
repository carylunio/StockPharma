using StockPharma.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockPharma.Core.Interfaces
{
    public interface IGestionStockService<T> where T: Medicament
    {
        Medicament getByID(int id);

        IEnumerable<Medicament> getAll();

        bool add(Medicament medoc);

        void delete(int id);

        bool update(Medicament medoc);
    }
}
