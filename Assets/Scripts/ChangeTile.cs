using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTile : MonoBehaviour
{
    public bool notClickable;

    public void ChangeStatus()
    {
        notClickable = true;
    }
}
