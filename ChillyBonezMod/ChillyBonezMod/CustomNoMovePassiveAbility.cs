// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CustomNoMovePassiveAbility
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class CustomNoMovePassiveAbility : BasePassiveAbilitySO
  {
    [Header("Multiplier Data")]
    [SerializeField]
    [Min(0.0f)]
    private int _modifyVal = 1;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (!(args is BooleanWithTriggerReference triggerReference))
        return;
      if (triggerReference.shouldTrigger)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(iunit.ID, iunit.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
      triggerReference.value = false;
    }

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
