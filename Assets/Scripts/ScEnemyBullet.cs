using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEnemyBullet : MonoBehaviour
{

	[SerializeField] public float bulletSpeed;
    [SerializeField] float lifeTime = 0f;
  
    float moveSpeed = 10f;

	Rigidbody2D rb;

	ScPlayer1Controller target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		target = GameObject.FindObjectOfType<ScPlayer1Controller>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}

	public void shootBullet(float angle)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed*Mathf.Cos(angle*Mathf.PI/180), bulletSpeed * Mathf.Sin(angle * Mathf.PI / 180));

       Destroy(this.gameObject,lifeTime);
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			Debug.Log ("Hit!");
			Destroy (gameObject);
		}
		if (col.CompareTag("Obstacle"))
        {
            BoxCollider2D m_ObjectCollider = this.gameObject.GetComponent < BoxCollider2D>();
            m_ObjectCollider.isTrigger = false;
        }
	}

	
}
