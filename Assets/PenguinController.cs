using UnityEngine;

public class PenguinController : MonoBehaviour
{
    public float speed = 5f;  
    public float jumpForce = 7f;  
    private Rigidbody2D rb;  
    private Animator animator;  
    private bool isGrounded = false;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем физику пингвина
        animator = GetComponent<Animator>(); // Получаем аниматор
    }

    private void Update()
    {
        Update(animator);
    }

    void Update(Animator animator)
    {
        moveInput = Input.GetAxis("Horizontal"); // Движение по горизонтали

        // Пороговое значение для активации анимации
        float movementThreshold = 0.1f;
        if (Mathf.Abs(moveInput) > movementThreshold)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Движение пингвина
            animator.SetBool("isMoving", true); // Анимация движения
        }
        else
        {
            animator.SetBool("isMoving", false); // Остановка анимации движения
        }

        // Разворот пингвина влево/вправо
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1); // Разворот пингвина
        }

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        // Скольжение (если зажать Shift)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isSliding", true);
        }
        else
        {
            animator.SetBool("isSliding", false);
        }
    }

    // Функция для определения, когда пингвин на земле
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Breakablelce"))
    {
        isGrounded = true;
        animator.SetBool("isJumping", false); // Остановить анимацию прыжка, когда пингвин на земле
        
    }
}

}
