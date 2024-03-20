// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ChangeMaxHealthEffectCorrectExit
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ChangeMaxHealthEffectCorrectExit : EffectSO
  {
    [SerializeField]
    public bool _increase = true;
    [SerializeField]
    public bool _entryAsPercentage;
    public bool _usePrevExitVal;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          int num1 = entryVariable;
          if (this._usePrevExitVal)
            num1 *= this.PreviousExitValue;
          if (this._entryAsPercentage)
            num1 = targets[index].Unit.CalculatePercentualAmount(num1);
          int num2 = targets[index].Unit.MaximumHealth + (this._increase ? num1 : -num1);
          if (targets[index].Unit.MaximizeHealth(num2))
          {
            if (num2 > 0)
            {
              exitAmount += num1;
            }
            else
            {
              int num3 = 1 - num2;
              int num4 = num1 - num3;
              exitAmount += num4;
            }
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
