using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFollow1 : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField] private Door1 door;


    private float arriveTime = 0.6f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;

    [HideInInspector]
    public bool canFollow = false;

    private bool canCheck = true;

    private void Start()
    {

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        FollowPlayer();

    }

    private void Update()
    {
        DestroyKey();
    }

    void FollowPlayer()
    {
        if (canFollow)
        {
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, arriveTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canCheck)
        {
            canFollow = true;
            canCheck = false;
        }
    }

    void DestroyKey()
    {
        if (door.doorIsOpen)
        {
            StartCoroutine(DisableFollow());

        }
    }

    IEnumerator DisableFollow()
    {
        yield return new WaitForSeconds(1.5f);
        canFollow = false;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
