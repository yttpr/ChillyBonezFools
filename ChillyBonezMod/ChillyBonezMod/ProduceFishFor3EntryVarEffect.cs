// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ProduceFishFor3EntryVarEffect
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class ProduceFishFor3EntryVarEffect : EffectSO
  {
    [SerializeField]
    public bool _isTreasure = false;
    [SerializeField]
    public bool _getLocked = false;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      entryVariable = this.PreviousExitValue;
      LootItemProbability lootItemProbability1;
      lootItemProbability1.itemName = "LeftShoe_ExtraW";
      lootItemProbability1.probability = 7;
      LootItemProbability lootItemProbability2;
      lootItemProbability2.itemName = "WelsCatfish_ExtraW";
      lootItemProbability2.probability = 5;
      LootItemProbability lootItemProbability3;
      lootItemProbability3.itemName = "Salmon_ExtraW";
      lootItemProbability3.probability = 12;
      LootItemProbability lootItemProbability4;
      lootItemProbability4.itemName = "Guppy_ExtraW";
      lootItemProbability4.probability = 20;
      LootItemProbability lootItemProbability5;
      lootItemProbability5.itemName = "GreatWhite_ExtraW";
      lootItemProbability5.probability = 5;
      LootItemProbability lootItemProbability6;
      lootItemProbability6.itemName = "RightShoe_ExtraW";
      lootItemProbability6.probability = 10;
      LootItemProbability lootItemProbability7;
      lootItemProbability7.itemName = "GrumpyGump_TW";
      lootItemProbability7.probability = 1;
      LootItemProbability lootItemProbability8;
      lootItemProbability8.itemName = "Ichthys_TW";
      lootItemProbability8.probability = 1;
      LootItemProbability lootItemProbability9;
      lootItemProbability9.itemName = "MedicalLeeches_SW";
      lootItemProbability9.probability = 1;
      LootItemProbability lootItemProbability10;
      lootItemProbability10.itemName = "MommaNooty_TW";
      lootItemProbability10.probability = 1;
      LootItemProbability lootItemProbability11;
      lootItemProbability11.itemName = "GamifiedSquid_TW";
      lootItemProbability11.probability = 1;
      LootItemProbability lootItemProbability12;
      lootItemProbability12.itemName = "GumpMingGoa_TW";
      lootItemProbability12.probability = 1;
      ExtraLootListEffect instance = ScriptableObject.CreateInstance<ExtraLootListEffect>();
      instance._treasurePercentage = 1;
      instance._nothingPercentage = 0;
      instance._shopPercentage = 2;
      instance._lootableItems = new LootItemProbability[10]
      {
        lootItemProbability3,
        lootItemProbability4,
        lootItemProbability5,
        lootItemProbability6,
        lootItemProbability7,
        lootItemProbability8,
        lootItemProbability9,
        lootItemProbability10,
        lootItemProbability11,
        lootItemProbability12
      };
      instance._lockedLootableItems = new LootItemProbability[2]
      {
        lootItemProbability2,
        lootItemProbability1
      };
      for (int index = 2; index < entryVariable; index += 3)
        ++exitAmount;
      Effect effect = new Effect((EffectSO) instance, exitAmount, new IntentType?((IntentType) 100), Slots.Self);
      if (exitAmount > 0)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          effect
        }), caster, 0));
      return exitAmount > 0;
    }
  }
}
