// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.NewItemYip
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class NewItemYip
  {
    public static void Add()
    {
      EffectItem effectItem1 = new EffectItem();
      effectItem1.name = "Phone Book";
      effectItem1.flavorText = "\"I know a guy who knows a guy who knows a guy who-\"";
      effectItem1.description = "Upon this party member's death, attempt to consume 15 coins, if successful, spawn a random same-level permanent party member. Does not work if equipped on Nowak. \nThis item is destroyed upon activation.";
      effectItem1.sprite = ResourceLoader.LoadSprite("phonebook");
      effectItem1.trigger = (TriggerCalls) 10;
      effectItem1.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<Has15CoinsEffectorCondition>()
      };
      effectItem1.consumeTrigger = (TriggerCalls) 1000;
      effectItem1.unlockableID = (UnlockableID) 444450;
      effectItem1.namePopup = true;
      effectItem1.consumedOnUse = true;
      effectItem1.itemPools = ItemPools.Shop;
      effectItem1.shopPrice = 0;
      effectItem1.startsLocked = false;
      effectItem1.immediate = false;
      effectItem1.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<SpawnTrulyRandomCharacterSameLevelSamePositionEffect>(), 1, new IntentType?((IntentType) 83), Slots.Self)
      };
      effectItem1.AddItem();
      PercentageEffectorCondition instance1 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
      instance1.triggerPercentage = 15;
      EffectItem effectItem2 = new EffectItem();
      effectItem2.name = "Firecrackers";
      effectItem2.flavorText = "\"We used to use them on urinals.\"";
      effectItem2.description = "15% to deal 10 indirect damage to all enemies upon using an ability. This item is destroyed upon activation.";
      effectItem2.sprite = ResourceLoader.LoadSprite("firecacker");
      effectItem2.trigger = (TriggerCalls) 14;
      effectItem2.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) instance1
      };
      effectItem2.consumeTrigger = (TriggerCalls) 1000;
      effectItem2.unlockableID = (UnlockableID) 444449;
      effectItem2.namePopup = true;
      effectItem2.consumedOnUse = true;
      effectItem2.itemPools = ItemPools.Shop;
      effectItem2.shopPrice = 5;
      effectItem2.startsLocked = false;
      effectItem2.immediate = false;
      DamageEffect instance2 = ScriptableObject.CreateInstance<DamageEffect>();
      instance2._indirect = true;
      Targetting_ByUnit_Side instance3 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance3.getAllies = false;
      instance3.getAllUnitSlots = false;
      effectItem2.effects = new Effect[1]
      {
        new Effect((EffectSO) instance2, 10, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) instance3)
      };
      effectItem2.AddItem();
      EffectItem effectItem3 = new EffectItem();
      effectItem3.name = "Farfetch";
      effectItem3.flavorText = "\"You sure it's gonna hit?\"";
      effectItem3.description = "When performing an action, deal 4 indirect damage to the far left and far right enemies.";
      effectItem3.sprite = ResourceLoader.LoadSprite("farfetch");
      effectItem3.trigger = (TriggerCalls) 14;
      effectItem3.consumeTrigger = (TriggerCalls) 1000;
      effectItem3.unlockableID = (UnlockableID) 444448;
      effectItem3.namePopup = true;
      effectItem3.consumedOnUse = false;
      effectItem3.itemPools = ItemPools.Shop;
      effectItem3.shopPrice = 3;
      effectItem3.startsLocked = false;
      effectItem3.immediate = false;
      effectItem3.effects = new Effect[1]
      {
        new Effect((EffectSO) instance2, 4, new IntentType?((IntentType) 1), Slots.SlotTarget(new int[2]
        {
          -2,
          2
        }))
      };
      effectItem3.AddItem();
      EffectItem effectItem4 = new EffectItem();
      effectItem4.name = "Forced March";
      effectItem4.flavorText = "\"Pop a pill and you'll be brand new!\"";
      effectItem4.description = "If this party member takes 5 or more damage, direct or indirect, apply 1 Adrenaline to self.";
      effectItem4.sprite = ResourceLoader.LoadSprite("forcedmarch");
      effectItem4.trigger = (TriggerCalls) 6;
      effectItem4.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<ForcedMarchEffectorCondition>()
      };
      effectItem4.consumeTrigger = (TriggerCalls) 1000;
      effectItem4.unlockableID = (UnlockableID) 444447;
      effectItem4.namePopup = true;
      effectItem4.consumedOnUse = false;
      effectItem4.itemPools = ItemPools.Shop;
      effectItem4.shopPrice = 6;
      effectItem4.startsLocked = false;
      effectItem4.immediate = false;
      effectItem4.effects = new Effect[0];
      effectItem4.AddItem();
      MultiConsumeEffectItem consumeEffectItem = new MultiConsumeEffectItem();
      consumeEffectItem.name = "Peaceful Sidelines";
      consumeEffectItem.flavorText = "\"You decide to do this now at this time of place, seriously!?\"";
      consumeEffectItem.description = "If this party member did not perform an action this turn, produce 1 coin. This item is destroyed upon performing an ability and on taking direct damage.";
      consumeEffectItem.sprite = ResourceLoader.LoadSprite("peace");
      consumeEffectItem.trigger = (TriggerCalls) 7;
      consumeEffectItem.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<HasUsedAbilityEffectorCondition>()
      };
      consumeEffectItem.consumeTrigger = (TriggerCalls) 14;
      consumeEffectItem.ExtraConsumeTriggers = new TriggerCalls[1]
      {
        (TriggerCalls) 12
      };
      consumeEffectItem.unlockableID = (UnlockableID) 444446;
      consumeEffectItem.namePopup = true;
      consumeEffectItem.consumedOnUse = false;
      consumeEffectItem.itemPools = ItemPools.Shop;
      consumeEffectItem.shopPrice = 3;
      consumeEffectItem.startsLocked = false;
      consumeEffectItem.immediate = false;
      consumeEffectItem.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<GainPlayerCurrencyEffect>(), 1, new IntentType?((IntentType) 105), Slots.Self)
      };
      consumeEffectItem.AddItem();
    }
  }
}
