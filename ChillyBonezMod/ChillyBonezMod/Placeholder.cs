// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Placeholder
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class Placeholder
  {
    private static string[] PNums = new string[20]
    {
      "P00",
      "P01",
      "P02",
      "P03",
      "P04",
      "P05",
      "P06",
      "P07",
      "P08",
      "P09",
      "P10",
      "P11",
      "P12",
      "P13",
      "P14",
      "P15",
      "P16",
      "P17",
      "P18",
      "P19"
    };

    public static Sprite Front => ResourceLoader.LoadSprite("PlaceholderFront.png");

    public static Sprite Phase0 => ResourceLoader.LoadSprite("Placeholder_0.png");

    public static Sprite Phase1 => ResourceLoader.LoadSprite("Placeholder_1.png");

    public static Sprite Phase2 => ResourceLoader.LoadSprite("Placeholder_2.png");

    public static Sprite Phase3 => ResourceLoader.LoadSprite("Placeholder_3.png");

    public static Sprite Back => Placeholder.Front;

    public static Sprite Menu => ResourceLoader.LoadSprite("MenuPlaceholder.png");

    public static Sprite World
    {
      get
      {
        return ResourceLoader.LoadSprite("OverworldPlaceholder.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      }
    }

    public static Sprite Ability => ResourceLoader.LoadSprite("CombatIconPlaceholder.png");

    public static Sprite Status => ResourceLoader.LoadSprite("PassivePlaceholder.png");

    public static Sprite Passive => Placeholder.Status;

    public static Sprite Item => ResourceLoader.LoadSprite("ItemPlaceholder.png");

    public static Sprite Mod => ResourceLoader.LoadSprite("ModIconPlaceholder.png");

    public static Sprite Random
    {
      get
      {
        return ResourceLoader.LoadSprite(Placeholder.PNums[UnityEngine.Random.Range(0, Placeholder.PNums.Length)]);
      }
    }
  }
}
