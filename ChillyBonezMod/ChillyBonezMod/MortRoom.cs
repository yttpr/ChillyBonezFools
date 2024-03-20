// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MortRoom
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using Hawthorne;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class MortRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Mortis";

    private static string Files => "Mortis_CH";

    private static Character chara => MortyRicker.Rock;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => false;

    private static Color32 Color => new Color32((byte) 45, (byte) 52, (byte) 26, byte.MaxValue);

    private static string roomName => MortRoom.Name + "Room";

    private static string convoName => MortRoom.Name + "Convo";

    private static string encounterName => MortRoom.Name + "Encounter";

    private static Sprite Talk => MortRoom.chara.frontSprite;

    private static Sprite Portal => MortRoom.chara.unlockedSprite;

    private static string Audio => MortRoom.chara.dialogueSound;

    private static int ID => (int) MortRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) MortRoom.ID, MortRoom.Portal);
      MortRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + MortRoom.Name + "Room.prefab");
      MortRoom.Room = MortRoom.Base.AddComponent<NPCRoomHandler>();
      MortRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) MortRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      MortRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) MortRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) MortRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = MortRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + MortRoom.Name + ".TryHire";
      MortRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = MortRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = MortRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = MortRoom.roomName;
      instance2._freeFool = MortRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) MortRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) MortRoom.ID
      };
      MortRoom.Free = instance2;
      MortRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = MortRoom.Audio,
        portrait = MortRoom.Talk,
        bundleTextColor = (MortRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = MortRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = MortRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = MortRoom.bundle;
      instance3.portraitLooksLeft = MortRoom.Left;
      instance3.portraitLooksCenter = MortRoom.Center;
      MortRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + MortRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + MortRoom.roomName, (BaseRoomHandler) MortRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + MortRoom.roomName] = (BaseRoomHandler) MortRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(MortRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(MortRoom.convoName, MortRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[MortRoom.convoName] = MortRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(MortRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(MortRoom.encounterName, MortRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[MortRoom.encounterName] = MortRoom.Free;
      Backrooms.AddPool(MortRoom.encounterName, MortRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(MortRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(MortRoom.speaker.speakerName, MortRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[MortRoom.speaker.speakerName] = MortRoom.speaker;
    }
  }
}
