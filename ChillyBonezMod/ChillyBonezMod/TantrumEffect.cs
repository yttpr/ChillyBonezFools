// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.TantrumEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class TantrumEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int entryVariable1 = 0;
      int entryVariable2 = 0;
      int entryVariable3 = Random.Range(1, 4);
      if (entryVariable == 0)
      {
        entryVariable2 = 3;
        entryVariable1 = Random.Range(1, 3);
      }
      if (entryVariable == 1)
      {
        entryVariable2 = 5;
        entryVariable1 = Random.Range(1, 4);
      }
      if (entryVariable == 2)
      {
        entryVariable2 = 7;
        entryVariable1 = Random.Range(2, 4);
      }
      if (entryVariable == 3)
      {
        entryVariable2 = 9;
        entryVariable1 = 3;
      }
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          AnimationVisualsEffect instance = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
          instance._animationTarget = Slots.Front;
          instance._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
          CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[4]
          {
            new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Front),
            new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), entryVariable2, new IntentType?(), Slots.Front),
            new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), entryVariable1, new IntentType?(), Slots.Front),
            new Effect((EffectSO) ScriptableObject.CreateInstance<SwapSidesEntryVariableTimesEffect>(), entryVariable3, new IntentType?(), Slots.Front)
          }), caster, 0));
        }
      }
      exitAmount += entryVariable2;
      exitAmount += entryVariable1;
      exitAmount += entryVariable3;
      return true;
    }
  }
}
