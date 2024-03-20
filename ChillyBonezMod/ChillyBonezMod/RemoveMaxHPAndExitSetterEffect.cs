// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.RemoveMaxHPAndExitSetterEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class RemoveMaxHPAndExitSetterEffect : EffectSO
  {
    public bool usePreviousExitValue;
    public bool entryAsPercentage;
    [SerializeField]
    public bool _directHeal = true;
    [SerializeField]
    public bool _onlyIfHasHealthOver0;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this.usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      if (caster is CharacterCombat characterCombat)
      {
        int maxHealth = characterCombat.Character.GetMaxHealth(characterCombat.Rank);
        int maximumHealth = caster.MaximumHealth;
        if (maximumHealth != maxHealth && maximumHealth > maxHealth)
        {
          caster.MaximizeHealth(maxHealth);
          exitAmount = maximumHealth - maxHealth;
        }
      }
      return exitAmount > 0;
    }
  }
}
