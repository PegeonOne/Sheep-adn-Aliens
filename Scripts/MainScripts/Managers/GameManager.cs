using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Level;
    public static int[][] SpawnGrid;
    public static byte DogoCount;
    public static byte DogoSpeed;
    public static byte DogoActingRadius;

    public enum Dogo_Actions
    {
        Dogo_Stay = 0,
        Dogo_Run = 1,
        Dogo_Transform_Wolf = 2,
        Wolf_Transform_Dogo = 3,
        Wolf_Eat_Conc_Ram = 4
    }
    public enum Sheep_Actions
    {
        SheepStay = 5,
        SheepRun = 6,
        Sheep_To_Ram = 7,
        Sheep_Out_Ram = 8
    }
    public enum Alien_Actions
    {
        Alien_Steal_Sheep = 9
    }
}
