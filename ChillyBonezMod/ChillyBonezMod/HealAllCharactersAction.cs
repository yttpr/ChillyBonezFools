// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HealAllCharactersAction
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class HealAllCharactersAction : CombatAction
  {
    public int Min;
    public int Max;

    public HealAllCharactersAction(int min, int maxExc)
    {
      this.Min = min;
      this.Max = maxExc;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      foreach (CharacterCombat chara in stats.CharactersOnField.Values)
      {
        int amt = Random.Range(this.Min, this.Max);
        if (chara.IsAlive)
          chara.Heal(amt, (HealType) 1, true);
      }
      yield break;
    }
  }
}
