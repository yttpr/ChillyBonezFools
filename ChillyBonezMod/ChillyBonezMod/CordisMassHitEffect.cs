// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CordisMassHitEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class CordisMassHitEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int num1 = 0;
      exitAmount = 0;
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
      {
        if (characterCombat.IsAlive && characterCombat != caster)
          ++num1;
      }
      int num2 = num1 * entryVariable;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          exitAmount += target.Unit.Damage(num2, caster, (DeathType) 1, -1, false, false, true, (DamageType) 0).damageAmount;
      }
      return exitAmount > 0;
    }
  }
}
