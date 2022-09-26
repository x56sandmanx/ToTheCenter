using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] private GameObject pauseScreen;
    private bool isGrounded;
    private bool isPaused = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(inputX, 0, 0);

        transform.Translate(movement*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseScreen.SetActive(isPaused);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
            isGrounded = true;
    }
}
