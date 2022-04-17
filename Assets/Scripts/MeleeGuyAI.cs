using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGuyAI : MonoBehaviour
{

    private float noticeDistance = 14;

    private bool noticed;

    public Collider2D hitTriger;
    public Transform player;
    public float moveSpeed = 15f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool attacking = false;
    private bool atackable = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        if (!attacking)
        {
            moveCharacter(movement);
        }

        if (attacking && atackable)
        {
            attack();
        }
        
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attacking = true;
            Debug.Log("asd");
        }
    }

    void attack()
    {

        StartCoroutine(swingTime());
    }

    IEnumerator swingTime()
    {
        atackable = false;
        StartCoroutine(swing());
        yield return new WaitForSeconds(0.7f);
        attacking = false;
        atackable = true;
    }

    IEnumerator swing()
    {
        hitTriger.enabled = true;
        yield return new WaitForSeconds(0.3f);
        hitTriger.enabled = false;
    }

}
