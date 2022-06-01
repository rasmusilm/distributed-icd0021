using System;
using System.Linq;
using System.Threading.Tasks;
using App.BLL;
using App.DAL.EF;
using App.Domain.Identity;
using App.Public.DTO.v1;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp;
using WebApp.ApiControllers.Functional;
using Xunit;

namespace Tests;

public class TagControllerTests
{
    private readonly TagController _controller;
    private readonly ApplicationDbContext _ctx;
    private readonly AppUOW _uow;
    private readonly AppBLL _bll;
    
    public TagControllerTests()
    {
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
        _controller = new TagController(_bll, configFinal.CreateMapper());

        _ctx.Users.Add(new User());
        _ctx.SaveChangesAsync();
    }
    
    [Fact]
    public async Task Test1()
    {
        var result = (await _controller.GetTags());
        Assert.NotNull(result);
        Assert.Empty(result);
    }
    
    [Fact]
    public async Task Test2()
    {
        var tag1 = new App.Domain.Tag()
        {
            Tagname =
            {
                ["et-EE"] = "Püüton",
                ["en-GB"] = "Python"
            }
        };
        _ctx.Tags.Add(tag1);
        _ctx.SaveChanges();
        
        var result = (await _controller.GetTags());
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.IsType<Tag>(result.First());
    }
    
    [Fact]
    public async Task Test3()
    {
        var tag1 = new App.Domain.Tag()
        {
            Tagname =
            {
                ["et-EE"] = "Püüton",
                ["en-GB"] = "Python"
            }
        };
        _ctx.Tags.Add(tag1);
        _ctx.SaveChanges();
        
        var result = (await _controller.GetTag(tag1.Id));
        Assert.NotNull(result);
        Assert.IsType<Tag>(result.Value);
        Assert.Equal(tag1.Tagname["et-EE"], result.Value.Tagname["et-EE"]);
    }
    
    [Fact]
    public async Task Test4()
    {
        var result = (await _controller.GetTag(new Guid()));
        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    [Fact]
    public async Task Test5()
    {
        var result = (await _controller.PostTag(new Tag() {
            Tagname =
            {
                ["et-EE"] = "Püüton",
                ["en-GB"] = "Python"
            }
        }));
        Assert.Single(_ctx.Tags.ToArray());
    }
}