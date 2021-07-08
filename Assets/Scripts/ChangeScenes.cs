using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ThanksScene(){
        SceneManager.LoadScene("Thanks");
    }
    public void PlayScreen(){
        SceneManager.LoadScene("playScreen");
    }
}
