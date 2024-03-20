// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.WrongPigRedirectItem
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class WrongPigRedirectItem : Item
  {
    public override BaseWearableSO Wearable()
    {
      WrongPigRedirectWearable instance = ScriptableObject.CreateInstance<WrongPigRedirectWearable>();
      instance.BaseWearable((Item) this);
      return (BaseWearableSO) instance;
    }
  }
}
