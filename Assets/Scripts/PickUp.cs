using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBlock : MonoBehaviour
{
    public GameObject pickUpText;         public GameObject BlockOnPlayer;  

    void Start()
    {
        pickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.T))
            {
                gameObject.SetActive(false);  
                BlockOnPlayer.SetActive(true); 
                pickUpText.SetActive(false);  
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(false);
        }
    }
}
