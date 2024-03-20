// Decompiled with JetBrains decompiler
// Type: Hawthorne.DamageTargetRandomEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Hawthorne
{
  public class DamageTargetRandomEffect : EffectSO
  {
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect = false;
    public int _scars;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          targetSlotInfoList.Add(target);
      }
      bool flag;
      if (targetSlotInfoList.Count <= 0)
      {
        flag = false;
      }
      else
      {
        int index = Random.Range(0, targetSlotInfoList.Count);
        TargetSlotInfo targetSlotInfo = targetSlotInfoList[index];
        areTargetSlots = true;
        int num1 = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
        int num2 = targetSlotInfo.SlotID - caster.SlotID;
        AnimationVisualsEffect instance = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
        instance._animationTarget = Slots.SlotTarget(new int[1]
        {
          num2
        });
        instance._visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
        Effect effect = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), entryVariable, new IntentType?((IntentType) 4), Slots.SlotTarget(new int[1]
        {
          num2
        }));
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
        {
          new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self),
          effect
        }), caster, 0));
        exitAmount = entryVariable;
        flag = exitAmount > 0;
      }
      return flag;
    }
  }
}
