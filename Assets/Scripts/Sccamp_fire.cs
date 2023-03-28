using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sccamp_fire : MonoBehaviour{   
    private ScCanBar PlayerDataManagerObj;
    private GameObject PlayerObj;
    [SerializeField]private GameObject TextObj;
    private bool isPlayerEntered=false;
    private bool healState=false;
    private float timer;
    [SerializeField]private float timerMax=2f;
    [SerializeField]private float healAmount=10f;
    // Start is called before the first frame update
    void Start(){   
        TextObj.SetActive(false);
        timer=timerMax;}
    // Update is called once per frame
    void Update() {
        if(Input.GetButton("Fire1")&& isPlayerEntered == true){
            if(healState==false) healState=true;}
        if(healState ==true){
            HealPlayer();} }
    private void HealPlayer() {
        timer= timer-Time.deltaTime;
        if(timer<0f){
            Debug.Log(PlayerDataManagerObj.getPlayerHealth());
            if(PlayerDataManagerObj.getPlayerHealth()>=100)
            {
                healState=false;
            }
            PlayerDataManagerObj.canMetod(); //canMetod(-1*healState
            timer=timerMax; } }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            Debug.Log("giriş");
            PlayerObj = other.gameObject;
            PlayerDataManagerObj= PlayerObj.GetComponent<ScCanBar>();
            TextObj.SetActive(true);
            isPlayerEntered=true;
            healState = false; }}
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject == PlayerObj){
            Debug.Log("cikiş");
            isPlayerEntered=false;
            TextObj.SetActive(false);
        }}}
