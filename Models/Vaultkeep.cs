namespace Keepr.Models
{
  public class Vaultkeep
  {
    public int Id { get; set; }
    public int KeepId { get; set; }
    public int VaultId { get; set; }
    public string UserId { get; set; }
  }

  // public class VaultKeepViewModel : Vaultkeep
  // {
  //   public int VaultKeepId { get; set; }
  // }
}