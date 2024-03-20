// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CordisMaxHPKillEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class CordisMaxHPKillEffect : EffectSO
  {
    public ApplyShieldSlotEffect ShieldApply = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>();
    public BaseCombatTargettingSO ShieldSlots = Slots.SlotTarget(new int[3]
    {
      -1,
      0,
      1
    }, true);

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int previousExitValue = this.PreviousExitValue;
      bool flag = false;
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num1 = caster.WillApplyDamage(entryVariable, target.Unit);
          if (num1 >= target.Unit.MaximumHealth)
          {
            exitAmount += target.Unit.MaximumHealth;
            target.Unit.MaximizeHealth(0);
            target.Unit.DirectDeath(caster, false);
            flag = true;
          }
          else
          {
            exitAmount += num1;
            int num2 = target.Unit.MaximumHealth - num1;
            target.Unit.MaximizeHealth(num2);
          }
        }
      }
      if (flag)
        previousExitValue += 2;
      int num;
      ((EffectSO) this.ShieldApply).PerformEffect(stats, caster, this.ShieldSlots.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), true, previousExitValue, out num);
      return exitAmount > 0;
    }
  }
}
