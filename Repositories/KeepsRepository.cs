using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<Keep> GetPublic()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }


    internal Keep Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { Id = id });
    }


    internal IEnumerable<Keep> GetUserKeeps(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @UserId";
      return _db.Query<Keep>(sql, new { userId });
    }


    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id, string userId)
    {
      string sql = @"
      SELECT 
      k.*,
      vk.id as vaultKeepId
      FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = VaultId AND vk.userId = @UserId)";
      return _db.Query<VaultKeepViewModel>(sql, new { id, userId });
    }


    internal Keep Create(Keep KeepData)
    {
      string sql = @"
            INSERT INTO keeps
            (userId, name, description, img, isPrivate, views, shares, keeps)
            Values
            (@UserId, @Name, @Description, @Img, @IsPrivate, views, @Shares, @Keeps);
        SELECT LAST_INSERT_ID();
        ";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
      return KeepData;
    }



    internal Keep Edit(Keep updatedKeep)
    {
      string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @description,
            keeps = @Keeps
            WHERE id = @id
            ";
      _db.Execute(sql, updatedKeep);
      return updatedKeep;
    }


    internal bool Delete(int Id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }


  }
}