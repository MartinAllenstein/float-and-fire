using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heartText;
    private int hitCount = 0;
    private int maxHits = 5;

    void Start()
    {
        UpdateHeartUI();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hitCount++;
            UpdateHeartUI();
            
            Destroy(other.gameObject);
            
            if (hitCount >= maxHits)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
    
    void UpdateHeartUI()
    {
        int remainingHearts = Mathf.Clamp(maxHits - hitCount, 0, maxHits);
        heartText.text = remainingHearts.ToString();
    }
}
