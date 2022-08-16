using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetMatchScript : MonoBehaviour
{
    [SerializeField] Text matchid, playfabid, info;
    public void GetMatch() {
        Debug.Log(matchid.text + " " + playfabid.text);
        StartCoroutine(Upload("https://lit-everglades-95963.herokuapp.com/getmatch"));
    }

    public void GetLastMatch() {
        Debug.Log(matchid.text + " " + playfabid.text);
        StartCoroutine(Upload("https://lit-everglades-95963.herokuapp.com/getlastmatch"));
    }


    IEnumerator Upload(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("matchId", matchid.text);
        form.AddField("PlayFabId", playfabid.text);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error -> "+ www.error);
                info.text = "Error -> " + www.error;
            }
            else
            {
                info.text = www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
