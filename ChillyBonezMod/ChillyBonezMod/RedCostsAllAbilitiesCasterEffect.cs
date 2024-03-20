using System;
using System.Collections.Generic;
using BrutalAPI;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000092 RID: 146
    public class RedCostsAllAbilitiesCasterEffect : EffectSO
    {
        // Token: 0x06000244 RID: 580 RVA: 0x00011AE0 File Offset: 0x0000FCE0
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = RedCostsAllAbilitiesCasterEffect.swap == null;
            if (flag)
            {
                RedCostsAllAbilitiesCasterEffect.swap = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            }
            List<ExtraAbilityInfo> list = new List<ExtraAbilityInfo>();
            CharacterCombat characterCombat = caster as CharacterCombat;
            bool flag2 = characterCombat != null;
            bool result;
            if (flag2)
            {
                foreach (CombatAbility combatAbility in characterCombat.CombatAbilities)
                {
                    ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo
                    {
                        ability = combatAbility.ability,
                        cost = new ManaColorSO[combatAbility.cost.Length]
                    };
                    for (int i = 0; i < extraAbilityInfo.cost.Length; i++)
                    {
                        extraAbilityInfo.cost[i] = Pigments.Red;
                    }
                    list.Add(extraAbilityInfo);
                }
                result = RedCostsAllAbilitiesCasterEffect.swap.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out exitAmount);
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0400011A RID: 282
        public static SwapCasterAbilitiesEffect swap = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
    }
}
