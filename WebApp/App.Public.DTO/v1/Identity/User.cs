namespace App.Public.DTO.v1.Identity;

public class User
{
    public Guid Id = Guid.NewGuid();
    public string? Name { get; set; } = "";
}