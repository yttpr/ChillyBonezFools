// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.FuckShitHomoeroticPorn
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class FuckShitHomoeroticPorn
  {
    public static Character Fucker;

    public static void Add()
    {
      Character character = new Character();
      character.name = "Prayer";
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 444443;
      character.overworldSprite = ResourceLoader.LoadSprite("PrayerOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("PrayerFront");
      character.backSprite = ResourceLoader.LoadSprite("PrayerBack");
      character.lockedSprite = ResourceLoader.LoadSprite("PrayerLocked");
      character.unlockedSprite = ResourceLoader.LoadSprite("PrayerMenu");
      character.menuChar = true;
      character.isSupport = true;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").dxSound;
      Targetting_ByUnit_Side instance1 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance1.getAllUnitSlots = false;
      instance1.getAllies = true;
      PreviousEffectCondition instance2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance2.wasSuccessful = false;
      PreviousEffectCondition instance3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance3.wasSuccessful = true;
      AttackVisualsSO visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
      AnimationVisualsEffect instance4 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
      instance4._animationTarget = Slots.Front;
      instance4._visuals = visuals;
      AnimVisIfTargetCarryExitEffect instance5 = ScriptableObject.CreateInstance<AnimVisIfTargetCarryExitEffect>();
      instance5._animationTarget = Slots.Right;
      instance5._visuals = visuals;
      DryDamageEffect instance6 = ScriptableObject.CreateInstance<DryDamageEffect>();
      instance6._usePreviousExitValue = true;
      Ability ability1 = new Ability();
      ability1.name = "A Small Blessing";
      ability1.description = "Heal the Right ally 5 health. \nIf healing would surpass the ally's maximum health, apply 3 Divine Protection to the Right enemy and deal the extra healing as dry damage to them.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability1.sprite = ResourceLoader.LoadSprite("blessingIcon.png");
      ability1.effects = new Effect[4]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealReturnOverhealEffect>(), 5, new IntentType?((IntentType) 21), Slots.SlotTarget(new int[1]
        {
          1
        }, true)),
        new Effect((EffectSO) instance5, 1, new IntentType?(), Slots.Right, (EffectConditionSO) instance3),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDPCarryExitEffect>(), 3, new IntentType?((IntentType) 158), Slots.Right),
        new Effect((EffectSO) instance6, 1, new IntentType?((IntentType) 1), Slots.Right)
      };
      ability1.animationTarget = Slots.SlotTarget(new int[1]
      {
        1
      }, true);
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Mend_1_A").visuals;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "A Hefty Blessing";
      ability2.description = "Heal the Right ally 6 health. \nIf healing would surpass the ally's maximum health, apply 3 Divine Protection to the Right enemy and deal the extra healing as dry damage to them.";
      ability2.effects[0]._entryVariable = 6;
      Ability ability3 = ability2.Duplicate();
      ability3.name = "A Plentiful Blessing";
      ability3.description = "Heal the Right ally 7 health. \nIf healing would surpass the ally's maximum health, apply 3 Divine Protection to the Right enemy and deal the extra healing as dry damage to them.";
      ability3.effects[0]._entryVariable = 7;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "A Bountiful Blessing";
      ability4.description = "Heal the Right ally 8 health. \nIf healing would surpass the ally's maximum health, apply 3 Divine Protection to the Right enemy and deal the extra healing as dry damage to them.";
      ability4.effects[0]._entryVariable = 8;
      ScriptableObject.CreateInstance<AddPassiveEffect>()._passiveToAdd = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").passiveAbilities[1];
      PreviousEffectCondition instance7 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance7.wasSuccessful = true;
      instance7.previousAmount = 4;
      PreviousEffectCondition instance8 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance8.wasSuccessful = true;
      instance8.previousAmount = 3;
      PreviousEffectCondition instance9 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance9.wasSuccessful = true;
      instance9.previousAmount = 2;
      PreviousEffectCondition instance10 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance10.wasSuccessful = false;
      instance10.previousAmount = 2;
      Ability ability5 = new Ability();
      ability5.name = "Repent Your Wrongdoings";
      ability5.description = "If there are Left or Right enemies, apply 3 Divine Protection and deal 6 dry damage to them. \nOtherwise, heal the respective ally 3 health.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Yellow
      };
      ability5.sprite = ResourceLoader.LoadSprite("repentIcon");
      ability5.effects = new Effect[6]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDivineProtectionAlwaysTrueIfTargetEffect>(), 3, new IntentType?((IntentType) 158), Slots.Right),
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 3, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
        {
          1
        }, true), (EffectConditionSO) instance2),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDivineProtectionAlwaysTrueIfTargetEffect>(), 3, new IntentType?((IntentType) 158), Slots.Left),
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 3, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
        {
          -1
        }, true), (EffectConditionSO) instance2),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DryDamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.Right, (EffectConditionSO) instance7),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DryDamageEffect>(), 6, new IntentType?((IntentType) 1), Slots.Left, (EffectConditionSO) instance8)
      };
      ability5.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create((BaseCombatTargettingSO) PrioritizeTargetting.Create(Slots.Right, Slots.SlotTarget(new int[1]
      {
        1
      }, true)), (BaseCombatTargettingSO) PrioritizeTargetting.Create(Slots.Left, Slots.SlotTarget(new int[1]
      {
        -1
      }, true)));
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Mend_1_A").visuals;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Repent Your Transgressions";
      ability6.description = "If there are Left or Right enemies, apply 3 Divine Protection and deal 8 dry damage to them. \nOtherwise, heal the respective ally 4 health.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple),
        Pigments.Yellow
      };
      ability6.effects[1]._entryVariable = 4;
      ability6.effects[4]._entryVariable = 8;
      ability6.effects[4]._intent = new IntentType?((IntentType) 2);
      ability6.effects[3]._entryVariable = 4;
      ability6.effects[5]._entryVariable = 8;
      ability6.effects[5]._intent = new IntentType?((IntentType) 2);
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Repent Your Wickedness";
      ability7.description = "If there are Left or Right enemies, apply 3 Divine Protection and deal 10 dry damage to them. \nOtherwise, heal the respective ally 5 health.";
      ability7.effects[1]._entryVariable = 5;
      ability7.effects[1]._intent = new IntentType?((IntentType) 21);
      ability7.effects[4]._entryVariable = 10;
      ability7.effects[3]._entryVariable = 5;
      ability7.effects[3]._intent = new IntentType?((IntentType) 21);
      ability7.effects[5]._entryVariable = 10;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Repent Your Unrighteousness";
      ability8.description = "If there are Left or Right enemies, apply 3 Divine Protection and deal 12 dry damage to them. \nOtherwise, heal the respective ally 6 health.";
      ability8.cost = new ManaColorSO[2]
      {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple),
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Red)
      };
      ability8.effects[1]._entryVariable = 6;
      ability8.effects[4]._entryVariable = 12;
      ability8.effects[4]._intent = new IntentType?((IntentType) 3);
      ability8.effects[3]._entryVariable = 6;
      ability8.effects[5]._entryVariable = 12;
      ability8.effects[5]._intent = new IntentType?((IntentType) 3);
      Targetting_ByUnit_Side instance11 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance11.getAllies = false;
      instance11.getAllUnitSlots = false;
      RemoveStatusEffectEffect instance12 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
      instance12._statusToRemove = (StatusEffectType) 10;
      ScriptableObject.CreateInstance<DamageEffect>()._usePreviousExitValue = true;
      Ability ability9 = new Ability();
      ability9.name = "Martyr Amongst the Peers";
      ability9.description = "If the Opposing enemy has Divine Protection, remove it and inflict 2 of either Scars, Frail, or Ruptured on them. \nOtherwise, apply 3 Divine Protection on them.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability9.sprite = ResourceLoader.LoadSprite("wrathIcon");
      ability9.effects = new Effect[5];
      ability9.effects[0] = new Effect((EffectSO) instance12, 1, new IntentType?((IntentType) 198), Slots.Front);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ScarFrailRuptureEffect>(), 2, new IntentType?((IntentType) 159), Slots.Front, (EffectConditionSO) instance3);
      ability9.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, new IntentType?((IntentType) 150), Slots.Front, (EffectConditionSO) instance10);
      ability9.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, new IntentType?((IntentType) 151), Slots.Front);
      ability9.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, new IntentType?((IntentType) 158), Slots.Front);
      ability9.visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
      ability9.animationTarget = Slots.Front;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Martyr Amongst the People";
      ability10.description = "If the Opposing enemy has Divine Protection, remove it and inflict 3 of either Scars, Frail, or Ruptured on them. \nOtherwise, apply 3 Divine Protection on them.";
      ability10.effects[1]._entryVariable = 3;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Martyr Amongst the Whole";
      ability11.description = "If the Opposing enemy has Divine Protection, remove it and inflict 3 of either Scars, Frail, or Ruptured on them. \nOtherwise, apply 4 Divine Protection on them.";
      ability11.effects[2]._entryVariable = 4;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Martyr Amongst the Horizon";
      ability12.description = "If the Opposing enemy has Divine Protection, remove it and inflict 4 of either Scars, Frail, or Ruptured on them. \nOtherwise, apply 4 Divine Protection on them.";
      ability12.effects[1]._entryVariable = 4;
      character.AddLevel(12, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(16, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(20, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(24, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      FuckShitHomoeroticPorn.Fucker = character;
    }
  }
}
