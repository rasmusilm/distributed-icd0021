using App.Contracts.DAL;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Repositories;

public class ProjectIdeaRepository : BaseEntityRepository<ProjectIdea, ApplicationDbContext>, IProjectIdeaRepository
{
    public ProjectIdeaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<IEnumerable<ProjectIdea>> GetAllByUser(string username)
    {
        throw new NotImplementedException();
    }
}