// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.AllDeathHealWearable
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Reflection;

#nullable disable
namespace ChillyBonezMod
{
  public class AllDeathHealWearable : BaseWearableSO
  {
    public static TriggerCalls AnyDeath = (TriggerCalls) 229266;

    public override bool DoesItemTrigger => true;

    public override bool IsItemImmediate => false;

    public static IEnumerator Execute(
      Func<CharacterWitheringAction, CombatStats, IEnumerator> orig,
      CharacterWitheringAction self,
      CombatStats stats)
    {
      IEnumerator enumerator = orig(self, stats);
      int num = 0;
      foreach (CharacterCombat characterCombat in CombatManager.Instance._stats.CharactersOnField.Values)
      {
        if (characterCombat.HasUsableItem && characterCombat.HeldItem is AllDeathHealWearable)
          ++num;
      }
      CombatManager.Instance.AddRootAction((CombatAction) new OnAnyDeathAction());
      for (int index = 0; index < num; ++index)
        CombatManager.Instance.AddRootAction((CombatAction) new HealAllCharactersAction(4, 9));
      return enumerator;
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterWitheringAction).GetMethod("Execute", ~BindingFlags.Default), typeof (AllDeathHealWearable).GetMethod("Execute", ~BindingFlags.Default));
    }
  }
}
