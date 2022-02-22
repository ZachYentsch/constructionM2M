

using System.Collections.Generic;
using constructionM2M.Models;
using constructionM2M.Repositories;

namespace constructionM2M.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _conr;
        public ContractorsService(ContractorsRepository conr)
        {
            _conr = conr;
        }

        internal List<Contractor> getAll()
        {
            return _conr.getAll();
        }

        internal Contractor getById(int id)
        {
            Contractor foundContractor = _conr.getById(id);
            if (foundContractor == null)
            {
                throw new System.Exception("Cannot find Contractor");
            }
            return foundContractor;
        }

        internal Contractor create(Contractor newContractor)
        {
            Contractor contractor = _conr.create(newContractor);
            return contractor;
        }

        internal void remove(int id)
        {
            Contractor contractorToDelete = getById(id);
            _conr.remove(id);
        }

        internal Contractor edit(Contractor updated)
        {
            Contractor foundContractor = getById(updated.Id);
            foundContractor.Name = updated.Name != null ? updated.Name : foundContractor.Name;
            _conr.edit(updated);
            return foundContractor;
        }
    }
}