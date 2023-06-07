using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Achivement
{
    int id;
    string name;
    bool active;
}
public class SavedAchivement 
{

    public Achivement[] achivements = new Achivement[4];


}
