// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.KYS
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class KYS
  {
    public static Character Hexer;

    public static void Add()
    {
      Character character = new Character();
      character.name = "Willow";
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 4444440;
      character.overworldSprite = ResourceLoader.LoadSprite("WillowOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("WillowFront");
      character.backSprite = ResourceLoader.LoadSprite("WillowBack");
      character.lockedSprite = ResourceLoader.LoadSprite("WillowMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("WillowMenu");
      character.menuChar = true;
      character.isSupport = true;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").dxSound;
      ChangeMaxHealthEffectCorrectExit instance1 = ScriptableObject.CreateInstance<ChangeMaxHealthEffectCorrectExit>();
      instance1._increase = true;
      ChangeMaxHealthEffectCorrectExit instance2 = ScriptableObject.CreateInstance<ChangeMaxHealthEffectCorrectExit>();
      instance2._increase = false;
      HealEffect instance3 = ScriptableObject.CreateInstance<HealEffect>();
      instance3.usePreviousExitValue = true;
      ChangeMaxHealthEffectCorrectExit instance4 = ScriptableObject.CreateInstance<ChangeMaxHealthEffectCorrectExit>();
      instance4._increase = true;
      instance4._usePrevExitVal = true;
      PreviousEffectCondition instance5 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance5.wasSuccessful = true;
      Effect effect = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) instance5);
      Ability ability1 = new Ability();
      ability1.name = "Stepping Up Your Veins";
      ability1.description = "Decrease this character's maximum health by 2. \nIncrease the right ally's max health by 4 and heal them the same amount.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability1.sprite = ResourceLoader.LoadSprite("WillowIconsVeins");
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) instance2, 2, new IntentType?((IntentType) 81), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) instance1, 4, new IntentType?((IntentType) 81), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals;
      ability1.animationTarget = Slots.SlotTarget(new int[1]
      {
        1
      }, true);
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Bumping Up Your Veins";
      ability2.description = "Decrease this character's maximum health by 2. \nIncrease the right ally's max health by 4 and heal them the same amount.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Cranking Up Your Veins";
      ability3.description = "Decrease this character's maximum health by 3. \nIncrease the right ally's max health by 6 and heal them the same amount.";
      ability3.effects[0]._entryVariable = 3;
      ability3.effects[1]._entryVariable = 6;
      ability3.effects[2]._entryVariable = 6;
      ability3.effects[2]._intent = new IntentType?((IntentType) 21);
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Beefing Up Your Veins";
      ability4.description = "Decrease this character's maximum health by 4. \nIncrease the right ally's max health by 8 and heal them the same amount.";
      ability4.effects[0]._entryVariable = 4;
      ability4.effects[1]._entryVariable = 8;
      ability4.effects[2]._entryVariable = 8;
      DoubleTargetting_BySlot_Index instance6 = ScriptableObject.CreateInstance<DoubleTargetting_BySlot_Index>();
      instance6.getAllies = true;
      instance6.slotPointerDirections = new int[1]{ -1 };
      instance6.secondGetAllies = false;
      instance6.secondSlotPointers = new int[1];
      Ability ability5 = new Ability();
      ability5.name = "Expecting the Opportunity";
      ability5.description = "Decrease the Opposing enemy's max health by 2. \nIncrease the left ally's max health and heal them for the same amount.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability5.sprite = ResourceLoader.LoadSprite("WillowIconOpportunity");
      ability5.effects = new Effect[3];
      ability5.effects[0] = new Effect((EffectSO) instance2, 2, new IntentType?((IntentType) 81), Slots.Front);
      ability5.effects[1] = new Effect((EffectSO) instance4, 1, new IntentType?((IntentType) 81), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability5.effects[2] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Showdown_1_A").visuals;
      ability5.animationTarget = (BaseCombatTargettingSO) instance6;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Predicting the Opportunity";
      ability6.description = "Decrease the Opposing enemy's max health by 3. \nIncrease the left ally's max health and heal them for the same amount.";
      ability6.effects[0]._entryVariable = 3;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Foreseeing the Opportunity";
      ability7.description = "Decrease the Opposing enemy's max health by 4. \nIncrease the left ally's max health and heal them for the same amount.";
      ability7.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability7.effects[0]._entryVariable = 4;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Envisioning the Opportunity";
      ability8.description = "Decrease the Opposing enemy's max health by 5. \nIncrease the left ally's max health and heal them for the same amount.";
      ability8.effects[0]._entryVariable = 5;
      ability8.effects[2]._intent = new IntentType?((IntentType) 21);
      RemoveStatusEffectEffect instance7 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
      PreviousEffectCondition instance8 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance8.wasSuccessful = false;
      instance8.previousAmount = 4;
      ChangeMaxHealthEffect instance9 = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
      instance9._entryAsPercentage = true;
      instance9._increase = false;
      Targetting_ByUnit_Side instance10 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance10.getAllies = true;
      instance10.ignoreCastSlot = true;
      instance7._statusToRemove = (StatusEffectType) 444440;
      Ability ability9 = new Ability();
      ability9.name = "Freed from the Troubles";
      ability9.description = "Increase the max health and heal all allies by 2. \nHalve this character's max health and fully heal them.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Blue
      };
      ability9.sprite = ResourceLoader.LoadSprite("WillowIconFree");
      ability9.effects = new Effect[4];
      ability9.effects[0] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 81), (BaseCombatTargettingSO) instance10);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?((IntentType) 20), (BaseCombatTargettingSO) instance10);
      ability9.effects[2] = new Effect((EffectSO) instance9, 50, new IntentType?((IntentType) 81), Slots.Self);
      ability9.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<FullHealEffect>(), 1, new IntentType?((IntentType) 22), Slots.Self);
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Malpractice_1_A").visuals;
      ability9.animationTarget = Slots.Self;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Freed from the Strains";
      ability10.description = "Increase the max health and heal all allies by 3. \nHalve this character's max health and fully heal them.";
      ability10.effects[0]._entryVariable = 3;
      ability10.effects[1]._entryVariable = 3;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Freed from the Burdens";
      ability11.description = "Increase the max health and heal all allies by 4. \nHalve this character's max health and fully heal them.";
      ability11.effects[0]._entryVariable = 4;
      ability11.effects[1]._entryVariable = 4;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Freed from the Torments";
      ability12.description = "Increase the max health and heal all allies by 5. \nHalve this character's max health and fully heal them.";
      ability12.effects[0]._entryVariable = 4;
      ability12.effects[1]._entryVariable = 4;
      ability12.effects[1]._intent = new IntentType?((IntentType) 21);
      character.AddLevel(24, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(24, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(24, new Ability[3]
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
      KYS.Hexer = character;
    }
  }
}
