// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.RefreshIfStoredValueNotZero
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class RefreshIfStoredValueNotZero : EffectSO
  {
    [SerializeField]
    public bool _doesExhaustInstead;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 2;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (caster.GetStoredValue(this._valueName) != 0)
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit && (this._doesExhaustInstead ? targets[index].Unit.ExhaustAbilityUse() : targets[index].Unit.RefreshAbilityUse()))
          {
            ++exitAmount;
            int num = caster.GetStoredValue(this._valueName) - entryVariable;
            if (num < 0)
              num = 0;
            caster.SetStoredValue(this._valueName, num);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
