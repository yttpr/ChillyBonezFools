// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.RoundUpValueModifier
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;

#nullable disable
namespace ChillyBonezMod
{
  public class RoundUpValueModifier : IntValueModifier
  {
    public readonly int toPow;
    public readonly IEffectorChecks effector;

    public RoundUpValueModifier(int ToPow, IEffectorChecks effector)
      : base(70)
    {
      this.toPow = ToPow;
      this.effector = effector;
    }

    public override int Modify(int value)
    {
      if (value < 10)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(this.effector.ID, this.effector.IsUnitCharacter, "Ungodly Relic", ResourceLoader.LoadSprite("holyfinger")));
      return Math.Max(value, this.toPow);
    }
  }
}
