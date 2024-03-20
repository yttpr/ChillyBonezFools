// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.BulletCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class BulletCondition : EffectConditionSO
  {
    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      int num = caster.GetStoredValue(BigGun.bullets) * 20;
      return Random.Range(0, 100) < num;
    }
  }
}
