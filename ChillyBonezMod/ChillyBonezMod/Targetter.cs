// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Targetter
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class Targetter
  {
    private static BaseCombatTargettingSO _leftAlly;
    private static BaseCombatTargettingSO _rightAlly;

    public static BaseCombatTargettingSO LeftAlly
    {
      get
      {
        if (_leftAlly == null)
          Targetter._leftAlly = Slots.SlotTarget(new int[1]
          {
            -1
          }, true);
        return Targetter._leftAlly;
      }
    }

    public static BaseCombatTargettingSO RightAlly
    {
      get
      {
        if (_rightAlly = null)
          Targetter._rightAlly = Slots.SlotTarget(new int[1]
          {
            1
          }, true);
        return Targetter._rightAlly;
      }
    }
  }
}
