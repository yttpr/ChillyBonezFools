// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ForcedMarchEffectorCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ForcedMarchEffectorCondition : EffectorConditionSO
  {
    [SerializeField]
    public bool _passIfTrue = true;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is DamageReceivedValueChangeException valueChangeException))
        return false;
      valueChangeException.AddModifier((IntValueModifier) new MarchTrigger(effector as IUnit));
      return true;
    }
  }
}
