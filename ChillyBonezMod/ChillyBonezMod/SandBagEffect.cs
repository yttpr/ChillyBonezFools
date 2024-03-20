// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SandBagEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class SandBagEffect : EffectSO
  {
    public IUnit kill;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (caster.HasUsableItem)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(caster.ID, caster.HeldItem._itemName, false, caster.HeldItem.wearableImage));
      DamageInfo damageInfo = this.kill.Damage(caster.WillApplyDamage(12, this.kill), caster, (DeathType) 1, -1, true, true, false, (DamageType) 0);
      exitAmount += damageInfo.damageAmount;
      return exitAmount > 0;
    }
  }
}
