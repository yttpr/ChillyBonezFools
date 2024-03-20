// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MoldEffectorCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections.Generic;

#nullable disable
namespace ChillyBonezMod
{
  public class MoldEffectorCondition : EffectorConditionSO
  {
    public static List<IUnit> HealingTargets = new List<IUnit>();
    public UnitStoredValueNames triggerOnce = (UnitStoredValueNames) 867572;

    public static bool IsHealable(IUnit unit)
    {
      return !unit.ContainsPassiveAbility((PassiveAbilityTypes) 24) && !unit.ContainsPassiveAbility((PassiveAbilityTypes) 26) && !unit.ContainsStatusEffect((StatusEffectType) 3, 0);
    }

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is UnitDamagedInfo info) || (double) info.healthPercent >= 0.5 || !MoldEffectorCondition.IsHealable(info.unit) || MoldEffectorCondition.HealingTargets.Contains(info.unit))
        return false;
      IUnit iunit = effector as IUnit;
      if (iunit.GetStoredValue(this.triggerOnce) == 88)
        return false;
      iunit.SetStoredValue(this.triggerOnce, 88);
      MoldEffectorCondition.HealingTargets.Add(info.unit);
      CombatManager.Instance.AddSubAction((CombatAction) new CrypticMoldAction(info, effector));
      return true;
    }
  }
}
