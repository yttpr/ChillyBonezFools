// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Targetting_ByUnit_Health
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class Targetting_ByUnit_Health : BaseCombatTargettingSO
  {
    public bool getAllies = false;
    public bool ignoreCastSlot;
    public bool getAllUnitSlots = false;
    public bool higher = true;
    public bool onlyOne = false;

    public override bool AreTargetAllies => this.getAllies;

    public override bool AreTargetSlots => this.getAllUnitSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] allUnitTargetSlots = slots.GetAllUnitTargetSlots(isCasterCharacter && this.getAllies || !isCasterCharacter && !this.getAllies, this.getAllUnitSlots, this.ignoreCastSlot ? casterSlotID : -1);
      List<TargetSlotInfo> targetSlotInfoList1 = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in allUnitTargetSlots)
      {
        if (targetSlotInfo.HasUnit)
          targetSlotInfoList1.Add(targetSlotInfo);
      }
      List<TargetSlotInfo> targetSlotInfoList2 = new List<TargetSlotInfo>();
      int num1 = 0;
      foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoList1)
      {
        if (targetSlotInfo.HasUnit)
        {
          if (targetSlotInfoList2.Count <= 0)
          {
            targetSlotInfoList2.Add(targetSlotInfo);
            num1 = targetSlotInfo.Unit.CurrentHealth;
          }
          else if (targetSlotInfo.Unit.CurrentHealth == num1)
            targetSlotInfoList2.Add(targetSlotInfo);
          else if (targetSlotInfo.Unit.CurrentHealth > num1)
          {
            targetSlotInfoList2.Clear();
            targetSlotInfoList2.Add(targetSlotInfo);
            num1 = targetSlotInfo.Unit.CurrentHealth;
          }
        }
      }
      List<TargetSlotInfo> targetSlotInfoList3 = new List<TargetSlotInfo>();
      int num2 = 0;
      foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoList1)
      {
        if (targetSlotInfo.HasUnit)
        {
          if (targetSlotInfoList3.Count <= 0)
          {
            targetSlotInfoList3.Add(targetSlotInfo);
            num2 = targetSlotInfo.Unit.CurrentHealth;
          }
          else if (targetSlotInfo.Unit.CurrentHealth == num2)
            targetSlotInfoList3.Add(targetSlotInfo);
          else if (targetSlotInfo.Unit.CurrentHealth < num2)
          {
            targetSlotInfoList3.Clear();
            targetSlotInfoList3.Add(targetSlotInfo);
            num2 = targetSlotInfo.Unit.CurrentHealth;
          }
        }
      }
      if (this.higher)
      {
        if (targetSlotInfoList2.Count <= 0)
          return new TargetSlotInfo[0];
        if (!this.onlyOne)
          return targetSlotInfoList2.ToArray();
        return new TargetSlotInfo[1]
        {
          targetSlotInfoList2[Random.Range(0, targetSlotInfoList2.Count)]
        };
      }
      if (targetSlotInfoList3.Count <= 0)
        return new TargetSlotInfo[0];
      if (!this.onlyOne)
        return targetSlotInfoList3.ToArray();
      return new TargetSlotInfo[1]
      {
        targetSlotInfoList3[Random.Range(0, targetSlotInfoList3.Count)]
      };
    }
  }
}
