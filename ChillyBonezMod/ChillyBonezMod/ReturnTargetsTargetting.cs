// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ReturnTargetsTargetting
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class ReturnTargetsTargetting : BaseCombatTargettingSO
  {
    public TargetSlotInfo[] targets;

    public override bool AreTargetAllies => true;

    public override bool AreTargetSlots => true;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      return this.targets != null ? this.targets : new TargetSlotInfo[0];
    }
  }
}
