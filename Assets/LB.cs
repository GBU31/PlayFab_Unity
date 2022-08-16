using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using UnityEngine.SceneManagement;
using PlayFab.ClientModels;

public class LB : MonoBehaviour
{
    public void GetMatchScene(){
        SceneManager.LoadScene(2);

    }

    public void SubmitScore(int playerScore) {
    PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest {
        Statistics = new List<StatisticUpdate> {
            new StatisticUpdate {
                StatisticName = "HighScore",
                Value = playerScore
            }
        }
    }, result=> OnStatisticsUpdated(result), FailureCallback);
}

private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult) {
    Debug.Log("Successfully submitted high score");
}

private void FailureCallback(PlayFabError error){
    Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
    Debug.LogError(error.GenerateErrorReport());
}
}
