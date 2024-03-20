using System;
using BrutalAPI;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000021 RID: 33
    public class DamagePlusBlueEffect : EffectSO
    {
        // Token: 0x060000DD RID: 221 RVA: 0x00007150 File Offset: 0x00005350
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool usePreviousExitValue = this._usePreviousExitValue;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }
            int num = 0;
            ManaBar mainManaBar = stats.MainManaBar;
            foreach (ManaBarSlot manaBarSlot in mainManaBar.ManaBarSlots)
            {
                bool flag = !manaBarSlot.IsEmpty && manaBarSlot.ManaColor == Pigments.Blue;
                if (flag)
                {
                    num++;
                }
            }
            entryVariable += num;
            exitAmount = 0;
            bool flag2 = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {
                    int num2 = areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : -1;
                    int num3 = entryVariable;
                    bool indirect = this._indirect;
                    DamageInfo damageInfo;
                    if (indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(num3, null, this._deathType, num2, false, false, true, 0);
                    }
                    else
                    {
                        num3 = caster.WillApplyDamage(num3, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(num3, caster, this._deathType, num2, true, true, this._ignoreShield, 0);
                    }
                    flag2 |= damageInfo.beenKilled;
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
                result = flag2;
            }
            return result;
        }

        // Token: 0x04000065 RID: 101
        [SerializeField]
        public DeathType _deathType = (DeathType)1;

        // Token: 0x04000066 RID: 102
        [SerializeField]
        public bool _usePreviousExitValue;

        // Token: 0x04000067 RID: 103
        [SerializeField]
        public bool _ignoreShield;

        // Token: 0x04000068 RID: 104
        [SerializeField]
        public bool _indirect;

        // Token: 0x04000069 RID: 105
        [SerializeField]
        public bool _returnKillAsSuccess;
    }
}
