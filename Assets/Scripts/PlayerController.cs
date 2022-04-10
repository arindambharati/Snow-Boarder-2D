using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private bool right;
    [SerializeField] private int score = 10;

    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private ParticleSystem playerDeadPS;

    [SerializeField] private UIController uIController;


    private Rigidbody2D rb2d;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            Debug.Log("Player dead");
            rb2d.bodyType = RigidbodyType2D.Static;
            playerDeadPS.Play();
            uIController.GameOverActiveUI();
            SoundManager.Instance.soundMusic.Stop();
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


    public void CollectableCoins()
    {
        uIController.IncrementScore(score);
    }
}
