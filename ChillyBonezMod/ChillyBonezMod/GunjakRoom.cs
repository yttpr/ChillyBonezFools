// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.GunjakRoom
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
  public static class GunjakRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Champ";

    private static string Files => "Champ_CH";

    private static Character chara => BigGun.Balls;

    private static int Zone => 0;

    private static bool Left => true;

    private static bool Center => true;

    private static Color32 Color => new Color32((byte) 118, (byte) 66, (byte) 138, byte.MaxValue);

    private static string roomName => GunjakRoom.Name + "Room";

    private static string convoName => GunjakRoom.Name + "Convo";

    private static string encounterName => GunjakRoom.Name + "Encounter";

    private static Sprite Talk => GunjakRoom.chara.frontSprite;

    private static Sprite Portal => GunjakRoom.chara.unlockedSprite;

    private static string Audio => GunjakRoom.chara.dialogueSound;

    private static int ID => (int) GunjakRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) GunjakRoom.ID, GunjakRoom.Portal);
      GunjakRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + GunjakRoom.Name + "Room.prefab");
      GunjakRoom.Room = GunjakRoom.Base.AddComponent<NPCRoomHandler>();
      GunjakRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) GunjakRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      GunjakRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) GunjakRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) GunjakRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = GunjakRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + GunjakRoom.Name + ".TryHire";
      GunjakRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = GunjakRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = GunjakRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = GunjakRoom.roomName;
      instance2._freeFool = GunjakRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) GunjakRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) GunjakRoom.ID
      };
      GunjakRoom.Free = instance2;
      GunjakRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = GunjakRoom.Audio,
        portrait = GunjakRoom.Talk,
        bundleTextColor = (GunjakRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = GunjakRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = GunjakRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = GunjakRoom.bundle;
      instance3.portraitLooksLeft = GunjakRoom.Left;
      instance3.portraitLooksCenter = GunjakRoom.Center;
      GunjakRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + GunjakRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + GunjakRoom.roomName, (BaseRoomHandler) GunjakRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + GunjakRoom.roomName] = (BaseRoomHandler) GunjakRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(GunjakRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(GunjakRoom.convoName, GunjakRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[GunjakRoom.convoName] = GunjakRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(GunjakRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(GunjakRoom.encounterName, GunjakRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[GunjakRoom.encounterName] = GunjakRoom.Free;
      Backrooms.AddPool(GunjakRoom.encounterName, GunjakRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(GunjakRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(GunjakRoom.speaker.speakerName, GunjakRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[GunjakRoom.speaker.speakerName] = GunjakRoom.speaker;
    }
  }
}
