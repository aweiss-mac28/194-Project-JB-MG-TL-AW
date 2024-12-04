using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private String publicLeaderboardKey = "433a0e600c63c24719e98898d568c9a0e3abfb3f9341b59b1f0377e1f585448e";

    public void GetLeaderboard(){
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, (msg =>{
            int loopLength = (msg.Length <names.Count) ? msg.Length : names.Count;
            for(int i = 0; i<loopLength;++i){
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(String username, int score){
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey,username,score,(msg=>{
        GetLeaderboard();
        }));
    }

    private void Start(){
        GetLeaderboard();
    }
}
