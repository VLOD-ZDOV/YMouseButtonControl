using System.Linq;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Settings.Models;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Settings;

public static class GetStringSetting
{
    public sealed class Handler(YMouseButtonControlDbContext db)
    {
        public string? Execute(Query q) =>
            db.SettingStrings.FirstOrDefault(x => x.Name == q.Name)?.StringValue;
    }
}
