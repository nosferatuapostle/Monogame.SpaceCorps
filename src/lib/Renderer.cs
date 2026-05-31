using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public static class Renderer
{
    private static HashSet<IRenderer> renderers;

    static Renderer()
    {
        renderers = [];
    }

    public static void Add(IRenderer r)
    {
        renderers.Add(r);
    }

    public static void Update(GameTime gt)
    {
        foreach(var u in renderers)
        {
            u.Update(gt);
        }
    }

    public static void Render()
    {
        var sb = Core.SpriteBatch;

        sb.Begin(transformMatrix: G.Camera.GetViewMatrix());
        foreach(var r in renderers)
        {
            r.Draw(sb);
        }
        sb.End();
    }
}