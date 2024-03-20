// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ShredMove3TimesEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ShredMove3TimesEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      CasterStoredValueChangeEffect instance = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance._minimumValue = 0;
      instance._valueName = (UnitStoredValueNames) 444441;
      instance._increase = true;
      Effect effect1 = new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      Effect effect2 = new Effect((EffectSO) instance, 1, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) Conditions.Chance(entryVariable));
      for (int index = 0; index < 3; ++index)
      {
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          effect1
        }), caster, 0));
        ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
