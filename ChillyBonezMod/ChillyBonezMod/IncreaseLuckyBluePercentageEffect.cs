// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.IncreaseLuckyBluePercentageEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class IncreaseLuckyBluePercentageEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = entryVariable;
      stats.SetLuckyBluePercentage(entryVariable + stats.LuckyManaPercentage);
      return exitAmount > 0;
    }
  }
}
