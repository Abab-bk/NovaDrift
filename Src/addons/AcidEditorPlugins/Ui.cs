using Godot;
using System;

namespace AcidWallStudio.AcidUtilities;

[Tool]
public partial class Ui : Control
{
    private LineEdit _lineEdit;
    private Button _yesBtn;

    public override void _Ready()
    {
        Name = "Encryptor";
        _lineEdit = GetNode<LineEdit>("%LineEdit");
        _yesBtn = GetNode<Button>("%YesBtn");
        _yesBtn.Pressed += () =>
        {
            _lineEdit.Text = Encryptor.Encode(_lineEdit.Text);
        };
    }
}
