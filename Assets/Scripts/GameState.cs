using UnityEngine;

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
                Debug.Log("Game Over!");
                Time.timeScale = 0;
            }
        }
    }
}
