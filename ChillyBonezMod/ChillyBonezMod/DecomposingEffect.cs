// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DecomposingEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using System;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class DecomposingEffect : EffectSO
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
      if (!caster.IsUnitCharacter)
        return false;
      SpawnCharacterAnywhereEffect instance1 = ScriptableObject.CreateInstance<SpawnCharacterAnywhereEffect>();
      instance1.chara = (caster as CharacterCombat).Character;
      if ((caster as CharacterCombat).Rank <= 0)
        return false;
      instance1._rank = Math.Max(0, (caster as CharacterCombat).Rank - 1);
      instance1._permanentSpawn = true;
      ExtraPassiveAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance2._extraPassiveAbility = Passives.Dying;
      instance1._extraModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance2
      };
      instance1.firstAbil = (caster as CharacterCombat)._firstAbility;
      instance1.secondAbil = (caster as CharacterCombat)._secondAbility;
      CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self)
      }), caster, 0));
      return true;
    }
  }
}
