using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player;
    Vector3 diff;

    private void Update()
    {
        Vector3 targ = player.transform.position;
        targ.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, angle));

        /*if (angle < -90 || angle > 90)
        {



            if (player.transform.eulerAngles.y == 0)
            {


                transform.localRotation = Quaternion.Euler(180, 0, -angle);


            }
            else if (player.transform.eulerAngles.y == 180)
            {


                transform.localRotation = Quaternion.Euler(180, 180, -angle);


            }

        }*/
    }
}
