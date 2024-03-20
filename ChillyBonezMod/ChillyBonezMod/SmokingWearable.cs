// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SmokingWearable
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
  public class SmokingWearable : PerformEffectWearable
  {
    public static bool ItemExists()
    {
      bool flag = false;
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        SmokingWearable heldItem = null;
        int num;
        if (characterCombat.HasUsableItem && characterCombat.HeldItem is SmokingWearable)
        {
          heldItem = characterCombat.HeldItem as SmokingWearable;
          num = heldItem != null ? 1 : 0;
        }
        else
          num = 0;
        if (num != 0)
        {
          CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(characterCombat.ID, "The Never-Ending Elegance", false, ((BaseWearableSO) heldItem).wearableImage));
          flag = true;
        }
      }
      return flag;
    }

    public static void UseAbility(
      Action<CharacterCombat, int, FilledManaCost[]> orig,
      CharacterCombat self,
      int abilityID,
      FilledManaCost[] filledCost)
    {
      orig(self, abilityID, filledCost);
      if (!SmokingWearable.ItemExists())
        return;
      int num = 0;
      foreach (FilledManaCost filledManaCost in filledCost)
      {
        if (filledManaCost.Mana == Pigments.Gray)
          ++num;
      }
      self.MaximizeHealth(self.MaximumHealth - num);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof (SmokingWearable).GetMethod("UseAbility", ~BindingFlags.Default));
    }
  }
}
