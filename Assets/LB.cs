using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PlayFab;
using UnityEngine.SceneManagement;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class LB : MonoBehaviour
{
    public int playerScore;
    public Text lbinfo;

    public void GetMatchScene(){
        SceneManager.LoadScene(2);

    }
    
    public void SubmitScore() {
    Debug.Log("test1");
    PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest {
        Statistics = new List<StatisticUpdate> {
            new StatisticUpdate {
                StatisticName = "HighScore",
                Value = playerScore
            }
        }
    }, result=> OnStatisticsUpdated(result), FailureCallback);

    
}
public void GetLeaderboard() {
        var request = new GetLeaderboardRequest{
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10,

        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, FailureCallback);
    }

    void OnLeaderboardGet(GetLeaderboardResult result) {
        // var allinfo = new List<string>();  
        foreach (var item in result.Leaderboard){
            string info= item.Position + " " + item.PlayFabId + " " + item.StatValue;
            // allinfo.Add(info);
            lbinfo.text += "\n" + info;
            
            Debug.Log(info);
        }
        // allinfo.ForEach(Debug.Log);
    }




private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult) {
    Debug.Log("Successfully submitted high score");
}

private void FailureCallback(PlayFabError error){
    Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
    Debug.LogError(error.GenerateErrorReport());
}
}
