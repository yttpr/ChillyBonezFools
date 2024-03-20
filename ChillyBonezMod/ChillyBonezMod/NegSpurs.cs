// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.NegSpurs
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Tools;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class NegSpurs
  {
    public static string ValueDisplay(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      string str1;
      if (storedValue == (UnitStoredValueNames)9 && value < 0)
      {
        string str2 = LocUtils.LocDB.GetUIData(self._boneSpursSTExtraLocID) + string.Format(" {0}", (object) value);
        string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
        string str4 = "</color>";
        str1 = str3 + str2 + str4;
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (NegSpurs).GetMethod("ValueDisplay", ~BindingFlags.Default));
    }
  }
}
