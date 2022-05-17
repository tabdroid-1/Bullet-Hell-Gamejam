using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurret : MonoBehaviour
{
    public void Hurt()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("ouch");
        }
    }
}
