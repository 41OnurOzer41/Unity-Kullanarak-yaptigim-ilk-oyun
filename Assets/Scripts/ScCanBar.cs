using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCanBar : Singleton<ScCanBar>
{       
    //Sccamp_fire campScript;
    public  GameObject canbar;
    public float can = 100f;


     private float timer;
    [SerializeField]private float timerMax = 2f;
    [SerializeField] private float healAmount = 10f;


    private bool isPlayerEntered = false;
    private bool healingState = false;




    // Start is called before the first frame update
    void Start()
    {
        timer = timerMax;

    }

    // Update is called once per frame
    void Update()
    {

        canMetod();
        canartma();
        /*if (Input.GetButton("Fire1") || isPlayerEntered == true)
        {
            if (healingState == false) healingState = true;
            {

            }
            if (healingState==true)
            {
                HealPlayer();
            }
        }*/
    }
    public void canMetod(){
        //campScript.healState = true;
        canbar.transform.localScale = new Vector3(can/100,1,1);
        if(can >=100){
            can=100;
        }
        if(can <=0){
            can=0;
        }

    }
     private void HealPlayer()
    {
        timer = timer - Time.deltaTime;
        if (timer<=0f)
        {
            timer = timerMax;
            can += healAmount;
        }

    }
    public float getPlayerHealth()
    {
        return can;


    }
    public void canartma()
    {
        if (/*Input.GetButton("Fire1") ||*/ isPlayerEntered == true)
        {
            if (healingState == false) healingState = true;
            {

            }
            if (healingState==true)
            {
                HealPlayer();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.tag == "yumruk") { 
            can-=25f;
        }
        if (collision.tag == "canverme")
        {
            isPlayerEntered = true;

          
        }
    
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "canverme" || collision.tag == "yumruk") 
        {
            isPlayerEntered = false;
        }
    }
     public void setGUIObjectsCan(GameObject g2)
    {
         canbar = g2;
    }
}
