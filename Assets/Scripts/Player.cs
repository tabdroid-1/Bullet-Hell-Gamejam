using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private BulletCollider bulletCollider;
    [SerializeField]
    private KeyFollow keyFollow;

    [SerializeField]
    private float speed = 25.0f;
    [SerializeField]
    public float blood = 100;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 100f;
    [HideInInspector] public bool dashable = true;
    [HideInInspector] public int dashLeft = 3;
    [SerializeField] private float dashCooldown = 1;
    [SerializeField] private float collisionDisableDuration = 0.2f;
    [Space]

    public bool hasKey = false;

    public bool gameOver = false;
    public bool finished = false;

    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<BulletCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        KeyCheck();
    }

    private void FixedUpdate()
    {
        Move();


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        
    }

    //movement for player
    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
    }

    //says what to do if game is over
    void GameOver()
    {
        if (gameOver)
        {
            speed = 0;
        }
    }

    //if player gets hit by bullet this will get bullets damage and damage player by same amount
    public void HitByBullet(BulletContainer bulletContainer, BulletCollider bulletCollider)
    {
        blood -= bulletContainer.Damage;
    }

    //damages player
    public void Damage(float damage)
    {
        blood -= damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(2);
        }
        if (collision.CompareTag("GoBack"))
        {
            SceneManager.LoadScene(1);
        }

    }

    //enables dash
    void Dash()
    {
        if (dashable)
        {
            StartCoroutine(DashCoolDown(dashCooldown));
        }
        
    }

    //checks if player have a key
    void KeyCheck()
    {

        hasKey = keyFollow.canFollow;
    }


    IEnumerator DashCoolDown(float dashCoolDown)
    {
        if (movement == new Vector2 (0, 0))
        {
            playerRb.MovePosition(playerRb.position + (new Vector2(1, 0) * dashSpeed) * Time.fixedDeltaTime);
        }else if (movement != new Vector2(0, 0))
        {
            playerRb.MovePosition(playerRb.position + (movement * dashSpeed) * Time.fixedDeltaTime);
        }
        StartCoroutine(BulletCollisionDisable(collisionDisableDuration));
        dashLeft -= 1;
        dashable = false;
        yield return new WaitForSeconds(dashCoolDown);
        if (dashLeft != 0)
        {
            dashable = true;
        }

    }

    IEnumerator BulletCollisionDisable(float disableDuration)
    {
        bulletCollider.enabled = false;
        yield return new WaitForSeconds(disableDuration);
        bulletCollider.enabled = true;
    }
}
