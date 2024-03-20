// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ChangeFirstTargetMaxHealthEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ChangeFirstTargetMaxHealthEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = false;
    [SerializeField]
    public bool _entryAsPercentage;

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
          if (this._entryAsPercentage)
            num1 = targets[index].Unit.CalculatePercentualAmount(num1);
          int num2 = targets[index].Unit.MaximumHealth + (this._increase ? num1 : -num1);
          if (targets[index].Unit.MaximizeHealth(num2))
          {
            exitAmount += num1;
            return exitAmount > 0;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
