using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplay : UICanvas
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Player player;
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        player.UpdateJoystick(_joystick);
    }
    public void SettingButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.Setting);

        Close();
    }
}
