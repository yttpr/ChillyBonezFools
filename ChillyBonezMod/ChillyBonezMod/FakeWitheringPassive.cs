using System;
using System.Runtime.CompilerServices;
using BrutalAPI;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000058 RID: 88
    public static class FakeWitheringPassive
    {
        // Token: 0x060001A1 RID: 417 RVA: 0x0000C464 File Offset: 0x0000A664
        public static BasePassiveAbilitySO FakeWithering()
        {
            PerformEffectPassiveAbility performEffectPassiveAbility = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            performEffectPassiveAbility._passiveName = Passives.Withering._passiveName;
            performEffectPassiveAbility.passiveIcon = Passives.Withering.passiveIcon;
            performEffectPassiveAbility.type = (PassiveAbilityTypes)3;
            performEffectPassiveAbility._enemyDescription = Passives.Withering._enemyDescription;
            performEffectPassiveAbility._characterDescription = Passives.Withering._characterDescription;
            performEffectPassiveAbility.doesPassiveTriggerInformationPanel = false;
            /*BasePassiveAbilitySO basePassiveAbilitySO = performEffectPassiveAbility;
            TriggerCalls[] array = new TriggerCalls[7];
            RuntimeHelpers.InitializeArray(array, fieldof(< PrivateImplementationDetails > .4017AD0E83F755E72811EEF72AE5D1BB0EAA00529DD209169BA6CEB5359696DA).FieldHandle);
            basePassiveAbilitySO._triggerOn = array;*/
            performEffectPassiveAbility._triggerOn = new TriggerCalls[]
            {
                TriggerCalls.OnBeingDamaged,
                TriggerCalls.OnBeingHealed,
                TriggerCalls.CanHeal,
                TriggerCalls.CanChangeHealthColor,
                TriggerCalls.CanApplyStatusEffect,
                TriggerCalls.CanBeInstaKilled,
                TriggerCalls.CanBeSwapped,
            };
            performEffectPassiveAbility.conditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<BrokenRelicCondition>()
            };
            performEffectPassiveAbility.effects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
            return performEffectPassiveAbility;
        }
    }
}
