// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Hexed_StatusEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using System;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class Hexed_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
  {
    public bool hasActed = false;

    public int StatusContent => this.Amount;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => this.Restrictor <= 0;

    public bool IsPositive => true;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Amount > 0)
          displayText = displayText;
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Amount { get; set; }

    public StatusEffectType EffectType => (StatusEffectType) 444440;

    public StatusEffectInfoSO EffectInfo { get; set; }

    public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

    public bool CanReduceDuration
    {
      get
      {
        BooleanReference booleanReference = new BooleanReference(true);
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new CheckHasStatusFieldReductionBlockIAction(booleanReference), false);
        return !booleanReference.value;
      }
    }

    public Hexed_StatusEffect(int amount, int restrictors = 0)
    {
      this.Amount = amount;
      this.Restrictor = restrictors;
    }

    public bool AddContent(IStatusEffect content)
    {
      this.Amount += (content as Hexed_StatusEffect).Amount;
      this.Restrictor += content.Restrictor;
      return true;
    }

    public bool TryAddContent(int amount)
    {
      if (this.Amount <= 0)
        return false;
      this.Amount += amount;
      return true;
    }

    public int JustRemoveAllContent()
    {
      int amount = this.Amount;
      this.Amount = 0;
      return amount;
    }

    public void OnTriggerAttached(IStatusEffector caller)
    {
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 16).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusFinished), ((TriggerCalls) 29).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnActionDone), ((TriggerCalls) 16).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnBeingHit), ((TriggerCalls) 12).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.HasActedBool), ((TriggerCalls) 14).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.TurnFinished), ((TriggerCalls) 7).ToString(), (object) caller);
      (caller as IUnit).SetStoredValue((UnitStoredValueNames) 444440, 3);
    }

    public void OnTriggerDettached(IStatusEffector caller)
    {
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 16).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusFinished), ((TriggerCalls) 29).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnActionDone), ((TriggerCalls) 16).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnBeingHit), ((TriggerCalls) 12).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.HasActedBool), ((TriggerCalls) 14).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.TurnFinished), ((TriggerCalls) 7).ToString(), (object) caller);
      (caller as IUnit).SetStoredValue((UnitStoredValueNames) 444440, 0);
    }

    public void OnSubActionTrigger(object sender, object args, bool stateCheck)
    {
    }

    public void OnBeingHit(object sender, object args)
    {
      this.DeleteDuration(sender as IStatusEffector);
    }

    public void HasActedBool(object sender, object args) => this.hasActed = true;

    public void TurnFinished(object sender, object args)
    {
      if (!this.hasActed)
        this.DeleteDuration(sender as IStatusEffector);
      else
        this.hasActed = false;
    }

    public void DeleteDuration(IStatusEffector effector)
    {
      int amount = this.Amount;
      this.Amount = 0;
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
    }

    public void OnActionDone(object sender, object args)
    {
      if (!(sender is IUnit iunit))
        return;
      ChangeMaxHealthEffect instance = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
      instance._increase = false;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance, 3, new IntentType?(), Slots.Self)
      }), iunit, 0));
    }

    public void OnStatusFinished(object sender, object args)
    {
      if (!(sender is IUnit iunit))
        return;
      int num = iunit.GetStoredValue((UnitStoredValueNames) 444440) + 3;
      iunit.SetStoredValue((UnitStoredValueNames) 444440, num);
    }

    public void OnCanHeal(object sender, object args)
    {
      if (!(sender is IUnit iunit) || !(args is CanHealReference canHealReference))
        return;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(iunit.ID, iunit.IsUnitCharacter, "Hexed", (Sprite) null));
      canHealReference.value = false;
    }

    public void OnStatusTriggered(object sender, object args)
    {
      if (!(sender is IUnit iunit))
        return;
      int storedValue = iunit.GetStoredValue((UnitStoredValueNames) 444440);
      (args as DamageDealtValueChangeException).AddModifier((IntValueModifier) new HexedValueModifier(storedValue));
    }

    public void OnTurnEnd(object sender, object args)
    {
      this.ReduceDuration(sender as IStatusEffector);
    }

    public void ReduceDuration(IStatusEffector effector)
    {
      if (!this.CanReduceDuration)
        return;
      int amount = this.Amount;
      this.Amount = Mathf.Max(0, this.Amount - 1);
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
    }

    public void ReduceDurationAgain(IStatusEffector effector)
    {
      if (!this.CanReduceDuration || UnityEngine.Random.Range(0, 100) > 33)
        return;
      int amount = this.Amount;
      this.Amount = Mathf.Max(0, this.Amount - 1);
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
      this.ReduceDurationAgain(effector);
    }

    public void IncreaseDuration(IStatusEffector effector, int amount)
    {
    }

    public void DettachRestrictor(IStatusEffector effector)
    {
      --this.Restrictor;
      if (this.TryRemoveStatusEffect(effector))
        return;
      effector.StatusEffectValuesChanged(this.EffectType, 0);
    }

    public bool TryRemoveStatusEffect(IStatusEffector effector)
    {
      if (this.Amount > 0 || !this.CanBeRemoved)
        return false;
      effector.RemoveStatusEffect(this.EffectType);
      return true;
    }
  }
}
