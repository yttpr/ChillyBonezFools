// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.BrokenRelicCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class BrokenRelicCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (CombatManager.Instance._stats.IsPlayerTurn || !(effector is IUnit iunit) || iunit.HasManuallySwappedThisTurn || iunit.HasManuallyUsedAbilityThisTurn)
        return false;
      switch (args)
      {
        case DamageReceivedValueChangeException valueChangeException1:
          valueChangeException1.AddModifier((IntValueModifier) new SetNumModifier(0));
          break;
        case IntValueChangeException valueChangeException2:
          valueChangeException2.AddModifier((IntValueModifier) new SetNumModifier(0));
          break;
        case StatusEffectApplication effectApplication:
          effectApplication.value = false;
          break;
        case CanHealReference canHealReference:
          canHealReference.value = false;
          break;
        case BooleanWithTriggerReference triggerReference:
          triggerReference.value = false;
          break;
        case BooleanReference booleanReference:
          booleanReference.value = false;
          break;
        default:
          return false;
      }
      Sprite sprite = (Sprite) null;
      if (effector is CharacterCombat characterCombat && characterCombat.HasUsableItem)
        sprite = characterCombat.HeldItem.wearableImage;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(iunit.ID, "Broken Artifact", false, sprite));
      return true;
    }
  }
}
