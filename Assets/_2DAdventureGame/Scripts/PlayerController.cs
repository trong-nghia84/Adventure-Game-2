using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        rigidbody2d = GetComponent<Rigidbody2D>();
        //Application.targetFrameRate = 10;
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();

        Debug.Log(move);
    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
}
