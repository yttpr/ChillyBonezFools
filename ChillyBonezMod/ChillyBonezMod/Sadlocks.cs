// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Sadlocks
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using Hawthorne;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class Sadlocks
  {
    public static void FuckShit(bool defaultUnlocked)
    {
      WrongPigRedirectWearable.Setup();
      WrongPigRedirectItem osmanUnlock = new WrongPigRedirectItem();
      osmanUnlock.name = "Martyr's Crown";
      osmanUnlock.flavorText = "\"I'm willing to die for my beliefs\"";
      osmanUnlock.description = "All Wrong Pigment damage will be redirected to this party member. \nThis party member has Dying as a passive.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("PrayerOS.png");
      osmanUnlock.trigger = (TriggerCalls) 1000;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 454443;
      osmanUnlock.namePopup = false;
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.consumedOnUse = false;
      ExtraPassiveAbility_Wearable_SMS instance1 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance1._extraPassiveAbility = Passives.Dying;
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance1
      };
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Pharoah's Ambassador";
      heavenUnlock.flavorText = "\"Everything will come into place.\"";
      heavenUnlock.description = "At the start of each turn, apply Two-Faced (Red and Blue) as a passive to the Opposing enemy. If unsuccessful, give this party member Two-Faced.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("PrayerH.png");
      heavenUnlock.trigger = (TriggerCalls) 21;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 464443;
      heavenUnlock.namePopup = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 3;
      heavenUnlock.startsLocked = false;
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<TwoFacedEffect>(), 1, new IntentType?(), Slots.Front)
      };
      EffectItem unlock = new EffectItem();
      unlock.name = "Broken Artifact";
      unlock.flavorText = "\"An illusion of punishment as a blessing\"";
      unlock.description = "If this party member has not moved manually or performed an ability manually, during the enemy's turn they are immune to all damage, all healing, movement, status effects, health color changes, and instant death. \nThis party member now has Withering as a passive.";
      unlock.sprite = ResourceLoader.LoadSprite("PrayerD.png");
      unlock.trigger = (TriggerCalls) 1000;
      unlock.consumeTrigger = (TriggerCalls) 1000;
      unlock.unlockableID = (UnlockableID) 474443;
      unlock.namePopup = false;
      unlock.consumedOnUse = false;
      unlock.itemPools = ItemPools.Treasure;
      unlock.shopPrice = 15;
      unlock.startsLocked = false;
      unlock.immediate = false;
      unlock.effects = new Effect[0];
      ExtraPassiveAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance2._extraPassiveAbility = FakeWitheringPassive.FakeWithering();
      unlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance2
      };
      EffectItem effectItem1 = new EffectItem();
      effectItem1.name = "Holy Mackarel";
      effectItem1.flavorText = "\"Only the most worthy can wield this\"";
      effectItem1.description = "When a status effect is applied to this party member, apply an equivalent amount of Divine Protection instead and heal this party member health for the amount of status applied. \n40% chance to be consumed at the end of combat.";
      effectItem1.sprite = ResourceLoader.LoadSprite("PrayerS.png");
      effectItem1.trigger = (TriggerCalls) 20;
      effectItem1.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<HolyMackarelCondition>()
      };
      effectItem1.consumeTrigger = (TriggerCalls) 31;
      /*EffectItem effectItem2 = effectItem1;
      EffectorConditionSO[] effectorConditionSoArray = new EffectorConditionSO[1];
      // ISSUE: reference to a compiler-generated field
      if (Sadlocks.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Sadlocks.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, EffectorConditionSO>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (EffectorConditionSO), typeof (Sadlocks)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      effectorConditionSoArray[0] = Sadlocks.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) Sadlocks.\u003C\u003Eo__0.\u003C\u003Ep__0, Conditions.Chance<EffectorConditionSO>(40));
      effectItem2.consumeConditions = effectorConditionSoArray;*/
            effectItem1.consumeConditions = new EffectorConditionSO[] { Effector.Chance(40) };
      effectItem1.unlockableID = (UnlockableID) 484443;
      effectItem1.namePopup = true;
      effectItem1.consumedOnUse = false;
      effectItem1.itemPools = ItemPools.Fish;
      effectItem1.shopPrice = 5;
      effectItem1.startsLocked = false;
      effectItem1.immediate = false;
      effectItem1.effects = new Effect[0];
      if (defaultUnlocked)
      {
        osmanUnlock.AddItem();
        heavenUnlock.AddItem();
        unlock.AddItem();
        effectItem1.AddItem();
        FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item) effectItem1), 3);
      }
      else
      {
        FoolBossUnlockSystem.FoolItemPairs foolItemPairs = new FoolBossUnlockSystem.FoolItemPairs(FuckShitHomoeroticPorn.Fucker, (Item) heavenUnlock, (Item) osmanUnlock);
        foolItemPairs.AddUnlock((BossType) 26991, (Item) unlock);
        foolItemPairs.AddUnlock((BossType) 55983, (Item) effectItem1, 3);
        foolItemPairs.Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 464443, (AchievementUnlockType) 5, "Pharaoh's Ambassador", "Unlocked a new item.", ResourceLoader.LoadSprite("PrayHeaven.png")).Prepare(FuckShitHomoeroticPorn.Fucker.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 454443, (AchievementUnlockType) 4, "Martyr's Crown", "Unlocked a new item.", ResourceLoader.LoadSprite("PrayOsman.png")).Prepare(FuckShitHomoeroticPorn.Fucker.entityID, (BossType) 9);
      }
    }

    public static void Stripper(bool defaultUnlocked)
    {
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Fleshy Tofu";
      osmanUnlock.flavorText = "\"Why does this exist?\"";
      osmanUnlock.description = "Direct healing for this party member is replaced by an equivalent amount of Shield on their position.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("stripOS.png");
      osmanUnlock.trigger = (TriggerCalls) 9;
      osmanUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<TofuCondition>()
      };
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 454444;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 3;
      osmanUnlock.startsLocked = false;
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[0];
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Decomposing Ouroboros";
      heavenUnlock.flavorText = "\"You're reaching towards an end\"";
      heavenUnlock.description = "On death, spawn a permanent copy of this party member that is one level lower and has Dying as a passive. Does not work if this party member is level one. \nThis party member has Dying as a passive.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("StripH.png");
      heavenUnlock.trigger = (TriggerCalls) 10;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<DecomposingCondition>()
      };
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 464444;
      heavenUnlock.namePopup = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 8;
      heavenUnlock.startsLocked = false;
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DecomposingEffect>(), 1, new IntentType?(), Slots.Self)
      };
      ExtraPassiveAbility_Wearable_SMS instance1 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance1._extraPassiveAbility = Passives.Dying;
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance1
      };
      AllDeathHealWearable.Setup();
      AllDeathHealItem unlock = new AllDeathHealItem();
      unlock.name = "Defective Happiness";
      unlock.flavorText = "\"I'm never gonna change for you.\"";
      unlock.description = "On any party member's death, heal all party members 4-8 health.";
      unlock.sprite = ResourceLoader.LoadSprite("StripD.png");
      unlock.trigger = AllDeathHealWearable.AnyDeath;
      unlock.consumeTrigger = (TriggerCalls) 1000;
      unlock.unlockableID = (UnlockableID) 474444;
      unlock.namePopup = true;
      unlock.consumedOnUse = false;
      unlock.itemPools = ItemPools.Shop;
      unlock.shopPrice = 7;
      unlock.startsLocked = false;
      DoubleEffectItem doubleEffectItem1 = new DoubleEffectItem();
      doubleEffectItem1.name = "The Prettiest Blob";
      doubleEffectItem1.flavorText = "\"You're so ugly, yet you're unphased by this\"";
      doubleEffectItem1.description = "Apply 2-5 Oil-Slicked to the Left and Right party members on performing an ability. Heal all party members the amount of Oil-Slicked they have at the start of each turn.";
      doubleEffectItem1.sprite = ResourceLoader.LoadSprite("StripS.png");
      doubleEffectItem1.trigger = (TriggerCalls) 14;
      doubleEffectItem1.consumeTrigger = (TriggerCalls) 31;
      /*DoubleEffectItem doubleEffectItem2 = doubleEffectItem1;
      EffectorConditionSO[] effectorConditionSoArray = new EffectorConditionSO[1];
      // ISSUE: reference to a compiler-generated field
      if (Sadlocks.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Sadlocks.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, EffectorConditionSO>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (EffectorConditionSO), typeof (Sadlocks)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      effectorConditionSoArray[0] = Sadlocks.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) Sadlocks.\u003C\u003Eo__1.\u003C\u003Ep__0, Conditions.Chance<EffectorConditionSO>(15));
      doubleEffectItem2.consumeConditions = effectorConditionSoArray;*/
            doubleEffectItem1.consumeConditions = new EffectorConditionSO[] { Effector.Chance(15) };
      doubleEffectItem1.unlockableID = (UnlockableID) 484444;
      doubleEffectItem1.namePopup = true;
      doubleEffectItem1.consumedOnUse = false;
      doubleEffectItem1.itemPools = ItemPools.Fish;
      doubleEffectItem1.shopPrice = 7;
      doubleEffectItem1.startsLocked = false;
      doubleEffectItem1.firstPopUp = true;
      doubleEffectItem1.secondPopUp = true;
      doubleEffectItem1.firstEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedTwoToFiveEffect>(), 1, new IntentType?(), Slots.Sides)
      };
      Targetting_ByUnit_Side_ForStatus instance2 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side_ForStatus>();
      instance2.getAllies = true;
      instance2.getAllUnitSlots = false;
      instance2.statusCheck = (StatusEffectType) 9;
      doubleEffectItem1.secondEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealForOilSlickedEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance2)
      };
      doubleEffectItem1.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      if (defaultUnlocked)
      {
        osmanUnlock.AddItem();
        heavenUnlock.AddItem();
        unlock.AddItem();
        doubleEffectItem1.AddItem();
        FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item) doubleEffectItem1), 2);
      }
      else
      {
        FoolBossUnlockSystem.FoolItemPairs foolItemPairs = new FoolBossUnlockSystem.FoolItemPairs(stickoMoFo.Sticky, (Item) heavenUnlock, (Item) osmanUnlock);
        foolItemPairs.AddUnlock((BossType) 26991, (Item) unlock);
        foolItemPairs.AddUnlock((BossType) 55983, (Item) doubleEffectItem1, 2);
        foolItemPairs.Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 464444, (AchievementUnlockType) 5, "Decomposing Ouroboros", "Unlocked a new item.", ResourceLoader.LoadSprite("StripHeaven.png")).Prepare(stickoMoFo.Sticky.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 454444, (AchievementUnlockType) 4, "Fleshy Tofu", "Unlocked a new item.", ResourceLoader.LoadSprite("StripOsman.png")).Prepare(stickoMoFo.Sticky.entityID, (BossType) 9);
      }
    }

    public static void ShitBrick(bool defaultUnlocked)
    {
      DamageByStoredValueEffect instance1 = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
      instance1._valueName = (UnitStoredValueNames) 9;
      instance1._indirect = true;
      CasterStoredValueChangeEffect instance2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance2._valueName = (UnitStoredValueNames) 9;
      instance2._minimumValue = -7;
      instance2._increase = false;
      NegSpurs.Setup();
      PerformEffectPassiveAbility instance3 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance3)._passiveName = "Bone Spurs (7)";
      ((BasePassiveAbilitySO) instance3).passiveIcon = LoadedAssetsHandler.GetCharcater("Fennec_CH").passiveAbilities[0].passiveIcon;
      ((BasePassiveAbilitySO) instance3).type = (PassiveAbilityTypes) 43;
      ((BasePassiveAbilitySO) instance3)._enemyDescription = "Deal 7 indirect damage to the Opposing party member upon recieving direct damage.";
      ((BasePassiveAbilitySO) instance3)._characterDescription = "Deal 7 indirect damage to the Opposing enemy upon recieving direct damage.";
      ((BasePassiveAbilitySO) instance3)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 12
      };
      instance3.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) instance1, 7, new IntentType?(), Slots.Front),
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
      });
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Crow's Foot";
      osmanUnlock.flavorText = "\"This ought to slow them down.\"";
      osmanUnlock.description = "This party member has Bone Spurs (7) as a passive. On Bone Spurs triggering, lower the amount of Bone Spurs by 1.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("MortisOS.png");
      osmanUnlock.trigger = (TriggerCalls) 12;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 454445;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.startsLocked = false;
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[0];
      ExtraPassiveAbility_Wearable_SMS instance4 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance4._extraPassiveAbility = (BasePassiveAbilitySO) instance3;
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance4
      };
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Lonesome Call";
      heavenUnlock.flavorText = "\"Any minute now...\"";
      heavenUnlock.description = "At the start of the third turn, deal 20 damage to the enemy/s with the highest health. This item is destroyed upon activation.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("MortisH.png");
      heavenUnlock.trigger = (TriggerCalls) 21;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<ThirdTurnCondition>()
      };
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 464445;
      heavenUnlock.namePopup = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 6;
      heavenUnlock.startsLocked = false;
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 20, new IntentType?(), (BaseCombatTargettingSO) ScriptableObject.CreateInstance<Targetting_ByUnit_Health>()),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?(), Slots.Self)
      };
      RankChange_Wearable_SMS instance5 = ScriptableObject.CreateInstance<RankChange_Wearable_SMS>();
      instance5._rankAdditive = -1;
      PerformDoubleEffectPassiveAbility instance6 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance6)._passiveName = "MultiAttack (2)";
      ((BasePassiveAbilitySO) instance6).passiveIcon = ResourceLoader.LoadSprite("MultiAttackIcon");
      ((BasePassiveAbilitySO) instance6).type = (PassiveAbilityTypes) 13;
      ((BasePassiveAbilitySO) instance6)._enemyDescription = "This shouldn't be on an enemy.";
      ((BasePassiveAbilitySO) instance6)._characterDescription = "This party member can perform two abilities per turn.";
      ((BasePassiveAbilitySO) instance6).specialStoredValue = (UnitStoredValueNames) 77889;
      CasterSetStoredValueEffect instance7 = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
      instance7._valueName = (UnitStoredValueNames) 77889;
      ((BasePassiveAbilitySO) instance6)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance6.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance7, 1, new IntentType?(), Slots.Self)
      });
      RefreshIfStoredValueNotZero instance8 = ScriptableObject.CreateInstance<RefreshIfStoredValueNotZero>();
      instance8._valueName = (UnitStoredValueNames) 77889;
      ScriptableObject.CreateInstance<CasterLowerStoredValueEffect>()._valueName = (UnitStoredValueNames) 77889;
      instance6._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      instance6._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance8, 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance6).doesPassiveTriggerInformationPanel = false;
      instance6._secondDoesPerformPopUp = false;
      ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>()._extraPassiveAbility = (BasePassiveAbilitySO) instance6;
      PeaPlatterHandler.Setup();
      EffectItem unlock1 = new EffectItem();
      unlock1.name = "Pea Platter";
      unlock1.flavorText = "\"Give it your all!\"";
      unlock1.description = "This party member is 1 level lower than they would normally be. On using an ability, use that ability again.";
      unlock1.sprite = ResourceLoader.LoadSprite("MortisD.png");
      unlock1.trigger = PeaPlatterHandler.call;
      unlock1.consumeTrigger = (TriggerCalls) 1000;
      unlock1.unlockableID = (UnlockableID) 474445;
      unlock1.namePopup = true;
      unlock1.consumedOnUse = false;
      unlock1.itemPools = ItemPools.Treasure;
      unlock1.shopPrice = 8;
      unlock1.startsLocked = false;
      unlock1.immediate = true;
      unlock1.effects = new Effect[0];
      unlock1.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance5
      };
      EffectItem unlock2 = new EffectItem();
      unlock2.name = "Mungcenary Munchkins";
      unlock2.flavorText = "\"This is utterly mungdiculous.\"";
      unlock2.description = "At the start of combat, fill all empty party member spaces with Mungs with Infestation (2) and Multiattack (2) as passives.";
      unlock2.sprite = ResourceLoader.LoadSprite("MortisS.png");
      unlock2.trigger = (TriggerCalls) 25;
      unlock2.consumeTrigger = (TriggerCalls) 1000;
      unlock2.unlockableID = (UnlockableID) 484445;
      unlock2.namePopup = true;
      unlock2.consumedOnUse = false;
      unlock2.itemPools = ItemPools.Shop;
      unlock2.shopPrice = 10;
      unlock2.startsLocked = false;
      unlock2.immediate = false;
      unlock2.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<MungcenariesEffect>(), 5, new IntentType?(), Slots.Self)
      };
      if (defaultUnlocked)
      {
        osmanUnlock.AddItem();
        heavenUnlock.AddItem();
        unlock1.AddItem();
        unlock2.AddItem();
      }
      else
      {
        FoolBossUnlockSystem.FoolItemPairs foolItemPairs = new FoolBossUnlockSystem.FoolItemPairs(MortyRicker.Rock, (Item) heavenUnlock, (Item) osmanUnlock);
        foolItemPairs.AddUnlock((BossType) 26991, (Item) unlock1);
        foolItemPairs.AddUnlock((BossType) 55983, (Item) unlock2);
        foolItemPairs.Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 464445, (AchievementUnlockType) 5, "Lonesome Call", "Unlocked a new item.", ResourceLoader.LoadSprite("MortHeaven.png")).Prepare(MortyRicker.Rock.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 454445, (AchievementUnlockType) 4, "Crow's Foot", "Unlocked a new item.", ResourceLoader.LoadSprite("MortOsman.png")).Prepare(MortyRicker.Rock.entityID, (BossType) 9);
      }
    }

    public static void ManILoveFish(bool defaultUnlocked)
    {
      DoubleRupturedEffectWearable.Setup();
      DoubleRupturedEffectItem osmanUnlock = new DoubleRupturedEffectItem();
      osmanUnlock.name = "Rusty Sawblade";
      osmanUnlock.flavorText = "\"That's one way to make the wound worse.\"";
      osmanUnlock.description = "Apply 5 Ruptured on the Opposing enemy at the start of combat. Ruptured now deals double damage.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("GuppyOS.png");
      osmanUnlock.trigger = (TriggerCalls) 25;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 454446;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.startsLocked = false;
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 5, new IntentType?(), Slots.Front)
      };
      DamageByStoredValueEffect instance1 = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
      instance1._valueName = (UnitStoredValueNames) 444441;
      instance1._indirect = true;
      PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance2)._passiveName = "Sharp Step (1)";
      ((BasePassiveAbilitySO) instance2).passiveIcon = ResourceLoader.LoadSprite("guppyPassive");
      ((BasePassiveAbilitySO) instance2).type = (PassiveAbilityTypes) 444441;
      ((BasePassiveAbilitySO) instance2)._enemyDescription = "Upon moving, deal a certain amount of indirect damage to the opposing party member.";
      ((BasePassiveAbilitySO) instance2)._characterDescription = "Upon moving, deal a certain amount of indirect damage to the opposing enemy";
      ((BasePassiveAbilitySO) instance2).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance2).specialStoredValue = (UnitStoredValueNames) 444441;
      ((BasePassiveAbilitySO) instance2)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 8
      };
      instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Front)
      });
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Barbed Presses";
      heavenUnlock.flavorText = "\"Why was this a good idea\"";
      heavenUnlock.description = "This party member has Sharp Step (1) as a passive. On moving manually, there is a 40% chance to increase Sharp Step by 1 and deal 2 direct damage to self.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("GuppyH.png");
      heavenUnlock.trigger = (TriggerCalls) 22;
      /*EffectItem effectItem1 = heavenUnlock;
      EffectorConditionSO[] effectorConditionSoArray = new EffectorConditionSO[1];
      // ISSUE: reference to a compiler-generated field
      if (Sadlocks.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Sadlocks.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, EffectorConditionSO>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (EffectorConditionSO), typeof (Sadlocks)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      effectorConditionSoArray[0] = Sadlocks.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) Sadlocks.\u003C\u003Eo__3.\u003C\u003Ep__0, Conditions.Chance<EffectorConditionSO>(40));
      effectItem1.triggerConditions = effectorConditionSoArray;*/
            heavenUnlock.triggerConditions = new EffectorConditionSO[] { Effector.Chance(40) };
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 464446;
      heavenUnlock.namePopup = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 5;
      heavenUnlock.startsLocked = false;
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<BarbedPressesEffect>(), 1, new IntentType?(), Slots.Self)
      };
      ExtraPassiveAbility_Wearable_SMS instance3 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance3._extraPassiveAbility = (BasePassiveAbilitySO) instance2;
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance3
      };
      EffectItem unlock = new EffectItem();
      unlock.name = "Party Ripple";
      unlock.flavorText = "\"They didn't stand a chance at first sight\"";
      unlock.description = "At the start of combat, for each enemy there is a 50% chance to reduce their maxmimum health by 25%.";
      unlock.sprite = ResourceLoader.LoadSprite("GuppyD.png");
      unlock.trigger = (TriggerCalls) 25;
      unlock.consumeTrigger = (TriggerCalls) 1000;
      unlock.unlockableID = (UnlockableID) 474446;
      unlock.namePopup = true;
      unlock.consumedOnUse = false;
      unlock.itemPools = ItemPools.Treasure;
      unlock.shopPrice = 7;
      unlock.startsLocked = false;
      unlock.immediate = false;
      Targetting_ByUnit_Side instance4 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance4.getAllies = false;
      instance4.getAllUnitSlots = false;
      unlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<PartyBalloonEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance4)
      };
      PerformEffectPassiveAbility instance5 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance5)._passiveName = "Sharp Step (3)";
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
        new Effect((EffectSO) instance1, 3, new IntentType?(), Slots.Front)
      });
      ExtraPassiveAbility_Wearable_SMS instance6 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance6._extraPassiveAbility = (BasePassiveAbilitySO) instance5;
      ExtraPassiveAbility_Wearable_SMS instance7 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance7._extraPassiveAbility = Passives.Slippery;
      EffectItem effectItem2 = new EffectItem();
      effectItem2.name = "Bumbling Blow-Up";
      effectItem2.flavorText = "\"You had it coming.\"";
      effectItem2.description = "This party member has Sharp Step (3) and Slippery as passives. \nAt the start of each turn, apply 2 Oil-Slicked and 2 Stunned to this party member, then move them Left or Right 1-3 times.";
      effectItem2.sprite = ResourceLoader.LoadSprite("GuppyS.png");
      effectItem2.trigger = (TriggerCalls) 21;
      effectItem2.consumeTrigger = (TriggerCalls) 1000;
      effectItem2.unlockableID = (UnlockableID) 484446;
      effectItem2.namePopup = true;
      effectItem2.consumedOnUse = false;
      effectItem2.itemPools = ItemPools.Treasure;
      effectItem2.shopPrice = 5;
      effectItem2.startsLocked = false;
      effectItem2.immediate = false;
      effectItem2.effects = new Effect[5]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 2, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<AddSwapEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<AddSwapEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(33)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<AddSwapEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(33))
      };
      effectItem2.equippedModifiers = new WearableStaticModifierSetterSO[2]
      {
        (WearableStaticModifierSetterSO) instance6,
        (WearableStaticModifierSetterSO) instance7
      };
      if (defaultUnlocked)
      {
        osmanUnlock.AddItem();
        heavenUnlock.AddItem();
        unlock.AddItem();
        effectItem2.AddItem();
        FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item) effectItem2), 1);
      }
      else
      {
        FoolBossUnlockSystem.FoolItemPairs foolItemPairs = new FoolBossUnlockSystem.FoolItemPairs(WhatAnchored.Tard, (Item) heavenUnlock, (Item) osmanUnlock);
        foolItemPairs.AddUnlock((BossType) 26991, (Item) unlock);
        foolItemPairs.AddUnlock((BossType) 55983, (Item) effectItem2, 1);
        foolItemPairs.Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 464446, (AchievementUnlockType) 5, "Barbed Presses", "Unlocked a new item.", ResourceLoader.LoadSprite("GupHeaven.png")).Prepare(WhatAnchored.Tard.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 454446, (AchievementUnlockType) 4, "Rusty Sawblade", "Unlocked a new item.", ResourceLoader.LoadSprite("GupOsman.png")).Prepare(WhatAnchored.Tard.entityID, (BossType) 9);
      }
    }

    public static void Tree(bool defaultUnlocked)
    {
      HealFleeingCharaWearable.Setup();
      AddPassiveEffect instance1 = ScriptableObject.CreateInstance<AddPassiveEffect>();
      instance1._passiveToAdd = Passives.Fleeting;
      HealFleetingEffectItem osmanUnlock = new HealFleetingEffectItem();
      osmanUnlock.name = "Wine and Dash";
      osmanUnlock.flavorText = "\"Really stood you up like that, huh.\"";
      osmanUnlock.description = "At the start of combat, give the left ally Fleeting (3).\nHeal 7 health to any allies who flee.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("WillowOS.png");
      osmanUnlock.trigger = (TriggerCalls) 25;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 454447;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.startsLocked = false;
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.SlotTarget(new int[1]
        {
          -1
        }, true))
      };
      SmokingWearable.Setup();
      SmokingEffectItem heavenUnlock = new SmokingEffectItem();
      heavenUnlock.name = "The Never-Ending Elegance";
      heavenUnlock.flavorText = "\"You're never properly dressed without a smoke!\"";
      heavenUnlock.description = "The Yellow Pigment Generator now produces Universal Gray Pigment. Using Universal Gray Pigment now decreases the party member's maximum health by 1 for each Pigment used.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("WillowH.png");
      heavenUnlock.unlockableID = (UnlockableID) 464447;
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.namePopup = true;
      heavenUnlock.shopPrice = 10;
      ChangePigmentGeneratorPool_Effect instance2 = ScriptableObject.CreateInstance<ChangePigmentGeneratorPool_Effect>();
      instance2._newPool = new ManaColorSO[1]
      {
        Pigments.Gray
      };
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) instance2, 0, new IntentType?(), Slots.Self)
      };
      heavenUnlock.trigger = (TriggerCalls) 25;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      EffectItem unlock = new EffectItem();
      unlock.name = "Untold Harvest";
      unlock.flavorText = "\"Equivalent Exchange\"";
      unlock.description = "At the start of combat, heal this party member and the Left ally 3 health, swap some abilities, and give each a random passive.";
      unlock.sprite = ResourceLoader.LoadSprite("WillowD.png");
      unlock.trigger = (TriggerCalls) 25;
      unlock.unlockableID = (UnlockableID) 474447;
      unlock.consumeTrigger = (TriggerCalls) 1000;
      unlock.shopPrice = 4;
      unlock.itemPools = ItemPools.Treasure;
      unlock.namePopup = true;
      unlock.effects = new Effect[3]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 3, new IntentType?(), Slots.SlotTarget(new int[2]
        {
          -1,
          0
        }, true)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<SwapAbilitiesCasterFirstTargetEffect>(), 1, new IntentType?(), Targetter.LeftAlly),
        new Effect((EffectSO) RandomPassiveEffect.Create(true), 1, new IntentType?(), Targetter.LeftAlly)
      };
      DoubleEffectItem doubleEffectItem1 = new DoubleEffectItem();
      doubleEffectItem1.name = "Soaring Cod";
      doubleEffectItem1.flavorText = "\"Break the limits of your abilities!\"";
      doubleEffectItem1.description = "Damage dealt by this party member is rounded up to 4. On dealing damage, increase this item's rounding value by 1. \n25% to be destroyed at the end of combat.";
      doubleEffectItem1.sprite = ResourceLoader.LoadSprite("WillowS.png");
      doubleEffectItem1.trigger = (TriggerCalls) 16;
      CodCondition.Setup();
      doubleEffectItem1.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<CodCondition>()
      };
      doubleEffectItem1.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 29
      };
      doubleEffectItem1.secondTriggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<SoarCondition>()
      };
      doubleEffectItem1.consumeTrigger = (TriggerCalls) 31;
      /*DoubleEffectItem doubleEffectItem2 = doubleEffectItem1;
      EffectorConditionSO[] effectorConditionSoArray = new EffectorConditionSO[1];
      // ISSUE: reference to a compiler-generated field
      if (Sadlocks.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Sadlocks.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, EffectorConditionSO>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (EffectorConditionSO), typeof (Sadlocks)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      effectorConditionSoArray[0] = Sadlocks.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) Sadlocks.\u003C\u003Eo__4.\u003C\u003Ep__0, Conditions.Chance<EffectorConditionSO>(25));
      doubleEffectItem2.consumeConditions = effectorConditionSoArray;*/
            doubleEffectItem1.consumeConditions = new EffectorConditionSO[] { Effector.Chance(25) };
      doubleEffectItem1.unlockableID = (UnlockableID) 484447;
      doubleEffectItem1.firstPopUp = true;
      doubleEffectItem1.secondPopUp = false;
      doubleEffectItem1.consumedOnUse = false;
      doubleEffectItem1.itemPools = ItemPools.Fish;
      doubleEffectItem1.shopPrice = 6;
      doubleEffectItem1.startsLocked = false;
      doubleEffectItem1._firsteEffectImmediat = true;
      doubleEffectItem1._secondImmediateEffect = false;
      doubleEffectItem1.firstEffects = new Effect[0];
      doubleEffectItem1.secondEffects = new Effect[0];
      if (defaultUnlocked)
      {
        osmanUnlock.AddItem();
        heavenUnlock.AddItem();
        unlock.AddItem();
        doubleEffectItem1.AddItem();
        FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item) doubleEffectItem1), 1);
      }
      else
      {
        FoolBossUnlockSystem.FoolItemPairs foolItemPairs = new FoolBossUnlockSystem.FoolItemPairs(KYS.Hexer, (Item) heavenUnlock, (Item) osmanUnlock);
        foolItemPairs.AddUnlock((BossType) 26991, (Item) unlock);
        foolItemPairs.AddUnlock((BossType) 55983, (Item) doubleEffectItem1, 1);
        foolItemPairs.Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 464447, (AchievementUnlockType) 5, "The Never-Ending Elegance", "Unlocked a new item.", ResourceLoader.LoadSprite("WillowHeaven.png")).Prepare(KYS.Hexer.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 454447, (AchievementUnlockType) 4, "Wine and Dash", "Unlocked a new item.", ResourceLoader.LoadSprite("WillowOsman.png")).Prepare(KYS.Hexer.entityID, (BossType) 9);
      }
    }

        public static void Chorder(bool defaultUnlocked)
        {
            //IL_007e: Unknown result type (might be due to invalid IL or missing references)
            //IL_00c5: Unknown result type (might be due to invalid IL or missing references)
            //IL_00ca: Unknown result type (might be due to invalid IL or missing references)
            //IL_00d4: Unknown result type (might be due to invalid IL or missing references)
            //IL_00da: Expected O, but got Unknown
            //IL_0137: Unknown result type (might be due to invalid IL or missing references)
            //IL_017e: Unknown result type (might be due to invalid IL or missing references)
            //IL_0183: Unknown result type (might be due to invalid IL or missing references)
            //IL_0204: Unknown result type (might be due to invalid IL or missing references)
            //IL_0290: Unknown result type (might be due to invalid IL or missing references)
            //IL_0295: Unknown result type (might be due to invalid IL or missing references)
            //IL_029f: Unknown result type (might be due to invalid IL or missing references)
            //IL_02a5: Expected O, but got Unknown
            //IL_0302: Unknown result type (might be due to invalid IL or missing references)
            //IL_035a: Unknown result type (might be due to invalid IL or missing references)
            //IL_035f: Unknown result type (might be due to invalid IL or missing references)
            FashionCondition.Setup();
            CordisEffectItem cordisEffectItem = new CordisEffectItem();
            ((Item)cordisEffectItem).name = "Freaky Fashion";
            ((Item)cordisEffectItem).flavorText = "\"It's too bold for you to handle.\"";
            ((Item)cordisEffectItem).description = "On manually moving to a position Opposing an enemy, 100% chance to apply 1 Stunned to them. On activation, decrease this chance by 35%.";
            ((Item)cordisEffectItem).sprite = ResourceLoader.LoadSprite("CordisOS.png");
            ((Item)cordisEffectItem).trigger = TriggerCalls.OnSwapTo;
            ((Item)cordisEffectItem).triggerConditions = new EffectorConditionSO[1] { ScriptableObject.CreateInstance<FashionCondition>() };
            ((Item)cordisEffectItem).consumeTrigger = TriggerCalls.Count;
            ((Item)cordisEffectItem).unlockableID = (UnlockableID)454448;
            ((Item)cordisEffectItem).itemPools = (ItemPools)1;
            ((Item)cordisEffectItem).shopPrice = 8;
            ((Item)cordisEffectItem).startsLocked = false;
            ((EffectItem)cordisEffectItem).immediate = true;
            ((Item)cordisEffectItem).namePopup = true;
            ((Item)cordisEffectItem).consumedOnUse = false;
            ((EffectItem)cordisEffectItem).effects = (Effect[])(object)new Effect[1]
            {
            new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, (IntentType?)null, Slots.Front, (EffectConditionSO)null)
            };
            EffectItem val = new EffectItem();
            ((Item)val).name = "Weaving Flesh";
            ((Item)val).flavorText = "\"I'll bend it to my liking.\"";
            ((Item)val).description = "On killing an enemy, apply this party member's maximum health as Shield to their position.";
            ((Item)val).sprite = ResourceLoader.LoadSprite("CordisH.png");
            ((Item)val).trigger = TriggerCalls.OnKill;
            ((Item)val).consumeTrigger = TriggerCalls.Count;
            ((Item)val).unlockableID = (UnlockableID)464448;
            ((Item)val).itemPools = (ItemPools)1;
            ((Item)val).shopPrice = 5;
            ((Item)val).startsLocked = false;
            val.immediate = false;
            ((Item)val).namePopup = true;
            ((Item)val).consumedOnUse = false;
            val.effects = (Effect[])(object)new Effect[1]
            {
            new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldForMaxHealthEffect>(), 1, (IntentType?)null, Slots.Self, (EffectConditionSO)null)
            };
            DoubleEffectItem doubleEffectItem = new DoubleEffectItem();
            ((Item)doubleEffectItem).name = "Outrageous Flame";
            ((Item)doubleEffectItem).flavorText = "\"It's not over until I say it's over\"";
            ((Item)doubleEffectItem).description = "When at 1 health, this party member will deal 3 more damage than they usually would. On taking damage reducing this character's health to 1, change all non-Red Pigment costs in their abilities to Red.";
            ((Item)doubleEffectItem).sprite = ResourceLoader.LoadSprite("CordisD.png");
            ((Item)doubleEffectItem).trigger = TriggerCalls.OnWillApplyDamage;
            ((Item)doubleEffectItem).triggerConditions = new EffectorConditionSO[1] { ScriptableObject.CreateInstance<OneHealthDamageBoostCondition>() };
            ((Item)doubleEffectItem).consumeTrigger = TriggerCalls.Count;
            ((Item)doubleEffectItem).unlockableID = (UnlockableID)474448;
            ((Item)doubleEffectItem).itemPools = (ItemPools)1;
            ((Item)doubleEffectItem).shopPrice = 7;
            ((Item)doubleEffectItem).startsLocked = false;
            doubleEffectItem._firsteEffectImmediat = true;
            ((Item)doubleEffectItem).namePopup = true;
            ((Item)doubleEffectItem).consumedOnUse = false;
            doubleEffectItem.firstEffects = (Effect[])(object)new Effect[0];
            doubleEffectItem._secondImmediateEffect = false;
            doubleEffectItem.secondPopUp = true;
            doubleEffectItem.SecondTrigger = new TriggerCalls[4]
            {
            TriggerCalls.OnDamaged,
            TriggerCalls.OnHealed,
            TriggerCalls.OnMaxHealthChanged,
            TriggerCalls.OnCombatStart
            };
            doubleEffectItem.secondTriggerConditions = new EffectorConditionSO[1] { ScriptableObject.CreateInstance<IsOneHealthCondition>() };
            doubleEffectItem.secondEffects = (Effect[])(object)new Effect[1]
            {
            new Effect((EffectSO)ScriptableObject.CreateInstance<RedCostsAllAbilitiesCasterEffect>(), 1, (IntentType?)null, Slots.Self, (EffectConditionSO)null)
            };
            EffectItem val2 = new EffectItem();
            ((Item)val2).name = "Head of Siren";
            ((Item)val2).flavorText = "\"This is just a mutated fish...\"";
            ((Item)val2).description = "At the start of combat, apply Withering as a passive to the Left and Right enemies. This item is destroyed upon activation.";
            ((Item)val2).sprite = ResourceLoader.LoadSprite("CordisS.png");
            ((Item)val2).trigger = TriggerCalls.OnCombatStart;
            ((Item)val2).consumeTrigger = TriggerCalls.Count;
            ((Item)val2).unlockableID = (UnlockableID)484448;
            ((Item)val2).itemPools = (ItemPools)4;
            ((Item)val2).shopPrice = 10;
            ((Item)val2).startsLocked = false;
            val2.immediate = false;
            ((Item)val2).namePopup = true;
            ((Item)val2).consumedOnUse = true;
            AddPassiveEffect addPassiveEffect = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addPassiveEffect._passiveToAdd = Passives.Withering;
            val2.effects = (Effect[])(object)new Effect[1]
            {
            new Effect((EffectSO)addPassiveEffect, 1, (IntentType?)null, Slots.LeftRight, (EffectConditionSO)null)
            };
            if (defaultUnlocked)
            {
                ((Item)cordisEffectItem).AddItem();
                ((Item)val).AddItem();
                ((Item)doubleEffectItem).AddItem();
                ((Item)val2).AddItem();
                FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item)(object)val2), 1);
            }
            else
            {
                FoolBossUnlockSystem.FoolItemPairs foolItemPairs = new FoolBossUnlockSystem.FoolItemPairs(ThisSucksElipses.Chorcer, (Item)(object)val, (Item)(object)cordisEffectItem);
                foolItemPairs.AddUnlock((BossType)26991, (Item)(object)doubleEffectItem);
                foolItemPairs.AddUnlock((BossType)55983, (Item)(object)val2, 1);
                foolItemPairs.Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)464448, AchievementUnlockType.TheDivine, "Weaving Flesh", "Unlocked a new item.", ResourceLoader.LoadSprite("CordHeaven.png")).Prepare(ThisSucksElipses.Chorcer.entityID, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)454448, AchievementUnlockType.TheWitness, "Freaky Fashion", "Unlocked a new item.", ResourceLoader.LoadSprite("CordOsman.png")).Prepare(ThisSucksElipses.Chorcer.entityID, BossType.OsmanSinnoks);
            }
        }

        public static void Concussion(bool defaultUnlocked)
    {
      Targetting_ByUnit_Side instance1 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance1.getAllies = false;
      instance1.getAllUnitSlots = false;
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Rioting Frenzy";
      osmanUnlock.flavorText = "\"This is getting out of control.\"";
      osmanUnlock.description = "On killing an enemy, apply 2 Fire to all enemy positions and 35% chance to give each enemy an additional action.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("HSOS.png");
      osmanUnlock.trigger = (TriggerCalls) 24;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 454449;
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.startsLocked = false;
      osmanUnlock.immediate = false;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.effects = new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, new IntentType?(), Slots.SlotTarget(new int[9]
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
        })),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RiotingFrenzyEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance1)
      };
      Targetting_ByUnit_Side instance2 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance2.getAllies = true;
      instance2.getAllUnitSlots = false;
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Leftover Testaments";
      heavenUnlock.flavorText = "\"Hope I don't get the short end of the stick.\"";
      heavenUnlock.description = "On death, give all other party members one move from the holder's current moveset.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("HSH.png");
      heavenUnlock.trigger = (TriggerCalls) 10;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 464449;
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 6;
      heavenUnlock.startsLocked = false;
      heavenUnlock.immediate = false;
      heavenUnlock.namePopup = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<TestamentEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance2)
      };
      SandbagItem.Setup();
      SandbagCondition.Setup();
      SandbagItem unlock1 = new SandbagItem();
      unlock1.name = "Striking Sandbag";
      unlock1.flavorText = "\"Charging up my attack for when you least expect it.\"";
      unlock1.description = "Once this party member has taken 12 damage this combat, if the 12th point of damage was dealt by a character or enemy deal 12 damage to that unit.";
      unlock1.sprite = ResourceLoader.LoadSprite("HSD.png");
      unlock1.trigger = (TriggerCalls) 5;
      unlock1.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<SandbagCondition>()
      };
      unlock1.consumeTrigger = (TriggerCalls) 1000;
      unlock1.unlockableID = (UnlockableID) 474449;
      unlock1.itemPools = ItemPools.Treasure;
      unlock1.shopPrice = 8;
      unlock1.startsLocked = false;
      unlock1.namePopup = false;
      unlock1.consumedOnUse = false;
      DoubleEffectItem unlock2 = new DoubleEffectItem();
      unlock2.name = "Bucket Full of Chum";
      unlock2.flavorText = "\"Devoted to all life\"";
      unlock2.description = "At the start of combat, set the Lucky Pigment percentage to 0. On anything dying, generate 2 Universal Grey Pigment.";
      unlock2.sprite = ResourceLoader.LoadSprite("HSS.png");
      unlock2.trigger = (TriggerCalls) 25;
      unlock2.consumeTrigger = (TriggerCalls) 1000;
      unlock2.unlockableID = (UnlockableID) 484449;
      unlock2.itemPools = ItemPools.Shop;
      unlock2.shopPrice = 6;
      unlock2.startsLocked = false;
      unlock2._firsteEffectImmediat = false;
      unlock2.namePopup = true;
      unlock2.firstPopUp = true;
      unlock2.consumedOnUse = false;
      unlock2.firstEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<LuckyBluePercentageSetEffect>(), 0, new IntentType?(), Slots.Self)
      };
      unlock2.SecondTrigger = new TriggerCalls[1]
      {
        PissYosself.AnyHasDied
      };
      unlock2.secondPopUp = true;
      unlock2.secondEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<GenerateGreyManaEffect>(), 2, new IntentType?(), Slots.Self)
      };
      if (defaultUnlocked)
      {
        osmanUnlock.AddItem();
        heavenUnlock.AddItem();
        unlock1.AddItem();
        unlock2.AddItem();
      }
      else
      {
        FoolBossUnlockSystem.FoolItemPairs foolItemPairs = new FoolBossUnlockSystem.FoolItemPairs(Jelmer.Dumbass, (Item) heavenUnlock, (Item) osmanUnlock);
        foolItemPairs.AddUnlock((BossType) 26991, (Item) unlock1);
        foolItemPairs.AddUnlock((BossType) 55983, (Item) unlock2);
        foolItemPairs.Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 464449, (AchievementUnlockType) 5, "Leftover Testaments", "Unlocked a new item.", ResourceLoader.LoadSprite("HelmHeaven.png")).Prepare(Jelmer.Dumbass.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 454449, (AchievementUnlockType) 4, "Rioting Frenzy", "Unlocked a new item.", ResourceLoader.LoadSprite("HelmOsman.png")).Prepare(Jelmer.Dumbass.entityID, (BossType) 9);
      }
    }

    public static void Storage()
    {
      LoveDamageTypeHook.Add();
      FleetingPassiveAbility fleetingPassiveAbility = UnityEngine.Object.Instantiate<FleetingPassiveAbility>(Passives.Fleeting as FleetingPassiveAbility);
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._passiveName = "Fleeting (2)";
      ((BasePassiveAbilitySO) fleetingPassiveAbility)._characterDescription = "After 2 rounds this party member will flee... Coward.";
      fleetingPassiveAbility._turnsBeforeFleeting = 2;
      EffectItem effectItem = new EffectItem();
      effectItem.name = "Misfortune Roundabout";
      effectItem.flavorText = "\"Come aboard the love train!\"";
      effectItem.description = "This party member has Fleeting (2) as a passive. All damage dealt to this party member will be redirected as indirect damage to a random enemy.";
      effectItem.sprite = Placeholder.Random;
      effectItem.trigger = (TriggerCalls) 6;
      effectItem.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<LoveTrainCondition>()
      };
      effectItem.consumeTrigger = (TriggerCalls) 1000;
      effectItem.unlockableID = (UnlockableID) 474447;
      effectItem.namePopup = true;
      effectItem.consumedOnUse = false;
      effectItem.itemPools = ItemPools.Treasure;
      effectItem.shopPrice = 10;
      effectItem.startsLocked = false;
      effectItem.immediate = false;
      effectItem.effects = new Effect[0];
      ExtraPassiveAbility_Wearable_SMS instance = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance._extraPassiveAbility = (BasePassiveAbilitySO) fleetingPassiveAbility;
      effectItem.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance
      };
    }
  }
}
