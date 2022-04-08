using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.CollectableCoins();
            Destroy(gameObject);
        }
    }
}
