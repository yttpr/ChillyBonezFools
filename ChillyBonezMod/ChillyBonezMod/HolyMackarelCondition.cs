// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HolyMackarelCondition
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;

#nullable disable
namespace ChillyBonezMod
{
  public class HolyMackarelCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is StatusEffectApplication effectApplication1 && effectApplication1.statusEffectType != (StatusEffectType)10)
      {
        effectApplication1.value = false;
        int num = Math.Max(1, effectApplication1.amount);
        IStatusEffect istatusEffect = (IStatusEffect) new DivineProtection_StatusEffect(num, 0);
        StatusEffectInfoSO statusEffectInfoSo;
        CombatManager.Instance._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 10, out statusEffectInfoSo);
        istatusEffect.SetEffectInformation(statusEffectInfoSo);
        (effector as IUnit).ApplyStatusEffect(istatusEffect, num);
        return true;
      }
      if (!(args is StatusEffectApplication effectApplication2))
        return false;
      (effector as IUnit).Heal(Math.Max(1, effectApplication2.amount), (HealType) 1, true);
      return false;
    }
  }
}
