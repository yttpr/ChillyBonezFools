// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ProduceShopFor10EntryVarEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ProduceShopFor10EntryVarEffect : EffectSO
  {
    [SerializeField]
    public bool _isTreasure = false;
    [SerializeField]
    public bool _getLocked = false;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      for (int index = 9; index < this.PreviousExitValue; index += 10)
      {
        ++exitAmount;
        if (this._isTreasure)
          stats.AddTreasureLoot(entryVariable, this._getLocked);
        else
          stats.AddShopItemLoot(entryVariable, this._getLocked);
      }
      return exitAmount > 0;
    }
  }
}
