using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

public class Unit : GameObject
{
    public AnimatedSprite sprite;
    public UnitValues values;

    public Unit(AnimatedSprite aSprite, UnitValues uv)
    {
        sprite = aSprite;
        values = uv;
    }

    public void Update(GameTime gt)
    {
        sprite.Update(gt);
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(sprite, Transform);
    }
}