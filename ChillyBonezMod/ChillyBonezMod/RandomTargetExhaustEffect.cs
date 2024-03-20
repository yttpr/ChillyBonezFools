// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.RandomTargetExhaustEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class RandomTargetExhaustEffect : EffectSO
  {
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
    public int _scars;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          targetSlotInfoList.Add(target);
      }
      if (targetSlotInfoList.Count <= 0)
        return false;
      int index = Random.Range(0, targetSlotInfoList.Count);
      TargetSlotInfo targetSlotInfo = targetSlotInfoList[index];
      int num = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
      targetSlotInfo.Unit.ExhaustAbilityUse();
      ++exitAmount;
      return exitAmount > 0;
    }
  }
}
