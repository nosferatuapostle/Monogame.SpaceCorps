using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

    protected override void LoadContent()
    {
        var sprite = G.CreateAnimatedSprite(G.UNIT_BIOMANTES_SCOUT_BASE, 64, 64, 7, 0.1);

        var uv = new UnitValues
        {
            Health = 100f,
            MaxHealth = 100f,
            Speed = 100f
        };

        unit = new Unit(uv);

        unit.Transform.Position = new Vector2(100, 100);

        var r = new AnimatedSpriteRenderer(sprite, unit.Transform);
        Renderer.Add(r);

        unit.isPlayer = true;

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
        foreach (var u in anotherUnits)
        {
            u.Update(gt);
        }

        index++;

        if (index % 200 == 0)
        {
            var s = G.CreateAnimatedSprite(G.UNIT_BIOMANTES_SCOUT_BASE, 64, 64, 7, 0.1);
            var u = new Unit(new UnitValues
            {
                Health = 100f,
                MaxHealth = 100f,
                Speed = 100f
            });

            u.Transform.Position = new Vector2(nextPosition * 100, 200);
            nextPosition++;

            anotherUnits.Add(u);

            Renderer.Add(new AnimatedSpriteRenderer(s, u.Transform));

            index = 0;
        }

        base.Update(gt);
    }
}