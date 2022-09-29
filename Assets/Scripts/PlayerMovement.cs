using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int maxPlayerHealth = 100;
    [SerializeField] private int currPlayerHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private TextMeshProUGUI scoreText;
    private bool isGrounded;
    private bool isPaused = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currPlayerHealth = maxPlayerHealth;
        Score.score = 0;
        scoreText.text = Score.score.ToString();
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
            gameManager.PauseScreen(isPaused);
        }

        if(currPlayerHealth == 0)
        {
            gameManager.ChangeScene("DeathScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;
        if(collision.gameObject.tag == "Rock")
        {
            currPlayerHealth -= 10;
            StartCoroutine(DecreaseHealth());
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Score.score += 10;
            scoreText.text = Score.score.ToString();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
            isGrounded = false;
    }

    IEnumerator DecreaseHealth()
    {
        while(healthSlider.value >= currPlayerHealth)
        {
            healthSlider.value -= 25 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
