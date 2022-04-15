using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField]
    private float speed = 25.0f;
    public float blood = 100;

    public bool gameOver = false;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GameOver();
    }

    private void FixedUpdate()
    {
        Move();
        BloodLeft(5f);
    }

    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
    }

    void BloodLeft(float value)
    {
        if (playerRb.velocity.x != 0 || playerRb.velocity.y != 0)
        {
            blood -= value * Time.smoothDeltaTime;

            Debug.Log(blood);
        }

        if (blood <= 0)
        {
            gameOver = true;
        }
    }

    void GameOver()
    {
        if (gameOver)
        {
            speed = 0;
        }
    }

    public void HitByBullet(BulletContainer bulletContainer, BulletCollider bulletCollider)
    {
        blood -= bulletContainer.Damage;
    }
}
