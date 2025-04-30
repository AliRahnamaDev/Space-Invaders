using UnityEngine;
public class MusicShotManager : MonoBehaviour
{
    public GameObject basemusic; 
    public AudioSource audioSource;
    public AudioClip eminemClip;
    public float delayBeforeStop = 0.6f;

    private float timer;
    private bool isShooting;

    void Start()
    {
        audioSource.clip = eminemClip;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (isShooting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                audioSource.Pause();
                isShooting = false;

                
                if (basemusic != null)
                {
                    AudioSource baseAudio = basemusic.GetComponent<AudioSource>();
                    if (baseAudio != null && !baseAudio.isPlaying)
                    {
                        baseAudio.Play(); 
                    }
                }
            }
        }
    }

    public void OnPlayerShoot()
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.Play();

            
            if (basemusic != null)
            {
                AudioSource baseAudio = basemusic.GetComponent<AudioSource>();
                if (baseAudio != null && baseAudio.isPlaying)
                {
                    baseAudio.Pause(); 
                }
            }
        }
        else if (audioSource.isPlaying && audioSource.time >= eminemClip.length)
        {
            audioSource.Stop();
            audioSource.time = 0;
            audioSource.Play();
        }

        timer = delayBeforeStop;
        isShooting = true;
    }
}