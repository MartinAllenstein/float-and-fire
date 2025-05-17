using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip bgmClip;
    public AudioClip clickSound;
    public AudioClip shootSound;

    public Toggle bgmToggle;
    public Toggle sfxToggle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();
        
        bgmToggle.isOn = bgmSource.mute == false;
        sfxToggle.isOn = sfxSource.mute == false;
        
        bgmToggle.onValueChanged.AddListener(OnBGMToggle);
        sfxToggle.onValueChanged.AddListener(OnSFXToggle);
    }

    public void PlayClick()
    {
        if (!sfxSource.mute && clickSound != null)
            sfxSource.PlayOneShot(clickSound);
    }

    public void PlayShoot()
    {
        if (!sfxSource.mute && shootSound != null)
            sfxSource.PlayOneShot(shootSound);
    }

    public void OnBGMToggle(bool isOn)
    {
        bgmSource.mute = !isOn;
    }

    public void OnSFXToggle(bool isOn)
    {
        sfxSource.mute = !isOn;
    }
}