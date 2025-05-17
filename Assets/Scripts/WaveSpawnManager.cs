using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling; 
    
    public TextMeshProUGUI waveMessageText;
    public float waveStartDelay = 3f;

    private int currentWave = 0;
    private float waveEndTime = 0f;
    private bool isWaitingForNextWave = false;

    void Start()
    {
        StartCoroutine(StartWaveWithMessage());
    }

    void Update()
    {
        if (isWaitingForNextWave) return;

        if (currentWave >= waveConfigurations.Length)
        {
            if (enableWaveCycling)
            {
                currentWave = 0;
                StartCoroutine(StartWaveWithMessage());
            }
            else
            {
                return;
            }
        }

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                StartCoroutine(StartWaveWithMessage());
            }
        }
    }

    IEnumerator StartWaveWithMessage()
    {
        isWaitingForNextWave = true;
        
        if (waveMessageText != null)
        {
            waveMessageText.gameObject.SetActive(true);
            
            waveMessageText.text = $"Wave {currentWave + 1} Start in 3...";
            yield return new WaitForSeconds(1f);

            waveMessageText.text = $"Wave {currentWave + 1} Start in 2...";
            yield return new WaitForSeconds(1f);

            waveMessageText.text = $"Wave {currentWave + 1} Start in 1...";
            yield return new WaitForSeconds(1f);

            waveMessageText.gameObject.SetActive(false);
        }
        else
        { 
            yield return new WaitForSeconds(waveStartDelay);
        }
        
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;

        isWaitingForNextWave = false;
    }
}
