// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.WrongPigRedirectWearable
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Reflection;
using Tools;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class WrongPigRedirectWearable : BaseWearableSO
  {
    public override bool DoesItemTrigger => false;

    public override bool IsItemImmediate => false;

    public static void DealWrongPigDamage(CharacterCombat target, int wrongPigs)
    {
      if (wrongPigs == 0)
        return;
      int num1 = Mathf.Max(1, Mathf.FloorToInt((float) ((double) wrongPigs * (double) Utils.characterDamagePercentagePerManaCost * (double) target.MaximumHealth / 100.0)));
      int num2 = target.FinalizeCostDamage(num1);
      Sprite sprite = (Sprite) null;
      if (target.HasUsableItem)
        sprite = target.HeldItem.wearableImage;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(target.ID, "Martyr's Crown", false, sprite));
      target.Damage(num2, (IUnit) null, (DeathType) 10, -1, false, false, true, (DamageType) 5);
    }

    public static int CalculateAbilityCostsDamage(
      Func<CharacterCombat, int, FilledManaCost[], int> orig,
      CharacterCombat self,
      int abilityID,
      FilledManaCost[] filledCost)
    {
      int abilityCostsDamage = orig(self, abilityID, filledCost);
      if (self.HasUsableItem && self.HeldItem is WrongPigRedirectWearable)
        return abilityCostsDamage;
      foreach (CharacterCombat target in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (target.HasUsableItem && target.HeldItem is WrongPigRedirectWearable)
        {
          CombatManager.Instance.AddRootAction((CombatAction) new WrongPigRedirectWearable.DelayedAction((CombatAction) new WrongPigRedirectWearable.WPWAction(target, self.LastCalculatedWrongMana)));
          return 0;
        }
      }
      return abilityCostsDamage;
    }

    public static int FinalizeCostDamage(
      Func<CharacterCombat, int, int> orig,
      CharacterCombat self,
      int damageAmount)
    {
      if (self.HasUsableItem && self.HeldItem is WrongPigRedirectWearable)
        return orig(self, damageAmount);
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (characterCombat.HasUsableItem && characterCombat.HeldItem is WrongPigRedirectWearable)
          return 0;
      }
      return orig(self, damageAmount);
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("CalculateAbilityCostsDamage", ~BindingFlags.Default), typeof (WrongPigRedirectWearable).GetMethod("CalculateAbilityCostsDamage", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("FinalizeCostDamage", ~BindingFlags.Default), typeof (WrongPigRedirectWearable).GetMethod("FinalizeCostDamage", ~BindingFlags.Default));
    }

    public class WPWAction : CombatAction
    {
      public CharacterCombat c;
      public int w;

      public WPWAction(CharacterCombat target, int wrongPigs)
      {
        this.c = target;
        this.w = wrongPigs;
      }

      public override IEnumerator Execute(CombatStats stats)
      {
        WrongPigRedirectWearable.DealWrongPigDamage(this.c, this.w);
        yield return (object) null;
      }
    }

    public class DelayedAction : CombatAction
    {
      public CombatAction a;

      public DelayedAction(CombatAction orig) => this.a = orig;

      public override IEnumerator Execute(CombatStats stats)
      {
        CombatManager.Instance.AddSubAction(this.a);
        yield return (object) null;
      }
    }
  }
}
