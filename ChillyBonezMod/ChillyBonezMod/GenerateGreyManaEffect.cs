// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.GenerateGreyManaEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;

#nullable disable
namespace ChillyBonezMod
{
  public class GenerateGreyManaEffect : EffectSO
  {
    public bool usePreviousExitValue;
    public ManaColorSO mana = Pigments.Gray;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this.usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = entryVariable;
      this.mana.canGenerateMana = true;
      CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new AddManaToManaBarAction(this.mana, entryVariable, caster.IsUnitCharacter, caster.ID), false);
      this.mana.canGenerateMana = false;
      return true;
    }
  }
}
