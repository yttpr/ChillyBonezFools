// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.OneHealthDamageBoostCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class OneHealthDamageBoostCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is DamageDealtValueChangeException valueChangeException) || !(effector is IUnit iunit) || iunit.CurrentHealth > 1)
        return false;
      valueChangeException.AddModifier((IntValueModifier) new AdditionValueModifier(true, 3));
      return true;
    }
  }
}
