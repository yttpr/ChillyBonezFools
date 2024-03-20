// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.BigGun
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Tools;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class BigGun
  {
    public static Character Balls;
    public static UnitStoredValueNames bullets = (UnitStoredValueNames) 4444436;
    public static UnitStoredValueNames abom = (UnitStoredValueNames) 4044436;
    public static UnitStoredValueNames count = (UnitStoredValueNames) 4224436;

    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (BigGun).GetMethod("ValueDisplay", ~BindingFlags.Default));
      CasterStoredValueChangeEffect instance1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance1._valueName = BigGun.abom;
      instance1._minimumValue = 0;
      instance1._increase = false;
      PreviousEffectCondition instance2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance2.wasSuccessful = true;
      PerformEffectPassiveAbility instance3 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance3)._passiveName = "Ballsy";
      ((BasePassiveAbilitySO) instance3).passiveIcon = ResourceLoader.LoadSprite("hahaballs.png");
      ((BasePassiveAbilitySO) instance3).type = (PassiveAbilityTypes) 4444436;
      ((BasePassiveAbilitySO) instance3)._enemyDescription = "This enemy gains an additional action for every turn it remains alive.";
      ((BasePassiveAbilitySO) instance3)._characterDescription = "This party member is ballsy and gains an additional action for every turn they remain alive.";
      ((BasePassiveAbilitySO) instance3).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance3)._triggerOn = new TriggerCalls[2]
      {
        (TriggerCalls) 14,
        (TriggerCalls) 7
      };
      ((BasePassiveAbilitySO) instance3).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<BallsyCondition>()
      };
      instance3.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance2)
      });
      Character character = new Character();
      character.name = "Champ";
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 4444436;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance3
      };
      character.usesBaseAbility = false;
      character.usesAllAbilities = true;
      character.overworldSprite = ResourceLoader.LoadSprite("champoverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("champfront.png");
      character.backSprite = ResourceLoader.LoadSprite("champback.png");
      character.lockedSprite = ResourceLoader.LoadSprite("champmenu.png");
      character.unlockedSprite = ResourceLoader.LoadSprite("champmenu.png");
      character.menuChar = WhereDaFlarbz.Debugger;
      character.appearsInShops = true;
      character.isSupport = true;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetSpeakerData("Osman" + PathUtils.speakerDataSuffix)._defaultBundle.dialogueSound;
      character.levels = new CharacterRankedData[1];
      CasterStoredValueChangeEffect instance4 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance4._valueName = BigGun.bullets;
      instance4._minimumValue = 0;
      instance4._increase = false;
      CasterStoredValueChangeEffect instance5 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance5._valueName = BigGun.bullets;
      instance5._minimumValue = 0;
      instance5._increase = true;
      ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
      ScriptableObject.CreateInstance<DamageEffect>()._indirect = true;
      Ability ability1 = new Ability();
      ability1.name = "Man Off";
      ability1.description = "For each Bullet, 20% chance to remove 1 action from the Opposing enemy, if no more actions can be removed deal 20 indirect damage to the Opposing enemy. \nFor each Bullet there is also a 8% chance to deal 20 damage to this character and Remove 1 Bullet.";
      ability1.cost = new ManaColorSO[1]{ Pigments.Gray };
      ability1.sprite = ResourceLoader.LoadSprite("manoffmove.png");
      ability1.effects = new Effect[4]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveTargetTimelineBulletsEffect>(), 1, new IntentType?((IntentType) 100), Slots.Front, (EffectConditionSO) ScriptableObject.CreateInstance<BulletCondition>()),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 6), Slots.Front),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 20, new IntentType?((IntentType) 6), Slots.Self, (EffectConditionSO) ScriptableObject.CreateInstance<LessBulletCondition>()),
        new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance2)
      };
      ability1.animationTarget = Slots.Self;
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals;
      Ability ability2 = new Ability();
      ability2.name = "Man Up";
      ability2.description = "Insert 1 Bullet and refresh this character's movement.";
      ability2.cost = new ManaColorSO[1]{ Pigments.Yellow };
      ability2.sprite = ResourceLoader.LoadSprite("manupmove.png");
      ability2.effects = new Effect[2]
      {
        new Effect((EffectSO) instance5, 1, new IntentType?((IntentType) 100), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self)
      };
      ability2.animationTarget = Slots.Self;
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
      Targetting_ByUnit_Side instance6 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance6.getAllies = true;
      instance6.getAllUnitSlots = false;
      Targetting_ByUnit_Side instance7 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance7.getAllies = false;
      instance7.getAllUnitSlots = false;
      character.AddLevel(21, new Ability[3]
      {
        ability1,
        ability2,
        new Ability()
        {
          name = "Man Power",
          description = "For each Bullet, there is a 20% chance to shuffle all enemies, apply 1-2 Adrenaline to all party members, and 0-1 Adrenaline to all enemies. \nIf successful, remove 1 Bullet.",
          cost = new ManaColorSO[1]{ Pigments.Gray },
          sprite = ResourceLoader.LoadSprite("manpowerskill.png"),
          effects = new Effect[4]
          {
            new Effect((EffectSO) instance4, 1, new IntentType?(), (BaseCombatTargettingSO) instance6, (EffectConditionSO) ScriptableObject.CreateInstance<BulletCondition>()),
            new Effect((EffectSO) ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, new IntentType?((IntentType) 43), (BaseCombatTargettingSO) instance7, (EffectConditionSO) DidThat.Create(true)),
            new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAdrenalineUpToPlusOneEffect>(), 1, new IntentType?((IntentType) 444442), (BaseCombatTargettingSO) instance6, (EffectConditionSO) DidThat.Create(true, 2)),
            new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAdrenalineUpToPlusOneEffect>(), 0, new IntentType?((IntentType) 444442), (BaseCombatTargettingSO) instance7, (EffectConditionSO) DidThat.Create(true, 3))
          },
          animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create(Slots.SlotTarget(new int[9]
          {
            -4,
            -3,
            -2,
            -1,
            0,
            1,
            2,
            3,
            4
          }), Slots.SlotTarget(new int[8]
          {
            -4,
            -3,
            -2,
            -1,
            1,
            2,
            3,
            4
          }, true)),
          visuals = LoadedAssetsHandler.GetEnemyAbility("Rupture_A").visuals
        }
      }, 0);
      character.AddCharacter();
      BigGun.Balls = character;
    }

    public static string ValueDisplay(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == BigGun.bullets)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Bullets:" + string.Format(" {0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else if (storedValue == BigGun.abom)
      {
        if (value <= 0 || !CombatManager.Instance._stats.IsPlayerTurn)
        {
          str1 = "";
        }
        else
        {
          string str5 = "Ballsy" + string.Format(" +{0}", (object) value);
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
