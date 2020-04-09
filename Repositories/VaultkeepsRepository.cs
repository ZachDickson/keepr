using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultkeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultkeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<Vaultkeep> Get(string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE userId = @UserId";
      return _db.Query<Vaultkeep>(sql, new { userId });
    }


    internal Vaultkeep Get(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vaultkeep>(sql, new { id });
    }



    internal Vaultkeep Create(Vaultkeep VaultkeepData)
    {
      string sql = @"
            INSERT INTO vaultkeeps
            (keepId, vaultId, userId)
            Values
            (@KeepId, @VaultId, @UserId);
             SELECT LAST_INSERT_ID();
             ";
      VaultkeepData.Id = _db.ExecuteScalar<int>(sql, VaultkeepData);
      return VaultkeepData;
    }


    internal bool Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { id });
      return removed == 1;
    }


  }
}