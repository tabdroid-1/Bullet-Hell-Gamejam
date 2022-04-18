using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [HideInInspector]public bool flipped = false;

    private SpriteRenderer spriteRenderer;
    public Sprite lever2;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flipped = true;
            spriteRenderer.sprite = lever2;
        }
    }
}
