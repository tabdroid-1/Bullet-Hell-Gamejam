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
    private GameObject weaponPivot;
    private SpriteRenderer sprite;

    [SerializeField]
    private float currentSpeed = 8.0f;
    [SerializeField]
    private float speed = 25.0f;
    [SerializeField]
    public float hitPoint = 100;



    [Header("Dodge Settings")]
    [SerializeField] private float dodgeSpeed = 20.0f;
    [HideInInspector] public bool dashable = true;
    [SerializeField] private float dashCooldown = 1;
    [SerializeField] private float collisionDisableDuration = 0.6f;
    [Space]

    public bool gameOver = false;
    public bool finished = false;

    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<BulletCollider>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        
    }


    //--------------------------------------------------



    //movement for player
    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerRb.MovePosition(playerRb.position + movement * currentSpeed * Time.fixedDeltaTime);
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
        hitPoint -= bulletContainer.Damage;
    }

    //damages player
    public void Damage(float damage)
    {
        hitPoint -= damage;
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

    IEnumerator DashCoolDown(float dashCoolDown)
    {
        currentSpeed = dodgeSpeed;
        StartCoroutine(BulletCollisionDisable(collisionDisableDuration));
        dashable = false;
        yield return new WaitForSeconds(dashCoolDown);
        dashable = true;
    }

    IEnumerator BulletCollisionDisable(float disableDuration)
    {
        bulletCollider.enabled = false;
        StartCoroutine(SetSpeed());
        yield return new WaitForSeconds(disableDuration);
        bulletCollider.enabled = true;
    }

    IEnumerator SetSpeed()
    {
        yield return new WaitForSeconds(0.5f);
        currentSpeed = speed;
    }

    void Rotation()
    {
        if ((weaponPivot.transform.rotation.y > 0.7 && weaponPivot.transform.rotation.y < 1) || (weaponPivot.transform.rotation.y < -0.7 && weaponPivot.transform.rotation.y > -1))
        {
            sprite.flipX = true;
        }

        if (weaponPivot.transform.rotation.y == 0)
        {
            sprite.flipX = false;
        }
    }

}
