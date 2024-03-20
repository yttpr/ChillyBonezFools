// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.UnitDamagedInfo
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

#nullable disable
namespace ChillyBonezMod
{
  public class UnitDamagedInfo
  {
    public IUnit unit;
    public IUnit attacker;

    public int currentHealth => this.unit.CurrentHealth;

    public int maxHealth => this.unit.MaximumHealth;

    public float healthPercent => (float) this.currentHealth / (float) this.maxHealth;

    public UnitDamagedInfo(IUnit Unit, IUnit Attacker = null)
    {
      this.unit = Unit;
      if (Attacker == null)
        return;
      this.attacker = Attacker;
    }
  }
}
