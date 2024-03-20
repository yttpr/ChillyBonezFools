// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CasterLowerStoredValueEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class CasterLowerStoredValueEffect : EffectSO
  {
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
      int num = caster.GetStoredValue(this._valueName) - entryVariable;
      if (num < 0)
        num = 0;
      caster.SetStoredValue(this._valueName, num);
      return exitAmount > 0;
    }
  }
}
