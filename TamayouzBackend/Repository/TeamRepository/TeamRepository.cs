using TamayouzShared.Base;
using TamayouzAPI.Data;
using TamayouzShared.Model.Team;

namespace TamayouzAPI.Repository.TeamRepository
{
    public class TeamRepository : Repository<TeamUser>, IteamRepository
    {
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
