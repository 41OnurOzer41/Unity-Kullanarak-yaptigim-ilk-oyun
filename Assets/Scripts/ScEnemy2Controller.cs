using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScEnemy2Controller : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Animator myAnim;
    public Transform target;
    public Transform homPos;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    
    void Start()
    {
           
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<ScPlayer1Controller>().transform;

        if(target != null)
            Debug.Log("Start içinde, Player var, tag: " + target.tag);
        else
            Debug.Log("Start içinde, Player(target) yok!");

    }

    // Update is called once per frame
    void Update()
    {
        if(target==null)
        {Debug.Log("player yok");
        //target = FindObjectOfType<ScPlayer1Controller>().transform;
        
        }
        if(target != null){
            {Debug.Log("update içinde player var");}
            //var a=transform.position;
            if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            {

                FollowPlayer();

            }
            else if (Vector3.Distance(target.position, transform.position) >= maxRange)
            {
                GoHome();
            }
            
        }else{
            Debug.Log("Update içinden, playeer yok!");
            
            target = FindObjectOfType<ScPlayer1Controller>().transform;

            if(target != null)
                Debug.Log("Update içinde yendien target arama, Target var, tag: " + target.tag);
            else
                Debug.Log("Update içinde yendien target arama, Target yok!");
        }
    }

   public void FollowPlayer()
    {
        myAnim.SetBool("isDurum", false);
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,speed * Time.deltaTime);
    }

    public void GoHome()
    {
         myAnim.SetFloat("moveX", (homPos.position.x - transform.position.x));
         myAnim.SetFloat("moveY", (homPos.position.y - transform.position.y));
         transform.position = Vector3.MoveTowards(transform.position, homPos.transform.position,speed * Time.deltaTime);
 
        if(Vector3.Distance(transform.position,homPos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
            myAnim.SetBool("isDurum", true);

        }
    }
}
