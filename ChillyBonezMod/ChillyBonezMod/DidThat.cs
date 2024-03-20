// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DidThat
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class DidThat
  {
    public static PreviousEffectCondition Create(bool did, int prev = 1)
    {
      PreviousEffectCondition instance = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance.wasSuccessful = did;
      instance.previousAmount = prev;
      return instance;
    }
  }
}
