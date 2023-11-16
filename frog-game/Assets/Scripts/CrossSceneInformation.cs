using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneInformation 
{
    // Access by CrossSceneInformation.currentLevel
    private static string defaultLevel = "Level1";
    public static string curentLevel  { get { return defaultLevel; } set { defaultLevel = value; } }

    private static float defaultFrogJumpForce = 1;
    public static float frogJumpForce  { get { return defaultFrogJumpForce; } set { defaultFrogJumpForce = value; } }

}
