// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.LoveTrainCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class LoveTrainCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is DamageReceivedValueChangeException hitBy))
        return false;
      hitBy.AddModifier((IntValueModifier) new LoveTrainMod(hitBy));
      return true;
    }
  }
}
