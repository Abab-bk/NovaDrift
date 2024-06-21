using Godot;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Systems.Bodies;

public class Snake : Body
{
    private SnakeContainer _snakeContainer;
    
    public override void Use()
    {
        base.Use();

        _snakeContainer = new SnakeContainer();
        _snakeContainer.Actor = Actor;
        Actor.AddChild(_snakeContainer);

        for (int i = 0; i < (int)Values[0]; i++)
        {
            AddPart();
        }
    }
    
    private void AddPart()
    {
        _snakeContainer.AddPart();
    }
}