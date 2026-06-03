using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

public record class SpriteKey(string AssetName, string Name = "base");

public static class G
{
    public const string UNIT_BIOMANTES_SCOUT_BASE = "unit_biomantes_scout_base";

    private static Dictionary<Color, Texture2D> pixelTextures;
    public static Dictionary<string, SpriteSheet> ssheets;

    public static OrthographicCamera Camera;

    public static Vector2 MouseWorldPosition => Camera.ScreenToWorld(Input.Mouse.Position.ToVector2());

    public static InputSystem Input;
    public static TimeSystem Time;
    public static RenderSystem Renderer;

    public static EntitySystem Entt;

    public static EventBus EventBus;

    static G()
    {
        pixelTextures = [];
        ssheets = [];

        Input = new InputSystem();
        Time = new TimeSystem();
        Renderer = new RenderSystem();

        Entt = new EntitySystem();

        EventBus = new EventBus();
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

    public static AnimatedSprite CreateAnimatedSprite(SpriteKey key, int w, int h, int frameCount, double frameTime, bool loop = true)
    {
        var assetName = key.AssetName;
        var name = key.Name;
        if (!ssheets.ContainsKey(assetName))
        {
            var tex = Core.Content.Load<Texture2D>(assetName);
            var atlas = Texture2DAtlas.Create("atlas\\" + assetName, tex, w, h);
            var ss = new SpriteSheet("spritesheet\\" + assetName, atlas);

            ss.DefineAnimation(name, builder =>
            {
                builder.IsLooping(loop);
                for (int i = 0; i < frameCount; i++)
                {
                    builder.AddFrame(i, TimeSpan.FromSeconds(frameTime));
                }
            });

            ssheets[assetName] = ss;
        }

        return new AnimatedSprite(ssheets[assetName], name);
    }
}