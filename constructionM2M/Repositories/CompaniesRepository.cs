using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using constructionM2M.Models;
using Dapper;

namespace constructionM2M.Repositories
{
    public class CompaniesRepository
    {
        private readonly IDbConnection _db;
        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Company> getAll()
        {
            string sql = @"
            SELECT * FROM companies";
            List<Company> companies = _db.Query<Company>(sql).ToList();
            return companies;
        }

        internal Company getById(int id)
        {
            string sql = @"
            SELECT * FROM companies WHERE id = @id";
            Company company = _db.QueryFirstOrDefault<Company>(sql, new { id });
            return company;
        }

        internal Company create(Company newCompany)
        {
            string sql = @"
            INSERT INTO companies
            (name, location)
            VALUES
            (@Name, @Location);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCompany);
            newCompany.Id = id;
            return newCompany;
        }

        internal void remove(int id)
        {
            string sql = "DELETE FROM companies WHERE id = @id LIMIT 1";
            int changed = _db.Execute(sql, new { id });
            if (changed == 0)
            {
                throw new SystemException("ERROR, not deleted");
            }
        }

        internal void edit(Company updated)
        {
            string sql = @"
            UPDATE companies
            SET
            name = @Name,
            location = @Location
            WHERE id = @Id;";
            _db.Execute(sql, updated);
        }
    }
}