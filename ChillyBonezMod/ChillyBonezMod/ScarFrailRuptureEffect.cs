using System;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000038 RID: 56
    public class ScarFrailRuptureEffect : EffectSO
    {
        // Token: 0x06000142 RID: 322 RVA: 0x0000ACB4 File Offset: 0x00008EB4
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = entryVariable <= 0;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = ScarFrailRuptureEffect.scar == null;
                if (flag2)
                {
                    ScarFrailRuptureEffect.scar = ScriptableObject.CreateInstance<ApplyScarsEffect>();
                }
                bool flag3 = ScarFrailRuptureEffect.frail == null;
                if (flag3)
                {
                    ScarFrailRuptureEffect.frail = ScriptableObject.CreateInstance<ApplyFrailEffect>();
                }
                bool flag4 = ScarFrailRuptureEffect.rupture == null;
                if (flag4)
                {
                    ScarFrailRuptureEffect.rupture = ScriptableObject.CreateInstance<ApplyRupturedEffect>();
                }
                EffectSO[] array = new EffectSO[]
                {
                    ScarFrailRuptureEffect.scar,
                    ScarFrailRuptureEffect.frail,
                    ScarFrailRuptureEffect.rupture
                };
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    bool hasUnit = targetSlotInfo.HasUnit;
                    if (hasUnit)
                    {
                        int num;
                        bool flag5 = array[UnityEngine.Random.Range(0, array.Length)].PerformEffect(stats, caster, targetSlotInfo.SelfArray(), areTargetSlots, entryVariable, out num);
                        if (flag5)
                        {
                            exitAmount += num;
                        }
                    }
                }
                result = (exitAmount > 0);
            }
            return result;
        }

        // Token: 0x0400009F RID: 159
        public static ApplyScarsEffect scar;

        // Token: 0x040000A0 RID: 160
        public static ApplyFrailEffect frail;

        // Token: 0x040000A1 RID: 161
        public static ApplyRupturedEffect rupture;
    }
}
