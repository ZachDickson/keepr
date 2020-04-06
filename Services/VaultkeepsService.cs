using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultkeepsService
  {
    private readonly VaultkeepsRepository _repo;
    public VaultkeepsService(VaultkeepsRepository repo)
    {
      _repo = repo;
    }


    public IEnumerable<Vaultkeep> Get()
    {
      return _repo.Get();
    }



    public Vaultkeep Get(int id)
    {
      Vaultkeep found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }



    public Vaultkeep Create(Vaultkeep newVaultkeep)
    {
      Vaultkeep created = _repo.Create(newVaultkeep);
      if (created == null)
      {
        throw new Exception("create failed");
      }
      return _repo.Create(newVaultkeep);
    }



    public Vaultkeep Delete(int id, string userId)
    {
      Vaultkeep found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("Invalid Request");
      }
      if (_repo.Delete(id))
      {
        return found;
      }
      throw new Exception("Something went terribly wrong");
    }


  }
}