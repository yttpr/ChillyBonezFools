// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.fisheh
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class fisheh
  {
    public static void Add()
    {
      EffectItem effectItem1 = new EffectItem();
      effectItem1.name = "Blood Box";
      effectItem1.flavorText = "\"All this violence for a trinket...\"";
      effectItem1.description = "On anything dying, 10% chance to destroy this item and produce 1 Treasure item.";
      effectItem1.sprite = ResourceLoader.LoadSprite("bloodybox");
      effectItem1.trigger = PissYosself.AnyHasDied;
      effectItem1.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ChanceCondition.Chance(10)
      };
      effectItem1.consumeTrigger = (TriggerCalls) 1000;
      effectItem1.unlockableID = (UnlockableID) 444445;
      effectItem1.namePopup = true;
      effectItem1.consumedOnUse = true;
      effectItem1.itemPools = ItemPools.Shop;
      effectItem1.shopPrice = 4;
      effectItem1.startsLocked = false;
      effectItem1.immediate = false;
      ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>()._consumeMana = Pigments.Red;
      ExtraLootEffect instance1 = ScriptableObject.CreateInstance<ExtraLootEffect>();
      instance1._isTreasure = true;
      effectItem1.effects = new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self)
      };
      effectItem1.AddItem();
      EffectItem effectItem2 = new EffectItem();
      effectItem2.name = "Sorrowful Bait";
      effectItem2.flavorText = "\"The tears of your enemies will lure them to you.\"";
      effectItem2.description = "At the end of combat, consume all blue pigment. For every 3 blue pigment consumed, produce 1 \"fish\".";
      effectItem2.sprite = ResourceLoader.LoadSprite("sorrowful");
      effectItem2.trigger = (TriggerCalls) 31;
      effectItem2.triggerConditions = new EffectorConditionSO[0];
      effectItem2.consumeTrigger = (TriggerCalls) 1000;
      effectItem2.unlockableID = (UnlockableID) 444444;
      effectItem2.namePopup = true;
      effectItem2.consumedOnUse = false;
      effectItem2.itemPools = ItemPools.Shop;
      effectItem2.shopPrice = 4;
      effectItem2.startsLocked = false;
      effectItem2.immediate = false;
      ConsumeAllColorManaEffect instance2 = ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>();
      instance2._consumeMana = Pigments.Blue;
      effectItem2.effects = new Effect[2]
      {
        new Effect((EffectSO) instance2, 1, new IntentType?((IntentType) 61), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ProduceFishFor3EntryVarEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self)
      };
      effectItem2.AddItem();
      EffectItem effectItem3 = new EffectItem();
      effectItem3.name = "Cryptic Mold";
      effectItem3.flavorText = "\"I'll make you whole.\"";
      effectItem3.description = "Whenever any party member has their health reduced below 50%, fully heal them and apply permanent Frail. Does not work on Inanimate or Dying party members or party members who are Cursed. \nThis item is destroyed upon activation.";
      effectItem3.sprite = ResourceLoader.LoadSprite("cyptricshell");
      effectItem3.trigger = PissYosself.CharacterWasHealthChanged;
      effectItem3.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<MoldEffectorCondition>()
      };
      effectItem3.consumeTrigger = (TriggerCalls) 1000;
      effectItem3.unlockableID = (UnlockableID) 444443;
      effectItem3.namePopup = false;
      effectItem3.consumedOnUse = false;
      effectItem3.itemPools = ItemPools.Treasure;
      effectItem3.shopPrice = 4;
      effectItem3.startsLocked = false;
      effectItem3.immediate = true;
      ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>()._consumeMana = Pigments.Purple;
      effectItem3.effects = new Effect[0];
      effectItem3.AddItem();
    }
  }
}
