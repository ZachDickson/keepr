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
      string sql = "SELECT * FROM keeps WHERE authorId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"
            INSERT INTO keeps
            (userId, name, description, img, isPrivate, shares, keeps)
            Values
            (@userId, @name, @description, @img, @isPrivate, @shares, @keeps)";
      // SELECT LAST_INSERT()";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
      return KeepData;
    }




  }
}