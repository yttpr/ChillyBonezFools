// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CasterStoredValueCHeckingEffectCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class CasterStoredValueCHeckingEffectCondition : EffectConditionSO
  {
    public bool wasSuccessful = true;
    [Range(1f, 20f)]
    public int previousAmount = 1;
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 444400;
    public int minimumAmount = 0;
    public int _checkValue = 2;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      int num = currentIndex - this.previousAmount;
      return caster.GetStoredValue(this._valueName) >= this._checkValue;
    }
  }
}
