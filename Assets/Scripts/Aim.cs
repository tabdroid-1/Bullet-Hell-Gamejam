using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    public GameObject myPlayer;


    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (angle < -90 || angle > 90)
        {



            if (myPlayer.transform.eulerAngles.y == 0)
            {


                transform.localRotation = Quaternion.Euler(180, 0, -angle);


            }
            else if (myPlayer.transform.eulerAngles.y == 180)
            {


                transform.localRotation = Quaternion.Euler(180, 180, -angle);


            }

        }

    }

}