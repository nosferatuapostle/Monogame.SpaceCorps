using MonoGame.Extended;

public class GameObject
{
    public Transform2 Transform { get; private set;}

    public GameObject()
    {
        Transform = new();
    }
}