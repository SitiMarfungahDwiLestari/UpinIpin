using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;    
    public AudioSource musicSource;
    public AudioClip backgroundMusic;

    void Awake()    
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }
}