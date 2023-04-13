using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;

    [SerializeField] private AudioSource audioSource;
    
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
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
