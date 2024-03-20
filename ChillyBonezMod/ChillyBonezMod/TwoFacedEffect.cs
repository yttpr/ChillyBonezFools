// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.TwoFacedEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;

#nullable disable
namespace ChillyBonezMod
{
  public class TwoFacedEffect : EffectSO
  {
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
        if (target.HasUnit && target.Unit.AddPassiveAbility(Passives.TwoFaced))
          ++exitAmount;
      }
      if (exitAmount > 0)
        return true;
      caster.AddPassiveAbility(Passives.TwoFaced);
      return false;
    }
  }
}
