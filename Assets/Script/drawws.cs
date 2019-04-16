﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class wwwHelper
{

}
	

public class drawws : MonoBehaviour
{
	public static Dictionary<int , Texture2D> arms = new Dictionary<int, Texture2D>();
	public static Dictionary<int, Texture2D> bodys = new Dictionary<int, Texture2D>();

	public string siteName = "https://drawws.kgr-lab.com";
    public int charNo;
	private GameObject armr, arml;
	private bool flag = false;

	public float rotateSpeed = 1f;
	[Range(-100, 100)]
	public float rotateleft = 1f;
	[Range(-100, 100)]
	public float rotateright = 1f;


	public void SetProducer(int charno, float speed)
	{
		this.charNo = charno;
		this.rotateSpeed = speed;
	}


	IEnumerator Start()
	{

		GameObject body = transform.Find("body").gameObject;
		Renderer bodyRenderer = body.GetComponent<Renderer>();

		armr = transform.Find("armr").gameObject;
		Renderer armrRenderer = armr.GetComponent<Renderer>();

		arml = transform.Find("arml").gameObject;
		Renderer armlRenderer = arml.GetComponent<Renderer>();

		string bodyFile = string.Format("/b{0:0000}", charNo);
		string armFile = string.Format("/a{0:0000}", charNo);

		Texture2D tbody;
		Texture2D tarm;
		tbody = Resources.Load<Texture2D>("Texture" + bodyFile);
		tarm = Resources.Load<Texture2D>("Texture" + armFile);

		if (tbody == null)
			Debug.LogErrorFormat(" www bodyFile{0} {1}", bodyFile, (tbody != null).ToString());

		if(tarm == null)
			Debug.LogErrorFormat(" www armFile{0} {1}", armFile, (tarm != null).ToString());


		if (tbody == null && bodys.ContainsKey(charNo))
			tbody = bodys[charNo];

		if (tarm == null && arms.ContainsKey(charNo))
			tarm = arms[charNo];

		if (tbody == null || tarm == null)
		{
			

			WWW bodyWWW = new WWW(siteName + bodyFile + ".png");
			WWW armWWW = new WWW(siteName + armFile + ".png");
			yield return bodyWWW;
			yield return armWWW;

			bodys[charNo] = bodyWWW.texture;
			arms[charNo] = armWWW.texture;

			bodyRenderer.material.mainTexture = bodyWWW.texture;
			armrRenderer.material.mainTexture = armWWW.texture;
			armlRenderer.material.mainTexture = armWWW.texture;
		}
		else
		{
			bodyRenderer.material.mainTexture = tbody;
			armrRenderer.material.mainTexture = tarm;
			armlRenderer.material.mainTexture = tarm;
		}

		flag = true;
	}

	// Update is called once per frame
	void Update()
	{

		rotateSpeed = ProducerManerger.Instance.produceSpeed;

		if (flag)
		{

			armr.transform.Rotate(0, rotateleft * rotateSpeed, 0);
			arml.transform.Rotate(0, rotateright * rotateSpeed, 0);
		}
	}
}
