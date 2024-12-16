using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneScoreManager : MonoBehaviour
{

    public static SceneScoreManager instance; 
    public Text scoreText;

    int score = 0;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(){
        score+=10;
        scoreText.text = score.ToString() + " POINTS";
    }
}
