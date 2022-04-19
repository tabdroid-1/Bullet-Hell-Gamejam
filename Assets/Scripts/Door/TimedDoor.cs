using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoor : MonoBehaviour
{
    public float time1;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(OpenDoor(time1));
    }

    IEnumerator OpenDoor(float time) 
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
