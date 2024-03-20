// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.RemoveAndHealDivineProtectionEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class RemoveAndHealDivineProtectionEffect : EffectSO
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
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 10, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          new DivineProtection_StatusEffect(entryVariable, 0).SetEffectInformation(statusEffectInfoSo);
          if (targets[index].Unit.ContainsStatusEffect((StatusEffectType) 10, 0))
          {
            int num = targets[index].Unit.TryRemoveStatusEffect((StatusEffectType) 10);
            exitAmount += targets[index].Unit.Heal(num * 2, (HealType) 0, true);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
