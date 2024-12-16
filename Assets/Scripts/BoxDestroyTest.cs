using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyTest : MonoBehaviour
{

    public String destroyTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collided){
        if(collided.transform.CompareTag(destroyTag)){
            Destroy(collided.gameObject);
            SceneScoreManager.instance.AddPoints();
        }
    }
}
