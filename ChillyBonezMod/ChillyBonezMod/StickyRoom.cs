// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.StickyRoom
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
  public static class StickyRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "StripStick";

    private static string Files => "StripStick_CH";

    private static Character chara => stickoMoFo.Sticky;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => true;

    private static Color32 Color => new Color32((byte) 96, (byte) 96, (byte) 93, byte.MaxValue);

    private static string roomName => StickyRoom.Name + "Room";

    private static string convoName => StickyRoom.Name + "Convo";

    private static string encounterName => StickyRoom.Name + "Encounter";

    private static Sprite Talk => StickyRoom.chara.frontSprite;

    private static Sprite Portal => StickyRoom.chara.unlockedSprite;

    private static string Audio => StickyRoom.chara.dialogueSound;

    private static int ID => (int) StickyRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) StickyRoom.ID, StickyRoom.Portal);
      StickyRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + StickyRoom.Name + "Room.prefab");
      StickyRoom.Room = StickyRoom.Base.AddComponent<NPCRoomHandler>();
      StickyRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) StickyRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      StickyRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) StickyRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) StickyRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = StickyRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + StickyRoom.Name + ".TryHire";
      StickyRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = StickyRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = StickyRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = StickyRoom.roomName;
      instance2._freeFool = StickyRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) StickyRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) StickyRoom.ID
      };
      StickyRoom.Free = instance2;
      StickyRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = StickyRoom.Audio,
        portrait = StickyRoom.Talk,
        bundleTextColor = (StickyRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = StickyRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = StickyRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = StickyRoom.bundle;
      instance3.portraitLooksLeft = StickyRoom.Left;
      instance3.portraitLooksCenter = StickyRoom.Center;
      StickyRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + StickyRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + StickyRoom.roomName, (BaseRoomHandler) StickyRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + StickyRoom.roomName] = (BaseRoomHandler) StickyRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(StickyRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(StickyRoom.convoName, StickyRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[StickyRoom.convoName] = StickyRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(StickyRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(StickyRoom.encounterName, StickyRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[StickyRoom.encounterName] = StickyRoom.Free;
      Backrooms.AddPool(StickyRoom.encounterName, StickyRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(StickyRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(StickyRoom.speaker.speakerName, StickyRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[StickyRoom.speaker.speakerName] = StickyRoom.speaker;
    }
  }
}
