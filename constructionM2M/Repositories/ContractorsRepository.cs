
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using constructionM2M.Models;
using Dapper;

namespace constructionM2M.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;
        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Contractor> getAll()
        {
            string sql = @"
            SELECT * FROM contractors";
            List<Contractor> contractors = _db.Query<Contractor>(sql).ToList();
            return contractors;
        }

        internal Contractor getById(int id)
        {
            string sql = @"
            SELECT * FROM contractors WHERE id = @id";
            Contractor contractor = _db.QueryFirstOrDefault<Contractor>(sql, new { id });
            return contractor;
        }

        internal Contractor create(Contractor newContractor)
        {
            string sql = @"
            INSERT INTO contractors
            (name, specialty)
            VALUES
            (@Name, @Specialty);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newContractor);
            newContractor.Id = id;
            return newContractor;
        }

        internal void remove(int id)
        {
            string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
            int changed = _db.Execute(sql, new { id });
            if (changed == 0)
            {
                throw new SystemException("ERROR, not deleted");
            }
        }

        internal void edit(Contractor updated)
        {
            string sql = @"
            UPDATE contractors
            SET
            name = @Name,
            specialty = @Specialty
            WHERE id = @Id;";
            _db.Execute(sql, updated);
        }
    }
}