using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameplay : UICanvas
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Player player;
    [SerializeField] private CharacterCombat characterCombat;
    [SerializeField] private Text aliveText;
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();

        player.UpdateJoystick(_joystick);

        BotManager.Ins.SpawnBotFromPool();

        GameManager.Ins.ChangeState(GameState.GamePlay);

        characterCombat.ActiveNameText();
    }

    private void Update() 
    {
        aliveText.text = "Alive: " + BotManager.Ins.GetBotAlive().ToString();
        if(BotManager.Ins.GetBotAlive() == 0)
        {
            // GameManager.Ins.ChangeState(GameState.Result);
            UIManager.Ins.OpenUI(UICanvasID.Win);
        }
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.Setting);

        SoundManager.Ins.PlayButtonClickSound();

        characterCombat.DeactiveNameText();
        
        Close();
    }
}
