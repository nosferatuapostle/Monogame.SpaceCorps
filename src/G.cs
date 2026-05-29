using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public static class G
{
    public static GraphicsDevice GraphicsDevice;

    private static Dictionary<Color, Texture2D> pixelTextures = [];

    public static Texture2D GetPixelTexture(Color color)
    {
        if (pixelTextures.TryGetValue(color, out var tex))
        {
            return tex;
        }

        pixelTextures[color] = tex;
        return tex;
    }
}