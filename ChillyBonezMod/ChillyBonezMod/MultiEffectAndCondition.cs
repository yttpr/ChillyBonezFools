// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MultiEffectAndCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class MultiEffectAndCondition : EffectConditionSO
  {
    public EffectConditionSO first;
    public EffectConditionSO second;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return this.first.MeetCondition(caster, effects, currentIndex) && this.second.MeetCondition(caster, effects, currentIndex);
    }

    public static MultiEffectAndCondition Create(EffectConditionSO first, EffectConditionSO second)
    {
      MultiEffectAndCondition instance = ScriptableObject.CreateInstance<MultiEffectAndCondition>();
      instance.first = first;
      instance.second = second;
      return instance;
    }
  }
}
