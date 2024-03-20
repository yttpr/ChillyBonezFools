// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ChanceCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ChanceCondition : EffectorConditionSO
  {
    public int chance;

    public static ChanceCondition Chance(int num)
    {
      ChanceCondition instance = ScriptableObject.CreateInstance<ChanceCondition>();
      instance.chance = num;
      return instance;
    }

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      return Random.Range(0, 100) < this.chance;
    }
  }
}
