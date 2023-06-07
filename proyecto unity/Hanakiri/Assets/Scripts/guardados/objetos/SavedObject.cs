using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct PowerUp
{
    public string name;
    public int life;
    public int speed;
    public int jump;
    public int attack;
    public bool active;
    public float time;
}
public class SavedObject 
{

    public PowerUp[] PowerUps = new PowerUp[9];
    
}
