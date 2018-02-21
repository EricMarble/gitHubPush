using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showUI : MonoBehaviour 
{
	public GameObject textEvent1;
	// Use this for initialization
	void Start () 
	{
		textEvent1.SetActive (false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag== "Player")
		{
			textEvent1.SetActive (true);
			StartCoroutine("WaitForSec");
		}
	}

	IEnumerator WaitForSec()
	{
		yield return new WaitForSeconds(5);
		Destroy (textEvent1);
		Destroy (gameObject);
	}


}
