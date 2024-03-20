// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.TofuCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class TofuCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is CanHealReference canHealReference) || !canHealReference.directHeal)
        return false;
      canHealReference.value = false;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), canHealReference.healAmount, new IntentType?(), Slots.Self)
      }), effector as IUnit, 0));
      return true;
    }
  }
}
