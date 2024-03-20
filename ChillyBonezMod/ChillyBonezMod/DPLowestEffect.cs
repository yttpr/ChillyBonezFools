// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DPLowestEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class DPLowestEffect : EffectSO
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
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      int num = -1;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.IsAlive)
        {
          if (num < 0)
          {
            targetSlotInfoList.Add(target);
            num = target.Unit.CurrentHealth;
          }
          else if (target.Unit.CurrentHealth < num)
          {
            targetSlotInfoList.Clear();
            targetSlotInfoList.Add(target);
            num = target.Unit.CurrentHealth;
          }
          else if (target.Unit.CurrentHealth == num)
            targetSlotInfoList.Add(target);
        }
      }
      for (int index = 0; index < targetSlotInfoList.Count; ++index)
      {
        AnimationVisualsEffect instance = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
        instance._visuals = LoadedAssetsHandler.GetCharacterAbility("Malpractice_1_A").visuals;
        instance._animationTarget = Slots.Self;
        TargetSlotInfo targetSlotInfo = targetSlotInfoList[index];
        Effect effect1 = new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self);
        Effect effect2 = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), entryVariable, new IntentType?(), Slots.Self);
        Effect effect3 = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), entryVariable, new IntentType?(), Slots.Self);
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
        {
          effect1,
          effect3
        }), targetSlotInfo.Unit, 0));
        exitAmount += entryVariable;
      }
      return exitAmount > 0;
    }
  }
}
