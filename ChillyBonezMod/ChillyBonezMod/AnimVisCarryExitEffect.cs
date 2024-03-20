// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.AnimVisCarryExitEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class AnimVisCarryExitEffect : EffectSO
  {
    [Header("Visual")]
    [SerializeField]
    public AttackVisualsSO _visuals;
    [SerializeField]
    public BaseCombatTargettingSO _animationTarget;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      CombatManager.Instance.AddUIAction((CombatAction) new PlayAbilityAnimationAction(this._visuals, this._animationTarget, caster));
      exitAmount = this.PreviousExitValue;
      return true;
    }
  }
}
