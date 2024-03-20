using System;
using System.Collections.Generic;
using BrutalAPI;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000090 RID: 144
    public class SwapAbilitiesCasterFirstTargetEffect : EffectSO
    {
        // Token: 0x0600023B RID: 571 RVA: 0x000115A4 File Offset: 0x0000F7A4
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool flag = SwapAbilitiesCasterFirstTargetEffect.swap == null;
            if (flag)
            {
                SwapAbilitiesCasterFirstTargetEffect.swap = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            }
            exitAmount = 0;
            bool flag2 = !caster.IsUnitCharacter;
            bool result;
            if (flag2)
            {
                result = false;
            }
            else
            {
                CharacterCombat characterCombat = caster as CharacterCombat;
                CharacterCombat characterCombat2 = null;
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    CharacterCombat characterCombat3 = null;
                    bool flag3;
                    if (targetSlotInfo.HasUnit && targetSlotInfo.Unit is CharacterCombat)
                    {
                        characterCombat3 = (targetSlotInfo.Unit as CharacterCombat);
                        flag3 = (characterCombat3 != null);
                    }
                    else
                    {
                        flag3 = false;
                    }
                    bool flag4 = flag3;
                    if (flag4)
                    {
                        characterCombat2 = characterCombat3;
                        break;
                    }
                }
                bool flag5 = characterCombat2 == null || characterCombat2.Equals(null);
                if (flag5)
                {
                    result = false;
                }
                else
                {
                    List<CombatAbility> list = new List<CombatAbility>();
                    foreach (CombatAbility combatAbility in characterCombat.CombatAbilities)
                    {
                        list.Add(combatAbility);
                    }
                    foreach (CombatAbility combatAbility2 in characterCombat2.CombatAbilities)
                    {
                        list.Add(combatAbility2);
                    }
                    List<ExtraAbilityInfo> list2 = new List<ExtraAbilityInfo>();
                    List<ExtraAbilityInfo> list3 = new List<ExtraAbilityInfo>();
                    bool flag6 = true;
                    foreach (CombatAbility combatAbility3 in list)
                    {
                        ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo
                        {
                            ability = combatAbility3.ability,
                            cost = combatAbility3.cost
                        };
                        bool flag7 = flag6;
                        if (flag7)
                        {
                            flag6 = false;
                            list2.Add(extraAbilityInfo);
                        }
                        else
                        {
                            flag6 = true;
                            list3.Add(extraAbilityInfo);
                        }
                    }
                    SwapAbilitiesCasterFirstTargetEffect.swap._abilitiesToSwap = list2.ToArray();
                    int num;
                    SwapAbilitiesCasterFirstTargetEffect.swap.PerformEffect(stats, characterCombat, Slots.Self.GetTargets(stats.combatSlots, characterCombat.SlotID, characterCombat.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out num);
                    exitAmount += num;
                    SwapAbilitiesCasterFirstTargetEffect.swap._abilitiesToSwap = list3.ToArray();
                    int num2;
                    SwapAbilitiesCasterFirstTargetEffect.swap.PerformEffect(stats, characterCombat2, Slots.Self.GetTargets(stats.combatSlots, characterCombat2.SlotID, characterCombat2.IsUnitCharacter), Slots.Self.AreTargetAllies, 1, out num2);
                    exitAmount += num2;
                    result = (exitAmount > 0);
                }
            }
            return result;
        }

        // Token: 0x04000116 RID: 278
        private static SwapCasterAbilitiesEffect swap = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
    }
}
