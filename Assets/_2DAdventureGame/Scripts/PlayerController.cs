using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; } }
    public float speed = 3.0f;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
                isInvincible = false;
        }
        move = MoveAction.ReadValue<Vector2>();
        //Debug.Log(move);
    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

     public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

    }
}
