using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f; // แรงกระโดด (ปรับเพิ่ม/ลดได้ใน Inspector)

    private GatherInput gatherInput;
    private Rigidbody2D rigidbody2D;
    private int direction = 1;

    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Flip();
        rigidbody2D.velocity = new Vector2(speed * gatherInput.valueX, rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        // ถ้ามีการกดปุ่ม Jump
        if (gatherInput.jumpInput)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            gatherInput.jumpInput = false; // รีเซ็ตค่าเพื่อไม่ให้กระโดดซ้ำรวดเดียว
        }
    }

    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            direction *= -1;
        }
    }
}