using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

public class RenderSystem
{
    private HashSet<IRenderer> renderers;

    public RenderSystem()
    {
        renderers = [];
    }

    public void Add(IRenderer r)
    {
        renderers.Add(r);
    }

    public void Remove(IRenderer r)
    {
        renderers.Remove(r);
    }

    public void Update(GameTime gt)
    {
        foreach(var u in renderers)
        {
            u.Update(gt);
        }
    }

    public void Render()
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