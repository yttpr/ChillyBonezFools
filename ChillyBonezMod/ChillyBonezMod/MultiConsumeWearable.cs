// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MultiConsumeWearable
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;

#nullable disable
namespace ChillyBonezMod
{
  public class MultiConsumeWearable : PerformEffectWearable
  {
    public TriggerCalls[] consumeTriggers;

    public override void CustomOnTriggerAttached(IWearableEffector caller)
    {
      ((BaseWearableSO) this).CustomOnTriggerAttached(caller);
      foreach (int consumeTrigger in this.consumeTriggers)
      {
        TriggerCalls triggerCalls = (TriggerCalls) consumeTrigger;
        if (triggerCalls != (TriggerCalls)1000)
          CombatManager.Instance.AddObserver(new Action<object, object>(((BaseWearableSO) this).JustConsumeWearable), triggerCalls.ToString(), (object) caller);
      }
    }

    public override void CustomOnTriggerDettached(IWearableEffector caller)
    {
      ((BaseWearableSO) this).CustomOnTriggerDettached(caller);
      foreach (int consumeTrigger in this.consumeTriggers)
      {
        TriggerCalls triggerCalls = (TriggerCalls) consumeTrigger;
        if (triggerCalls != (TriggerCalls)1000)
          CombatManager.Instance.RemoveObserver(new Action<object, object>(((BaseWearableSO) this).JustConsumeWearable), triggerCalls.ToString(), (object) caller);
      }
    }
  }
}
