using System.Collections.Generic;

public class EntitySystem
{
    private List<Entity> entities;
    public List<Entity> List => entities;

    public EntitySystem()
    {
        entities = [];
    }

    public void Add(Entity e)
    {
        e.Initialize();
        entities.Add(e);
    }

    public void Update()
    {
        foreach (var e in entities)
        {
            e.Update();
        }
    }
}