﻿using StockPharma.Core.Entities;
using StockPharma.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StockPharma.Infrastructure.Repository
{
    public class GestionStockRepository<T>: IGestionStockRepository<T> where T: Medicament
    {
        readonly StockPharmaContext ContextStock;

        public GestionStockRepository(StockPharmaContext _ContextStock)
        {
            ContextStock = _ContextStock;
        }

        public Medicament  getByID(int id) {

            var medicament = from medoc in ContextStock.medicaments
                                    where medoc.Id == id
                                    select medoc;

            return  medicament.First();
        }

        public IEnumerable<Medicament> getAll() {

            var ListeMedicaments = from medoc in ContextStock.medicaments
                              select medoc;

            return ListeMedicaments;
        }

        public bool add(Medicament medoc) {

            if (verifierExistenceMedicament(medoc))
            {
                ContextStock.medicaments.Add(medoc);
                ContextStock.SaveChanges();
            }
            else
                return false;

            return true;
        }

        public void delete(int id)
        {
         
            ContextStock.medicaments.Remove(ContextStock.medicaments.Find(id));
            ContextStock.SaveChanges();
        }

        public bool update(Medicament medoc)
        {
            var retour =false;
            if (verifierExistenceMedicament(medoc))
            {

                var medicamenTemp = ContextStock.medicaments.Find(medoc.Id);

                if (medicamenTemp != null)
                {

                    medicamenTemp.designation = medoc.designation;
                    medicamenTemp.dose = medoc.dose;
                    medicamenTemp.type = medoc.type;

                    ContextStock.SaveChanges();

                    retour= true;
                }


            }
            else
                retour = false;

            return retour;
        }

       public bool verifierExistenceMedicament(Medicament medoc) {

            var nombreMedicament = (from medicament in ContextStock.medicaments
                                   where medicament.designation == medoc.designation &&
                                         medicament.dose == medoc.dose &&
                                         medicament.type == medoc.type
                                   select medicament).Count();

            if (nombreMedicament != 0)
                return false;


            return true;
        }

        public IEnumerable<Medicament> rechercherMedicament(string medocRecherche) {

            var listePotentielMedoc = (from medoc in ContextStock.medicaments
                                      where medoc.designation.ToLower().Contains(medocRecherche.ToLower()) || medoc.designation.ToLower().StartsWith(medocRecherche.ToLower())
                                      || medoc.designation.ToLower().EndsWith(medocRecherche.ToLower())
                                      select medoc).Take(6);


            return listePotentielMedoc;
        }

    }
}
