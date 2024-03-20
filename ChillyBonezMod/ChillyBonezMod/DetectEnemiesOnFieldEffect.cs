// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DetectEnemiesOnFieldEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class DetectEnemiesOnFieldEffect : EffectSO
  {
    [SerializeField]
    public int _searchAmount = 1;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          ++exitAmount;
      }
      return exitAmount == this._searchAmount;
    }
  }
}
