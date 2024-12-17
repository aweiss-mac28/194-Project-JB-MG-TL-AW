using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<String,int> submitScoreEvent;

    public void SubmitScore(){
        submitScoreEvent.Invoke(inputName.text, SceneScoreManager.instance.GetPoints());
    }
}
