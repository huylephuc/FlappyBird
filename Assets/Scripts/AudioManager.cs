using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource audioSource;
    
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = Player.FindObjectOfType<AudioSource>();
    }

    public void PlayAudio(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
