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


    public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }



    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }



    public Keep Edit(Keep updatedKeep)
    {
      Keep found = Get(updatedKeep.Id);
      if (found.UserId != updatedKeep.UserId)
      {
        throw new Exception("Invalid Request");
      }
      found.Name = updatedKeep.Name;
      found.Description = updatedKeep.Description != null ? updatedKeep.Description : found.Description;
      return _repo.Edit(found);
    }



    public Keep Delete(int id, string userId)
    {
      Keep found = Get(id);
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