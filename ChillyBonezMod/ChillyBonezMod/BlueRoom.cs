// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.BlueRoom
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
  public static class BlueRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Cobalt";

    private static string Files => "CaptainCobalt_CH";

    private static Character chara => Bluejak.Blue;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => false;

    private static Color32 Color => new Color32((byte) 24, (byte) 51, (byte) 186, byte.MaxValue);

    private static string roomName => BlueRoom.Name + "Room";

    private static string convoName => BlueRoom.Name + "Convo";

    private static string encounterName => BlueRoom.Name + "Encounter";

    private static Sprite Talk => BlueRoom.chara.frontSprite;

    private static Sprite Portal => BlueRoom.chara.unlockedSprite;

    private static string Audio => BlueRoom.chara.dialogueSound;

    private static int ID => (int) BlueRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) BlueRoom.ID, BlueRoom.Portal);
      BlueRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + BlueRoom.Name + "Room.prefab");
      BlueRoom.Room = BlueRoom.Base.AddComponent<NPCRoomHandler>();
      BlueRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) BlueRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      BlueRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) BlueRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) BlueRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = BlueRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + BlueRoom.Name + ".TryHire";
      BlueRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = BlueRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = BlueRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = BlueRoom.roomName;
      instance2._freeFool = BlueRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) BlueRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) BlueRoom.ID
      };
      BlueRoom.Free = instance2;
      BlueRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = BlueRoom.Audio,
        portrait = BlueRoom.Talk,
        bundleTextColor = (BlueRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = BlueRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = BlueRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = BlueRoom.bundle;
      instance3.portraitLooksLeft = BlueRoom.Left;
      instance3.portraitLooksCenter = BlueRoom.Center;
      BlueRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + BlueRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + BlueRoom.roomName, (BaseRoomHandler) BlueRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + BlueRoom.roomName] = (BaseRoomHandler) BlueRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(BlueRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(BlueRoom.convoName, BlueRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[BlueRoom.convoName] = BlueRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(BlueRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(BlueRoom.encounterName, BlueRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[BlueRoom.encounterName] = BlueRoom.Free;
      Backrooms.AddPool(BlueRoom.encounterName, BlueRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(BlueRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(BlueRoom.speaker.speakerName, BlueRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[BlueRoom.speaker.speakerName] = BlueRoom.speaker;
    }
  }
}
