// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SoarCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class SoarCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      IUnit iunit = effector as IUnit;
      int storedValue = iunit.GetStoredValue((UnitStoredValueNames) CodCondition.Soar);
      if (args is IntegerReference integerReference && integerReference.value > 0)
        iunit.SetStoredValue((UnitStoredValueNames) CodCondition.Soar, storedValue + 1);
      return false;
    }
  }
}
