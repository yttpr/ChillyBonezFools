// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HalveScarsEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class HalveScarsEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 11, out statusEffectInfoSo);
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        if (targets[index1].HasUnit)
        {
          int num1 = 0;
          for (int index2 = 1; index2 < 151; ++index2)
          {
            if (targets[index1].Unit.ContainsStatusEffect((StatusEffectType) 11, index2))
              num1 = index2;
          }
          if (num1 <= 1)
          {
            targets[index1].Unit.TryRemoveStatusEffect((StatusEffectType) 11);
            ++exitAmount;
            return true;
          }
          Decimal d = (Decimal) num1;
          if (num1 < 100)
            d /= 2M;
          if (num1 > 100)
            d = 50M;
          int num2 = -(int) Math.Ceiling(d);
          int num3 = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          int num4 = num2;
          Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(num4, 0);
          scarsStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index1].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, num4))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
