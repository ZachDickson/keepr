using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultkeepsController : ControllerBase
  {
    private readonly VaultkeepsService _vks;
    public VaultkeepsController(VaultkeepsService vks)
    {
      _vks = vks;
    }


    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Vaultkeep>> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Get(userId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]
    [Authorize]
    public ActionResult<Vaultkeep> Get(int id)
    {
      try
      {
        return Ok(_vks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    public ActionResult<Vaultkeep> Create([FromBody] Vaultkeep newVaultkeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newVaultkeep.UserId = userId;
        return Ok(_vks.Create(newVaultkeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Vaultkeep> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}