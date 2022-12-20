using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameplay : UICanvas
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Text aliveText;
    float timer;
    float mapGold;
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        mapGold = PlayerDataManager.Ins.GetPlayerGold();

        Input.ResetInputAxes();

        PlayerDataManager.Ins.GetPlayer().UpdateJoystick(_joystick);
        PlayerDataManager.Ins.GetPlayer().StopMove();
        PlayerDataManager.Ins.GetPlayer().GetJoystick().DisableJoystick();
        PlayerDataManager.Ins.GetCharacterCombat().ActiveNameText();
        PlayerDataManager.Ins.GetCharacterCombat().ResetMapGold();

        BotManager.Ins.SpawnBotFromPool();

        GameManager.Ins.ChangeState(GameState.GamePlay);
    }

    private void Update() 
    {
        aliveText.text = "Alive: " + BotManager.Ins.GetBotAlive().ToString();
        if(BotManager.Ins.GetBotAlive() == 0)
        {
            // timer += Time.deltaTime;
            
            // GameManager.Ins.ChangeState(GameState.Result);
            // PlayerDataManager.Ins.GetPlayer().StopMove();
            // UIManager.Ins.OpenUI(UICanvasID.BlockRay);
            // if(timer > ConstValues.DELAY_WIN_TIME)
            // {
            //     UIManager.Ins.CloseUI(UICanvasID.BlockRay);
            //     UIManager.Ins.OpenUI(UICanvasID.Win);
            //     Close();
            // }
            UIManager.Ins.OpenUI(UICanvasID.Win);
            Close();
        }
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.Setting);

        SoundManager.Ins.PlayButtonClickSound();

        PlayerDataManager.Ins.GetCharacterCombat().DeactiveNameText();
        
        Close();
    }
}
