// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Has15CoinsEffectorCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class Has15CoinsEffectorCondition : EffectorConditionSO
  {
    [SerializeField]
    public bool _passIfTrue = true;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (effector.IsMainCharacter || CombatManager.Instance._stats.PlayerCurrency < 15)
        return false;
      CombatManager.Instance.AddPriorityRootAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 15, new IntentType?(), Slots.Self)
      }), effector as IUnit, 0));
      return true;
    }
  }
}
