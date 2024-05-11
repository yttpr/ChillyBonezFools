// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SandbagItem
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class SandbagItem : EffectItem
  {
    public override BaseWearableSO Wearable()
    {
      SandbagWearable instance = ScriptableObject.CreateInstance<SandbagWearable>();
      instance.BaseWearable((Item) this);
      return (BaseWearableSO) instance;
    }

    public static DamageInfo Damage(
      Func<CharacterCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      CharacterCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      DamageInfo damageInfo = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
      if (self.HasUsableItem && self.HeldItem is SandbagWearable && self.GetStoredValue(SandbagCondition.Pain) >= 12 && killer != null && self.GetStoredValue((UnitStoredValueNames)28282901) <= 0)
      {
                self.SetStoredValue((UnitStoredValueNames)28282901, 1);
        SandBagEffect instance = ScriptableObject.CreateInstance<SandBagEffect>();
        instance.kill = killer;
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) instance, 12, new IntentType?(), Slots.Self)
        }), (IUnit) self, 0));
      }
      return damageInfo;
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (SandbagItem).GetMethod("Damage", ~BindingFlags.Default));
    }
  }
}
