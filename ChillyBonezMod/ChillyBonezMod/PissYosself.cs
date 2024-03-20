// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.PissYosself
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace ChillyBonezMod
{
  public static class PissYosself
  {
    public static TriggerCalls CharacterHasDied = (TriggerCalls) 629445;
    public static TriggerCalls EnemyHasDied = (TriggerCalls) 629446;
    public static TriggerCalls AnyHasDied = (TriggerCalls) 629447;
    public static TriggerCalls CharacterWasHealthChanged = (TriggerCalls) 884419;

    public static void CharacterDeath(
      PissYosself.OutFourth<CharacterCombat, DeathReference, DeathType, bool> orig,
      CharacterCombat self,
      DeathReference reference,
      DeathType type,
      out bool CanBeRemoved)
    {
      orig(self, reference, type, out CanBeRemoved);
      CombatStats stats = CombatManager.Instance._stats;
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
      {
        CombatManager.Instance.PostNotification(PissYosself.CharacterHasDied.ToString(), (object) characterCombat, (object) self);
        CombatManager.Instance.PostNotification(PissYosself.AnyHasDied.ToString(), (object) characterCombat, (object) self);
      }
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
      {
        CombatManager.Instance.PostNotification(PissYosself.CharacterHasDied.ToString(), (object) enemyCombat, (object) self);
        CombatManager.Instance.PostNotification(PissYosself.AnyHasDied.ToString(), (object) enemyCombat, (object) self);
      }
    }

    public static void EnemyDeath(
      Action<EnemyCombat, DeathReference, DeathType> orig,
      EnemyCombat self,
      DeathReference reference,
      DeathType type)
    {
      orig(self, reference, type);
      CombatStats stats = CombatManager.Instance._stats;
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
      {
        CombatManager.Instance.PostNotification(PissYosself.EnemyHasDied.ToString(), (object) characterCombat, (object) self);
        CombatManager.Instance.PostNotification(PissYosself.AnyHasDied.ToString(), (object) characterCombat, (object) self);
      }
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
      {
        CombatManager.Instance.PostNotification(PissYosself.EnemyHasDied.ToString(), (object) enemyCombat, (object) self);
        CombatManager.Instance.PostNotification(PissYosself.AnyHasDied.ToString(), (object) enemyCombat, (object) self);
      }
    }

    public static DamageInfo Damage(
      Func<CharacterCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      CharacterCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      DamageInfo damageInfo = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
      CombatStats stats = CombatManager.Instance._stats;
      UnitDamagedInfo unitDamagedInfo = new UnitDamagedInfo((IUnit) self, killer);
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) characterCombat, (object) unitDamagedInfo);
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) enemyCombat, (object) unitDamagedInfo);
      return damageInfo;
    }

    public static int OtherDamageInt(
      Func<CharacterCombat, int, int> orig,
      CharacterCombat self,
      int newHealth)
    {
      int num = orig(self, newHealth);
      CombatStats stats = CombatManager.Instance._stats;
      UnitDamagedInfo unitDamagedInfo = new UnitDamagedInfo((IUnit) self);
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) characterCombat, (object) unitDamagedInfo);
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) enemyCombat, (object) unitDamagedInfo);
      return num;
    }

    public static bool OtherDamageBool(
      Func<CharacterCombat, int, bool> orig,
      CharacterCombat self,
      int newHealth)
    {
      bool flag = orig(self, newHealth);
      CombatStats stats = CombatManager.Instance._stats;
      UnitDamagedInfo unitDamagedInfo = new UnitDamagedInfo((IUnit) self);
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) characterCombat, (object) unitDamagedInfo);
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) enemyCombat, (object) unitDamagedInfo);
      return flag;
    }

    public static int ManaDamage(
      Func<CharacterCombat, int, bool, DeathType, int> orig,
      CharacterCombat self,
      int amount,
      bool useManaSound,
      DeathType deathType)
    {
      int num = orig(self, amount, useManaSound, deathType);
      CombatStats stats = CombatManager.Instance._stats;
      UnitDamagedInfo unitDamagedInfo = new UnitDamagedInfo((IUnit) self);
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) characterCombat, (object) unitDamagedInfo);
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) enemyCombat, (object) unitDamagedInfo);
      return num;
    }

    public static int Heal(
      Func<CharacterCombat, int, HealType, bool, int> orig,
      CharacterCombat self,
      int amount,
      HealType healType,
      bool directHeal)
    {
      int num = orig(self, amount, healType, directHeal);
      CombatStats stats = CombatManager.Instance._stats;
      UnitDamagedInfo unitDamagedInfo = new UnitDamagedInfo((IUnit) self);
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) characterCombat, (object) unitDamagedInfo);
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) enemyCombat, (object) unitDamagedInfo);
      return num;
    }

    public static void StartCombat(Action<CharacterCombat> orig, CharacterCombat self)
    {
      orig(self);
      CombatStats stats = CombatManager.Instance._stats;
      UnitDamagedInfo unitDamagedInfo = new UnitDamagedInfo((IUnit) self);
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) characterCombat, (object) unitDamagedInfo);
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        CombatManager.Instance.PostNotification(PissYosself.CharacterWasHealthChanged.ToString(), (object) enemyCombat, (object) unitDamagedInfo);
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("CharacterDeath", ~BindingFlags.Default), typeof (PissYosself).GetMethod("CharacterDeath", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("EnemyDeath", ~BindingFlags.Default), typeof (PissYosself).GetMethod("EnemyDeath", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (PissYosself).GetMethod("Damage", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ManaDamage", ~BindingFlags.Default), typeof (PissYosself).GetMethod("ManaDamage", ~BindingFlags.Default));
      IDetour idetour5 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("MaximizeHealth", ~BindingFlags.Default), typeof (PissYosself).GetMethod("OtherDamageBool", ~BindingFlags.Default));
      IDetour idetour6 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("SetHealthTo", ~BindingFlags.Default), typeof (PissYosself).GetMethod("OtherDamageBool", ~BindingFlags.Default));
      IDetour idetour7 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ChangeHealthTo", ~BindingFlags.Default), typeof (PissYosself).GetMethod("OtherDamageBool", ~BindingFlags.Default));
      IDetour idetour8 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ReduceHealthTo", ~BindingFlags.Default), typeof (PissYosself).GetMethod("OtherDamageInt", ~BindingFlags.Default));
      IDetour idetour9 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("Heal", ~BindingFlags.Default), typeof (PissYosself).GetMethod("Heal", ~BindingFlags.Default));
      IDetour idetour10 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("StartCombat", ~BindingFlags.Default), typeof (PissYosself).GetMethod("StartCombat", ~BindingFlags.Default));
    }

    public delegate void OutFourth<T1, T2, T3, T4>(T1 a, T2 b, T3 c, out T4 d);
  }
}
