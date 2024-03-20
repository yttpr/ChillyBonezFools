// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.PlayStatusEffectPopupUIAction
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public class PlayStatusEffectPopupUIAction : CombatAction
  {
    public int _id;
    public bool _isUnitCharacter;
    public int _amount;
    public StatusEffectInfoSO _status;
    public StatusFieldEffectPopUpType _popUpType;

    public PlayStatusEffectPopupUIAction(
      int id,
      bool isUnitCharacter,
      int amount,
      StatusEffectInfoSO status,
      StatusFieldEffectPopUpType popUpType)
    {
      this._id = id;
      this._isUnitCharacter = isUnitCharacter;
      this._amount = amount;
      this._status = status;
      this._popUpType = popUpType;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      Vector3 vector;
      if (this._isUnitCharacter)
      {
        CharacterCombatUIInfo character;
        stats.combatUI._charactersInCombat.TryGetValue(this._id, out character);
        vector = stats.combatUI._characterZone.GetCharacterPosition(character.FieldID);
        stats.combatUI.PlaySoundOnPosition(this._status.UpdatedSoundEvent, vector);
        int ppu = 32;
        Sprite sprite = Sprite.Create(this._status.icon.texture, new Rect(0.0f, 0.0f, (float) ((Texture) this._status.icon.texture).width, (float) ((Texture) this._status.icon.texture).height), new Vector2(0.5f, 0.5f), (float) ppu);
        yield return (object) stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(false, vector, this._popUpType, this._amount, sprite);
        sprite = (Sprite) null;
      }
      else
      {
        EnemyCombatUIInfo enemy;
        stats.combatUI._enemiesInCombat.TryGetValue(this._id, out enemy);
        vector = stats.combatUI._enemyZone.GetEnemyPosition(enemy.FieldID);
        stats.combatUI.PlaySoundOnPosition(this._status.UpdatedSoundEvent, vector);
        int ppu = 32;
        Sprite sprite = Sprite.Create(this._status.icon.texture, new Rect(0.0f, 0.0f, (float) ((Texture) this._status.icon.texture).width, (float) ((Texture) this._status.icon.texture).height), new Vector2(0.5f, 0.5f), (float) ppu);
        yield return (object) stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(true, vector, this._popUpType, this._amount, sprite);
        sprite = (Sprite) null;
      }
    }
  }
}
