// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SlicesDamageByStoredValueEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class SlicesDamageByStoredValueEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 144444;
    [SerializeField]
    public bool _increaseDamage = true;
    [SerializeField]
    public bool _indirect;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      int num1 = caster.GetStoredValue(this._valueName);
      if (!this._increaseDamage)
        num1 = -num1;
      int num2 = Mathf.Max(num1, 0);
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num3 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          DamageInfo damageInfo;
          if (this._indirect)
          {
            damageInfo = target.Unit.Damage(num2, (IUnit) null, this._deathType, num3, false, false, true, (DamageType) 0);
          }
          else
          {
            int num4 = caster.WillApplyDamage(num2, target.Unit);
            damageInfo = target.Unit.Damage(num4, caster, this._deathType, num3, true, true, false, (DamageType) 0);
          }
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
