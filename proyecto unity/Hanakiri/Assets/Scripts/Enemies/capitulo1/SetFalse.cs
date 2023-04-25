using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFalse : MonoBehaviour
{
    public bool shoot;
    public bool action;

    public void False()
    {
        shoot = false;
        action = false;
    }

    public void True()
    {
        shoot = true;
        action = true;
    }
}
