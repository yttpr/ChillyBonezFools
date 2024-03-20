using System;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000080 RID: 128
    public class SpawnTrulyRandomCharacterSameLevelSamePositionEffect : EffectSO
    {
        // Token: 0x06000204 RID: 516 RVA: 0x0000FCE8 File Offset: 0x0000DEE8
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CharacterDataBase characterDB = LoadedAssetsHandler.GetCharacterDB();
            bool flag = characterDB == null || characterDB.Equals(null);
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                List<CharacterSO> randomCharacters = characterDB.GetRandomCharacters(entryVariable);
                string nameAdditionData = LocUtils.LocDB.GetNameAdditionData(this._nameAddition);
                int rank = this._rank;
                CharacterCombat characterCombat = caster as CharacterCombat;
                bool flag2 = characterCombat != null;
                if (flag2)
                {
                    rank = characterCombat.Rank;
                }
                CharacterSO[] array = WhereDaFlarbz.Characters.ToArray();
                for (int i = 0; i < entryVariable; i++)
                {
                    CharacterSO characterSO = array[UnityEngine.Random.Range(0, array.Length - 1)];
                    bool flag3 = false;
                    foreach (SelectableCharacterData selectableCharacterData in WhereDaFlarbz.SelectableCharacters)
                    {
                        flag3 = true;
                    }
                    bool flag4 = characterSO.rankedData.Length > rank && flag3;
                    if (flag4)
                    {
                        int maxHealth = characterSO.GetMaxHealth(rank);
                        int num;
                        int num2;
                        characterSO.GenerateAbilities(out num, out num2);
                        CombatManager.Instance.AddSubAction(new SpawnCharacterAction(characterSO, caster.SlotID, false, nameAdditionData, this._permanentSpawn, rank, num, num2, maxHealth, null));
                    }
                    else
                    {
                        i--;
                    }
                }
                exitAmount = entryVariable;
                result = true;
            }
            return result;
        }

        // Token: 0x040000FA RID: 250
        [Header("Rank Data")]
        [SerializeField]
        public int _rank;

        // Token: 0x040000FB RID: 251
        [SerializeField]
        public NameAdditionLocID _nameAddition;

        // Token: 0x040000FC RID: 252
        [SerializeField]
        public bool _permanentSpawn = true;
    }
}
