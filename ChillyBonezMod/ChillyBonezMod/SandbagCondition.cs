// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SandbagCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class SandbagCondition : EffectorConditionSO
  {
    public static UnitStoredValueNames Pain = (UnitStoredValueNames) 357401;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is IntegerReference integerReference)
      {
        (effector as IUnit).SetStoredValue(SandbagCondition.Pain, (effector as IUnit).GetStoredValue(SandbagCondition.Pain) + integerReference.value);
        if ((effector as IUnit).GetStoredValue(SandbagCondition.Pain) < 12)
          return false;
      }
      return true;
    }

    public static string AddStoredValueName1(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == SandbagCondition.Pain)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Damage Taken This Combat:" + string.Format(" {0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
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
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (SandbagCondition).GetMethod("AddStoredValueName1", ~BindingFlags.Default));
    }
  }
}
