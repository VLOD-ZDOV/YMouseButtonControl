using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YMouseButtonControl.Core.Mappings;
using YMouseButtonControl.Core.Services.Profiles;
using YMouseButtonControl.Core.ViewModels.Models;
using YMouseButtonControl.Domain.Models;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Core.ViewModels.MainWindow.Commands.Profiles;

public static class ApplyProfiles
{
    public sealed class Handler(YMouseButtonControlDbContext db, IProfilesCache profilesCache)
    {
        public async Task ExecuteAsync()
        {
            var dbProfiles = await db.Profiles.AsNoTracking().ToListAsync();

            // delete profiles that exist in the db but not in the profiles service. User had to remove a profile for this to occur
            // NOTE: these loops use awaited foreach rather than List.ForEach(async ...).
            // List.ForEach(async ...) compiles to fire-and-forget async void: the work is not
            // awaited before SaveChangesAsync below and can run concurrently on this
            // non-thread-safe DbContext. With the synchronous SQLite provider the continuations
            // usually complete inline so writes are not lost in practice, but the pattern is a
            // latent correctness bug (lost writes / "a second operation was started on this
            // context" exceptions) and is avoided here.
            foreach (
                var dbProfile in dbProfiles.Where(x =>
                    profilesCache.Profiles.All(y => y.Id != x.Id)
                )
            )
            {
                var ent = await db.Profiles.FindAsync(dbProfile.Id);
                if (ent is not null)
                {
                    db.Profiles.Remove(ent);
                }
            }

            // update profiles that exist in both profiles service and db
            foreach (
                var profilesServicePvm in profilesCache.Profiles.Where(x =>
                    dbProfiles.Any(y => y.Id == x.Id)
                )
            )
            {
                var ent =
                    await db.Profiles.FindAsync(profilesServicePvm.Id)
                    ?? throw new Exception("Profile not found");
                ent.Checked = profilesServicePvm.Checked;
                ent.Description = profilesServicePvm.Description;
                ent.DisplayPriority = profilesServicePvm.DisplayPriority;
                ent.IsDefault = profilesServicePvm.IsDefault;
                ent.MatchType = profilesServicePvm.MatchType;
                ent.Name = profilesServicePvm.Name;
                ent.ParentClass = profilesServicePvm.ParentClass;
                ent.Process = profilesServicePvm.Process;
                ent.WindowCaption = profilesServicePvm.WindowCaption;
                ent.WindowClass = profilesServicePvm.WindowClass;

                foreach (var profilesServicePvmBtnMapVm in profilesServicePvm.ButtonMappings)
                {
                    var dbBm = await db.ButtonMappings.FindAsync(profilesServicePvmBtnMapVm.Id);

                    // if button mapping doesn't exist in the db, add it
                    // else if button mapping exists in the db and does not equal the button mapping in the profiles service profile, update button mapping
                    if (dbBm is null)
                    {
                        var newBm = ButtonMappingMapper.MapToEntity(profilesServicePvmBtnMapVm);
                        db.ButtonMappings.Add(newBm);
                    }
                    else
                    {
                        var dbBmMapped = ButtonMappingMapper.MapToViewModel(dbBm);
                        if (profilesServicePvmBtnMapVm.Equals(dbBmMapped))
                        {
                            continue;
                        }

                        dbBm.AutoRepeatDelay = profilesServicePvmBtnMapVm.AutoRepeatDelay;
                        dbBm.AutoRepeatRandomizeDelayEnabled =
                            profilesServicePvmBtnMapVm.AutoRepeatRandomizeDelayEnabled;
                        dbBm.BlockOriginalMouseInput =
                            profilesServicePvmBtnMapVm.BlockOriginalMouseInput;
                        dbBm.Keys = profilesServicePvmBtnMapVm.Keys;
                        dbBm.MouseButton = profilesServicePvmBtnMapVm.MouseButton;
                        dbBm.Selected = profilesServicePvmBtnMapVm.Selected;
                        if (profilesServicePvmBtnMapVm.SimulatedKeystrokeType is not null)
                        {
                            dbBm.SimulatedKeystrokeType =
                                profilesServicePvmBtnMapVm.SimulatedKeystrokeType switch
                                {
                                    AsMousePressedAndReleasedActionTypeVm =>
                                        SimulatedKeystrokeType.AsMousePressedAndReleasedActionType,
                                    DuringMouseActionTypeVm =>
                                        SimulatedKeystrokeType.DuringMouseActionType,
                                    InAnotherThreadPressedActionTypeVm =>
                                        SimulatedKeystrokeType.InAnotherThreadPressedActionType,
                                    InAnotherThreadReleasedActionTypeVm =>
                                        SimulatedKeystrokeType.InAnotherThreadReleasedActionType,
                                    MouseButtonPressedActionTypeVm =>
                                        SimulatedKeystrokeType.MouseButtonPressedActionType,
                                    MouseButtonReleasedActionTypeVm =>
                                        SimulatedKeystrokeType.MouseButtonReleasedActionType,
                                    RepeatedlyWhileButtonDownActionTypeVm =>
                                        SimulatedKeystrokeType.RepeatedlyWhileButtonDownActionType,
                                    StickyHoldActionTypeVm =>
                                        SimulatedKeystrokeType.StickyHoldActionType,
                                    StickyRepeatActionTypeVm =>
                                        SimulatedKeystrokeType.StickyRepeatActionType,
                                    _ => throw new NotImplementedException(),
                                };
                        }
                    }
                }
            }

            // add profiles that exist in the profile service but not the db. this occurs when a user adds a profile
            await db.Profiles.AddRangeAsync(
                profilesCache
                    .Profiles.Where(x => dbProfiles.All(y => y.Id != x.Id))
                    .Select(ProfileMapper.MapToEntity)
            );

            await db.SaveChangesAsync();
        }
    }
}
