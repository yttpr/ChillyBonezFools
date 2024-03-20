// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.GupperRoom
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class GupperRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Guppy";

    private static string Files => "Guppy_CH";

    private static Character chara => WhatAnchored.Tard;

    private static int Zone => 0;

    private static bool Left => true;

    private static bool Center => true;

    private static Color32 Color => new Color32(byte.MaxValue, (byte) 47, (byte) 79, byte.MaxValue);

    private static string roomName => GupperRoom.Name + "Room";

    private static string convoName => GupperRoom.Name + "Convo";

    private static string encounterName => GupperRoom.Name + "Encounter";

    private static Sprite Talk => GupperRoom.chara.frontSprite;

    private static Sprite Portal => GupperRoom.chara.unlockedSprite;

    private static string Audio => GupperRoom.chara.dialogueSound;

    private static int ID => (int) GupperRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) GupperRoom.ID, GupperRoom.Portal);
      GupperRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + GupperRoom.Name + "Room.prefab");
      GupperRoom.Room = GupperRoom.Base.AddComponent<NPCRoomHandler>();
      GupperRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) GupperRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      GupperRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) GupperRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) GupperRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = GupperRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + GupperRoom.Name + ".TryHire";
      GupperRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = GupperRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = GupperRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = GupperRoom.roomName;
      instance2._freeFool = GupperRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) GupperRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) GupperRoom.ID
      };
      GupperRoom.Free = instance2;
      GupperRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = GupperRoom.Audio,
        portrait = GupperRoom.Talk,
        bundleTextColor = (GupperRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = GupperRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = GupperRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = GupperRoom.bundle;
      instance3.portraitLooksLeft = GupperRoom.Left;
      instance3.portraitLooksCenter = GupperRoom.Center;
      GupperRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + GupperRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + GupperRoom.roomName, (BaseRoomHandler) GupperRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + GupperRoom.roomName] = (BaseRoomHandler) GupperRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(GupperRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(GupperRoom.convoName, GupperRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[GupperRoom.convoName] = GupperRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(GupperRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(GupperRoom.encounterName, GupperRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[GupperRoom.encounterName] = GupperRoom.Free;
      Backrooms.AddPool(GupperRoom.encounterName, GupperRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(GupperRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(GupperRoom.speaker.speakerName, GupperRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[GupperRoom.speaker.speakerName] = GupperRoom.speaker;
    }
  }
}
