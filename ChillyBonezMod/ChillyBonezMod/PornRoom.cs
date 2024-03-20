// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.PornRoom
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
  public static class PornRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Prayer";

    private static string Files => "Prayer_CH";

    private static Character chara => FuckShitHomoeroticPorn.Fucker;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 202, (byte) 17, (byte) 17, byte.MaxValue);

    private static string roomName => PornRoom.Name + "Room";

    private static string convoName => PornRoom.Name + "Convo";

    private static string encounterName => PornRoom.Name + "Encounter";

    private static Sprite Talk => PornRoom.chara.frontSprite;

    private static Sprite Portal => PornRoom.chara.unlockedSprite;

    private static string Audio => PornRoom.chara.dialogueSound;

    private static int ID => (int) PornRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) PornRoom.ID, PornRoom.Portal);
      PornRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + PornRoom.Name + "Room.prefab");
      PornRoom.Room = PornRoom.Base.AddComponent<NPCRoomHandler>();
      PornRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) PornRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      PornRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) PornRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) PornRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = PornRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + PornRoom.Name + ".TryHire";
      PornRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = PornRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = PornRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = PornRoom.roomName;
      instance2._freeFool = PornRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) PornRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) PornRoom.ID
      };
      PornRoom.Free = instance2;
      PornRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = PornRoom.Audio,
        portrait = PornRoom.Talk,
        bundleTextColor = (PornRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = PornRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = PornRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = PornRoom.bundle;
      instance3.portraitLooksLeft = PornRoom.Left;
      instance3.portraitLooksCenter = PornRoom.Center;
      PornRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + PornRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + PornRoom.roomName, (BaseRoomHandler) PornRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + PornRoom.roomName] = (BaseRoomHandler) PornRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(PornRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(PornRoom.convoName, PornRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[PornRoom.convoName] = PornRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(PornRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(PornRoom.encounterName, PornRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[PornRoom.encounterName] = PornRoom.Free;
      Backrooms.AddPool(PornRoom.encounterName, PornRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(PornRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(PornRoom.speaker.speakerName, PornRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[PornRoom.speaker.speakerName] = PornRoom.speaker;
    }
  }
}
