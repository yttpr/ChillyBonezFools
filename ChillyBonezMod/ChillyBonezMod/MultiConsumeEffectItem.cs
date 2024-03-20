// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.MultiConsumeEffectItem
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class MultiConsumeEffectItem : Item
  {
    public Effect[] effects = new Effect[0];
    public bool immediate = false;
    public bool addResultToEffect = false;
    public TriggerCalls[] ExtraConsumeTriggers = new TriggerCalls[0];

    public override BaseWearableSO Wearable()
    {
      MultiConsumeWearable instance = ScriptableObject.CreateInstance<MultiConsumeWearable>();
      ((BaseWearableSO) instance).BaseWearable((Item) this);
      instance.effects = ExtensionMethods.ToEffectInfoArray(this.effects);
      instance._immediateEffect = this.immediate;
      instance.consumeTriggers = this.ExtraConsumeTriggers;
      return (BaseWearableSO) instance;
    }
  }
}
