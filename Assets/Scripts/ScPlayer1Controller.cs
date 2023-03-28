using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScPlayer1Controller : MonoBehaviour
{
    // Start is called before the first frame update
     //Input Variables

    
    private float h_Input;
    private float v_Input;
     //Components
    private Rigidbody2D playerRB;

    private float weaponAngle = 0f;

      //GameObjects
    private GameObject WeaponObj;
    

    //Player Control Variables
   [SerializeField]private float movementSpeed = 5.0f;

   public float weaponAwayRadius = 2f;

     //Equip Weapon
    private bool isWeaponEquipped;

    //Animator
    Animator p_Animator;//anımasyon

   public ScScoreSystem paraSystem ;
    private  int goldCoin = 0;
  
    //Character States
    private bool isIdle;
    private bool isWalkingX;
    private bool isWalkingY;
    private bool isWalking;

    ScCanBar CanScript;
  

    void Awake()
    {
        playerRB = this.GetComponent<Rigidbody2D>();//otomatik olarak bir oyuncunun eigidboyd componentine erişerek fiziksel hamle yaptırtma
        p_Animator = this.GetComponent<Animator>(); //animasyon
        isWeaponEquipped = false;
    
        isIdle = true; //animasyon
        isWalkingX=false;
        isWalkingY=false;
        isWalking=false;
    
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Görseller
        
        CheckInput();
    }
    void FixedUpdate()
    {
        //Fiziksel
        
        ApplyMovement();


    }
     void ApplyMovement()
    {
     //h_Input = movementSpeed   
     playerRB.velocity = new Vector2( h_Input * movementSpeed , v_Input * movementSpeed  );


    }
    void CheckInput()
    {
        h_Input=Input.GetAxis("Horizontal");
        v_Input = Input.GetAxis("Vertical");

//animasyon bas
        //Player State Changes
        if(h_Input>0.01f || h_Input<-0.01f)
        {
            isIdle=false;
            isWalkingX=true;
            isWalking=true;
            p_Animator.SetBool("Bool_isIdle",isIdle);
            p_Animator.SetBool("Bool_isWalking",isWalking);
            //p_Animator.SetBool("Bool_MovementX",isWalkingX);
            p_Animator.SetFloat("MoveX",h_Input);
        }
        if(v_Input>0.01f || v_Input<-0.01f)
        {
            isIdle=false;
            isWalkingY=true;
            isWalking=true;
            p_Animator.SetBool("Bool_isIdle",isIdle);
            p_Animator.SetBool("Bool_isWalking",isWalking);
            //p_Animator.SetBool("Bool_MovementY",isWalkingY);
            p_Animator.SetFloat("MoveY",v_Input);
        }
        if( h_Input<0.01f && h_Input>-0.01f) 
        {
            isWalkingX=false;
            //p_Animator.SetBool("Bool_MovementX",isWalkingX);
        }
        if( v_Input<0.01f && v_Input>-0.01f) 
        {
            isWalkingY=false;
            //p_Animator.SetBool("Bool_MovementY",isWalkingY); 
        }
        if(isIdle==false && isWalkingX==false && isWalkingY==false)
        {
            isWalking = false;
            //Debug.Log("Idle True State");
            isIdle=true;
            p_Animator.SetBool("Bool_isWalking",isWalking);
            p_Animator.SetBool("Bool_isIdle", isIdle);
            
            StartCoroutine(WaitForIdleAnimation());
            
        } //animasyon son



        if(WeaponObj != null && isWeaponEquipped==true)
        {
        Vector3 mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - WeaponObj.transform.position;
        float angle = Vector2.SignedAngle(Vector2.right,direction);
        weaponAngle = angle;
        //Debug.Log("Angle:"+angle+"-Rad"+(angle*Mathf.PI/180));
        WeaponObj.transform.position = new Vector2(this.gameObject.transform.position.x+weaponAwayRadius*Mathf.Cos(angle * Mathf.PI / 180), this.gameObject.transform.position.y + weaponAwayRadius * Mathf.Sin(angle * Mathf.PI / 180));
        WeaponObj.transform.eulerAngles = new Vector3(0,0,angle);
        }
        if(isWeaponEquipped==true && Input.GetButtonDown("Fire1"))
        {

            if(WeaponObj != null)
            {
                WeaponObj.GetComponent<ScHandGun>().shoot(weaponAngle);
            }
            else {Debug.LogError("Error:" + WeaponObj);}

        }


    }
    public void increaseCoinCount(){this.goldCoin++;}
    public int getCoinCount(){return this.goldCoin;}
    //public void increaseScore(){this.score++;}
    //public int getScore(){return this.score;}
    

    //public void IncreasePlayerScore(){increaseScore();}

   public void OnTriggerEnter2D(Collider2D col)
   {
    if(isWeaponEquipped == false && col.CompareTag("Weapon"))
   {
    WeaponObj = col.gameObject;
    col.transform.parent = this.gameObject.transform;
    //col.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x+0.7f, this.gameObject.transform.position.y);
    col.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x+weaponAwayRadius,this.gameObject.transform.position.y+(-0.6f));
    col.gameObject.transform.parent = this.gameObject.transform;
    isWeaponEquipped = true;
    }
  
    if(col.gameObject.tag == "Coin")
    {

        Debug.Log("Acquired Coin!");
        increaseCoinCount();
        paraSystem.para += 10;
        Destroy(col.gameObject);
    }
   }
    
   
   
  


//animasyon
   //Coroutine for Changing Idle Animation
    IEnumerator WaitForIdleAnimation()
    {  
        yield return new WaitForSeconds(0.1f);
        Debug.Log("1 Sec");
        p_Animator.SetBool("Bool_isIdle", false);
    }
}
