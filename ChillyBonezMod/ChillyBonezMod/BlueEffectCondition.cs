using System;
using BrutalAPI;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000020 RID: 32
    public class BlueEffectCondition : EffectConditionSO
    {
        // Token: 0x060000DA RID: 218 RVA: 0x0000709C File Offset: 0x0000529C
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            CombatStats stats = CombatManager.Instance._stats;
            ManaBar mainManaBar = stats.MainManaBar;
            int num = 0;
            foreach (ManaBarSlot manaBarSlot in mainManaBar.ManaBarSlots)
            {
                bool flag = !manaBarSlot.IsEmpty && manaBarSlot.ManaColor == Pigments.Blue;
                if (flag)
                {
                    num++;
                }
            }
            return UnityEngine.Random.Range(0, 100) < num * this.Per;
        }

        // Token: 0x060000DB RID: 219 RVA: 0x00007124 File Offset: 0x00005324
        public static BlueEffectCondition Create(int per)
        {
            BlueEffectCondition blueEffectCondition = ScriptableObject.CreateInstance<BlueEffectCondition>();
            blueEffectCondition.Per = per;
            return blueEffectCondition;
        }

        // Token: 0x04000064 RID: 100
        public int Per;
    }
}
