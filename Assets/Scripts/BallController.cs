using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float jumpForce = 5f;
    public float gravity = 9.81f;
    public float maxVelocity = 10f;
    
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Camera mainCamera;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        
        // Rigidbody ayarları
        rb.gravityScale = 0; // Manuel gravity kullanacağız
        rb.freezeRotation = true;
    }
    
    void Update()
    {
        // Dokunma kontrolü (mobil)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
        
        // Klavye kontrolü (test için)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        // Gravity uygula
        ApplyGravity();
    }
    
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    
    void ApplyGravity()
    {
        // Manuel gravity uygula
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - gravity * Time.deltaTime);
        
        // Maksimum hız sınırla
        if (Mathf.Abs(rb.velocity.y) > maxVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxVelocity);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
