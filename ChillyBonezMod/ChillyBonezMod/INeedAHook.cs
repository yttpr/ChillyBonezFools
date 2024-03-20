// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.INeedAHook
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace ChillyBonezMod
{
  public class INeedAHook
  {
    public static void TheHook(Action<Character> orig, Character fool)
    {
      orig(fool);
      if (fool.menuChar)
        WhereDaFlarbz.SelectableCharacters.Add(fool.charData);
      WhereDaFlarbz.Characters.Add(fool.c);
    }

    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (Character).GetMethod("AddCharacter", ~BindingFlags.Default), typeof (INeedAHook).GetMethod("TheHook", ~BindingFlags.Default));
    }
  }
}
