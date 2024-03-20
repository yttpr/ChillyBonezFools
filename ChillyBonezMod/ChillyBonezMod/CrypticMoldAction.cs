// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.CrypticMoldAction
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections;

#nullable disable
namespace ChillyBonezMod
{
  public class CrypticMoldAction : CombatAction
  {
    public UnitDamagedInfo info;
    public IEffectorChecks effector;
    public int SlotID;

    public static bool IsHealable(IUnit unit)
    {
      return !unit.ContainsPassiveAbility((PassiveAbilityTypes) 24) && !unit.ContainsPassiveAbility((PassiveAbilityTypes) 26) && !unit.ContainsStatusEffect((StatusEffectType) 3, 0);
    }

    public CrypticMoldAction(UnitDamagedInfo info, IEffectorChecks effector)
    {
      this.info = info;
      this.SlotID = info.unit.SlotID;
      this.effector = effector;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      if ((double) this.info.healthPercent < 0.5 && CrypticMoldAction.IsHealable(this.info.unit))
      {
        if (!this.info.unit.IsAlive)
          stats.ResurrectDeadCharacter(this.info.unit as CharacterCombat, this.SlotID, 0);
        this.info.unit.Heal(this.info.maxHealth - this.info.currentHealth, (HealType) 1, true);
        StatusEffectInfoSO value;
        stats.statusEffectDataBase.TryGetValue((StatusEffectType) 1, out value);
        Frail_StatusEffect permaFrail = new Frail_StatusEffect(0, 1);
        permaFrail.SetEffectInformation(value);
        this.info.unit.ApplyStatusEffect((IStatusEffect) permaFrail, 0);
        if (MoldEffectorCondition.HealingTargets.Contains(this.info.unit))
          MoldEffectorCondition.HealingTargets.Remove(this.info.unit);
        (this.effector as IUnit).TryConsumeWearable();
        value = (StatusEffectInfoSO) null;
        permaFrail = (Frail_StatusEffect) null;
      }
      yield return (object) null;
    }
  }
}
