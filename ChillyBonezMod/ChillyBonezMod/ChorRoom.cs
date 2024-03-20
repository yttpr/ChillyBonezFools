// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ChorRoom
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
  public static class ChorRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Cordis";

    private static string Files => "Cordis_CH";

    private static Character chara => ThisSucksElipses.Chorcer;

    private static int Zone => 2;

    private static bool Left => true;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 202, (byte) 17, (byte) 17, byte.MaxValue);

    private static string roomName => ChorRoom.Name + "Room";

    private static string convoName => ChorRoom.Name + "Convo";

    private static string encounterName => ChorRoom.Name + "Encounter";

    private static Sprite Talk => ChorRoom.chara.frontSprite;

    private static Sprite Portal => ChorRoom.chara.unlockedSprite;

    private static string Audio => ChorRoom.chara.dialogueSound;

    private static int ID => (int) ChorRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) ChorRoom.ID, ChorRoom.Portal);
      ChorRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + ChorRoom.Name + "Room.prefab");
      ChorRoom.Room = ChorRoom.Base.AddComponent<NPCRoomHandler>();
      ChorRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) ChorRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      ChorRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) ChorRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) ChorRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = ChorRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + ChorRoom.Name + ".TryHire";
      ChorRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = ChorRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = ChorRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = ChorRoom.roomName;
      instance2._freeFool = ChorRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) ChorRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) ChorRoom.ID
      };
      ChorRoom.Free = instance2;
      ChorRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = ChorRoom.Audio,
        portrait = ChorRoom.Talk,
        bundleTextColor = (ChorRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = ChorRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = ChorRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = ChorRoom.bundle;
      instance3.portraitLooksLeft = ChorRoom.Left;
      instance3.portraitLooksCenter = ChorRoom.Center;
      ChorRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + ChorRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + ChorRoom.roomName, (BaseRoomHandler) ChorRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + ChorRoom.roomName] = (BaseRoomHandler) ChorRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(ChorRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(ChorRoom.convoName, ChorRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[ChorRoom.convoName] = ChorRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(ChorRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(ChorRoom.encounterName, ChorRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[ChorRoom.encounterName] = ChorRoom.Free;
      Backrooms.AddPool(ChorRoom.encounterName, ChorRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(ChorRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(ChorRoom.speaker.speakerName, ChorRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[ChorRoom.speaker.speakerName] = ChorRoom.speaker;
    }
  }
}
