using System;
using Tools;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000050 RID: 80
    public class SpawnCharacterAnywhereEffect : EffectSO
    {
        // Token: 0x06000191 RID: 401 RVA: 0x0000BFB8 File Offset: 0x0000A1B8
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CharacterSO characterSO = this.chara;
            bool flag = characterSO == null || characterSO.Equals(null);
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                int num = this._usePreviousAsHealth ? Mathf.Max(1, base.PreviousExitValue) : characterSO.GetMaxHealth(this._rank);
                int num2;
                int num3;
                characterSO.GenerateAbilities(out num2, out num3);
                WearableStaticModifiers wearableStaticModifiers = new WearableStaticModifiers();
                WearableStaticModifierSetterSO[] extraModifiers = this._extraModifiers;
                for (int i = 0; i < extraModifiers.Length; i++)
                {
                    extraModifiers[i].OnAttachedToCharacter(wearableStaticModifiers, characterSO, this._rank);
                }
                string nameAdditionData = LocUtils.LocDB.GetNameAdditionData(this._nameAddition);
                for (int j = 0; j < entryVariable; j++)
                {
                    CombatManager.Instance.AddSubAction(new SpawnCharacterAction(characterSO, -1, false, nameAdditionData, this._permanentSpawn, this._rank, this.firstAbil, this.secondAbil, num, wearableStaticModifiers));
                }
                exitAmount = entryVariable;
                result = true;
            }
            return result;
        }

        // Token: 0x040000AF RID: 175
        public int firstAbil;

        // Token: 0x040000B0 RID: 176
        public int secondAbil;

        // Token: 0x040000B1 RID: 177
        [Header("Rank Data")]
        [CharacterRef]
        [SerializeField]
        public string _characterCopy = "";

        // Token: 0x040000B2 RID: 178
        public CharacterSO chara;

        // Token: 0x040000B3 RID: 179
        [SerializeField]
        public int _rank;

        // Token: 0x040000B4 RID: 180
        [SerializeField]
        public NameAdditionLocID _nameAddition;

        // Token: 0x040000B5 RID: 181
        [SerializeField]
        public bool _permanentSpawn;

        // Token: 0x040000B6 RID: 182
        [SerializeField]
        public bool _usePreviousAsHealth;

        // Token: 0x040000B7 RID: 183
        [SerializeField]
        public WearableStaticModifierSetterSO[] _extraModifiers;
    }
}
