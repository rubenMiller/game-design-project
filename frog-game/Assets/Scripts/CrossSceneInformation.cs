using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneInformation 
{
    private static string defaultLevel = "Level1";
    public static string curentLevel  { get { return defaultLevel; } set { defaultLevel = value; } }

    private static float defaultFrogMousePressedPercentage = 0;
    public static float frogMousePressedPercentage  { get { return defaultFrogMousePressedPercentage; } set { defaultFrogMousePressedPercentage = value; } }

}
