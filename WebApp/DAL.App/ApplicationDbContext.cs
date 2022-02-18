using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DAL.App;

public class ApplicationDbContext : IdentityDbContext<User, UserRole, Guid>
{
    public DbSet<TestItem> TestItems { get; set; } = default!;
    public DbSet<Difficulty> Difficulties { get; set; } = default!;
    public DbSet<Complexity> Complexities  { get; set; } = default!;
    public DbSet<ProjectIdea> ProjectIdeas  { get; set; } = default!;
    public DbSet<IdeaRating> IdeaRatings  { get; set; } = default!;
    public DbSet<IdeaTag> IdeaTags  { get; set; } = default!;
    public DbSet<Tag> Tags  { get; set; } = default!;
    public DbSet<Comment> Comments  { get; set; } = default!;
    public DbSet<CommentRating> CommentRatings  { get; set; } = default!;
    public DbSet<FeedTag> FeedTags  { get; set; } = default!;
    public DbSet<IdeaFeedProfile> IdeaFeedProfiles  { get; set; } = default!;
    public DbSet<IdeaInfeed> IdeaInfeeds  { get; set; } = default!;
    public DbSet<ProjectTask> ProjectTasks  { get; set; } = default!;
    public DbSet<ProjectTaskStatus> ProjectTaskStatus  { get; set; } = default!;
    public DbSet<Project> Projects  { get; set; } = default!;
    public DbSet<Team> Teams  { get; set; } = default!;
    public DbSet<UserInTeam> UserInTeams  { get; set; } = default!;
    public DbSet<RoleInTeam> RoleInTeams  { get; set; } = default!;
    public DbSet<UserInProject> UserInProjects { get; set; } = default!;
    public DbSet<TeamInProject> TeamInProjects { get; set; } = default!;
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}