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
    [SerializeField] private float currPlayerHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private TextMeshProUGUI scoreText;
    Animator anim;
    SpriteRenderer sRender;
    private bool isGrounded = true;
    private bool isPaused = false;
    private Rigidbody2D rb;
    public AudioSource[] sounds;
    private AudioSource jump;
    private AudioSource rock;
    private AudioSource death;
    private AudioSource land;
    private AudioSource levelUp;
    private AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sRender = GetComponentInChildren<SpriteRenderer>();
        currPlayerHealth = GameData.health;
        healthSlider.value = currPlayerHealth;
        scoreText.text = GameData.score.ToString();
        Time.timeScale = 1;
        sounds = GetComponents<AudioSource>();
        jump = sounds[0];
        rock = sounds[1];
        death = sounds[2];
        land = sounds[3];
        levelUp = sounds[4];
        win = sounds[5];
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
            jump.Play();
        }
        if(inputX != 0)
        {
            anim.Play("Falling Player");
        }
        else
        {
            anim.Play("IdlePlayer");
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            gameManager.PauseScreen(isPaused);
        }

        if(currPlayerHealth == 0)
        {
			death.Play();
            gameManager.ChangeScene("DeathScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
			death.Play();
            currPlayerHealth = 0;
		}
        if(collision.gameObject.tag == "Rock")
        {
            currPlayerHealth -= 10;
            StartCoroutine(DecreaseHealth());
            GetComponent<AudioSource>().Play();
            rock.Play();
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            if (collision.gameObject.GetComponent<ObstacleMovement>().isTouched == false)
            {
                GameData.score += 10;
                scoreText.text = GameData.score.ToString();
                collision.gameObject.GetComponent<ObstacleMovement>().isTouched = true;
            }
            isGrounded = true;
            land.Play();
            CheckLevel(GameData.score);
        }
    }

    public void CheckLevel(int score)
    {
        if (score == 100)
        {
            gameManager.SetLevel("Level 2");
            levelUp.Play();
            
        }
        if (score == 300)
        {
            gameManager.SetLevel("Level 3");
            levelUp.Play();
        }
        if (score == 600)
        {
            gameManager.SetLevel("Level 4");
            levelUp.Play();
        }
        if (score == 1200)
        {
            gameManager.SetLevel("Win");
            win.Play();
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
        GameData.health = healthSlider.value;
    }
}
