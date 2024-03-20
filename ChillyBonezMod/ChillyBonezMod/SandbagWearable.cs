// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.SandbagWearable
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class SandbagWearable : BaseWearableSO
  {
    public override bool DoesItemTrigger => true;

    public override bool IsItemImmediate => true;

    public override void OnTriggerAttachedAction(IWearableEffector caller)
    {
      base.OnTriggerAttachedAction(caller);
    }

    public override void OnTriggerDettachedAction(IWearableEffector caller)
    {
      base.OnTriggerDettachedAction(caller);
    }
  }
}
