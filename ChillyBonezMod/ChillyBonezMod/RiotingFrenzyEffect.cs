// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.RiotingFrenzyEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class RiotingFrenzyEffect : EffectSO
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
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && !target.IsTargetCharacterSlot && Random.Range(0, 100) < 35)
        {
          EnemyCombat enemyOnField = stats.TryGetEnemyOnField(target.Unit.ID);
          stats.timeline.TryAddNewExtraEnemyTurns((ITurn) enemyOnField, entryVariable);
          exitAmount += entryVariable;
        }
      }
      return true;
    }
  }
}
