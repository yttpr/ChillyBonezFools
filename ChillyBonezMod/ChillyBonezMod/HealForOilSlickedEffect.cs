// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HealForOilSlickedEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class HealForOilSlickedEffect : EffectSO
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
        if (target.HasUnit && (!this._onlyIfHasHealthOver0 || target.Unit.CurrentHealth > 0) && target.Unit.ContainsStatusEffect((StatusEffectType) 9, 0))
        {
          int num1 = 0;
          if (target.Unit is IStatusEffector unit)
          {
            foreach (IStatusEffect statusEffect in unit.StatusEffects)
            {
              if (statusEffect.EffectType == (StatusEffectType)9)
              {
                num1 = statusEffect.StatusContent;
                break;
              }
            }
          }
          int num2 = num1;
          if (this.entryAsPercentage)
            num2 = target.Unit.CalculatePercentualAmount(num2);
          exitAmount += target.Unit.Heal(num2, (HealType) 1, this._directHeal);
        }
      }
      return exitAmount > 0;
    }
  }
}
