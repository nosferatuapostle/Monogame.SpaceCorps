using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

public static class G
{
    private static Dictionary<Color, Texture2D> pixelTextures;

    public static OrthographicCamera Camera;

    public static Vector2 MouseWorldPosition => Camera.ScreenToWorld(Input.Mouse.Position.ToVector2());

    static G()
    {
        pixelTextures = [];
    }

    public static Texture2D GetPixelTexture(Color color)
    {
        if (pixelTextures.TryGetValue(color, out var tex))
        {
            return tex;
        }

        var pixelTex = new Texture2D(Core.GraphicsDevice, 1, 1);
        pixelTex.SetData([color]);
        pixelTextures[color] = pixelTex;
        return pixelTex;
    }
}