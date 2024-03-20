// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CustomHealEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class CustomHealEffect : EffectSO
  {
    public bool usePreviousExitValue = true;
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
        entryVariable = (int) Math.Ceiling((Decimal) entryVariable / 4M * (Decimal) this.PreviousExitValue);
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && (!this._onlyIfHasHealthOver0 || target.Unit.CurrentHealth > 0))
        {
          int num = entryVariable;
          if (this.entryAsPercentage)
            num = target.Unit.CalculatePercentualAmount(num);
          exitAmount += target.Unit.Heal(num, (HealType) 1, this._directHeal);
        }
      }
      return exitAmount > 0;
    }
  }
}
