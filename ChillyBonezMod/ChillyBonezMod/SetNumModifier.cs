// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SetNumModifier
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class SetNumModifier : IntValueModifier
  {
    public readonly int toSet;

    public SetNumModifier(int set)
      : base(120)
    {
      this.toSet = set;
    }

    public override int Modify(int value)
    {
      value = this.toSet;
      return value;
    }
  }
}
