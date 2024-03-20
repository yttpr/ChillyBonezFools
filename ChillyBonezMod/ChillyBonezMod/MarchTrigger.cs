// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MarchTrigger
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class MarchTrigger : IntValueModifier
  {
    public readonly IUnit unit;

    public MarchTrigger(IUnit Unit)
      : base(888)
    {
      this.unit = Unit;
    }

    public override int Modify(int value)
    {
      if (value >= 5)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAdrenalineEffect>(), 1, new IntentType?((IntentType) 444422), Slots.Self)
        }), this.unit, 0));
      return value;
    }
  }
}
