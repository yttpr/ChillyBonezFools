// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ApplyDivineProtectionAlwaysTrueIfTargetEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class ApplyDivineProtectionAlwaysTrueIfTargetEffect : EffectSO
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
      if (entryVariable <= 0)
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 10, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          ++exitAmount;
          DivineProtection_StatusEffect protectionStatusEffect = new DivineProtection_StatusEffect(entryVariable, 0);
          protectionStatusEffect.SetEffectInformation(statusEffectInfoSo);
          targets[index].Unit.ApplyStatusEffect((IStatusEffect) protectionStatusEffect, entryVariable);
        }
      }
      return exitAmount > 0;
    }
  }
}
