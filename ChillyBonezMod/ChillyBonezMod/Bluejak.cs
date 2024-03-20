// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Bluejak
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class Bluejak
  {
    public static Character Blue;

    public static void Add()
    {
      PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Seamless";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("seamlesspassvie.png");
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 4444437;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "On using an ability, increase the Lucky Pigment production chance by 5%.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "This party member blends in with the flow and increases the lucky pigment production percent by 5 upon performing an ability.";
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<IncreaseLuckyBluePercentageEffect>(), 5, new IntentType?(), Slots.Self)
      });
      Character character = new Character();
      character.name = "CaptainCobalt";
      character.healthColor = Pigments.Blue;
      character.entityID = (EntityIDs) 4444437;
      character.usesBaseAbility = true;
      character.usesAllAbilities = false;
      character.overworldSprite = ResourceLoader.LoadSprite("CCoverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("CCfront.png");
      character.backSprite = ResourceLoader.LoadSprite("CCback.png");
      character.lockedSprite = ResourceLoader.LoadSprite("CCoverworld.png");
      character.unlockedSprite = ResourceLoader.LoadSprite("CCoverworld.png");
      character.menuChar = WhereDaFlarbz.Debugger;
      character.appearsInShops = true;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Anton_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Anton_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Anton_CH").dxSound;
      character.passives = new BasePassiveAbilitySO[2]
      {
        Passives.Slippery,
        (BasePassiveAbilitySO) instance1
      };
      DamageEffect instance2 = ScriptableObject.CreateInstance<DamageEffect>();
      instance2._indirect = true;
      PreviousEffectCondition instance3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance3.wasSuccessful = true;
      Ability ability1 = new Ability();
      ability1.name = "Flowing Streams";
      ability1.description = "Deal 6 indirect damage to the Opposing enemy. \nIf Wrong Pigment was not used, this ability has a 5% chance to refresh this party member's ability usage for every Blue Pigment in the tray.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Yellow
      };
      ability1.sprite = ResourceLoader.LoadSprite("streams.png");
      ability1.effects = new Effect[3]
      {
        new Effect((EffectSO) instance2, 6, new IntentType?((IntentType) 1), Slots.Front),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DetectWrongPigmentEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) BlueEffectCondition.Create(5)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) instance3)
      };
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Flowing Rivers";
      ability2.description = "Deal 6 indirect damage to the Opposing enemy. \nIf Wrong Pigment was not used, this ability has a 6% chance to refresh this party member's ability usage for every Blue Pigment in the tray.";
      ability2.effects[1]._condition = (EffectConditionSO) BlueEffectCondition.Create(6);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Flowing Currents";
      ability3.description = "Deal 6 indirect damage to the Opposing enemy. \nIf Wrong Pigment was not used, this ability has a 7% chance to refresh this party member's ability usage for every Blue Pigment in the tray.";
      ability3.effects[1]._condition = (EffectConditionSO) BlueEffectCondition.Create(7);
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Flowing Surges";
      ability4.description = "Deal 6 indirect damage to the Opposing enemy. \nIf Wrong Pigment was not used, this ability has an 8% chance to refresh this party member's ability usage for every Blue Pigment in the tray.";
      ability4.effects[1]._condition = (EffectConditionSO) BlueEffectCondition.Create(8);
      GenerateColorManaEffect instance4 = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
      instance4.mana = Pigments.Blue;
      Ability ability5 = new Ability();
      ability5.name = "Crashing Ripples";
      ability5.description = "Deal 2 + the amount of Blue Pigment in the tray as damage to the Opposing enemy. Produce 1 Blue Pigment.";
      ability5.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability5.sprite = ResourceLoader.LoadSprite("crashing.png");
      ability5.effects = new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamagePlusBlueEffect>(), 2, new IntentType?((IntentType) 3), Slots.Front),
        new Effect((EffectSO) instance4, 1, new IntentType?((IntentType) 60), Slots.Self)
      };
      ability5.animationTarget = Slots.Front;
      ability5.visuals = LoadedAssetsHandler.GetEnemy("SmoothSkin_BOSS").abilities[0].ability.visuals;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Crashing Waves";
      ability6.description = "Deal 7 + the amount of Blue Pigment in the tray as damage to the Opposing enemy. Produce 2 Blue Pigment.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability6.effects[0]._entryVariable = 7;
      ability6.effects[1]._entryVariable = 2;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Crashing Tides";
      ability7.description = "Deal 10 + the amount of Blue Pigment in the tray as damage to the Opposing enemy. Produce 3 Blue Pigment.";
      ability7.effects[0]._entryVariable = 10;
      ability7.effects[0]._intent = new IntentType?((IntentType) 4);
      ability7.effects[1]._entryVariable = 3;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Crashing Oceans";
      ability8.description = "Deal 15 + the amount of Blue Pigment in the tray as damage to the Opposing enemy. Produce 4 Blue Pigment.";
      ability8.effects[0]._entryVariable = 15;
      ability8.effects[1]._entryVariable = 4;
      ability8.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Blue
      };
      ChangeToRandomHealthColorEffect instance5 = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
      instance5._healthColors = new ManaColorSO[1]
      {
        Pigments.Blue
      };
      AnimationVisualsEffect instance6 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
      instance6._animationTarget = Slots.Front;
      instance6._visuals = LoadedAssetsHandler.GetCharacterAbility("Amalgam_1_A").visuals;
      Ability ability9 = new Ability();
      ability9.name = "Glass Sand";
      ability9.description = "Move Left or Right and deal 6 dry damage to the Opposing enemy, then change their health color to Blue. \nDeals 50% more damage to Blue enemies.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability9.sprite = ResourceLoader.LoadSprite("glass.png");
      ability9.effects = new Effect[4]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self),
        new Effect((EffectSO) instance6, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DryDamageMoreIfBlueEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front),
        new Effect((EffectSO) instance5, 1, new IntentType?((IntentType) 63), Slots.Front)
      };
      ability9.animationTarget = Slots.Self;
      ability9.visuals = (AttackVisualsSO) null;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Glass Shores";
      ability10.description = "Move Left or Right and deal 8 dry damage to the Opposing enemy, then change their health color to Blue. \nDeals 50% more damage to Blue enemies.";
      ability10.effects[2]._entryVariable = 8;
      ability10.effects[2]._intent = new IntentType?((IntentType) 2);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Glass Beaches";
      ability11.description = "Move Left or Right and deal 10 dry damage to the Opposing enemy, then change their health color to Blue. \nDeals 50% more damage to Blue enemies.";
      ability11.effects[2]._entryVariable = 10;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Glass Seas";
      ability12.description = "Move Left or Right and deal 12 dry damage to the Opposing enemy, then change their health color to Blue. \nDeals 50% more damage to Blue enemies.";
      ability12.cost = new ManaColorSO[2]
      {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Red),
        Pigments.Blue
      };
      ability12.effects[2]._entryVariable = 12;
      ability12.effects[2]._intent = new IntentType?((IntentType) 3);
      character.AddLevel(11, new Ability[3]
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
      character.AddLevel(17, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(19, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Bluejak.Blue = character;
      LoadedAssetsHandler.GetCharcater("CaptainCobalt_CH")._characterName = "Captain Cobalt";
    }
  }
}
