// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.NestSingleEffectEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class NestSingleEffectEffect : EffectSO
  {
    public EffectSO _effect;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      ReturnTargetsTargetting instance = ScriptableObject.CreateInstance<ReturnTargetsTargetting>();
      instance.targets = targets;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect(this._effect, entryVariable, new IntentType?(), (BaseCombatTargettingSO) instance)
      }), caster, 0));
      return true;
    }
  }
}
