using App.BLL.DTO;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using Base.BLL;
using Base.Contracts.Base;
using Helpers.WebApp;

namespace App.BLL.Services;

public class IdeaFeedService : BaseEntityService<IdeaFeedProfile, DAL.DTO.IdeaFeedProfile, IIdeaFeedProfileRepository>, IIdeaFeedProfileService
{
    public IdeaFeedService(IIdeaFeedProfileRepository repository, IMapper<IdeaFeedProfile, DAL.DTO.IdeaFeedProfile> mapper) : base(repository, mapper)
    {
    }

    public new async Task<IdeaFeedProfile?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {
        var profile = Mapper.Map(await Repository.FirstOrDefaultAsync(id, noTracking));
        profile!.FeedTags!.ForEach(t => profile.TagIds.Add(t.TagId));
        return profile;
    }

    public async Task<IEnumerable<IdeaFeedProfile>> GetAllByUser(Guid id)
    {
        return (await Repository.GetAllByUser(id)).Select(x => Mapper.Map(x)!);
    }
}