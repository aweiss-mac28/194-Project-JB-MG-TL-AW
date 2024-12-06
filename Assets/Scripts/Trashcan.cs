using UnityEngine;

public class TrashcanMaterialDetector : MonoBehaviour
{
    // Optional: Sounds for feedback
    public AudioClip plasticSound;
    public AudioClip glassSound;
    public AudioClip paperSound;
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component to play sounds
        audioSource = GetComponent<AudioSource>();
    }

    // This function will be called when another object enters the trashcan's trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the object entering the trashcan
        switch (other.tag)
        {
            case "Plastic":
                Debug.Log("Plastic material detected!");
                PlayFeedback(plasticSound);
                break;

            case "Glass":
                Debug.Log("Glass material detected!");
                PlayFeedback(glassSound);
                break;

            case "Paper":
                Debug.Log("Paper material detected!");
                PlayFeedback(paperSound);
                break;

            default:
                Debug.Log("Unknown material detected!");
                break;
        }
    }

    // Optional function to play a feedback sound when the correct material is detected
    private void PlayFeedback(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
