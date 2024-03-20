// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.HealFleetingEffectItem
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class HealFleetingEffectItem : EffectItem
  {
    public override BaseWearableSO Wearable()
    {
      HealFleeingCharaWearable instance = ScriptableObject.CreateInstance<HealFleeingCharaWearable>();
      ((BaseWearableSO) instance).BaseWearable((Item) this);
      instance.effects = ExtensionMethods.ToEffectInfoArray(this.effects);
      instance._immediateEffect = this.immediate;
      return (BaseWearableSO) instance;
    }
  }
}
