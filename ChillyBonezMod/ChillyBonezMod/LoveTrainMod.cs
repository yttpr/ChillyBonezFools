// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.LoveTrainMod
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class LoveTrainMod : IntValueModifier
  {
    public DamageReceivedValueChangeException _hitBy;

    public LoveTrainMod(DamageReceivedValueChangeException hitBy)
      : base(80)
    {
      this._hitBy = hitBy;
    }

    public override int Modify(int value)
    {
      if (value <= 0)
        return value;
      List<EnemyCombat> enemyCombatList = new List<EnemyCombat>((IEnumerable<EnemyCombat>) CombatManager.Instance._stats.EnemiesOnField.Values);
      if (enemyCombatList.Count <= 0)
        return value;
      CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new TriggerLoveTrainImmediateAction(true, value), false);
      EnemyCombat enemyCombat = enemyCombatList[UnityEngine.Random.Range(0, enemyCombatList.Count)];
      value = (int) Math.Floor((double) ((float) value / 2f));
      return value;
    }
  }
}
