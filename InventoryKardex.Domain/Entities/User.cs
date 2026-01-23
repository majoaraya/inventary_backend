namespace InventoryKardex.Domain.Entities;

public class User
{
    public long Id {get; set;}
    public string Email{get; set;}=string.Empty;
    public string PasswordHash {get; set;} = string.Empty;
    public int RoleId{get; set;}
    public bool IsActive{get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTimeKind UpdatedAt{get; set;}

    //Optional (useful when joining)
    public string? RoleName{get;set;}

}