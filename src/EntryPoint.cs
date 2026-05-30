using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;

public class EntryPoint : Core
{
    public Unit unit;

    public EntryPoint() : base("Space Corpses", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    public const string UNIT_BIOMANTES_SCOUT_BASE = "unit_biomantes_scout_base";

    public static Dictionary<string, SpriteSheet> ssheets = [];

    public static AnimatedSprite CreateAnimatedSprite(string assetName, int w, int h, int frameCount, double frameTime, bool loop = true, string name = "base")
    {
        if (!ssheets.ContainsKey(assetName))
        {
            var tex = Content.Load<Texture2D>(assetName);
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

    protected override void LoadContent()
    {
        var sprite = CreateAnimatedSprite(UNIT_BIOMANTES_SCOUT_BASE, 64, 64, 7, 0.1);

        var uv = new UnitValues
        {
            Health = 100f,
            MaxHealth = 100f,
            Speed = 100f
        };

        unit = new Unit(sprite, uv);

        unit.Transform.Position = new Vector2(100, 100);

        base.LoadContent();
    }

    List<Unit> anotherUnits = [];

    int index = 0;
    int nextPosition = 1;

    protected override void Update(GameTime gt)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        unit.Update(gt);

        index++;

        if (index % 200 == 0)
        {
            var s = CreateAnimatedSprite(UNIT_BIOMANTES_SCOUT_BASE, 64, 64, 7, 0.1);
            var unit = new Unit(s, new UnitValues
            {
                Health = 100f,
                MaxHealth = 100f,
                Speed = 100f
            });

            unit.Transform.Position = new Vector2(nextPosition * 100, 200);
            nextPosition++;

            anotherUnits.Add(unit);

            index = 0;
        }

        foreach (var u in anotherUnits)
        {
            u.Update(gt);
        }

        base.Update(gt);
    }

    protected override void Draw(GameTime gt)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin();

        unit.Draw(SpriteBatch);

        foreach (var u in anotherUnits)
        {
            u.Draw(SpriteBatch);
        }

        SpriteBatch.End();

        base.Draw(gt);
    }
}