using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    
    [SerializeField] Text email, password;
   public void LoginButton() {
    var request = new LoginWithEmailAddressRequest {
        Email = email.text,
        Password = password.text
        };
    PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);

    Debug.Log(email.text + " " + password.text);

    
   }
   void OnLoginSuccess(LoginResult result) {
    SceneManager.LoadScene(1);

   }

   void OnError(PlayFabError error) {
    Debug.Log(error.ErrorMessage);
   }
   
}
