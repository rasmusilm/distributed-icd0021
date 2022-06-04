using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class Team : DomainEntityId
{
    public string? Name { get; set; }

    public ICollection<UserInTeam>? UserInTeams { get; set; }
    public ICollection<TeamInProject>? TeamInProjects { get; set; }
}