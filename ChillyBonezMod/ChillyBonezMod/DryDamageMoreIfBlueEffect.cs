using System;
using BrutalAPI;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000022 RID: 34
    public class DryDamageMoreIfBlueEffect : EffectSO
    {
        // Token: 0x060000DF RID: 223 RVA: 0x00007300 File Offset: 0x00005500
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool usePreviousExitValue = this._usePreviousExitValue;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }
            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {
                    int num = areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : -1;
                    int num2 = entryVariable;
                    bool flag2 = targetSlotInfo.Unit.HealthColor == Pigments.Blue;
                    if (flag2)
                    {
                        float num3 = (float)num2;
                        num3 *= 1.5f;
                        num2 = (int)Math.Ceiling((double)num3);
                    }
                    bool indirect = this._indirect;
                    DamageInfo damageInfo;
                    if (indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(num2, null, this._deathType, num, false, false, true, 0);
                    }
                    else
                    {
                        num2 = caster.WillApplyDamage(num2, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(num2, caster, this._deathType, num, false, true, this._ignoreShield, 0);
                    }
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }
            bool flag3 = !this._indirect && exitAmount > 0;
            if (flag3)
            {
                caster.DidApplyDamage(exitAmount);
            }
            bool flag4 = !this._returnKillAsSuccess;
            bool result;
            if (flag4)
            {
                result = (exitAmount > 0);
            }
            else
            {
                result = flag;
            }
            return result;
        }

        // Token: 0x0400006A RID: 106
        [SerializeField]
        public DeathType _deathType = (DeathType)1;

        // Token: 0x0400006B RID: 107
        [SerializeField]
        public bool _usePreviousExitValue;

        // Token: 0x0400006C RID: 108
        [SerializeField]
        public bool _ignoreShield;

        // Token: 0x0400006D RID: 109
        [SerializeField]
        public bool _indirect;

        // Token: 0x0400006E RID: 110
        [SerializeField]
        public bool _returnKillAsSuccess;
    }
}
