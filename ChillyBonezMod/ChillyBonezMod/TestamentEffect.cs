// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.TestamentEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class TestamentEffect : EffectSO
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
      List<CombatAbility> combatAbilityList = new List<CombatAbility>();
      switch (caster)
      {
        case CharacterCombat characterCombat:
          combatAbilityList = new List<CombatAbility>((IEnumerable<CombatAbility>) characterCombat.CombatAbilities);
          break;
        case EnemyCombat enemyCombat:
          combatAbilityList = new List<CombatAbility>((IEnumerable<CombatAbility>) enemyCombat.Abilities);
          break;
      }
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.AbilityCount < 6 && target.Unit.CurrentHealth > 0)
        {
          int index = Random.Range(0, combatAbilityList.Count);
          RaritySO instance = ScriptableObject.CreateInstance<RaritySO>();
          instance.rarityValue = 5;
          instance.canBeRerolled = true;
          ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo()
          {
            ability = combatAbilityList[index].ability,
            cost = combatAbilityList[index].cost,
            rarity = instance
          };
          target.Unit.AddExtraAbility(extraAbilityInfo);
          ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
