// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.TriggerLoveTrainImmediateAction
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class TriggerLoveTrainImmediateAction : IImmediateAction
  {
    public IUnit _attackedUnit;
    public int _damageReference;
    public bool chara;

    public TriggerLoveTrainImmediateAction(bool Chara, int damageReference)
    {
      this.chara = Chara;
      this._damageReference = damageReference;
    }

    public void Execute(CombatStats stats)
    {
      List<IUnit> iunitList = new List<IUnit>();
      if (!this.chara)
      {
        foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        {
          if (characterCombat.IsAlive && characterCombat.CurrentHealth > 0)
            iunitList.Add((IUnit) characterCombat);
        }
      }
      else
      {
        foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        {
          if (enemyCombat.IsAlive)
            iunitList.Add((IUnit) enemyCombat);
        }
      }
      if (iunitList.Count <= 0)
        return;
      int num;
      for (float damageReference = (float) this._damageReference; iunitList.Count > 0 && (double) damageReference > 0.0; damageReference -= (float) num)
      {
        num = Mathf.CeilToInt(damageReference / (float) iunitList.Count);
        int index = Random.Range(0, iunitList.Count);
        IUnit iunit = iunitList[index];
        iunitList.RemoveAt(index);
        iunit.Damage(num, (IUnit) null, (DeathType) 1, -1, false, false, true, (DamageType) 768313);
      }
    }
  }
}
