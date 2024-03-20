// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Adrenaline
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
  public static class Adrenaline
  {
    public static StatusEffectInfoSO adrenaline = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
    public static IntentInfo adrenalineIntent = (IntentInfo) new IntentInfoBasic();

    public static void AddAdrenalineStatusEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      (Adrenaline.adrenaline).name = nameof (Adrenaline);
      Adrenaline.adrenaline.icon = ResourceLoader.LoadSprite("aderlineIcon");
      Adrenaline.adrenaline._statusName = nameof (Adrenaline);
      Adrenaline.adrenaline.statusEffectType = (StatusEffectType) 444442;
      Adrenaline.adrenaline._description = "Increase damage dealt by this character by 30%. Upon dealing damage, decrease Adrenaline by 1.";
      Adrenaline.adrenaline._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].AppliedSoundEvent;
      Adrenaline.adrenaline._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].UpdatedSoundEvent;
      Adrenaline.adrenaline._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 444442, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) 444442, Adrenaline.adrenaline);
    }

    public static void AdrenalineIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      Adrenaline.adrenalineIntent._type = (IntentType) 444442;
      Adrenaline.adrenalineIntent._sprite = ResourceLoader.LoadSprite("aderlineIcon");
      Adrenaline.adrenalineIntent._color = Color.white;
      Adrenaline.adrenalineIntent._sound = self._intentDB[(IntentType) 159]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) 444442, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) 444442, Adrenaline.adrenalineIntent);
    }

    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (Adrenaline).GetMethod("AddAdrenalineStatusEffect", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (Adrenaline).GetMethod("AdrenalineIntent", ~BindingFlags.Default));
    }
  }
}
