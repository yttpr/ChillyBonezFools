// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.BrokenRelicEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using System;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class BrokenRelicEffect : EffectSO
  {
    public static int ID = 26175457;
    public static Sprite Image;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (!caster.IsUnitCharacter)
        return false;
      SpawnCharacterAnywhereEffect instance1 = ScriptableObject.CreateInstance<SpawnCharacterAnywhereEffect>();
      instance1.chara = (caster as CharacterCombat).Character;
      instance1._rank = Math.Max(0, (caster as CharacterCombat).Rank);
      int num = instance1._rank + 1;
      instance1._permanentSpawn = false;
      ExtraPassiveAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance2._extraPassiveAbility = Passives.Withering;
      instance1._extraModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance2
      };
      instance1.firstAbil = (caster as CharacterCombat)._firstAbility;
      instance1.secondAbil = (caster as CharacterCombat)._secondAbility;
      string characterName = (caster as CharacterCombat).Character._characterName;
      string str = "(" + characterName + ")";
      EffectItem w = new EffectItem();
      w.name = "Hidden Relic " + str;
      w.flavorText = "\"An illusion of punishment as a blessing\"";
      w.description = "On combat start, spawn a level " + num.ToString() + " nompermanent " + characterName + " with Withering as a passive.";
      w.sprite = BrokenRelicEffect.Image;
      w.trigger = (TriggerCalls) 25;
      w.consumeTrigger = (TriggerCalls) 1000;
      w.unlockableID = (UnlockableID) BrokenRelicEffect.ID;
      exitAmount = BrokenRelicEffect.ID;
      ++BrokenRelicEffect.ID;
      w.namePopup = true;
      w.consumedOnUse = false;
      w.itemPools = ItemPools.Extra;
      w.shopPrice = 6 + num;
      w.startsLocked = false;
      w.immediate = false;
      w.effects = new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self)
      };
      w.AddItem();
      stats.AddExtraLootAddition(FoolBossUnlockSystem.GetItemName((Item) w));
      caster.DirectDeath((IUnit) null, false);
      return true;
    }
  }
}
