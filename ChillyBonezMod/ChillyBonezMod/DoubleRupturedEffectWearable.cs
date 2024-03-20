// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DoubleRupturedEffectWearable
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace ChillyBonezMod
{
  public class DoubleRupturedEffectWearable : PerformEffectWearable
  {
    public static int Multiply = 1;

    public override void CustomOnTriggerAttached(IWearableEffector caller)
    {
      ((BaseWearableSO) this).CustomOnTriggerAttached(caller);
      DoubleRupturedEffectWearable.Multiply *= 2;
    }

    public override void CustomOnTriggerDettached(IWearableEffector caller)
    {
      ((BaseWearableSO) this).CustomOnTriggerDettached(caller);
      DoubleRupturedEffectWearable.Multiply /= 2;
    }

    public static void OnSubActionTrigger(
      Action<Ruptured_StatusEffect, object, object, bool> orig,
      Ruptured_StatusEffect self,
      object sender,
      object args,
      bool stateCheck)
    {
      if (DoubleRupturedEffectWearable.Multiply > 2)
        (sender as IUnit).Damage(DoubleRupturedEffectWearable.Multiply, (IUnit) null, (DeathType) 51, -1, false, false, true, (DamageType) 7);
      else
        orig(self, sender, args, stateCheck);
    }

    public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
    {
      DoubleRupturedEffectWearable.Multiply = 2;
      orig(self);
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (DoubleRupturedEffectWearable).GetMethod("InitializeCombat", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (Ruptured_StatusEffect).GetMethod("OnSubActionTrigger", ~BindingFlags.Default), typeof (DoubleRupturedEffectWearable).GetMethod("OnSubActionTrigger", ~BindingFlags.Default));
    }
  }
}
