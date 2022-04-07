using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    //[SerializeField] private float timeDelay = 0.2f;

    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private ParticleSystem playerDeadPS;

    private Rigidbody2D rb2d;
    [SerializeField] private bool right;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            Debug.Log("Player dead");
            rb2d.bodyType = RigidbodyType2D.Static;
            //Destroy(gameObject,timeDelay);
            playerDeadPS.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            particleSystem.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            particleSystem.Stop();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            right = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            right = true;
        }
    }


    private void FixedUpdate()
    {
        if (right)
        {
            rb2d.AddTorque(-torqueAmount);
        }
        else if (!right)
        {
            rb2d.AddTorque(torqueAmount);
        }
    }


}
