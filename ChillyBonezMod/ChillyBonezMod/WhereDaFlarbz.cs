// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.WhereDaFlarbz
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BepInEx;
using Hawthorne;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  [BepInPlugin("ChillyBonez.DreamOfAFlarb", "Chilly Bonez Foolz", "1.1.3")]
    [BepInDependency("Bones404.BrutalAPI", (BepInDependency.DependencyFlags)1)]
    public class WhereDaFlarbz : BaseUnityPlugin
  {
    public static List<CharacterSO> Characters = new List<CharacterSO>();
    public static List<BasePassiveAbilitySO> Passives = new List<BasePassiveAbilitySO>();
    public static List<SelectableCharacterData> SelectableCharacters = new List<SelectableCharacterData>();
    public static bool Unlocks = true;
    public static bool Debugger = false;

    public void Awake()
    {
      AbilityNameFix.Setup();
      foreach (SelectableCharacterData character in BrutalAPI.BrutalAPI.selCharsSO._characters)
        WhereDaFlarbz.SelectableCharacters.Add(character);
      INeedAHook.Add();
      foreach (CharacterSO vanillaChar in BrutalAPI.BrutalAPI.vanillaChars)
        WhereDaFlarbz.Characters.Add(vanillaChar);
      foreach (CharacterSO moddedChar in BrutalAPI.BrutalAPI.moddedChars)
        WhereDaFlarbz.Characters.Add(moddedChar);
      foreach (BasePassiveAbilitySO passiveAbilitySo in Resources.FindObjectsOfTypeAll<BasePassiveAbilitySO>())
        WhereDaFlarbz.Passives.Add(passiveAbilitySo);
      FuckShitHomoeroticPorn.Add();
      stickoMoFo.Add();
      Adrenaline.Add();
      MortyRicker.Add();
      WhatAnchored.Add();
      EATSHITDIE.Add();
      KYS.Add();
      ThisSucksElipses.Add();
      NewItemYip.Add();
      PissYosself.Setup();
      fisheh.Add();
      OneLastSong.Add();
      Jelmer.Add();
      Bluejak.Add();
      BigGun.Add();
      if (WhereDaFlarbz.Unlocks)
      {
        FoolBossUnlockSystem.Setup();
        Sadlocks.FuckShit(WhereDaFlarbz.Debugger);
        Sadlocks.Stripper(WhereDaFlarbz.Debugger);
        Sadlocks.ShitBrick(WhereDaFlarbz.Debugger);
        Sadlocks.ManILoveFish(WhereDaFlarbz.Debugger);
        Sadlocks.Tree(WhereDaFlarbz.Debugger);
        Sadlocks.Chorder(WhereDaFlarbz.Debugger);
        Sadlocks.Concussion(WhereDaFlarbz.Debugger);
      }
      Backrooms.Setup();
      if (WhereDaFlarbz.Debugger)
      {
        Backrooms.MoreFool(Backrooms.Hard[0]);
        Backrooms.MoreFool(Backrooms.Hard[1]);
        Backrooms.MoreFool(Backrooms.Hard[2]);
      }
      this.Logger.LogInfo((object) "ChillyBonez.DreamOfAFlarb loaded successfully!");
    }
  }
}
