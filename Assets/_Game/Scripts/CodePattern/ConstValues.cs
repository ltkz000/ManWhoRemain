using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstValues
{
    //Animation
    public const string ANIM_TRIGGER_IDLE = "Idle";
    public const string ANIM_TRIGGER_RUN = "Run";
    public const string ANIM_TRIGGER_ATTACK = "Attack";
    public const string ANIM_TRIGGER_DEAD = "Dead";
    public const string ANIM_TRIGGER_ULTI = "Ulti";
    public const string ANIM_TRIGGER_DANCEWIN = "DanceWin";
    public const string ANIM_TRIGGER_DANCESKIN = "DanceSkin";
    public const float ATTACK_ANIM_TIME = 0.5f;
    public const float DEAD_ANIM_TIME = 1.8f;
    public const float WEAPONSTUCK_TIME = 2f;

    //Tags
    public const string TARGET_TAG = "Target";
    public const string OBSTACLE_TAG = "Obstacle";
    public const string GIFT_TAG = "Gift";
    public const string TEST_TAG = "Test";

    //UI 
    public const string EQUIPPED_TEXT = "EQUIPPED";
    public const string SELECT_TEXT = "SELECT";

    //Gameplay
    public const int KILL_GOLD = 10;
    public const int MAX_LEVEL = 5;
    public const int ATTACK_RANGE_DEFAULT = 7;
    public const float DELAY_THROWWEAPON_TIME = 0.3f;
    public const float DELAY_WIN_TIME = 1.5f;
}
