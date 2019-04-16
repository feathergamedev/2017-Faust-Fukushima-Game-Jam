
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducerManerger : MonoBehaviour {
    
    private static ProducerManerger _instance;
	public  int producerNumber=1;//生產者數目
                                 //setingproducevalue()
    public float produceSpeed ;//3*(0.98)^n  生產口香糖時間
	public  int ProduceCost;//生產花費金幣   10+20*(1.1)^n+n*10
	public  float atttackDamage;//100*(1.01)^n+n*(1.05)^n

	public  float skillBuffer = 1;//技能瘋狂咀嚼    2*(1.01)^n
	public  bool skillOn = false;

	public  float jumpFrequency;//跳躍間格
									  // Use this for initialization
	public GumWorker worker;
	
    public static ProducerManerger Instance
	{
		get
		{
			return _instance;
		}
	}
	//private void Awake()
	//{
 //       if (_instance==null)
	//	{
 //           _instance = new ProducerManerger();
	//	}
		
	//}
	private void Awake()
	{
		_instance = this;
	}


	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        SetingProduceValue();




	}
    public void SetingProduceValue()
    {

        producerNumber = worker.Get_Worke_Num;
        produceSpeed = (float)((3 * Math.Pow((double)0.98, (double)producerNumber)));

        ProduceCost = (int)(10 + 20 * Math.Pow((double)1.1,(double)producerNumber) + producerNumber * 10);
        atttackDamage = (float)Math.Round((100 * Math.Pow((double)1.01, (double)producerNumber) + producerNumber * (Math.Pow((double)1.05, (double)producerNumber))),2);
        if (skillOn == true)
            skillBuffer = (float)(2 * Math.Pow((double)1.01, (double)producerNumber)); 
        else
        {
            skillBuffer = 1;
        }
    }
    public void CreateProducer(int charNo,Vector3 location)
    {
        producerNumber++;
        //create

    }

}
