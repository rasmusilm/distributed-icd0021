using App.Contracts.DAL;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Repositories;

public class ProjectIdeaRepository : BaseEntityRepository<ProjectIdea, ApplicationDbContext>, IProjectIdeaRepository
{
    private readonly ApplicationDbContext _context;
    public ProjectIdeaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public IEnumerable<ProjectIdea> GetAllByUser(Guid userId)
    {
        var projectIdeas = _context.ProjectIdeas.Where(p => p.UserId.Equals(userId));
        return projectIdeas.AsEnumerable();
    }
}