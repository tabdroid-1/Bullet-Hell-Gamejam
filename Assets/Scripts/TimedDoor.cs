using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoor : MonoBehaviour
{
    public float time1;
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private float arriveTime = 1f;
    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(OpenDoor(time1));
    }

    IEnumerator OpenDoor(float time) 
    {
        yield return new WaitForSeconds(time);
        if (transform.position != openPosition)
        {
            transform.position = Vector3.SmoothDamp(transform.position, openPosition, ref velocity, arriveTime);
        }
    }
}
