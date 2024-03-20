// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.PartyBalloonEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class PartyBalloonEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && UnityEngine.Random.Range(0, 100) < 50)
        {
          int num = (int) Math.Ceiling((double) ((float) target.Unit.MaximumHealth * 0.75f));
          target.Unit.MaximizeHealth(num);
        }
      }
      return true;
    }
  }
}
