using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ProducerSetting : MonoBehaviour {

    public Rigidbody2D rb;
	public GameObject gum;
	public Transform gumRotation;
	public Vector3 gumPosion;
	public float jumpFrequency = 0;
    public float produceSpeed;
    public float MoveTime = 5f;
    public GameObject targetchar;
    public Vector3 targetPosition;
    public float count=0;
    // Use this for initialization
	
	// Use this for initialization
    void Start () {
        rb =transform.GetComponent<Rigidbody2D>();
        targetchar = GameObject.Find("char");
        targetPosition = targetchar.transform.position;

    }
    
    // Update is called once per frame
    void Update () {
        produceSpeed = ProducerManerger.Instance.produceSpeed;
        //Debug.Log(produceSpeed);
        count += Time.deltaTime/produceSpeed;
      //  Debug.Log(count);

        if (count>=1)
        {
            count = 0;
            ProduceGun();

        }



    }


	public void ProduceGun()
	{
		gumPosion = transform.position + Vector3.up * 3;
        GameObject gums = Instantiate(gum, transform.position, transform.rotation);
        gums.transform.DOMove(targetPosition, 5f).SetEase(Ease.Linear);
        Destroy(gums, 5f);
        //addgun

        
	}
       
   // public void Jump()
   // {
        
		
			//rb.velocity = new Vector3(0, 3, 0);

			//Debug.Log("rb");
		

    }

