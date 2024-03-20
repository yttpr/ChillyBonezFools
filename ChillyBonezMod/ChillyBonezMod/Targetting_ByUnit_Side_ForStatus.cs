// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Targetting_ByUnit_Side_ForStatus
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections.Generic;

#nullable disable
namespace ChillyBonezMod
{
  public class Targetting_ByUnit_Side_ForStatus : BaseCombatTargettingSO
  {
    public bool getAllies;
    public bool ignoreCastSlot;
    public bool getAllUnitSlots;
    public StatusEffectType statusCheck;

    public override bool AreTargetAllies => this.getAllies;

    public override bool AreTargetSlots => this.getAllUnitSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] allUnitTargetSlots = slots.GetAllUnitTargetSlots(isCasterCharacter && this.getAllies || !isCasterCharacter && !this.getAllies, this.getAllUnitSlots, this.ignoreCastSlot ? casterSlotID : -1);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in allUnitTargetSlots)
      {
        if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.ContainsStatusEffect(this.statusCheck, 0))
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }
  }
}
