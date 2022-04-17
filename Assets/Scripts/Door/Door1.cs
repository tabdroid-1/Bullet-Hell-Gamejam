using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public DoorTrigger1 triger;
    public Player player;

    public bool doorIsOpen = false;

    [SerializeField] private Vector3 openPosition;
    [SerializeField] private float arriveTime = 1f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        if (triger.unlocked)
        {
            transform.position = Vector3.SmoothDamp(transform.position, openPosition, ref velocity, arriveTime);
            doorIsOpen = true;
        }
    }
}