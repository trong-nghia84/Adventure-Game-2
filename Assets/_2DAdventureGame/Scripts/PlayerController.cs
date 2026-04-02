using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public int maxHealth = 5;
    int currentHealth = 1;
    public float speed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
        //currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
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
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

    }
}
