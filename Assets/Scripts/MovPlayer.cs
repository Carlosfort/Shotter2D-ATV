using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    [SerializeField] float Speed;
    private PlayerControl playerControl;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;


    private void Awake()
    {
        playerControl = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {   
        playerControl.Enable();
    }
    void Update()
    {
        PlayerInput();
        FlipX();
    }
    void FixedUpdate()
    {
        Move();
    }
    private void PlayerInput()
    {
        movement = playerControl.Movement.Move.ReadValue<Vector2>();
        anim.SetFloat("moveX",movement.x);
        anim.SetFloat("moveY",movement.y);
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (Speed *Time.fixedDeltaTime));
    }
    private void FlipX()
    {
        if(movement.x > 0 ){sprite.flipX = false;}
        else if(movement.x < 0 ){sprite.flipX = true;}
    }
}
