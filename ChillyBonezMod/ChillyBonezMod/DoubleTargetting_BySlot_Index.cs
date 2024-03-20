// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DoubleTargetting_BySlot_Index
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections.Generic;

#nullable disable
namespace ChillyBonezMod
{
  public class DoubleTargetting_BySlot_Index : BaseCombatTargettingSO
  {
    public bool getAllies;
    public int[] slotPointerDirections;
    public bool allSelfSlots;
    public bool secondGetAllies;
    public int[] secondSlotPointers;
    public bool secondAllSelfSlots;

    public override bool AreTargetAllies => this.getAllies;

    public override bool AreTargetSlots => true;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      for (int index = 0; index < this.slotPointerDirections.Length; ++index)
      {
        if (!this.getAllies && this.slotPointerDirections[index] == 0)
          targetSlotInfoList.AddRange((IEnumerable<TargetSlotInfo>) slots.GetFrontOpponentSlotTargets(casterSlotID, isCasterCharacter));
        else if (this.allSelfSlots && this.getAllies && this.slotPointerDirections[index] == 0)
          targetSlotInfoList.AddRange((IEnumerable<TargetSlotInfo>) slots.GetAllSelfSlots(casterSlotID, isCasterCharacter));
        else if (this.getAllies)
        {
          TargetSlotInfo allySlotTarget = slots.GetAllySlotTarget(casterSlotID, this.slotPointerDirections[index], isCasterCharacter);
          if (allySlotTarget != null)
            targetSlotInfoList.Add(allySlotTarget);
        }
        else
        {
          TargetSlotInfo opponentSlotTarget = slots.GetOpponentSlotTarget(casterSlotID, this.slotPointerDirections[index], isCasterCharacter);
          if (opponentSlotTarget != null)
            targetSlotInfoList.Add(opponentSlotTarget);
        }
      }
      if (this.secondSlotPointers == null)
        return targetSlotInfoList.ToArray();
      for (int index = 0; index < this.secondSlotPointers.Length; ++index)
      {
        if (!this.secondGetAllies && this.secondSlotPointers[index] == 0)
          targetSlotInfoList.AddRange((IEnumerable<TargetSlotInfo>) slots.GetFrontOpponentSlotTargets(casterSlotID, isCasterCharacter));
        else if (this.secondAllSelfSlots && this.secondGetAllies && this.secondSlotPointers[index] == 0)
          targetSlotInfoList.AddRange((IEnumerable<TargetSlotInfo>) slots.GetAllSelfSlots(casterSlotID, isCasterCharacter));
        else if (this.secondGetAllies)
        {
          TargetSlotInfo allySlotTarget = slots.GetAllySlotTarget(casterSlotID, this.secondSlotPointers[index], isCasterCharacter);
          if (allySlotTarget != null)
            targetSlotInfoList.Add(allySlotTarget);
        }
        else
        {
          TargetSlotInfo opponentSlotTarget = slots.GetOpponentSlotTarget(casterSlotID, this.secondSlotPointers[index], isCasterCharacter);
          if (opponentSlotTarget != null)
            targetSlotInfoList.Add(opponentSlotTarget);
        }
      }
      return targetSlotInfoList.ToArray();
    }
  }
}
