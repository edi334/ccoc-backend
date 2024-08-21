using MCMS.Base.Data.TypeConfig;
using MCMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CCOCBackend.API.Data;

public class AppDbContext : BaseDbContext
{
    public AppDbContext(DbContextOptions options, IOptions<EntitiesConfig> entitiesConfig) : base(options, entitiesConfig)
    {
    }
}