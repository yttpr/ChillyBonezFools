using System;
using System.Collections.Generic;
using BrutalAPI;
using Tools;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x0200002A RID: 42
    public class SpawnTrulyRandomCharacterLevelBasedOnEntryVarEffect : EffectSO
    {
        // Token: 0x06000111 RID: 273 RVA: 0x00008660 File Offset: 0x00006860
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
                int num = this._rank;
                bool flag2 = base.PreviousExitValue >= 5;
                if (flag2)
                {
                    num = 0;
                    for (int i = 6; i < base.PreviousExitValue; i += 2)
                    {
                        num++;
                    }
                    bool flag3 = num > 3;
                    if (flag3)
                    {
                        num = 3;
                    }
                    CharacterSO[] array = WhereDaFlarbz.Characters.ToArray();
                    for (int j = 0; j < entryVariable; j++)
                    {
                        CharacterSO characterSO = array[UnityEngine.Random.Range(0, array.Length - 1)];
                        bool flag4 = characterSO.rankedData.Length > num;
                        if (flag4)
                        {
                            int maxHealth = characterSO.GetMaxHealth(num);
                            int num2;
                            int num3;
                            characterSO.GenerateAbilities(out num2, out num3);
                            CombatManager.Instance.AddSubAction(new SpawnCharacterAction(characterSO, -1, false, nameAdditionData, this._permanentSpawn, num, num2, num3, maxHealth, null));
                        }
                        else
                        {
                            j--;
                        }
                    }
                    Effect effect = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, new IntentType?((IntentType)100), Slots.Self, null);
                    bool flag5 = entryVariable > 0;
                    if (flag5)
                    {
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
                        {
                            effect
                        }), caster, 0));
                    }
                    exitAmount = entryVariable;
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x0400007C RID: 124
        [Header("Rank Data")]
        [SerializeField]
        public int _rank;

        // Token: 0x0400007D RID: 125
        [SerializeField]
        public NameAdditionLocID _nameAddition;

        // Token: 0x0400007E RID: 126
        [SerializeField]
        public bool _permanentSpawn = true;
    }
}
