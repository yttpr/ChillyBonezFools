// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CasterCheckStoredValueAboveCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class CasterCheckStoredValueAboveCondition : EffectConditionSO
  {
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 444400;
    public int minimumAmount = 0;
    public int _checkValue = 2;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return caster.GetStoredValue(this._valueName) == this._checkValue;
    }
  }
}
