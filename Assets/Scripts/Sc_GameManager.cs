using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class Sc_GameManager : Singleton<Sc_GameManager>{
    [SerializeField] private GameObject PlayerPrefab;
    private GameObject PlayerGO;
    private ScCanBar PlayerCanSc;
    private ScScoreSystem PlayerScoreSc;
    [SerializeField] private GameObject GuiPrefab;
    private GameObject INGameGUI;
    private GameObject InGameCanvas;
    private ScInGameCanvas InGameCanvasScript;
    //Sound Manager
    [SerializeField] private GameObject SoundManagerPrefab;
    private GameObject SndManager;
    //Playerdata
    ScPlayer1Controller Pxdata;
    private bool StartAtBeggining = false;
    //Scene Information
    Scene currentScene;
    void Start(){
        //Get Current Scene
        currentScene = SceneManager.GetActiveScene();
        //Instantiate Player
        PlayerGO = Instantiate(PlayerPrefab, new Vector3(0,0,0),Quaternion.identity);
        PlayerCanSc = PlayerGO.GetComponent<ScCanBar>();
        PlayerScoreSc = PlayerGO.GetComponent<ScScoreSystem>();
        //Create SoundManager
        SndManager = Instantiate(SoundManagerPrefab, new Vector3(0,0,0), Quaternion.identity);
        //Instantiate In Game Canvas //INGameGUI = Instantiate(GuiPrefab, new Vector3(0,0,0), Quaternion.identity);//InGameCanvas = INGameGUI.transform.GetChild(0).gameObject;
        InGameCanvas = Instantiate(GuiPrefab, new Vector3(0,0,0), Quaternion.identity);
        InGameCanvasScript = InGameCanvas.GetComponent<ScInGameCanvas>();
        //InGameCanvasScript.setPlayer(PlayerGO);//InGameCanvasScript.SetPlayerGUIObjects();
        /*if (currentScene.buildIndex == 0)
        {
            //PlayerGO.SetActive(false);
            InGameCanvas.SetActive(false);
        }*/ }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(SndManager==null){
            SndManager = GameObject.FindWithTag("SoundManager");
        }
        if(SndManager!=null){
            SndManager.GetComponent<Sc_SoundManager>().changeMusicOnLevel();}else{  Debug.LogError("Error Sound Manager not Found");}
        Debug.Log("OnSceneLoaded: "+ scene.name);
        Debug.Log(mode);
        GameObject cineMachine = GameObject.FindWithTag("Cinemachine");
        if(cineMachine != null){
            CinemachineVirtualCamera vcam = cineMachine.GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = PlayerGO.transform;
        } }
    void Update(){    }
    public void MainMenuStart(){
        StartAtBeggining = true;
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void LoadNextScene() {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex+1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }}
