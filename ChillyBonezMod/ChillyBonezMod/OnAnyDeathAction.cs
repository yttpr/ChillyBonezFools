// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.OnAnyDeathAction
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections;

#nullable disable
namespace ChillyBonezMod
{
  public class OnAnyDeathAction : CombatAction
  {
    public override IEnumerator Execute(CombatStats stats)
    {
      foreach (CharacterCombat chara in stats.CharactersOnField.Values)
      {
        if (chara.IsAlive)
          CombatManager.Instance.PostNotification(AllDeathHealWearable.AnyDeath.ToString(), (object) chara, (object) null);
      }
      yield break;
    }
  }
}
