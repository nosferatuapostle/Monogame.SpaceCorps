using System.Collections.Generic;

public abstract class Component
{
    public Entity Entity;

    public virtual void OnAdded() {}
    public virtual void OnUpdate() {}
    public virtual void OnRemoved() {}
}

public class Entity : GameObject
{
    private List<Component> components;

    public List<Component> ComponentList => components;

    public Entity()
    {
        components = [];
    }

    public virtual void Initialize() {}

    public virtual void Update()
    {
        foreach (var c in components)
        {
            c.OnUpdate();
        }
    }

    public T AddComponent<T>(T c) where T : Component
    {
        c.Entity = this;
        c.OnAdded();
        components.Add(c);

        return c;
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (var c in components)
        {
            if (c is T result)
            {
                return result;
            }
        }

        return default;
    }

    public void RemoveComponent<T>(T c) where T : Component
    {
        c.OnRemoved();
        components.Remove(c);
    }
}