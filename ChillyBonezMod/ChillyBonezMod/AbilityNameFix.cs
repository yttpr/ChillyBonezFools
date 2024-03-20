// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.AbilityNameFix
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
  public static class AbilityNameFix
  {
    public static global::CharacterAbility CharacterAbility(
      Func<Ability, global::CharacterAbility> orig,
      Ability self)
    {
      global::CharacterAbility characterAbility = orig(self);
      characterAbility.ability._abilityName = self.name;
      characterAbility.ability._description = self.description;
      ( characterAbility.ability).name = self.name;
      AbilitySO abilitySo = AbilityNameFix.AddStoredValue(characterAbility.ability, self.name);
      characterAbility.ability = abilitySo;
      return characterAbility;
    }

    public static EnemyAbilityInfo EnemyAbility(Func<Ability, EnemyAbilityInfo> orig, Ability self)
    {
      EnemyAbilityInfo enemyAbilityInfo = orig(self);
      enemyAbilityInfo.ability._abilityName = self.name;
      enemyAbilityInfo.ability._description = self.description;
      (enemyAbilityInfo.ability).name = self.name;
      AbilitySO abilitySo = AbilityNameFix.AddStoredValue(enemyAbilityInfo.ability, self.name);
      enemyAbilityInfo.ability = abilitySo;
      return enemyAbilityInfo;
    }

    public static AbilitySO AddStoredValue(AbilitySO ret, string name)
    {
      if (name.Contains("Stir"))
        ret.specialStoredValue = Jelmer.Stir;
      else if (name.Contains("Head Dive"))
        ret.specialStoredValue = Jelmer.Dive;
      return ret;
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("CharacterAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("CharacterAbility", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("EnemyAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("EnemyAbility", ~BindingFlags.Default));
    }
  }
}
