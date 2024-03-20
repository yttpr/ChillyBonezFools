// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.DecomposingCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class DecomposingCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      return effector is CharacterCombat characterCombat && characterCombat.Rank > 0;
    }
  }
}
