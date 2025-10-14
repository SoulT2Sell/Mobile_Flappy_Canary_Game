using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Animator anim;
    private CircleCollider2D col;
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    private bool isDead;
    private bool canFly = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleAnimation();
        CheckDeadZone();
    }

    private void HandleAnimation()
    {
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    private void HandleInput()
    {
        if (isDead)
            return;

        if (!Touchscreen.current.primaryTouch.press.isPressed && !canFly)
        {
            canFly = true;
        }

        if (Touchscreen.current.primaryTouch.press.isPressed && canFly)
        {
            canFly = false;

            rb.linearVelocity = Vector2.zero;

            rb.linearVelocity = Vector2.up * jumpForce * Time.deltaTime;

            Debug.Log(rb.linearVelocity);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        col.enabled = false;
        isDead = true;
        Game_UI.Instance.LoadEndGameMenu();
    }
    private void CheckDeadZone()
    {
        if (transform.position.y > 5 || transform.position.y < -5)
        {
            isDead = true;
            Game_UI.Instance.LoadEndGameMenu();
        }
    }

}
