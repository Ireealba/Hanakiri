using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Coleccionable
{
    public string name;
    public bool owned;
}

public class savedColeccionables 
{
    public Coleccionable[] coleccionables = new Coleccionable[10];
}
