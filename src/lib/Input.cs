using MonoGame.Extended.Input;

public static class Input
{
    public static MouseStateExtended Mouse => MouseExtended.GetState();
    public static KeyboardStateExtended Keyboard => KeyboardExtended.GetState();

    public static void Update()
    {
        MouseExtended.Update();
        KeyboardExtended.Update();
    }
}