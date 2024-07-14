using Godot;

namespace AcidJoystick;

[GlobalClass]
public partial class JoyKnob : TouchScreenButton
{
    public Vector2 TargetDir { private set; get; }
    
    private const float DragRadius = 250f;
    
    private int _fingerIndex = -1;
    private Vector2 _dragOffset;
    private Vector2 _restPos;
    
    public override void _Ready()
    {
        _restPos = GlobalPosition;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventScreenTouch screenTouch)
        {
            if (screenTouch.Pressed && _fingerIndex == -1)
            {
                var globalPos = screenTouch.Position * GetCanvasTransform();
                var localPos = globalPos * GetGlobalTransform();
                var rect = new Rect2(Vector2.Zero, TextureNormal.GetSize());
                if (rect.HasPoint(localPos))
                {
                    // 按下
                    _fingerIndex = screenTouch.Index;
                    _dragOffset = globalPos - GlobalPosition;
                }
            } 
            else if (!screenTouch.Pressed && screenTouch.Index == _fingerIndex)
            {
                // 释放
                _fingerIndex = -1;
                GlobalPosition = _restPos;
            } 
        }
        
        if (@event is InputEventScreenDrag screenDrag)
        {
            if (screenDrag.Index == _fingerIndex)
            {
                // 拖动
                var wishPos = screenDrag.Position * GetCanvasTransform() - _dragOffset;
                var movement = (wishPos - _restPos).LimitLength(DragRadius);
                GlobalPosition = _restPos + movement;
                TargetDir = movement / DragRadius;
            }
        }
    }
}
