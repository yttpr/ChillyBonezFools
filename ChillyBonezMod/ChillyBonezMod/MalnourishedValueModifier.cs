// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MalnourishedValueModifier
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;

#nullable disable
namespace ChillyBonezMod
{
  public class MalnourishedValueModifier : IntValueModifier
  {
    public readonly float decimate;

    public MalnourishedValueModifier(float timesBy)
      : base(70)
    {
      this.decimate = timesBy;
    }

    public override int Modify(int value)
    {
      value = (int) Math.Ceiling((double) ((float) value * this.decimate));
      return value;
    }
  }
}
