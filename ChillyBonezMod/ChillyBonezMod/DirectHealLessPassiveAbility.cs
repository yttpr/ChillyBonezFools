// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DirectHealLessPassiveAbility
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class DirectHealLessPassiveAbility : BasePassiveAbilitySO
  {
    [Header("Multiplier Data")]
    [SerializeField]
    [Min(0.0f)]
    private int _modifyVal = 1;
    public bool hasDirectHealed = false;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (args is CanHealReference canHealReference && canHealReference.healAmount > 0 && args is CanHealReference && !(args as CanHealReference).Equals((object) null))
        this.hasDirectHealed = canHealReference.directHeal;
      if (!(args is IntValueChangeException valueChangeException) || valueChangeException.amount <= 0 || !(args is IntValueChangeException) || (args as IntValueChangeException).Equals((object) null) || !this.hasDirectHealed)
        return;
      valueChangeException.AddModifier((IntValueModifier) new MalnourishedValueModifier(0.25f));
      CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(((IEffectorChecks) (sender as IPassiveEffector)).ID, ((IEffectorChecks) (sender as IPassiveEffector)).IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
    }

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
