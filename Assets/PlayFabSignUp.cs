using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayFabSignUp : MonoBehaviour
{

    [SerializeField] Text username, userEmail, userPassword;   
    string encryptedPassword;

    public void Register() {
        // Debug.Log(username.text + " "  + Encrypt(userPassword.text) + " " + userEmail.text);
        var registerRequest = new RegisterPlayFabUserRequest{Username=username.text, Email=userEmail.text, Password=Encrypt(userPassword.text)};
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnregisterRequestSuccess, OnregisterRequestFailure);
    }

    void OnregisterRequestSuccess(RegisterPlayFabUserResult result){
        Debug.Log("User Registered");
        SceneManager.LoadScene(1);
    }

    void OnregisterRequestFailure(PlayFabError error) {
        Debug.Log("Error");

    }

    string Encrypt(string pw){
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] epw = System.Text.Encoding.UTF8.GetBytes(pw);
        epw = x.ComputeHash(epw);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in epw){
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }

}
