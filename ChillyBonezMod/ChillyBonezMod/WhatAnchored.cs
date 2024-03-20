// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.WhatAnchored
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class WhatAnchored
  {
    public static Character Tard;

    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (WhatAnchored).GetMethod("SharpStepDisplay", ~BindingFlags.Default));
      CasterStoredValueChangeEffect instance1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance1._minimumValue = 0;
      instance1._valueName = (UnitStoredValueNames) 444441;
      instance1._increase = true;
      CasterStoreValueSetterEffect instance2 = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
      instance2._valueName = (UnitStoredValueNames) 444441;
      CasterStoredValueChangeEffect instance3 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance3._minimumValue = 0;
      instance3._valueName = (UnitStoredValueNames) 144444;
      instance3._increase = false;
      ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>()._valueName = instance3._valueName;
      DamageByStoredValueEffect instance4 = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
      instance4._valueName = (UnitStoredValueNames) 444441;
      instance4._indirect = true;
      PerformEffectPassiveAbility instance5 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance5)._passiveName = "Sharp Step (2)";
      ((BasePassiveAbilitySO) instance5).passiveIcon = ResourceLoader.LoadSprite("guppyPassive");
      ((BasePassiveAbilitySO) instance5).type = (PassiveAbilityTypes) 444441;
      ((BasePassiveAbilitySO) instance5)._enemyDescription = "Upon moving, deal a certain amount of indirect damage to the opposing party member.";
      ((BasePassiveAbilitySO) instance5)._characterDescription = "Upon moving, deal a certain amount of indirect damage to the opposing enemy";
      ((BasePassiveAbilitySO) instance5).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance5).specialStoredValue = (UnitStoredValueNames) 444441;
      ((BasePassiveAbilitySO) instance5)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 8
      };
      instance5.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance4, 2, new IntentType?(), Slots.Front)
      });
      CustomNoMovePassiveAbility instance6 = ScriptableObject.CreateInstance<CustomNoMovePassiveAbility>();
      instance6._passiveName = "Steadfast";
      instance6.passiveIcon = ResourceLoader.LoadSprite("PassivePlaceholder");
      instance6.type = (PassiveAbilityTypes) 441111;
      instance6._enemyDescription = "huhh??";
      instance6._characterDescription = "This party member cannot be swapped into.";
      instance6.doesPassiveTriggerInformationPanel = false;
      instance6.specialStoredValue = (UnitStoredValueNames) 444111;
      instance6._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 15
      };
      PerformEffectPassiveAbility instance7 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance7)._passiveName = "Panic Attack";
      ((BasePassiveAbilitySO) instance7).passiveIcon = LoadedAssetsHandler.GetCharcater("Arnold_CH").passiveAbilities[0].passiveIcon;
      ((BasePassiveAbilitySO) instance7).type = (PassiveAbilityTypes) 443111;
      ((BasePassiveAbilitySO) instance7)._enemyDescription = "Upon receiving direct damage, lose all boosts to Sharp Step.";
      ((BasePassiveAbilitySO) instance7)._characterDescription = "Upon receiving direct damage, lose all boosts to Sharp Step.";
      ((BasePassiveAbilitySO) instance7).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance7)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 12
      };
      instance7.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance2, 0, new IntentType?(), Slots.Self)
      });
      Character character = new Character();
      character.name = "Guppy";
      character.healthColor = Pigments.Blue;
      character.entityID = (EntityIDs) 4444441;
      character.passives = new BasePassiveAbilitySO[2]
      {
        (BasePassiveAbilitySO) instance5,
        (BasePassiveAbilitySO) instance7
      };
      character.overworldSprite = ResourceLoader.LoadSprite("guppyOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("guppyFront");
      character.backSprite = ResourceLoader.LoadSprite("guppyBack");
      character.lockedSprite = ResourceLoader.LoadSprite("MenuPlaceholder");
      character.unlockedSprite = ResourceLoader.LoadSprite("guppyMenu");
      character.menuChar = true;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound;
      PreviousEffectCondition instance8 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance8.wasSuccessful = true;
      Effect effect = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance8);
      Ability ability1 = new Ability();
      ability1.name = "Sharpen the Twig";
      ability1.description = "Deal 5 damage to the opposing enemy. \nIf damage was dealt, increase Sharp Step by 2.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ResourceLoader.LoadSprite("guppySharpen");
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) instance8);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(0));
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
      ability1.animationTarget = Slots.Front;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Sharpen the Spear";
      ability2.description = "Deal 6 damage to the opposing enemy. \nIf damage was dealt, increase Sharp Step by 2.";
      ability2.effects[0]._entryVariable = 6;
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Sharpen the Edge";
      ability3.description = "Deal 7 damage to the opposing enemy. \nIf damage was dealt, increase Sharp Step by 3.";
      ability3.effects[0]._entryVariable = 7;
      ability3.effects[0]._intent = new IntentType?((IntentType) 2);
      ability3.effects[1]._entryVariable = 3;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Sharpen the Blade";
      ability4.description = "Deal 7 damage to the opposing enemy. \nIf damage was dealt, increase Sharp Step by 4.";
      ability4.effects[0]._entryVariable = 7;
      ability4.effects[1]._entryVariable = 4;
      NestSingleEffectEffect instance9 = ScriptableObject.CreateInstance<NestSingleEffectEffect>();
      instance9._effect = (EffectSO) instance1;
      Ability ability5 = new Ability();
      ability5.name = "Shredding Their Flesh";
      ability5.description = "Deal 7 damage to the opposing enemy. Move left or right 3 times. Increase Sharp Step by 1.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Red
      };
      ability5.sprite = ResourceLoader.LoadSprite("guppyShred");
      ability5.effects = new Effect[5];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 7, new IntentType?((IntentType) 2), Slots.Front);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO) Conditions.Chance(0));
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ShredMove3TimesEffect>(), 30, new IntentType?((IntentType) 40), Slots.Self);
      ability5.effects[3] = new Effect((EffectSO) instance9, 1, new IntentType?((IntentType) 100), Slots.Self);
      ability5.effects[4] = new Effect((EffectSO) instance9, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(0));
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Skewer_1_A").visuals;
      ability5.animationTarget = Slots.Front;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Shredding Their Bones";
      ability6.description = "Deal 7 damage to the opposing enemy. Move left or right 3 times. Increase Sharp Step by 2.";
      ability6.effects[0]._entryVariable = 7;
      ability6.effects[0]._intent = new IntentType?((IntentType) 2);
      ability6.effects[3]._entryVariable = 2;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Shredding Their Hopes";
      ability7.description = "Deal 9 damage and apply 3 Ruptured to the opposing enemy. Move left or right 3 times. Increase Sharp Step by 2.";
      ability7.effects[0]._entryVariable = 9;
      ability7.effects[1]._entryVariable = 3;
      ability7.effects[1]._condition = (EffectConditionSO) Conditions.Chance(100);
      ability7.effects[1]._intent = new IntentType?((IntentType) 151);
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Shredding Their Existence";
      ability8.description = "Deal 9 damage and apply 3 Ruptured to the opposing enemy. Move left or right 3 times. Increase Sharp Step by 3-4.";
      ability8.effects[3]._entryVariable = 3;
      ability8.effects[4]._condition = (EffectConditionSO) Conditions.Chance(50);
      Ability ability9 = new Ability();
      ability9.name = "Improvised Slices";
      ability9.description = "Deal 5 damage to the opposing enemy and move left or right. \nRepeat this 3 times total, each consecutive time decreasing damage by 1-3.\nDamage is reset upon using this ability again.";
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Red
      };
      ability9.sprite = ResourceLoader.LoadSprite("guppySlices");
      ability9.effects = new Effect[3];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<SlicesMove3TimesEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front);
      ability9.effects[1] = new Effect((EffectSO) instance1, 0, new IntentType?((IntentType) 40), Slots.Self, (EffectConditionSO) Conditions.Chance(0));
      ability9.effects[2] = new Effect((EffectSO) instance1, 0, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) Conditions.Chance(0));
      ability9.visuals = (AttackVisualsSO) null;
      ability9.animationTarget = Slots.Front;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Unrehearsed Slices";
      ability10.description = "Deal 7 damage to the opposing enemy and move left or right. \nRepeat this 3 times total, each consecutive time decreasing damage by 1-3.\nDamage is reset upon using this ability again.";
      ability10.effects[0]._entryVariable = 7;
      ability10.effects[0]._intent = new IntentType?((IntentType) 2);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Choreographed Slices";
      ability11.description = "Deal 9 damage to the opposing enemy and move left or right. \nRepeat this 3 times total, each consecutive time decreasing damage by 1-3.\nDamage is reset upon using this ability again.";
      ability11.effects[0]._entryVariable = 9;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Orchestrated Slices";
      ability12.description = "Deal 11 damage to the opposing enemy and move left or right. \nRepeat this 3 times total, each consecutive time decreasing damage by 1-3.\nDamage is reset upon using this ability again.";
      ability12.effects[0]._entryVariable = 11;
      ability12.effects[0]._intent = new IntentType?((IntentType) 3);
      character.AddLevel(12, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(15, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(18, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(21, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      WhatAnchored.Tard = character;
    }

    public static string SharpStepDisplay(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)444441)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Sharp Step" + string.Format(" +{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.cyan) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }
  }
}
