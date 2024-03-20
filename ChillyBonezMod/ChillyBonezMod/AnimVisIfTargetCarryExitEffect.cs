// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.AnimVisIfTargetCarryExitEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class AnimVisIfTargetCarryExitEffect : EffectSO
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
      exitAmount = this.PreviousExitValue;
      bool flag = false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          flag = true;
      }
      if (!flag)
        return false;
      CombatManager.Instance.AddUIAction((CombatAction) new PlayAbilityAnimationAction(this._visuals, this._animationTarget, caster));
      return true;
    }
  }
}
