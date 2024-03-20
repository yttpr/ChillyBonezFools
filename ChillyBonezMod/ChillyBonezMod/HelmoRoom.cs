// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HelmoRoom
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
  public static class HelmoRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Helmspark";

    private static string Files => "Helmspark_CH";

    private static Character chara => Jelmer.Dumbass;

    private static int Zone => 2;

    private static bool Left => true;

    private static bool Center => true;

    private static Color32 Color => new Color32((byte) 186, (byte) 126, (byte) 167, byte.MaxValue);

    private static string roomName => HelmoRoom.Name + "Room";

    private static string convoName => HelmoRoom.Name + "Convo";

    private static string encounterName => HelmoRoom.Name + "Encounter";

    private static Sprite Talk => HelmoRoom.chara.frontSprite;

    private static Sprite Portal => HelmoRoom.chara.unlockedSprite;

    private static string Audio => HelmoRoom.chara.dialogueSound;

    private static int ID => (int) HelmoRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) HelmoRoom.ID, HelmoRoom.Portal);
      HelmoRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + HelmoRoom.Name + "Room.prefab");
      HelmoRoom.Room = HelmoRoom.Base.AddComponent<NPCRoomHandler>();
      HelmoRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) HelmoRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      HelmoRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) HelmoRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) HelmoRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = HelmoRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Chilly." + HelmoRoom.Name + ".TryHire";
      HelmoRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = HelmoRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = HelmoRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = HelmoRoom.roomName;
      instance2._freeFool = HelmoRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) HelmoRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) HelmoRoom.ID
      };
      HelmoRoom.Free = instance2;
      HelmoRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = HelmoRoom.Audio,
        portrait = HelmoRoom.Talk,
        bundleTextColor = (HelmoRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = HelmoRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = HelmoRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = HelmoRoom.bundle;
      instance3.portraitLooksLeft = HelmoRoom.Left;
      instance3.portraitLooksCenter = HelmoRoom.Center;
      HelmoRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + HelmoRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + HelmoRoom.roomName, (BaseRoomHandler) HelmoRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + HelmoRoom.roomName] = (BaseRoomHandler) HelmoRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(HelmoRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(HelmoRoom.convoName, HelmoRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[HelmoRoom.convoName] = HelmoRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(HelmoRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(HelmoRoom.encounterName, HelmoRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[HelmoRoom.encounterName] = HelmoRoom.Free;
      Backrooms.AddPool(HelmoRoom.encounterName, HelmoRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(HelmoRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(HelmoRoom.speaker.speakerName, HelmoRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[HelmoRoom.speaker.speakerName] = HelmoRoom.speaker;
    }
  }
}
