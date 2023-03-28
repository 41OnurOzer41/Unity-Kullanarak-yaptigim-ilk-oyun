using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScLevel0 : MonoBehaviour
{
    int sceheID;
    GameObject GameManagerObj;
    Sc_GameManager GameManagerSc;
    void Start(){
        sceheID = SceneManager.GetActiveScene().buildIndex;
        GameManagerObj = GameObject.FindWithTag("GameManager");
        GameManagerSc = GameManagerObj.GetComponent<Sc_GameManager>();
    }
    void Update() {   }

    public void func_exit_button(){
        Application.Quit();
    }
    public void func_startNewGame(){
        //SceneManager.LoadScene(sceheID + 1);
        GameManagerSc.MainMenuStart();
    }
    public void func_loadGame(){}
    public void func_settings(){}
}
