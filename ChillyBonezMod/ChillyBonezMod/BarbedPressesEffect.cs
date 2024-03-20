// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.BarbedPressesEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class BarbedPressesEffect : EffectSO
  {
    public NameAdditionLocID _nameAddition;
    public bool _usePreviousAsHealth;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      CasterStoredValueChangeEffect instance = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance._minimumValue = 0;
      instance._valueName = (UnitStoredValueNames) 444441;
      instance._increase = true;
      ScriptableObject.CreateInstance<DamageEffect>()._indirect = true;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?(), Slots.Self)
      }), caster, 0));
      exitAmount = 0;
      return true;
    }
  }
}
