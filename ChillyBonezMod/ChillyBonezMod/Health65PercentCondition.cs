// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.Health65PercentCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class Health65PercentCondition : EffectConditionSO
  {
    public bool Greater;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      float maximumHealth = (float) caster.MaximumHealth;
      float num = (float) caster.CurrentHealth / maximumHealth;
      return this.Greater && (double) num > 0.64999997615814209 || !this.Greater && (double) num <= 0.64999997615814209;
    }

    public static Health65PercentCondition Create(bool more)
    {
      Health65PercentCondition instance = ScriptableObject.CreateInstance<Health65PercentCondition>();
      instance.Greater = more;
      return instance;
    }
  }
}
