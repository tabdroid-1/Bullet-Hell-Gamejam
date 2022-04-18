using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorIsOpen = false;
    public GameObject lever;

    private void Update()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        if (lever.GetComponent<Lever>().flipped)
        {
            gameObject.SetActive(false);
            doorIsOpen = true;
        }
    }
}