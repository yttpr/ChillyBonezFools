// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CodCondition
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
  public class CodCondition : EffectorConditionSO
  {
    public static int Soar = 484447;

    public static string ValueDisplay(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      string str1;
      if (storedValue == (UnitStoredValueNames)CodCondition.Soar)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Soaring Cod" + string.Format(" +{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
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
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (CodCondition).GetMethod("ValueDisplay", ~BindingFlags.Default));
    }

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      int storedValue = (effector as IUnit).GetStoredValue((UnitStoredValueNames) CodCondition.Soar);
      if (!(args is DamageDealtValueChangeException valueChangeException))
        return false;
      valueChangeException.AddModifier((IntValueModifier) new CodCondition.RoundValueMod(4 + storedValue, effector));
      return true;
    }

    public class RoundValueMod : IntValueModifier
    {
      public readonly int toPow;
      public readonly IEffectorChecks effector;

      public RoundValueMod(int ToPow, IEffectorChecks effector)
        : base(70)
      {
        this.toPow = ToPow;
        this.effector = effector;
      }

      public override int Modify(int value) => Math.Max(value, this.toPow);
    }
  }
}
