// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.AdrenalineValueModifier
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;

#nullable disable
namespace ChillyBonezMod
{
  public class AdrenalineValueModifier : IntValueModifier
  {
    public readonly Decimal toPow;

    public AdrenalineValueModifier()
      : base(70)
    {
      this.toPow = 3M;
      this.toPow /= 10M;
      this.toPow += 1M;
    }

    public override int Modify(int value)
    {
      value = (int) Math.Ceiling((Decimal) value * this.toPow);
      return value;
    }
  }
}
