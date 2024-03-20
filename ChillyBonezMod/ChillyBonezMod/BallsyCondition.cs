// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.BallsyCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class BallsyCondition : EffectorConditionSO
  {
    public static UnitStoredValueNames abom = (UnitStoredValueNames) 4044436;
    public static UnitStoredValueNames count = (UnitStoredValueNames) 4224436;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (effector is IUnit iunit)
      {
        if (args is IntegerReference)
        {
          if (iunit.GetStoredValue(BallsyCondition.abom) > 0)
            return true;
        }
        else
        {
          iunit.SetStoredValue(BallsyCondition.count, iunit.GetStoredValue(BallsyCondition.count) + 1);
          iunit.SetStoredValue(BallsyCondition.abom, iunit.GetStoredValue(BallsyCondition.count));
          return false;
        }
      }
      return false;
    }
  }
}
