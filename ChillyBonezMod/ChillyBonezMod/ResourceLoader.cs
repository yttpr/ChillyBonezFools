// Decompiled with JetBrains decompiler
// Type: ChillyBonezMod.ResourceLoader
// Assembly: ChillyBonezMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CE20A977-9DCF-4893-AFD8-C4695F1721DA
// Assembly location: C:\Users\windows\Downloads\ChillyBonezMod.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace ChillyBonezMod
{
  public static class ResourceLoader
  {
    public static Texture2D LoadTexture(string name)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      string name1 = ((IEnumerable<string>) executingAssembly.GetManifestResourceNames()).First<string>((Func<string, bool>) (r => r.Contains(name)));
      Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name1);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        byte[] buffer = new byte[16384];
        int count;
        while ((count = manifestResourceStream.Read(buffer, 0, buffer.Length)) > 0)
          memoryStream.Write(buffer, 0, count);
        Texture2D texture2D1 = new Texture2D(0, 0, (TextureFormat) 5, false);
        ((Texture) texture2D1).anisoLevel = 1;
        ((Texture) texture2D1).filterMode = (FilterMode) 0;
        Texture2D texture2D2 = texture2D1;
        ImageConversion.LoadImage(texture2D2, memoryStream.ToArray());
        return texture2D2;
      }
    }

    public static Sprite LoadSprite(string name, int ppu = 32, Vector2? pivot = null)
    {
      if (!pivot.HasValue)
        pivot = new Vector2?(new Vector2(0.5f, 0.5f));
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      Sprite random;
      try
      {
        string name1 = ((IEnumerable<string>) executingAssembly.GetManifestResourceNames()).First<string>((Func<string, bool>) (r => r.Contains(name)));
        Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name1);
        using (MemoryStream memoryStream = new MemoryStream())
        {
          byte[] buffer = new byte[16384];
          int count;
          while ((count = manifestResourceStream.Read(buffer, 0, buffer.Length)) > 0)
            memoryStream.Write(buffer, 0, count);
          Texture2D texture2D1 = new Texture2D(0, 0, (TextureFormat) 5, false);
          ((Texture) texture2D1).anisoLevel = 1;
          ((Texture) texture2D1).filterMode = (FilterMode) 0;
          Texture2D texture2D2 = texture2D1;
          ImageConversion.LoadImage(texture2D2, memoryStream.ToArray());
          random = Sprite.Create(texture2D2, new Rect(0.0f, 0.0f, (float) ((Texture) texture2D2).width, (float) ((Texture) texture2D2).height), pivot.Value, (float) ppu);
        }
      }
      catch (InvalidOperationException ex)
      {
        Debug.LogError((object) ("Missing Texture! " + name + " \nCheck for typos when using ResourceLoader.LoadSprite() and that all of your textures have their build action as Embedded Resource."));
        random = Placeholder.Random;
      }
      return random;
    }

    public static byte[] ResourceBinary(string name)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      string name1 = ((IEnumerable<string>) executingAssembly.GetManifestResourceNames()).First<string>((Func<string, bool>) (r => r.Contains(name)));
      using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name1))
      {
        if (manifestResourceStream == null)
          return (byte[]) null;
        byte[] buffer = new byte[manifestResourceStream.Length];
        manifestResourceStream.Read(buffer, 0, buffer.Length);
        return buffer;
      }
    }
  }
}
