// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Jelmer
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
  public static class Jelmer
  {
    public static Character Dumbass;
    public static UnitStoredValueNames Stir = (UnitStoredValueNames) 4444438;
    public static UnitStoredValueNames Dive = (UnitStoredValueNames) 4244438;

    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (Jelmer).GetMethod("ValueDisplay", ~BindingFlags.Default));
      Character character = new Character();
      character.name = "Helmspark";
      character.healthColor = Pigments.Red;
      character.entityID = (EntityIDs) 4444438;
      character.passives = new BasePassiveAbilitySO[1]
      {
        Passives.Delicate
      };
      character.usesBaseAbility = true;
      character.usesAllAbilities = false;
      character.overworldSprite = ResourceLoader.LoadSprite("HSoverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("HSfront.png");
      character.backSprite = ResourceLoader.LoadSprite("HSback.png");
      character.lockedSprite = ResourceLoader.LoadSprite("HSMenu.png");
      character.unlockedSprite = ResourceLoader.LoadSprite("HSMenu.png");
      character.menuChar = true;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Hans_CH").dxSound;
      DamageByStoredValueEffect instance1 = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
      instance1._valueName = Jelmer.Stir;
      CasterStoredValueChangeEffect instance2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance2._valueName = Jelmer.Stir;
      instance2._minimumValue = 0;
      instance2._increase = true;
      Ability ability1 = new Ability();
      ability1.name = "Miniscule Stir";
      ability1.description = "Deal 3 damage to the Opposing enemy. \nIf above 65% health, permenantly boost this attack's damage by 2. Otherwise, 35% chance to refresh this party member's abilities. \nThis character takes 2 direct damage not from herself.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability1.sprite = ResourceLoader.LoadSprite("stirmove.png");
      ability1.effects = new Effect[4]
      {
        new Effect((EffectSO) instance1, 3, new IntentType?((IntentType) 1), Slots.Front),
        new Effect((EffectSO) instance2, 2, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) Health65PercentCondition.Create(true)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) MultiEffectAndCondition.Create((EffectConditionSO) Health65PercentCondition.Create(false), (EffectConditionSO) Conditions.Chance(35))),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageNoEmpowerEffect>(), 2, new IntentType?((IntentType) 0), Slots.Self)
      };
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Meager Stir";
      ability2.description = "Deal 4 damage to the Opposing enemy. \nIf above 65% health, permenantly boost this attack's damage by 2. Otherwise, 45% chance to refresh this party member's abilities. \nThis character takes 2 direct damage not from herself.";
      ability2.effects[0]._entryVariable = 4;
      ability2.effects[2]._condition = (EffectConditionSO) MultiEffectAndCondition.Create((EffectConditionSO) Health65PercentCondition.Create(false), (EffectConditionSO) Conditions.Chance(45));
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Subpar Stir";
      ability3.description = "Deal 5 damage to the Opposing enemy. \nIf above 65% health, permenantly boost this attack's damage by 2. Otherwise, 55% chance to refresh this party member's abilities. \nThis character takes 2 direct damage not from herself.";
      ability3.effects[0]._entryVariable = 5;
      ability3.effects[2]._condition = (EffectConditionSO) MultiEffectAndCondition.Create((EffectConditionSO) Health65PercentCondition.Create(false), (EffectConditionSO) Conditions.Chance(55));
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Adequate Stir";
      ability4.description = "Deal 6 damage to the Opposing enemy. \nIf above 65% health, permenantly boost this attack's damage by 2. Otherwise, 65% chance to refresh this party member's abilities. \nThis character takes 2 direct damage not from herself.";
      ability4.effects[0]._entryVariable = 6;
      ability4.effects[2]._condition = (EffectConditionSO) MultiEffectAndCondition.Create((EffectConditionSO) Health65PercentCondition.Create(false), (EffectConditionSO) Conditions.Chance(65));
      Ability ability5 = new Ability();
      ability5.name = "Foresighting the Faulty";
      ability5.description = "If this party member is below 65% of their health, heal them for 4. Otherwise, deal 7 damage to the Opposing enemy and apply 1 Adrenaline to self.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability5.sprite = ResourceLoader.LoadSprite("forsatingmove.png");
      ability5.effects = new Effect[4]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 7, new IntentType?((IntentType) 2), Slots.Front, (EffectConditionSO) Health65PercentCondition.Create(true)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAdrenalineEffect>(), 1, new IntentType?((IntentType) 444442), Slots.Self, (EffectConditionSO) Health65PercentCondition.Create(true)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAdrenalineEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) MultiEffectAndCondition.Create((EffectConditionSO) Health65PercentCondition.Create(true), (EffectConditionSO) Conditions.Chance(0))),
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.Self, (EffectConditionSO) Health65PercentCondition.Create(false))
      };
      ability5.animationTarget = Slots.Self;
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Resolve_1_A").visuals;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Foresighting the Dread";
      ability6.description = "If this party member is below 65% of their health, heal them for 5. Otherwise, deal 8 damage to the Opposing enemy and apply 1-2 Adrenaline to self.";
      ability6.effects[3]._entryVariable = 5;
      ability6.effects[3]._intent = new IntentType?((IntentType) 21);
      ability6.effects[0]._entryVariable = 8;
      ability6.effects[2]._condition = (EffectConditionSO) MultiEffectAndCondition.Create((EffectConditionSO) Health65PercentCondition.Create(true), (EffectConditionSO) Conditions.Chance(50));
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Foresighting the Heinousness";
      ability7.description = "If this party member is below 65% of their health, heal them for 6. Otherwise, deal 9 damage to the Opposing enemy and apply 1-2 Adrenaline to self.";
      ability7.effects[3]._entryVariable = 6;
      ability7.effects[0]._entryVariable = 9;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Foresighting the Atrocities";
      ability8.description = "If this party member is below 65% of their health, heal them for 7. Otherwise, deal 10 damage to the Opposing enemy and apply 2 Adrenaline to self.";
      ability8.effects[3]._entryVariable = 7;
      ability8.effects[0]._entryVariable = 10;
      ability8.effects[2]._condition = (EffectConditionSO) Conditions.Chance(0);
      DamageByStoredValueEffect instance3 = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
      instance3._valueName = Jelmer.Dive;
      instance3._increaseDamage = false;
      CasterStoredValueChangeEffect instance4 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance4._valueName = Jelmer.Dive;
      instance4._minimumValue = 0;
      instance4._increase = true;
      Ability ability9 = new Ability();
      ability9.name = "Huge Head Dive";
      ability9.description = "Deal 10 damage to the Opposing enemy. If this character is above 75% of their health, inflict 2 Frail on self, otherwise decrease the damage of this ability by 4. \nThis character takes 3 direct damage not from herself.";
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability9.sprite = ResourceLoader.LoadSprite("headdivemoveset.png");
      ability9.effects = new Effect[4]
      {
        new Effect((EffectSO) instance3, 10, new IntentType?((IntentType) 2), Slots.Front),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, new IntentType?((IntentType) 150), Slots.Self, (EffectConditionSO) Health75PercentCondition.Create(true)),
        new Effect((EffectSO) instance4, 4, new IntentType?(), Slots.Self, (EffectConditionSO) Health75PercentCondition.Create(false)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageNoEmpowerEffect>(), 3, new IntentType?((IntentType) 1), Slots.Self)
      };
      ability9.animationTarget = Slots.Front;
      ability9.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Enormous Head Dive";
      ability10.description = "Deal 13 damage to the Opposing enemy. If this character is above 75% of their health, inflict 2 Frail on self, otherwise decrease the damage of this ability by 3. \nThis character takes 3 direct damage not from herself.";
      ability10.effects[0]._entryVariable = 13;
      ability10.effects[0]._intent = new IntentType?((IntentType) 3);
      ability10.effects[2]._entryVariable = 3;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Humongous Head Dive";
      ability11.description = "Deal 16 damage to the Opposing enemy. If this character is above 75% of their health, inflict 2 Frail on self, otherwise decrease the damage of this ability by 3. \nThis character takes 3 direct damage not from herself.";
      ability11.effects[0]._entryVariable = 16;
      ability11.effects[0]._intent = new IntentType?((IntentType) 4);
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Colossal Head Dive";
      ability12.description = "Deal 16 damage to the Opposing enemy. If this character is above 75% of their health, inflict 2 Frail on self, otherwise decrease the damage of this ability by 2. \nThis character takes 2 direct damage not from herself.";
      ability12.effects[2]._entryVariable = 2;
      ability12.effects[3]._entryVariable = 2;
      ability12.effects[3]._intent = new IntentType?((IntentType) 0);
      character.AddLevel(12, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(14, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(16, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(18, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Jelmer.Dumbass = character;
    }

    public static string ValueDisplay(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == Jelmer.Stir)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Stir" + string.Format(" +{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else if (storedValue == Jelmer.Dive)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str5 = "Dive" + string.Format(" -{0}", (object) value);
          string str6 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
          string str7 = "</color>";
          str1 = str6 + str5 + str7;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }
  }
}
