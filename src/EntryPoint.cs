using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class EntryPoint : Core
{
    public AnimatedSprite unit;
    public Vector2 unitPosition;

    public EntryPoint() : base("Space Corpses", 1280, 720, false)
    {
        
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        var tex = Content.Load<Texture2D>("unit_biomantes_scout_base");
        var atlas = new TextureAtlas(tex);

        atlas.AddRegion("frame1", 0, 0, 64, 64);
        atlas.AddRegion("frame2", 64, 0, 64, 64);
        atlas.AddRegion("frame3", 128, 0, 64, 64);
        atlas.AddRegion("frame4", 192, 0, 64, 64);
        atlas.AddRegion("frame5", 256, 0, 64, 64);
        atlas.AddRegion("frame6", 320, 0, 64, 64);
        atlas.AddRegion("frame7", 384, 0, 64, 64);

        var frames = new List<TextureRegion>
        {
            atlas.GetRegion("frame1"),
            atlas.GetRegion("frame2"),
            atlas.GetRegion("frame3"),
            atlas.GetRegion("frame4"),
            atlas.GetRegion("frame5"),
            atlas.GetRegion("frame6"),
            atlas.GetRegion("frame7"),
        };

        unit = atlas.CreateAnimatedSprite("base", new Animation(frames, TimeSpan.FromSeconds(0.1)));

        unitPosition = new Vector2(100, 100);
        
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        unit.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin();

        unit.Draw(unitPosition);

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}