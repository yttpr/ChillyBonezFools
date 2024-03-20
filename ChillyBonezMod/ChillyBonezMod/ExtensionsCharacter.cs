// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ExtensionsCharacter
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;
using Utility.SerializableCollection;

#nullable disable
namespace ChillyBonezMod
{
    public static class Effector
    {
        public static PercentageEffectorCondition Chance(int chance)
        {
            PercentageEffectorCondition ret = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            ret.triggerPercentage = chance;
            return ret;
        }
    }
  
}
