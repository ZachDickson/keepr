using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }


    public IEnumerable<Keep> Get()
    {
      return _repo.GetPublic();
    }


    public IEnumerable<Keep> GetUserKeeps(string userId)
    {
      return _repo.GetUserKeeps(userId);
    }

    public Keep Get(int id)
    {
      Keep found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }



    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }
  }
}