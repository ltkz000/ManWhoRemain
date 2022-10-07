using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSetting : UICanvas
{
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        Time.timeScale = 0;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);

        Close();
    }

    public void ResumeButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.GamePlay);
        Close();
    }

    public void RestartButton()
    {
        // UIManager.Ins.OpenUI(UICanvasID.GamePlay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Close();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
        Time.timeScale = 1;
    }
}
