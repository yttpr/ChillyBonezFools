// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.WallRoom
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
  public static class WallRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Willow";

    private static string Files => "Willow_CH";

    private static Character chara => KYS.Hexer;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => true;

    private static Color32 Color => new Color32((byte) 56, (byte) 56, (byte) 117, byte.MaxValue);

    private static string roomName => WallRoom.Name + "Room";

    private static string convoName => WallRoom.Name + "Convo";

    private static string encounterName => WallRoom.Name + "Encounter";

    private static Sprite Talk => WallRoom.chara.frontSprite;

    private static Sprite Portal => WallRoom.chara.unlockedSprite;

    private static string Audio => WallRoom.chara.dialogueSound;

    private static int ID => (int) WallRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) WallRoom.ID, WallRoom.Portal);
      WallRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + WallRoom.Name + "Room.prefab");
      WallRoom.Room = WallRoom.Base.AddComponent<NPCRoomHandler>();
      WallRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) WallRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      WallRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) WallRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) WallRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = WallRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + WallRoom.Name + ".TryHire";
      WallRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = WallRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = WallRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = WallRoom.roomName;
      instance2._freeFool = WallRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) WallRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) WallRoom.ID
      };
      WallRoom.Free = instance2;
      WallRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = WallRoom.Audio,
        portrait = WallRoom.Talk,
        bundleTextColor = (WallRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = WallRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = WallRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = WallRoom.bundle;
      instance3.portraitLooksLeft = WallRoom.Left;
      instance3.portraitLooksCenter = WallRoom.Center;
      WallRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + WallRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + WallRoom.roomName, (BaseRoomHandler) WallRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + WallRoom.roomName] = (BaseRoomHandler) WallRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(WallRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(WallRoom.convoName, WallRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[WallRoom.convoName] = WallRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(WallRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(WallRoom.encounterName, WallRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[WallRoom.encounterName] = WallRoom.Free;
      Backrooms.AddPool(WallRoom.encounterName, WallRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(WallRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(WallRoom.speaker.speakerName, WallRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[WallRoom.speaker.speakerName] = WallRoom.speaker;
    }
  }
}
