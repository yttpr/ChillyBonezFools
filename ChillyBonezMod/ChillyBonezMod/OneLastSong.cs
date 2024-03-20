// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.OneLastSong
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class OneLastSong
  {
    public static void Add()
    {
      EffectItem effectItem1 = new EffectItem();
      effectItem1.name = "Motivational Speaker";
      effectItem1.flavorText = "\"You can do anything!\"";
      effectItem1.description = "Replaces slap on this party member with \"Motivation of the Century\".";
      effectItem1.sprite = ResourceLoader.LoadSprite("moviativespeaker");
      effectItem1.consumeTrigger = (TriggerCalls) 1000;
      effectItem1.unlockableID = (UnlockableID) 444442;
      effectItem1.namePopup = false;
      effectItem1.consumedOnUse = false;
      effectItem1.itemPools = ItemPools.Treasure;
      effectItem1.shopPrice = 3;
      effectItem1.startsLocked = false;
      effectItem1.immediate = true;
      Ability ability = new Ability();
      ability.sprite = ResourceLoader.LoadSprite("yougotthis");
      ability.name = "Motivation of the Century";
      ability.description = "Make the left ally randomly perform one of their abilities.";
      ability.cost = new ManaColorSO[1]{ Pigments.Purple };
      ability.effects = new Effect[1];
      ability.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability.animationTarget = Slots.Self;
      ability.visuals = (AttackVisualsSO) null;
      effectItem1.equippedModifiers = new WearableStaticModifierSetterSO[1];
      effectItem1.equippedModifiers[0] = (WearableStaticModifierSetterSO) ScriptableObject.CreateInstance<BasicAbilityChange_Wearable_SMS>();
      ((BasicAbilityChange_Wearable_SMS) effectItem1.equippedModifiers[0])._basicAbility = ability.CharacterAbility();
      effectItem1.AddItem();
      EffectItem effectItem2 = new EffectItem();
      effectItem2.name = "Pull the Strings";
      effectItem2.flavorText = "\"Give them a false sense of control.\"";
      effectItem2.description = "Give this party member Multi Attack (2) as a passive. At the start of each turn, exhaust a random other party member.";
      effectItem2.sprite = ResourceLoader.LoadSprite("Pullthestring");
      effectItem2.trigger = (TriggerCalls) 21;
      effectItem2.triggerConditions = new EffectorConditionSO[0];
      effectItem2.consumeTrigger = (TriggerCalls) 1000;
      effectItem2.unlockableID = (UnlockableID) 444441;
      effectItem2.namePopup = true;
      effectItem2.consumedOnUse = false;
      effectItem2.itemPools = ItemPools.Treasure;
      effectItem2.shopPrice = 3;
      effectItem2.startsLocked = false;
      effectItem2.immediate = false;
      effectItem2.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RandomTargetExhaustEffect>(), 1, new IntentType?((IntentType) 100), Slots.SlotTarget(new int[8]
        {
          -4,
          -3,
          -2,
          -1,
          1,
          2,
          3,
          4
        }, true))
      };
      PerformDoubleEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "MultiAttack (2)";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("MultiAttackIcon");
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 13;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "This shouldn't be on an enemy.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "This party member can perform two abilities per turn.";
      ((BasePassiveAbilitySO) instance1).specialStoredValue = (UnitStoredValueNames) 77889;
      CasterSetStoredValueEffect instance2 = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
      instance2._valueName = (UnitStoredValueNames) 77889;
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
      });
      RefreshIfStoredValueNotZero instance3 = ScriptableObject.CreateInstance<RefreshIfStoredValueNotZero>();
      instance3._valueName = (UnitStoredValueNames) 77889;
      ScriptableObject.CreateInstance<CasterLowerStoredValueEffect>()._valueName = (UnitStoredValueNames) 77889;
      instance1._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      instance1._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1._secondDoesPerformPopUp = false;
      ExtraPassiveAbility_Wearable_SMS instance4 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance4._extraPassiveAbility = (BasePassiveAbilitySO) instance1;
      effectItem2.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance4
      };
      effectItem2.AddItem();
      EffectItem effectItem3 = new EffectItem();
      effectItem3.name = "Ungodly Relic";
      effectItem3.flavorText = "\"Better not ruin its rarity.\"";
      effectItem3.description = "Round up all damage dealt by this party member to 10. On killing something, destroy this item.";
      effectItem3.sprite = ResourceLoader.LoadSprite("holyfinger");
      effectItem3.trigger = (TriggerCalls) 16;
      effectItem3.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<RoundUpDamageEffectorCondition>()
      };
      effectItem3.consumeTrigger = (TriggerCalls) 24;
      effectItem3.unlockableID = (UnlockableID) 444440;
      effectItem3.namePopup = false;
      effectItem3.consumedOnUse = false;
      effectItem3.itemPools = ItemPools.Treasure;
      effectItem3.shopPrice = 3;
      effectItem3.startsLocked = false;
      effectItem3.immediate = false;
      effectItem3.AddItem();
    }
  }
}
