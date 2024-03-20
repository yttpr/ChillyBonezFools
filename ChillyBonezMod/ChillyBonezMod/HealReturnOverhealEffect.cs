// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HealReturnOverhealEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class HealReturnOverhealEffect : EffectSO
  {
    public bool usePreviousExitValue;
    public bool entryAsPercentage;
    [SerializeField]
    public bool _directHeal = true;
    [SerializeField]
    public bool _onlyIfHasHealthOver0;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this.usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && (!this._onlyIfHasHealthOver0 || target.Unit.CurrentHealth > 0))
        {
          int num1 = entryVariable;
          if (this.entryAsPercentage)
            num1 = target.Unit.CalculatePercentualAmount(num1);
          int num2 = target.Unit.MaximumHealth - target.Unit.CurrentHealth;
          int num3 = target.Unit.Heal(num1, (HealType) 1, this._directHeal);
          if (num1 > num3)
            exitAmount += num1 - num3;
        }
      }
      return exitAmount > 0;
    }
  }
}
