namespace App.Contracts.DAL;

public interface IAppUnitOfWork
{
    IProjectIdeaRepository ProjectIdeas { get; }
}