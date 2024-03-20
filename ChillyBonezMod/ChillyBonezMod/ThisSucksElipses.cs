// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ThisSucksElipses
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class ThisSucksElipses
  {
    public static Character Chorcer;

    public static void Add()
    {
      Character character = new Character();
      character.name = "Cordis";
      character.healthColor = Pigments.Red;
      character.entityID = (EntityIDs) 4444439;
      character.overworldSprite = ResourceLoader.LoadSprite("smallcordis", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("cordisfront");
      character.backSprite = ResourceLoader.LoadSprite("cordisback");
      character.lockedSprite = ResourceLoader.LoadSprite("smallercordis");
      character.unlockedSprite = ResourceLoader.LoadSprite("smallercordis");
      character.menuChar = true;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").dxSound;
      PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Hex";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("hexpassvie");
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 444440;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "Upon killing, apply Hexed to self.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "Upon killing, apply Hexed to self.";
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 24
      };
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyHexedEffect>(), 1, new IntentType?((IntentType) 444440), Slots.Self)
      });
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance1
      };
      ExtraCCSprites_ArraySO instance2 = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
      instance2._doesLoop = false;
      instance2._useDefault = (ExtraSpriteType) 0;
      instance2._useSpecial = (ExtraSpriteType) 4444439;
      instance2._frontSprite = new Sprite[1]
      {
        ResourceLoader.LoadSprite("freakyfront.png")
      };
      instance2._backSprite = new Sprite[1]
      {
        ResourceLoader.LoadSprite("freakyback.png")
      };
      character.extraSprites = (ExtraCharacterCombatSpritesSO) instance2;
      PreviousEffectCondition instance3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance3.wasSuccessful = true;
      Effect effect = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance3);
      ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>()._consumeMana = Pigments.Purple;
      Targetting_ByUnit_Side instance4 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance4.getAllies = false;
      instance4.getAllUnitSlots = false;
      ChangeMaxHealthEffect instance5 = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
      instance5._increase = false;
      DoubleTargetting instance6 = ScriptableObject.CreateInstance<DoubleTargetting>();
      instance6.firstTargetting = (BaseCombatTargettingSO) instance4;
      instance6.secondTargetting = Slots.Self;
      Ability ability1 = new Ability();
      ability1.name = "Weaken the Crowd";
      ability1.description = "For every other party member in combat, deal 2 indirect damage to all enemies. Decrease this party member's max health by 2.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ResourceLoader.LoadSprite("cowrdcontrol");
      ability1.effects = new Effect[2];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<CordisMassHitEffect>(), 2, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) instance4);
      ability1.effects[1] = new Effect((EffectSO) instance5, 2, new IntentType?((IntentType) 81), Slots.Self);
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A").visuals;
      ability1.animationTarget = (BaseCombatTargettingSO) instance6;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Weaken the Masses";
      ability2.description = "For every other party member in combat, deal 2 indirect damage to all enemies. Decrease this party member's max health by 2.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Weaken the Swarm";
      ability3.description = "For every other party member in combat, deal 3 indirect damage to all enemies. Decrease this party member's max health by 3.";
      ability3.effects[0]._entryVariable = 3;
      ability3.effects[1]._entryVariable = 3;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Weaken the Horde";
      ability4.description = "For every other party member in combat, deal 3 indirect damage to all enemies. Decrease this party member's max health by 3";
      ability4.cost = new ManaColorSO[1]{ Pigments.Red };
      CasterStoredValueChangeEffect instance7 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance7._minimumValue = 0;
      instance7._valueName = (UnitStoredValueNames) 444400;
      instance7._increase = true;
      ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>();
      RemovePassiveEffect instance8 = ScriptableObject.CreateInstance<RemovePassiveEffect>();
      instance8._passiveToRemove = (PassiveAbilityTypes) 444440;
      PerformDoubleEffectPassiveAbility instance9 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance9)._passiveName = "Hex (1)";
      ((BasePassiveAbilitySO) instance9).passiveIcon = ResourceLoader.LoadSprite("hexedIcon");
      ((BasePassiveAbilitySO) instance9).type = (PassiveAbilityTypes) 444440;
      ((BasePassiveAbilitySO) instance9)._enemyDescription = "Upon moving, deal a certain amount of damage to the opposing party member.";
      ((BasePassiveAbilitySO) instance9)._characterDescription = "Upon killing, apply Hexed to self. Remove this passive after 1 turn.";
      ((BasePassiveAbilitySO) instance9).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance9)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 24
      };
      instance9.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyHexedEffect>(), 1, new IntentType?((IntentType) 444440), Slots.Self)
      });
      instance9._secondDoesPerformPopUp = false;
      instance9._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance9._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance8, 1, new IntentType?((IntentType) 100), Slots.Self)
      });
      PerformDoubleEffectPassiveAbility instance10 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance10)._passiveName = "Hex (2)";
      ((BasePassiveAbilitySO) instance10).passiveIcon = ResourceLoader.LoadSprite("hexedIcon");
      ((BasePassiveAbilitySO) instance10).type = (PassiveAbilityTypes) 444440;
      ((BasePassiveAbilitySO) instance10)._enemyDescription = "Upon moving, deal a certain amount of damage to the opposing party member.";
      ((BasePassiveAbilitySO) instance10)._characterDescription = "Upon killing, apply Hexed to self. Remove this passive after 2 turns.";
      ((BasePassiveAbilitySO) instance10).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance10)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 24
      };
      instance10.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyHexedEffect>(), 1, new IntentType?((IntentType) 444440), Slots.Self)
      });
      instance10._secondDoesPerformPopUp = false;
      instance10._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance10._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) instance7, 1, new IntentType?((IntentType) 100), Slots.Self),
        new Effect((EffectSO) instance8, 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) ScriptableObject.CreateInstance<CasterStoredValueCHeckingEffectCondition>())
      });
      ScriptableObject.CreateInstance<AddPassiveEffect>()._passiveToAdd = (BasePassiveAbilitySO) instance9;
      ScriptableObject.CreateInstance<AddPassiveEffect>()._passiveToAdd = (BasePassiveAbilitySO) instance10;
      ScriptableObject.CreateInstance<ChangeMaxHealthEffect>()._increase = true;
      ScriptableObject.CreateInstance<DamageEffect>()._returnKillAsSuccess = true;
      PreviousEffectCondition instance11 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance11.wasSuccessful = false;
      instance11.previousAmount = 2;
      Ability ability5 = new Ability();
      ability5.name = "Drain Their Skin";
      ability5.description = "Decrease the Opposing enemy's maximum health by 6. This amount is affected by damage modifiers and can kill. \nApply 2 Shield to this party member and the left and right allies. If the Opposing enemy was killed, apply 2 more Shield than otherwise.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Red
      };
      ability5.sprite = ResourceLoader.LoadSprite("draintheirskin");
      ability5.effects = new Effect[2];
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<CordisMaxHPKillEffect>(), 6, new IntentType?((IntentType) 81), Slots.Front);
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 2, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[3]
      {
        -1,
        0,
        1
      }, true));
      ability5.visuals = LoadedAssetsHandler.GetEnemyAbility("Genesis_A").visuals;
      ability5.animationTarget = Slots.Front;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Drain Their Blood";
      ability6.description = "Decrease the Opposing enemy's maximum health by 9. This amount is affected by damage modifiers and can kill. \nApply 3 Shield to this party member and the left and right allies. If the Opposing enemy was killed, apply 2 more Shield than otherwise.";
      ability6.effects[0]._entryVariable = 3;
      ability6.effects[1]._entryVariable = 9;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Drain Their Memories";
      ability7.description = "Decrease the Opposing enemy's maximum health by 12. This amount is affected by damage modifiers and can kill. \nApply 4 Shield to this party member and the left and right allies. If the Opposing enemy was killed, apply 2 more Shield than otherwise.";
      ability7.effects[0]._entryVariable = 4;
      ability7.effects[1]._entryVariable = 12;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Envisioning the Opportunity";
      ability8.description = "Decrease the Opposing enemy's maximum health by 15. This amount is affected by damage modifiers and can kill. \nApply 5 Shield to this party member and the left and right allies. If the Opposing enemy was killed, apply 2 more Shield than otherwise.";
      ability8.effects[0]._entryVariable = 5;
      ability8.effects[1]._entryVariable = 15;
      RemoveStatusEffectEffect instance12 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
      PreviousEffectCondition instance13 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance13.wasSuccessful = false;
      instance13.previousAmount = 4;
      PreviousEffectCondition instance14 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance14.wasSuccessful = true;
      instance14.previousAmount = 2;
      instance12._statusToRemove = (StatusEffectType) 444440;
      Ability ability9 = new Ability();
      ability9.name = "Blast the Heart";
      ability9.description = "Attempt to decrease the Left ally's max health by 2. If unsuccessful, decrease this party member's max health instead. \nDeal 10 damage to the Opposing enemy, producing 2 extra Pigment of their health color if successful.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability9.sprite = ResourceLoader.LoadSprite("slaytheheart");
      ability9.effects = new Effect[3];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ChangeFirstTargetMaxHealthEffect>(), 2, new IntentType?((IntentType) 81), Slots.SlotTarget(new int[2]
      {
        -1,
        0
      }, true));
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?((IntentType) 2), Slots.Front);
      ability9.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 2, new IntentType?((IntentType) 60), Slots.Front, (EffectConditionSO) instance3);
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Blow_1_A").visuals;
      ability9.animationTarget = Slots.Front;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Slay the Heart";
      ability10.description = "Attempt to decrease the Left ally's max health by 2. If unsuccessful, decrease this party member's max health instead. \nDeal 13 damage to the Opposing enemy, producing 2 extra Pigment of their health color if successful.";
      ability10.effects[1]._entryVariable = 13;
      ability10.effects[1]._intent = new IntentType?((IntentType) 3);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Burst the Heart";
      ability11.description = "Attempt to decrease the Left ally's max health by 3. If unsuccessful, decrease this party member's max health instead. \nDeal 16 damage to the Opposing enemy, producing 2 extra Pigment of their health color if successful.";
      ability11.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Red)
      };
      ability11.effects[0]._entryVariable = 3;
      ability11.effects[1]._entryVariable = 16;
      ability11.effects[1]._intent = new IntentType?((IntentType) 4);
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Freed from the Torments";
      ability12.description = "Attempt to decrease the Left ally's max health by 3. If unsuccessful, decrease this party member's max health instead. \nDeal 19 damage to the Opposing enemy, producing 2 extra Pigment of their health color if successful.";
      ability12.effects[1]._entryVariable = 19;
      character.AddLevel(5, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(7, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(9, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(11, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      ThisSucksElipses.Chorcer = character;
    }
  }
}
