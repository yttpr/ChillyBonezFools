// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.PeaPlatterHandler
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace ChillyBonezMod
{
  public static class PeaPlatterHandler
  {
    public static TriggerCalls call = (TriggerCalls) 739930;

    public static void UseAbility(
      Action<CharacterCombat, int, FilledManaCost[]> orig,
      CharacterCombat self,
      int abilityID,
      FilledManaCost[] filledCost)
    {
      orig(self, abilityID, filledCost);
      if (!self.HasUsableItem || self.HeldItem.triggerOn != PeaPlatterHandler.call)
        return;
      CombatManager.Instance.PostNotification(PeaPlatterHandler.call.ToString(), (object) self, (object) null);
      AbilitySO ability = self.CombatAbilities[abilityID].ability;
      CombatManager.Instance.AddRootAction((CombatAction) new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, (IUnit) self));
      CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(ability.effects, (IUnit) self, 0));
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof (PeaPlatterHandler).GetMethod("UseAbility", ~BindingFlags.Default));
    }
  }
}
