using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    public bool startR;
    
    void Start()
    {
        startR = false;
    }

    
    void Update()
    {
        if(startR)
        {
            Crotation(23);
        }
    }

    public void Crotation(int r)
    {

    }
}
