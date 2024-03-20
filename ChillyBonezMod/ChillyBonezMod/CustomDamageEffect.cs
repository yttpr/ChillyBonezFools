// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CustomDamageEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class CustomDamageEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _usePreviousExitValue = true;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect = true;
    [SerializeField]
    public bool _returnKillAsSuccess;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable = (int) Math.Ceiling((Decimal) entryVariable / 4M * (Decimal) this.PreviousExitValue);
      exitAmount = 0;
      bool flag = false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num1 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num2 = entryVariable;
          DamageInfo damageInfo;
          if (this._indirect)
          {
            damageInfo = target.Unit.Damage(num2, (IUnit) null, this._deathType, num1, false, false, true, (DamageType) 0);
          }
          else
          {
            int num3 = caster.WillApplyDamage(num2, target.Unit);
            damageInfo = target.Unit.Damage(num3, caster, this._deathType, num1, true, true, this._ignoreShield, (DamageType) 0);
          }
          flag |= damageInfo.beenKilled;
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
    }
  }
}
