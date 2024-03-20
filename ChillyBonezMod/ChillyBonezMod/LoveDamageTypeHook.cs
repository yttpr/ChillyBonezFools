using System;
using System.Reflection;
using DG.Tweening;
using MonoMod.RuntimeDetour;
using TMPro;
using UnityEngine;

namespace ChillyBonezMod
{
    // Token: 0x02000065 RID: 101
    public static class LoveDamageTypeHook
    {
        // Token: 0x060001BE RID: 446 RVA: 0x0000D180 File Offset: 0x0000B380
        public static Sequence DamageTypeSetter(Func<DamageTextOptions, CombatText, string, int, Sequence> orig, DamageTextOptions self, CombatText textHolder, string text, int type)
        {
            bool flag = type == 768313;
            Sequence result;
            if (flag)
            {
                Color32 color = new Color32(216, 22, 164, 255);
                TMP_ColorGradient tmp_ColorGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                tmp_ColorGradient.bottomLeft = color;
                tmp_ColorGradient.bottomRight = color;
                tmp_ColorGradient.topLeft = color;
                tmp_ColorGradient.topRight = color;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = tmp_ColorGradient;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<Sequence>(ShortcutExtensions.DOLocalJump(transform, transform.position, self._jumpForce * textHolder.Scale, 1, self._jumpTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence, tween);
                result = sequence;
            }
            else
            {
                result = orig(self, textHolder, text, type);
            }
            return result;
        }

        // Token: 0x060001BF RID: 447 RVA: 0x0000D264 File Offset: 0x0000B464
        public static string CustomDamageSound(Func<UnitSoundHandlerSO, DamageType, string> orig, UnitSoundHandlerSO self, DamageType damageType)
        {
            bool flag = damageType == (DamageType)768313;
            string result;
            if (flag)
            {
                result = self._oilSlickEvent;
            }
            else
            {
                result = orig(self, damageType);
            }
            return result;
        }

        // Token: 0x060001C0 RID: 448 RVA: 0x0000D298 File Offset: 0x0000B498
        public static void Add()
        {
            IDetour detour = new Hook(typeof(DamageTextOptions).GetMethod("PrepareTextOptions", (BindingFlags)(-1)), typeof(LoveDamageTypeHook).GetMethod("DamageTypeSetter", (BindingFlags)(-1)));
            IDetour detour2 = new Hook(typeof(UnitSoundHandlerSO).GetMethod("TryGetDamageEventName", (BindingFlags)(-1)), typeof(LoveDamageTypeHook).GetMethod("CustomDamageSound", (BindingFlags)(-1)));
        }

        // Token: 0x040000D0 RID: 208
        public const int Love = 768313;
    }
}
