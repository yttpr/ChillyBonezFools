// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HasUsedAbilityEffectorCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class HasUsedAbilityEffectorCondition : EffectorConditionSO
  {
    [SerializeField]
    public bool _passIfTrue = false;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      return this._passIfTrue == (effector as CharacterCombat)._amountManualAbilitiesPerformed > 0;
    }
  }
}
