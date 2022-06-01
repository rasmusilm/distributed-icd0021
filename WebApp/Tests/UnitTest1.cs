using System;
using System.Linq;
using System.Threading.Tasks;
using App.BLL;
using App.DAL.EF;
using App.Domain;
using App.Domain.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using WebApp;
using WebApp.ApiControllers.Functional;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProjectIdeaController _controller;
    private readonly ApplicationDbContext _ctx;
    private readonly AppUOW _uow;
    private readonly AppBLL _bll;
    
    public const string UserId = "UserId";

    public const string AuthenticationScheme = "Test";
    private readonly string _defaultUserId;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        
        var configDAL = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new App.DAL.EF.AutomapperConfig());
        });
        var configBLL = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new App.BLL.AutomapperConfig());
        });
        var configFinal = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperConfig());
        });

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _ctx = new ApplicationDbContext(optionsBuilder.Options);
        
        _ctx.Database.EnsureDeleted();
        _ctx.Database.EnsureCreated();

        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ProjectIdeaController>();

        _uow = new AppUOW(_ctx, configDAL.CreateMapper());
        _bll = new AppBLL(_uow, configBLL.CreateMapper());
        _controller = new ProjectIdeaController(_bll, configFinal.CreateMapper());

        _ctx.Users.Add(new User());
        _ctx.SaveChangesAsync();
    }
    
    [Fact]
    public async Task Test1()
    {
        var result = (await _controller.GetProjectIdeas());
        Assert.NotNull(result);
        Assert.Empty(result);
    }
    
    [Fact]
    public async Task Test2()
    {
        _ctx.Complexities.Add(new Complexity()
        {
            Name =
            {
                ["en-gb"] = "hard"
            }
        });
        _ctx.Difficulties.Add(new Difficulty()
        {
            Name =
            {
                ["en-gb"] = "hard"
            }
        });

        _ctx.SaveChanges();

        var user = _ctx.Users.First();
        var diff = _ctx.Difficulties.First();
        var comp = _ctx.Complexities.First();
        
        _ctx.ProjectIdeas.Add(new ProjectIdea
        {
            Id = new Guid(),
            Title = "title",
            Explanation = "no explanation",
            PostedAt = DateTime.Now,
            Edited = false,
            Deleted = false,
            ComplexityId = comp.Id,
            Complexity = comp,
            DifficultyId = diff.Id,
            Difficulty = diff,
            UserId = user.Id,
            User = user
        });
        
        _ctx.SaveChanges();
        var result = (await _controller.GetProjectIdeas());
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Single(result.ToArray());
        Assert.IsType(typeof(App.Public.DTO.v1.ProjectIdea), result.First());
    }
    
    [Fact]
    public async Task Test3()
    {
        _ctx.Complexities.Add(new Complexity()
        {
            Name =
            {
                ["en-gb"] = "hard"
            }
        });
        _ctx.Difficulties.Add(new Difficulty()
        {
            Name =
            {
                ["en-gb"] = "hard"
            }
        });

        _ctx.SaveChanges();

        var user = _ctx.Users.First();
        var diff = _ctx.Difficulties.First();
        var comp = _ctx.Complexities.First();
        
        _ctx.ProjectIdeas.Add(new ProjectIdea
        {
            Id = new Guid(),
            Title = "title",
            Explanation = "no explanation",
            PostedAt = DateTime.Now,
            Edited = false,
            Deleted = false,
            ComplexityId = comp.Id,
            Complexity = comp,
            DifficultyId = diff.Id,
            Difficulty = diff,
            UserId = user.Id,
            User = user
        });
        
        _ctx.SaveChanges();
        var id = _ctx.ProjectIdeas.First().Id;
        var result = (await _controller.GetProjectIdea(id));
        Assert.NotNull(result);
        Assert.IsType<App.Public.DTO.v1.ProjectIdea>(result.Value);
        Assert.Equal(_ctx.ProjectIdeas.First().Title, result.Value!.Title);
    }
    
    [Fact]
    public async Task Test4()
    {
        var result = (await _controller.GetProjectIdea(new Guid()));
        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    [Fact]
    public async Task Test5()
    {
        _ctx.Complexities.Add(new Complexity()
        {
            Name =
            {
                ["en-gb"] = "hard"
            }
        });
        _ctx.Difficulties.Add(new Difficulty()
        {
            Name =
            {
                ["en-gb"] = "hard"
            }
        });

        _ctx.SaveChanges();

        var user = _ctx.Users.First();
        var diff = _ctx.Difficulties.First();
        var comp = _ctx.Complexities.First();
        
        _ctx.ProjectIdeas.Add(new ProjectIdea
        {
            Id = new Guid(),
            Title = "title",
            Explanation = "no explanation",
            PostedAt = DateTime.Now,
            Edited = false,
            Deleted = false,
            ComplexityId = comp.Id,
            Complexity = comp,
            DifficultyId = diff.Id,
            Difficulty = diff,
            UserId = user.Id,
            User = user
        });
        
        _ctx.SaveChanges();
        var post = _ctx.ProjectIdeas.First();
        var id = post.Id;
        var newPost = new App.Public.DTO.v1.ProjectIdea ()
        {
            Id = new Guid(),
            Title = "title",
            Explanation = "no explanation",
            PostedAt = DateTime.Now,
            Edited = false,
            Deleted = false,
            ComplexityId = comp.Id,
            DifficultyId = diff.Id,
            UserId = user.Id,
        };
        var result = (await _controller.PostProjectIdea(newPost));
        Assert.Equal(_ctx.ProjectIdeas.First().Title, newPost.Title);
    }
    
    // [Fact]
    // public async Task Test6()
    // {
    //     _ctx.Complexities.Add(new Complexity()
    //     {
    //         Name =
    //         {
    //             ["en-gb"] = "hard"
    //         }
    //     });
    //     _ctx.Difficulties.Add(new Difficulty()
    //     {
    //         Name =
    //         {
    //             ["en-gb"] = "hard"
    //         }
    //     });
    //
    //     _ctx.SaveChanges();
    //
    //     var user = _ctx.Users.First();
    //     var diff = _ctx.Difficulties.First();
    //     var comp = _ctx.Complexities.First();
    //     
    //     _ctx.ProjectIdeas.Add(new ProjectIdea
    //     {
    //         Id = new Guid(),
    //         Title = "title",
    //         Explanation = "no explanation",
    //         PostedAt = DateTime.Now,
    //         Edited = false,
    //         Deleted = false,
    //         ComplexityId = comp.Id,
    //         Complexity = comp,
    //         DifficultyId = diff.Id,
    //         Difficulty = diff,
    //         UserId = user.Id,
    //         User = user
    //     });
    //     
    //     _ctx.SaveChanges();
    //     var post = _ctx.ProjectIdeas.First();
    //     var id = post.Id;
    //     var result = (await _controller.DeleteProjectIdea(id));
    //     Assert.Empty(_ctx.ProjectIdeas.ToArray());
    // }
}