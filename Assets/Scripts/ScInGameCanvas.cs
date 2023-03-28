using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ScInGameCanvas : Singleton<ScInGameCanvas>{
    [SerializeField] GameObject InGameGUIObj;
    [SerializeField] GameObject InGameMenuObj;
    [SerializeField] public GameObject PlayerGO;
    [SerializeField] public ScCanBar canbar1;
    [SerializeField] public ScScoreSystem ParaSC;
    private bool isActive_InGameMenu = false;
    void Start(){
        InGameGUIObj = this.transform.GetChild(0).gameObject;
        InGameMenuObj = this.transform.GetChild(1).gameObject;
        isActive_InGameMenu = false;
        InGameMenuObj.SetActive(isActive_InGameMenu);
        PlayerGO = GameObject.FindWithTag("Player");
        if (PlayerGO != null) { 
            canbar1 = PlayerGO.GetComponent<ScCanBar>();} else{   Debug.LogError("InGameCanvas Script Error -> Player Object bulunamadı "); }}
    void Update(){
        if(Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.P)){
            InGameMenu_Continue(); }}
    public void InGameMenu_Continue() {
        //In Game Menu Toggle
        if(isActive_InGameMenu == false) {
            isActive_InGameMenu = true;
            Time.timeScale = 0;
        } else{
            isActive_InGameMenu = false;
            Time.timeScale = 1;
        } InGameMenuObj.SetActive(isActive_InGameMenu); }
    public void InGameMenu_Exit() {
        Application.Quit(); }
    public void setPlayer(GameObject PlayerObject) {
        PlayerGO = PlayerObject; }
    public void SetPlayerGUIObjects(){
        if (PlayerGO != null){
            if (InGameGUIObj == null ||InGameMenuObj == null ){
                InGameGUIObj = this.transform.GetChild(0).gameObject;
                InGameMenuObj = this.transform.GetChild(1).gameObject; }
            //player guı 
            canbar1 = PlayerGO.GetComponent<ScCanBar>();
            GameObject canbar = InGameGUIObj.transform.GetChild(0).gameObject;
            canbar1.setGUIObjectsCan(canbar);
            ParaSC = PlayerGO.GetComponent<ScScoreSystem>();
            GameObject paraTextGO  = InGameGUIObj.transform.GetChild(1).gameObject;
            ParaSC.setGUIObjectsPara(paraTextGO);} else{Debug.LogError("InGameCanvas Script Error -> Player Object bulunamadı "); } }}
