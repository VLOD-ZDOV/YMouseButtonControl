using System;
using Newtonsoft.Json;
using ReactiveUI;
using YMouseButtonControl.Core.Localization;

namespace YMouseButtonControl.Core.ViewModels.Models;

[JsonObject(MemberSerialization.OptOut)]
public abstract class BaseSimulatedKeystrokeTypeVm
    : ReactiveObject,
        IEquatable<BaseSimulatedKeystrokeTypeVm>
{
    private int _index;
    private string? _description;
    private string? _shortDescription;
    private bool _enabled;
    public int Index
    {
        get => _index;
        set => this.RaiseAndSetIfChanged(ref _index, value);
    }
    public string? Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    public string? ShortDescription
    {
        get => _shortDescription;
        set => this.RaiseAndSetIfChanged(ref _shortDescription, value);
    }
    public bool Enabled
    {
        get => _enabled;
        set => this.RaiseAndSetIfChanged(ref _enabled, value);
    }

    protected BaseSimulatedKeystrokeTypeVm CreateClone(BaseSimulatedKeystrokeTypeVm clone)
    {
        clone.Index = Index;
        clone.Description = Description;
        clone.ShortDescription = ShortDescription;
        clone.Enabled = Enabled;
        return clone;
    }

    public abstract BaseSimulatedKeystrokeTypeVm Clone();

    public override string ToString() => $"{Index + 1} {Description}";

    public bool Equals(BaseSimulatedKeystrokeTypeVm? other)
    {
        if (ReferenceEquals(null, other))
            return false;
        if (ReferenceEquals(this, other))
            return true;
        return Index == other.Index
            && Description == other.Description
            && ShortDescription == other.ShortDescription
            && Enabled == other.Enabled;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((BaseSimulatedKeystrokeTypeVm)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Index, Description, ShortDescription, Enabled);
    }
}

public class AsMousePressedAndReleasedActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public AsMousePressedAndReleasedActionTypeVm()
    {
        Index = 8;
        Description = Localizer.Instance["Skt_AsPressedReleased"];
        ShortDescription = Localizer.Instance["SktShort_AsPressedReleased"];
        Enabled = true;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new AsMousePressedAndReleasedActionTypeVm());
}

public class DuringMouseActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public DuringMouseActionTypeVm()
    {
        Index = 2;
        Description = Localizer.Instance["Skt_During"];
        ShortDescription = Localizer.Instance["SktShort_During"];
        Enabled = true;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new DuringMouseActionTypeVm());
}

public class InAnotherThreadPressedActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public InAnotherThreadPressedActionTypeVm()
    {
        Index = 3;
        Description = Localizer.Instance["Skt_ThreadPressed"];
        ShortDescription = Localizer.Instance["SktShort_ThreadPressed"];
        Enabled = false;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new InAnotherThreadPressedActionTypeVm());
}

public class InAnotherThreadReleasedActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public InAnotherThreadReleasedActionTypeVm()
    {
        Index = 4;
        Description = Localizer.Instance["Skt_ThreadReleased"];
        ShortDescription = Localizer.Instance["SktShort_ThreadReleased"];
        Enabled = false;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new InAnotherThreadReleasedActionTypeVm());
}

public class MouseButtonPressedActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public MouseButtonPressedActionTypeVm()
    {
        Index = 0;
        Description = Localizer.Instance["Skt_AsPressed"];
        ShortDescription = Localizer.Instance["SktShort_AsPressed"];
        Enabled = true;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new MouseButtonPressedActionTypeVm());
}

public class MouseButtonReleasedActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public MouseButtonReleasedActionTypeVm()
    {
        Index = 1;
        Description = Localizer.Instance["Skt_AsReleased"];
        ShortDescription = Localizer.Instance["SktShort_AsReleased"];
        Enabled = true;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new MouseButtonReleasedActionTypeVm());
}

public class RepeatedlyWhileButtonDownActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public RepeatedlyWhileButtonDownActionTypeVm()
    {
        Index = 5;
        Description = Localizer.Instance["Skt_Repeat"];
        ShortDescription = Localizer.Instance["SktShort_Repeat"];
        Enabled = true;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new RepeatedlyWhileButtonDownActionTypeVm());
}

public class StickyHoldActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public StickyHoldActionTypeVm()
    {
        Index = 7;
        Description = Localizer.Instance["Skt_StickyHold"];
        ShortDescription = Localizer.Instance["SktShort_StickyHold"];
        Enabled = true;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new StickyHoldActionTypeVm());
}

public class StickyRepeatActionTypeVm : BaseSimulatedKeystrokeTypeVm
{
    public StickyRepeatActionTypeVm()
    {
        Index = 6;
        Description = Localizer.Instance["Skt_StickyRepeat"];
        ShortDescription = Localizer.Instance["SktShort_StickyRepeat"];
        Enabled = true;
    }

    public override BaseSimulatedKeystrokeTypeVm Clone() =>
        CreateClone(new StickyRepeatActionTypeVm());
}
