using System;
using BrutalAPI;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000091 RID: 145
    public class RandomPassiveEffect : EffectSO
    {
        // Token: 0x170000B8 RID: 184
        // (get) Token: 0x0600023E RID: 574 RVA: 0x00011845 File Offset: 0x0000FA45
        public static BasePassiveAbilitySO AddIt
        {
            get
            {
                return RandomPassiveEffect.Passi[UnityEngine.Random.Range(0, RandomPassiveEffect.Passi.Length)];
            }
        }

        // Token: 0x0600023F RID: 575 RVA: 0x0001185A File Offset: 0x0000FA5A
        public static void Setup()
        {
            RandomPassiveEffect.addPassi._passiveToAdd = RandomPassiveEffect.AddIt;
        }

        // Token: 0x06000240 RID: 576 RVA: 0x0001186C File Offset: 0x0000FA6C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = RandomPassiveEffect.addPassi == null;
            if (flag)
            {
                RandomPassiveEffect.addPassi = ScriptableObject.CreateInstance<AddPassiveEffect>();
            }
            bool casterToo = this.CasterToo;
            if (casterToo)
            {
                for (int i = 0; i < entryVariable; i++)
                {
                    RandomPassiveEffect.Setup();
                    int num;
                    bool flag2 = RandomPassiveEffect.addPassi.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out num);
                    if (flag2)
                    {
                        exitAmount++;
                    }
                }
            }
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {
                    IUnit unit = targetSlotInfo.Unit;
                    for (int k = 0; k < entryVariable; k++)
                    {
                        RandomPassiveEffect.Setup();
                        int num2;
                        bool flag3 = RandomPassiveEffect.addPassi.PerformEffect(stats, unit, Slots.Self.GetTargets(stats.combatSlots, unit.SlotID, unit.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out num2);
                        if (flag3)
                        {
                            exitAmount++;
                        }
                    }
                }
            }
            return exitAmount > 0;
        }

        // Token: 0x06000241 RID: 577 RVA: 0x000119B0 File Offset: 0x0000FBB0
        public static RandomPassiveEffect Create(bool casterToo)
        {
            RandomPassiveEffect randomPassiveEffect = ScriptableObject.CreateInstance<RandomPassiveEffect>();
            randomPassiveEffect.CasterToo = casterToo;
            return randomPassiveEffect;
        }

        // Token: 0x04000117 RID: 279
        public bool CasterToo;

        // Token: 0x04000118 RID: 280
        public static BasePassiveAbilitySO[] Passi = new BasePassiveAbilitySO[]
        {
            Passives.Skittish,
            Passives.Slippery,
            Passives.Dying,
            Passives.Confusion,
            Passives.Cashout,
            Passives.Inanimate,
            Passives.Immortal,
            Passives.Inferno,
            Passives.Leaky,
            Passives.Construct,
            Passives.Constricting,
            Passives.Transfusion,
            Passives.Pure,
            Passives.TwoFaced,
            Passives.Unstable,
            Passives.Catalyst,
            Passives.Absorb,
            Passives.Anchored,
            Passives.Delicate,
            Passives.Enfeebled,
            Passives.Withering,
            LoadedAssetsHandler.GetCharcater("Nowak_CH").passiveAbilities[0],
            LoadedAssetsHandler.GetEnemy("Keko_EN").passiveAbilities[0]
        };

        // Token: 0x04000119 RID: 281
        public static AddPassiveEffect addPassi = ScriptableObject.CreateInstance<AddPassiveEffect>();
    }
}
