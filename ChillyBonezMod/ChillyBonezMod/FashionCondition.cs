// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.FashionCondition
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
  public class FashionCondition : EffectorConditionSO
  {
    public static int Fashion = 474448;

    public static string ValueDisplay(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      string str1;
      if (storedValue == (UnitStoredValueNames)FashionCondition.Fashion)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Freaky Fashion" + string.Format(" -{0}%", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (FashionCondition).GetMethod("ValueDisplay", ~BindingFlags.Default));
    }

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      IUnit iunit = effector as IUnit;
      TargetSlotInfo[] targets = Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, iunit.SlotID, true);
      bool flag = false;
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit)
          flag = true;
      }
      if (!flag)
        return flag;
      int storedValue = iunit.GetStoredValue((UnitStoredValueNames) FashionCondition.Fashion);
      int num = 100 - storedValue;
      if (UnityEngine.Random.Range(0, 100) >= num)
        return false;
      iunit.SetStoredValue((UnitStoredValueNames) FashionCondition.Fashion, Math.Min(100, storedValue + 35));
      return true;
    }
  }
}
