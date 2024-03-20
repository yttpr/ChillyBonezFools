// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.RemoveTargetTimelineBulletsEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class RemoveTargetTimelineBulletsEffect : EffectSO
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
        if (target.HasUnit && !target.IsTargetCharacterSlot)
        {
          EnemyCombat enemyOnField = stats.TryGetEnemyOnField(target.Unit.ID);
          int num = stats.timeline.TryRemoveRandomEnemyTurns(enemyOnField, entryVariable);
          if (num <= 0)
            enemyOnField.Damage(20, (IUnit) null, (DeathType) 1, -1, false, false, true, (DamageType) 0);
          exitAmount += num;
        }
      }
      return exitAmount > 0;
    }
  }
}
