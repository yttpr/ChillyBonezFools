// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ApplyOilSlickedTwoToFiveEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ApplyOilSlickedTwoToFiveEffect : EffectSO
  {
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
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 9, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          int num = Random.Range(2, 6);
          OilSlicked_StatusEffect slickedStatusEffect = new OilSlicked_StatusEffect(num, 0);
          slickedStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) slickedStatusEffect, num))
            exitAmount += num;
        }
      }
      return exitAmount > 0;
    }
  }
}
