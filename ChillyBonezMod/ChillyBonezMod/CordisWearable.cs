// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CordisWearable
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class CordisWearable : PerformEffectWearable
  {
    public override void CustomOnTriggerAttached(IWearableEffector caller)
    {
      ((BaseWearableSO) this).CustomOnTriggerAttached(caller);
      if (!(caller is IUnit iunit) || !iunit.IsUnitCharacter)
        return;
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(iunit.ID, (ExtraSpriteType) 4444439));
    }

    public override void CustomOnTriggerDettached(IWearableEffector caller)
    {
      ((BaseWearableSO) this).CustomOnTriggerDettached(caller);
      if (!(caller is IUnit iunit) || !iunit.IsUnitCharacter || !(iunit is CharacterCombat characterCombat) || !(characterCombat.Character._characterName == "Cordis"))
        return;
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(iunit.ID, (ExtraSpriteType) 0));
    }
  }
}
