// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.stickoMoFo
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class stickoMoFo
  {
    public static Character Sticky;

    public static void Add()
    {
      ExtraCCSprites_ArraySO instance1 = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
      instance1._doesLoop = false;
      instance1._useDefault = (ExtraSpriteType) 0;
      instance1._useSpecial = (ExtraSpriteType) 557778;
      instance1._frontSprite = new Sprite[1]
      {
        ResourceLoader.LoadSprite("ExtraStickFront")
      };
      instance1._backSprite = new Sprite[1]
      {
        ResourceLoader.LoadSprite("ExtraStickBack")
      };
      DirectHealLessPassiveAbility instance2 = ScriptableObject.CreateInstance<DirectHealLessPassiveAbility>();
      instance2._passiveName = "Malnourished";
      instance2.passiveIcon = ResourceLoader.LoadSprite("stickMalnourished");
      instance2.type = (PassiveAbilityTypes) 4444444;
      instance2._enemyDescription = "All direct healing to this enemy is quartered.";
      instance2._characterDescription = "All direct healing to this character is quartered.";
      instance2.doesPassiveTriggerInformationPanel = false;
      instance2._triggerOn = new TriggerCalls[2]
      {
        (TriggerCalls) 9,
        (TriggerCalls) 40
      };
      Character character = new Character();
      character.name = "Stripstick";
      character.healthColor = Pigments.Red;
      character.entityID = (EntityIDs) 4444444;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance2
      };
      character.usesBaseAbility = false;
      character.usesAllAbilities = true;
      character.overworldSprite = ResourceLoader.LoadSprite("stickMenu", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("stickFront");
      character.backSprite = ResourceLoader.LoadSprite("stickBack");
      character.lockedSprite = ResourceLoader.LoadSprite("MenuPlaceholder");
      character.unlockedSprite = ResourceLoader.LoadSprite("stickMenu");
      character.extraSprites = (ExtraCharacterCombatSpritesSO) instance1;
      character.menuChar = true;
      character.isSupport = true;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").damageSound;
      SetCasterExtraSpritesEffect instance3 = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
      instance3._spriteType = (ExtraSpriteType) 557778;
      ChangeMaxHealthAndHPEffect instance4 = ScriptableObject.CreateInstance<ChangeMaxHealthAndHPEffect>();
      instance4._increase = true;
      PreviousEffectCondition instance5 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance5.wasSuccessful = true;
      Effect effect = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance5);
      HalveScarsEffect instance6 = ScriptableObject.CreateInstance<HalveScarsEffect>();
      Ability ability1 = new Ability();
      ability1.name = "Fast Growth";
      ability1.description = "Increase this party member's max health by 4, indirectly heal them 4, and apply 1 scar to self. \n50% chance to refresh this character.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Gray,
        Pigments.Gray
      };
      ability1.sprite = ResourceLoader.LoadSprite("stickGrowth");
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) instance4, 4, new IntentType?((IntentType) 81), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.Self);
      ability1.effects[2] = new Effect(effect);
      ability1.effects[2]._condition = (EffectConditionSO) Conditions.Chance(50);
      ability1.animationTarget = Slots.Self;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Rapid Growth";
      ability2.description = "Increase this party member's max health by 4, indirectly heal them 5, and apply 1 scar to self. \n60% chance to refresh this character.";
      ability2.effects[0]._entryVariable = 5;
      ability2.effects[2]._condition = (EffectConditionSO) Conditions.Chance(60);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Massive Growth";
      ability3.description = "Increase this party member's max health by 4, indirectly heal them 6, and apply 1 scar to self. \n70% chance to refresh this character.";
      ability3.effects[0]._entryVariable = 6;
      ability3.effects[2]._condition = (EffectConditionSO) Conditions.Chance(70);
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Unstoppable Growth";
      ability4.description = "Increase this party member's max health by 4, indirectly heal them 7, and apply 1 scar to self. \n80% chance to refresh this character.";
      ability4.effects[0]._entryVariable = 7;
      ability4.effects[2]._condition = (EffectConditionSO) Conditions.Chance(80);
      Ability ability5 = new Ability();
      ability5.name = "Alkaline Emanation";
      ability5.description = "Remove all max health from this character above what they would normally have for their rank. Heal all allies by 0.5x the max health lost. \nRemove half of the scars from this character.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Blue,
        Pigments.Blue
      };
      ability5.sprite = ResourceLoader.LoadSprite("stickHeal");
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveMaxHPAndExitSetterEffect>(), 1, new IntentType?((IntentType) 82), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<CustomHealEffect>(), 2, new IntentType?((IntentType) 21), Slots.SlotTarget(new int[8]
      {
        -4,
        -3,
        -2,
        -1,
        1,
        2,
        3,
        4
      }, true));
      ability5.effects[2] = new Effect((EffectSO) instance6, 1, new IntentType?((IntentType) 199), Slots.Self);
      ability5.effects[3] = new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self);
      ability5.visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;
      ability5.animationTarget = Slots.Self;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Refreshing Emanation";
      ability6.description = "Remove all max health from this character above what they would normally have for their rank. Heal all allies by 0.75x the max health lost. \nRemove half of the scars from this character.";
      ability6.effects[1]._entryVariable = 3;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Invigorating Emanation";
      ability7.description = "Remove all max health from this character above what they would normally have for their rank. Heal all allies by the max health lost. Remove \nhalf of the scars from this character.";
      ability7.effects[1]._entryVariable = 4;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Restorative Emanation";
      ability8.description = "Remove all max health from this character above what they would normally have for their rank. Heal all allies by 1.5x the max health lost. \nRemove half of the scars from this character.";
      ability8.effects[1]._entryVariable = 6;
      Ability ability9 = ability5.Duplicate();
      ability9.name = "Harmful Emission";
      ability9.description = "Remove all max health from this character above what they would normally have for their rank. Deal indirect damage to all enemies worth 0.5x the max health lost. \nRemove half of the scars from this character.";
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Blue
      };
      ability9.sprite = ResourceLoader.LoadSprite("stickHurt");
      ability9.effects[1]._effect = (EffectSO) ScriptableObject.CreateInstance<CustomDamageEffect>();
      Targetting_ByUnit_Side instance7 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance7.getAllies = false;
      instance7.getAllUnitSlots = false;
      ability9.effects[1]._target = (BaseCombatTargettingSO) instance7;
      ability9.effects[1]._intent = new IntentType?((IntentType) 1);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Noxious Emission";
      ability10.description = "Remove all max health from this character above what they would normally have for their rank. Deal indirect damage to all enemies worth 0.75x the max health lost. \nRemove half of the scars from this character.";
      ability10.effects[1]._entryVariable = 3;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Pestilential Emission";
      ability11.description = "Remove all max health from this character above what they would normally have for their rank. Deal indirect damage to all enemies worth the max health lost. \nRemove half of the scars from this character.";
      ability11.effects[1]._entryVariable = 4;
      ability11.effects[1]._intent = new IntentType?((IntentType) 2);
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Virulent Emission";
      ability12.description = "Remove all max health from this character above what they would normally have for their rank. Deal indirect damage to all enemies worth 1.5x the max health lost. \nRemove half of the scars from this character.";
      ability12.effects[1]._entryVariable = 6;
      character.AddLevel(8, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(8, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(8, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(8, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      stickoMoFo.Sticky = character;
    }
  }
}
