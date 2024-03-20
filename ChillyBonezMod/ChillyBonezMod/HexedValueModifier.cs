// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HexedValueModifier
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class HexedValueModifier : IntValueModifier
  {
    public readonly int toPow;

    public HexedValueModifier(int ToPow)
      : base(70)
    {
      this.toPow = ToPow;
    }

    public override int Modify(int value)
    {
      value += this.toPow;
      return value;
    }
  }
}
