using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource is not null and the AudioClip is set
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the audio
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing.");
        }
    }
}
