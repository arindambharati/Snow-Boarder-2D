using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private UIController uIController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("You Finished the level");
            particleSystem.Play();
            uIController.LevelCompleteActiveUI();
        }
    }

}
