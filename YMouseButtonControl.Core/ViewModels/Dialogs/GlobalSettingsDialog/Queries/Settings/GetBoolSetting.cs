using System.Linq;
using ReactiveUI;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Settings.Models;
using YMouseButtonControl.Domain.Models;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Settings;

public static class GetBoolSetting
{
    public sealed class BoolSettingVm(SettingBool setting) : ReactiveObject
    {
        private bool _value = setting.BoolValue;
        public string Name { get; } = setting.Name;

        // Must be a settable reactive property: the "Start Minimized" checkbox binds two-way to
        // this value. As a get-only auto-property the checkbox could never write the new value
        // back, so toggling it neither enabled the Apply button (WhenAnyValue never fired) nor
        // persisted the change. Mirrors IntSettingVm.
        public bool Value
        {
            get => _value;
            set => this.RaiseAndSetIfChanged(ref _value, value);
        }
    }

    public sealed class Handler(YMouseButtonControlDbContext db)
    {
        public BoolSettingVm Execute(Query q) => new(db.SettingBools.First(x => x.Name == q.Name));
    }
}
