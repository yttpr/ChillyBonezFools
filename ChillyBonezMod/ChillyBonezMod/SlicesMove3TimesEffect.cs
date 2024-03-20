// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SlicesMove3TimesEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class SlicesMove3TimesEffect : EffectSO
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
      AnimationVisualsEffect instance1 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
      instance1._visuals = LoadedAssetsHandler.GetEnemyAbility("FlayTheFlesh_A").visuals;
      instance1._animationTarget = Slots.Front;
      Effect effect1 = new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self);
      CasterStoredValueChangeEffect instance2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance2._minimumValue = 0;
      instance2._valueName = (UnitStoredValueNames) 144444;
      instance2._increase = false;
      CasterStoreValueSetterEffect instance3 = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
      instance3._valueName = instance2._valueName;
      CombatManager.Instance.AddPrioritySubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance3, entryVariable, new IntentType?(), Slots.Self)
      }), caster, 0));
      Effect effect2 = new Effect((EffectSO) ScriptableObject.CreateInstance<SlicesDamageByStoredValueEffect>(), 1, new IntentType?(), Slots.Front);
      Effect effect3 = new Effect((EffectSO) ScriptableObject.CreateInstance<IgnoreAnchoredSwapToSidesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      Effect effect4 = new Effect((EffectSO) instance2, 1, new IntentType?((IntentType) 100), Slots.Self);
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        effect1
      }), caster, 0));
      for (int index = 0; index < 3; ++index)
      {
        effect4._entryVariable = Random.Range(1, 4);
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3]
        {
          effect2,
          effect3,
          effect4
        }), caster, 0));
        ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
