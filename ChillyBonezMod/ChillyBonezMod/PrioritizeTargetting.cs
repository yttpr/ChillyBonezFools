// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.PrioritizeTargetting
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class PrioritizeTargetting : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO priority;
    public BaseCombatTargettingSO sub;

    public override bool AreTargetAllies
    {
      get => this.priority.AreTargetAllies && this.sub.AreTargetAllies;
    }

    public override bool AreTargetSlots => this.priority.AreTargetSlots && this.sub.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets1 = this.priority.GetTargets(slots, casterSlotID, isCasterCharacter);
      TargetSlotInfo[] targets2 = this.sub.GetTargets(slots, casterSlotID, isCasterCharacter);
      TargetSlotInfo[] targets3 = new TargetSlotInfo[0];
      bool flag = false;
      foreach (TargetSlotInfo targetSlotInfo in targets1)
      {
        if (targetSlotInfo.HasUnit)
        {
          flag = true;
          targets3 = targets1;
        }
      }
      if (!flag)
        targets3 = targets2;
      return targets3;
    }

    public static PrioritizeTargetting Create(
      BaseCombatTargettingSO first,
      BaseCombatTargettingSO second)
    {
      PrioritizeTargetting instance = ScriptableObject.CreateInstance<PrioritizeTargetting>();
      instance.priority = first;
      instance.sub = second;
      return instance;
    }
  }
}
