// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HealFleeingCharaWearable
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace ChillyBonezMod
{
  public class HealFleeingCharaWearable : PerformEffectWearable
  {
    public static bool ItemExists()
    {
      bool flag = false;
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (characterCombat.HasUsableItem && characterCombat.HeldItem is HealFleeingCharaWearable)
        {
          CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(characterCombat.ID, "Wine and Dash", false, characterCombat.HeldItem.wearableImage));
          flag = true;
        }
      }
      return flag;
    }

    public static void UnitWillFlee(Action<CharacterCombat> orig, CharacterCombat self)
    {
      if (HealFleeingCharaWearable.ItemExists())
        self.Heal(7, (HealType) 1, true);
      orig(self);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("UnitWillFlee", ~BindingFlags.Default), typeof (HealFleeingCharaWearable).GetMethod("UnitWillFlee", ~BindingFlags.Default));
    }
  }
}
