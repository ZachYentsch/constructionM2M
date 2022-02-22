
using System.Collections.Generic;
using constructionM2M.Models;
using constructionM2M.Repositories;

namespace constructionM2M.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _comr;
        public CompaniesService(CompaniesRepository comr)
        {
            _comr = comr;
        }

        internal List<Company> getAll()
        {
            return _comr.getAll();
        }

        internal Company getById(int id)
        {
            Company foundCompany = _comr.getById(id);
            if (foundCompany == null)
            {
                throw new System.Exception("Cannot find company");
            }
            return foundCompany;
        }

        internal Company create(Company newCompany)
        {
            Company company = _comr.create(newCompany);
            return company;
        }

        internal void remove(int id)
        {
            Company companyToDelete = getById(id);
            _comr.remove(id);
        }

        internal Company edit(Company updated)
        {
            Company foundCompany = getById(updated.Id);
            foundCompany.Name = updated.Name != null ? updated.Name : foundCompany.Name;
            _comr.edit(updated);
            return foundCompany;
        }
    }
}