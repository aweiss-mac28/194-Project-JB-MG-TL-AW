using UnityEngine;

public class TrashcanMaterialDetector : MonoBehaviour
{
    
    public AudioClip plasticSound;
    public AudioClip glassSound;
    public AudioClip paperSound;
    private AudioSource audioSource;

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
       
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

   
    private void PlayFeedback(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
