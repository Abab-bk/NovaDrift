using System;
using Godot;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.Popup;

public partial class PopupPanel : Popup
{
    private bool _showCloseButton;
    private Action _closeAction;
    private Action _confirmAction;
    private string _title;
    private string _message;
    
    public void SetConfig(
        string title,
        string message,
        bool showCloseButton = false,
        Action closeAction = null,
        Action confirmAction = null
        )
    {
        _title = title;
        _message = message;
        _showCloseButton = showCloseButton;
        _closeAction = closeAction;
        _confirmAction = confirmAction;
        
        UpdateUi();
    }
    
    public void SetConfig(
        string title,
        string message,
        Node node,
        bool showCloseButton = false,
        Action closeAction = null,
        Action confirmAction = null
    )
    {
        SetConfig(
            title,
            message,
            showCloseButton,
            closeAction,
            confirmAction
            );
        
        S_MessageContent.AddChild(node);
    }

    private void UpdateUi()
    {
        S_TitleLabel.Instance.Text = _title;
        S_MessageLabel.Instance.Text = _message;
        
        S_CloseBtn.Instance.Visible = _showCloseButton;
        
        if (_closeAction != null)
        {
            S_CloseBtn.Instance.Pressed += () =>
            {
                _closeAction?.Invoke();
                HideAnimation();
            };
        }
        else
        {
            S_CloseBtn.Instance.Pressed += HideAnimation;
        }

        if (_confirmAction != null)
        {
            S_ConfirmBtn.Instance.Pressed += () =>
            {
                _confirmAction?.Invoke();
                HideAnimation();
            };
        }
        else
        {
            S_ConfirmBtn.Instance.Pressed += HideAnimation;
        }
    }

    private void ShowAnimation()
    {
        S_Panel.Instance.Scale = new Vector2(0f, 1f);
        S_Panel.Instance
            .TweenScale(Vector2.One, 0.1f)
            .OnComplete(() =>
            {
                S_Content.Instance.Show();
            })
            .Play();
    }

    private void HideAnimation()
    {
        S_Content.Instance.Hide();
        S_Panel.Instance
            .TweenScale(new Vector2(0f, 1f), 0.1f)
            .OnComplete(QueueFree)
            .Play();
    }

    public override void _Ready()
    {
        S_Content.Instance.Hide();
        ShowAnimation();
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
