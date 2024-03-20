// Decompiled with JetBrains decompiler
// Type: Hawthorne.MortyRicker
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using ChillyBonezMod;
using Hawthorne;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class MortyRicker
  {
    public static Character Rock;

    public static void Add()
    {
      Character character = new Character();
      character.name = "Mortis";
      character.healthColor = Pigments.Gray;
      character.entityID = (EntityIDs) 444442;
      character.levels = new CharacterRankedData[1];
      character.menuChar = true;
      character.isSupport = false;
      character.usesBaseAbility = false;
      character.usesAllAbilities = true;
      character.appearsInShops = true;
      character.walksInOverworld = false;
      character.frontSprite = ChillyBonezMod.ResourceLoader.LoadSprite("frontmort");
      character.backSprite = ChillyBonezMod.ResourceLoader.LoadSprite("backmort");
      character.overworldSprite = ChillyBonezMod.ResourceLoader.LoadSprite("smallmort", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.unlockedSprite = ChillyBonezMod.ResourceLoader.LoadSprite("smallermort");
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        Passives.Inanimate
      };
      DamageTargetRandomEffect instance1 = ScriptableObject.CreateInstance<DamageTargetRandomEffect>();
      //instance1._scars = 0;
      Targetting_ByUnit_Side instance2 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance2.getAllUnitSlots = false;
      instance2.getAllies = false;
      Ability ability1 = new Ability();
      ability1.sprite = ChillyBonezMod.ResourceLoader.LoadSprite("punchmort");
      ability1.name = "Grand Blast";
      ability1.description = "Deal 15 damage to a random enemy.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability1.visuals = (AttackVisualsSO) null;
      ability1.animationTarget = Slots.Self;
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect((EffectSO) instance1, 15, new IntentType?((IntentType) 3), (BaseCombatTargettingSO) instance2);
      new Ability()
      {
        sprite = ChillyBonezMod.ResourceLoader.LoadSprite("punchmort"),
        name = "Big Blast",
        description = "Deal 16 damage to a random enemy.",
        cost = new ManaColorSO[3]
        {
          Pigments.Red,
          Pigments.Red,
          Pigments.Red
        },
        visuals = ((AttackVisualsSO) null),
        animationTarget = Slots.Self,
        effects = new Effect[1]
      }.effects[0] = new Effect((EffectSO) instance1, 16, new IntentType?((IntentType) 4), (BaseCombatTargettingSO) instance2);
      new Ability()
      {
        sprite = ChillyBonezMod.ResourceLoader.LoadSprite("punchmort"),
        name = "Big Blast",
        description = "Deal 20 damage to a random enemy.",
        cost = new ManaColorSO[3]
        {
          Pigments.Red,
          Pigments.Red,
          Pigments.Red
        },
        visuals = ((AttackVisualsSO) null),
        animationTarget = Slots.Self,
        effects = new Effect[1]
      }.effects[0] = new Effect((EffectSO) instance1, 20, new IntentType?((IntentType) 4), (BaseCombatTargettingSO) instance2);
      new Ability()
      {
        sprite = ChillyBonezMod.ResourceLoader.LoadSprite("punchmort"),
        name = "Big Blast",
        description = "Deal 25 damage to a random enemy.",
        cost = new ManaColorSO[3]
        {
          Pigments.Red,
          Pigments.Red,
          Pigments.Red
        },
        visuals = ((AttackVisualsSO) null),
        animationTarget = Slots.Self,
        effects = new Effect[1]
      }.effects[0] = new Effect((EffectSO) instance1, 25, new IntentType?((IntentType) 5), (BaseCombatTargettingSO) instance2);
      Ability ability2 = new Ability();
      ability2.sprite = ChillyBonezMod.ResourceLoader.LoadSprite("apocalypsemort");
      ability2.name = "Catastrophic Bombardment";
      ability2.description = "Deal 0-12 damage to all enemies. This damage ignores shields and produces no pigment.";
      ability2.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals;
      ability2.animationTarget = Slots.SlotTarget(new int[9]
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
      });
      ability2.effects = new Effect[2];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 0, new IntentType?(), Slots.Self);
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomDryDamageBetweenPreviousAndEntryEffect>(), 12, new IntentType?((IntentType) 3), (BaseCombatTargettingSO) instance2);
      ((RandomDryDamageBetweenPreviousAndEntryEffect) ability2.effects[1]._effect)._ignoreShield = true;
      Ability ability3 = new Ability();
      ability3.sprite = ChillyBonezMod.ResourceLoader.LoadSprite("apocalypsemort");
      ability3.name = "Big Rapture";
      ability3.description = "Deal 0-7 damage to all enemies. This damage ignores shields.";
      ability3.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability3.visuals = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").abilities[0].ability.visuals;
      ability3.animationTarget = Slots.Front;
      ability3.effects = new Effect[2];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 0, new IntentType?(), Slots.Self);
      ability3.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 7, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) instance2);
      ((RandomDamageBetweenPreviousAndEntryEffect) ability3.effects[1]._effect)._ignoreShield = true;
      Ability ability4 = new Ability();
      ability4.sprite = ChillyBonezMod.ResourceLoader.LoadSprite("apocalypsemort");
      ability4.name = "Big Rapture";
      ability4.description = "Deal 0-9 damage to all enemies. This damage ignores shields.";
      ability4.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability4.visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals;
      ability4.animationTarget = Slots.SlotTarget(new int[9]
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
      });
      ability4.effects = new Effect[2];
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 0, new IntentType?(), Slots.Self);
      ability4.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 9, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) instance2);
      ((RandomDamageBetweenPreviousAndEntryEffect) ability4.effects[1]._effect)._ignoreShield = true;
      Ability ability5 = new Ability();
      ability5.sprite = ChillyBonezMod.ResourceLoader.LoadSprite("apocalypsemort");
      ability5.name = "Big Rapture";
      ability5.description = "Deal 0-12 damage to all enemies. This damage ignores shields.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability5.visuals = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").abilities[0].ability.visuals;
      ability5.animationTarget = Slots.Front;
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 0, new IntentType?(), Slots.Front);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 12, new IntentType?((IntentType) 3), (BaseCombatTargettingSO) instance2);
      ((RandomDamageBetweenPreviousAndEntryEffect) ability5.effects[1]._effect)._ignoreShield = true;
      Ability ability6 = new Ability();
      ability6.sprite = ChillyBonezMod.ResourceLoader.LoadSprite("loadmort");
      ability6.name = "Load It";
      ability6.description = "Apply 1 Adrenaline to self. 15% chance to refresh self.";
      if (Random.Range(0, 100) < 1)
        ability6.description = "YOU SHOULD SCREAM FIRE IN A CROWDED MOVIE THEATER";
      ability6.cost = new ManaColorSO[3]
      {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Blue
      };
      ability6.visuals = (AttackVisualsSO) null;
      ability6.animationTarget = Slots.Self;
      ability6.effects = new Effect[2];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAdrenalineEffect>(), 1, new IntentType?((IntentType) 444442), Slots.Self);
      ability6.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 85), Slots.Self, (EffectConditionSO) Conditions.Chance(15));
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Load It!";
      ability7.description = "Apply 1 Adrenaline to self. 13% chance to refresh self.";
      ability7.effects[1]._condition = (EffectConditionSO) Conditions.Chance(13);
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Load It!!";
      ability8.description = "Apply 1 Adrenaline to self. 16% chance to refresh self.";
      ability7.effects[1]._condition = (EffectConditionSO) Conditions.Chance(16);
      Ability ability9 = ability8.Duplicate();
      ability9.name = "Load It!!!";
      ability9.description = "Apply 1 Adrenaline to self. 19% chance to refresh self.";
      ability9.effects[1]._condition = (EffectConditionSO) Conditions.Chance(20);
      character.AddLevel(50, new Ability[3]
      {
        ability1,
        ability2,
        ability6
      }, 0);
      character.AddCharacter();
      MortyRicker.Rock = character;
    }
  }
}
