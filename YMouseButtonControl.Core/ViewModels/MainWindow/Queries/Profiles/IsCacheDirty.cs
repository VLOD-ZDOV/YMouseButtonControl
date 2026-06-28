using System.Linq;
using Microsoft.EntityFrameworkCore;
using YMouseButtonControl.Core.Mappings;
using YMouseButtonControl.Core.Services.Profiles;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Core.ViewModels.MainWindow.Queries.Profiles;

public static class IsCacheDirty
{
    public sealed class Handler(IProfilesCache profilesCache, YMouseButtonControlDbContext db)
    {
        public bool Execute()
        {
            // Load the persisted profiles the same way the cache itself is loaded: include the
            // button mappings (ProfileMapper reads them) and read without tracking. Without the
            // Include the database side has empty button mappings, so the comparison below would
            // never match a cache profile and the app would always look "dirty".
            var dbProfiles = db
                .Profiles.AsNoTracking()
                .Include(x => x.ButtonMappings)
                .ToList()
                .Select(ProfileMapper.MapToViewModel)
                .OrderBy(x => x.Id);

            return !profilesCache.Profiles.OrderBy(x => x.Id).SequenceEqual(dbProfiles);
        }
    }
}
