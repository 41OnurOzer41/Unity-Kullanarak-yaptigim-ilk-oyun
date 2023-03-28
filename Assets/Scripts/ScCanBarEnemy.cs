using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScCanBarEnemy : MonoBehaviour
{
    public GameObject canbar;
     
    [SerializeField] GameObject ParticleBloodGO;
    [SerializeField] GameObject CoinGO;
    
    
    public float can = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canbar.transform.localScale = new Vector3(can/100,1,1);
        if(can <=0){
            can=0;
        }
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet") { 
            can-=25f;
            if(can==0){
                
               Instantiate(ParticleBloodGO, this.transform.position,Quaternion.identity);

                //Coin işlemleri
                float chance = Random.Range(0.0f,100.0f);
                if(chance>50f){
                    Instantiate(CoinGO, this.transform.position,Quaternion.identity);
                }
                //Player Score
                
                // Player Score Increase
                //ScPlayer1Controller.GetComponent<ScPlayer1Controller>().IncreasePlayerScore();
                Destroy(gameObject);
            }
        }
    }
}
