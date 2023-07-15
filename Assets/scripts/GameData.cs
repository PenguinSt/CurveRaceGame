using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData 
{
    public static bool isMusicOn=true;
    public static bool isSoundOn=true ;

    public static void setMusic(bool music)
    {
        isMusicOn=music;
    }
    public static void setSound(bool sound)
    {
        isSoundOn = sound;
    }
}
