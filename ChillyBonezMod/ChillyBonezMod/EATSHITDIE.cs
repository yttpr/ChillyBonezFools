// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.EATSHITDIE
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
  public static class EATSHITDIE
  {
    public static StatusEffectInfoSO hexed = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
    public static IntentInfo hexedIntent = (IntentInfo) new IntentInfoBasic();

    public static void AddHexedStatusEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      (EATSHITDIE.hexed).name = "Hexed";
      EATSHITDIE.hexed.icon = ResourceLoader.LoadSprite("hexedIcon");
      EATSHITDIE.hexed._statusName = "Hexed";
      EATSHITDIE.hexed.statusEffectType = (StatusEffectType) 444440;
      EATSHITDIE.hexed._description = "When Hexed, base damage is increased by 3. Upon dealing damage to an enemy, increase by another 3, and decrease max health by 3. \nThis status effect is removed when user skips a turn or is hit directly.";
      EATSHITDIE.hexed._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].AppliedSoundEvent;
      EATSHITDIE.hexed._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].UpdatedSoundEvent;
      EATSHITDIE.hexed._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 444440, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) 444440, EATSHITDIE.hexed);
    }

    public static void HexedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      EATSHITDIE.hexedIntent._type = (IntentType) 444440;
      EATSHITDIE.hexedIntent._sprite = ResourceLoader.LoadSprite("hexedIcon");
      EATSHITDIE.hexedIntent._color = Color.white;
      EATSHITDIE.hexedIntent._sound = self._intentDB[(IntentType) 152]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) 444440, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) 444440, EATSHITDIE.hexedIntent);
    }

    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (EATSHITDIE).GetMethod("AddHexedStatusEffect", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (EATSHITDIE).GetMethod("HexedIntent", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (EATSHITDIE).GetMethod("HexedDisplay", ~BindingFlags.Default));
    }

    public static string HexedDisplay(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)444440)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Hexed" + string.Format(" +{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.cyan) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }
  }
}
