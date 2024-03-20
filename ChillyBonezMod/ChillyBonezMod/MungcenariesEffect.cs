// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MungcenariesEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using Tools;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class MungcenariesEffect : EffectSO
  {
    public NameAdditionLocID _nameAddition;
    public bool _usePreviousAsHealth;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      CharacterSO charcater = LoadedAssetsHandler.GetCharcater("Mung_CH");
      PerformDoubleEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "MultiAttack (2)";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("MultiAttackIcon");
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 13;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "This shouldn't be on an enemy.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "This party member can perform two abilities per turn.";
      ((BasePassiveAbilitySO) instance1).specialStoredValue = (UnitStoredValueNames) 77889;
      CasterSetStoredValueEffect instance2 = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
      instance2._valueName = (UnitStoredValueNames) 77889;
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
      });
      RefreshIfStoredValueNotZero instance3 = ScriptableObject.CreateInstance<RefreshIfStoredValueNotZero>();
      instance3._valueName = (UnitStoredValueNames) 77889;
      ScriptableObject.CreateInstance<CasterLowerStoredValueEffect>()._valueName = (UnitStoredValueNames) 77889;
      instance1._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      instance1._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1._secondDoesPerformPopUp = false;
      ExtraPassiveAbility_Wearable_SMS instance4 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance4._extraPassiveAbility = (BasePassiveAbilitySO) instance1;
      ExtraPassiveAbility_Wearable_SMS instance5 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance5._extraPassiveAbility = LoadedAssetsHandler.GetCharcater("Mordrake_CH").passiveAbilities[0];
      int num1 = this._usePreviousAsHealth ? Mathf.Max(1, this.PreviousExitValue) : charcater.GetMaxHealth(0);
      int num2;
      int num3;
      charcater.GenerateAbilities(out num2, out num3);
      WearableStaticModifiers wearableStaticModifiers = new WearableStaticModifiers();
      WearableStaticModifierSetterSO[] modifierSetterSoArray = new WearableStaticModifierSetterSO[2]
      {
        (WearableStaticModifierSetterSO) instance4,
        (WearableStaticModifierSetterSO) instance5
      };
      foreach (WearableStaticModifierSetterSO modifierSetterSo in modifierSetterSoArray)
        modifierSetterSo.OnAttachedToCharacter(wearableStaticModifiers, charcater, 0);
      string nameAdditionData = LocUtils.LocDB.GetNameAdditionData(this._nameAddition);
      for (int index = 0; index < entryVariable; ++index)
        CombatManager.Instance.AddSubAction((CombatAction) new SpawnCharacterAction(charcater, -1, false, nameAdditionData, false, 0, num2, num3, num1, wearableStaticModifiers));
      exitAmount = entryVariable;
      return true;
    }
  }
}
