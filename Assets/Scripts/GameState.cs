using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private int hitCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hitCount++;
            if (hitCount >= 5)
            {
                Time.timeScale = 0;
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
