using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeylessDoorTrigger : MonoBehaviour
{
    private Collider2D triger;

    public bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        triger = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            unlocked = true;
            Debug.Log("asd");
        }
    }
}