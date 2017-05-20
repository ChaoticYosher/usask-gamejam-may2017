using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBumpedMe : MonoBehaviour {

	Material iron;
	Material slime;

	// Use this for initialization
	void Start () {
		slime = Resources.Load("LightUp", typeof(Material)) as Material;
		iron = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
		{
			ResetColour ();
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			Debug.Log("Boop" + GetComponent<Renderer>().material);
			GetComponent<Renderer> ().material = slime;
		}

	}

	void ResetColour()
	{
		GetComponent<Renderer> ().material = iron;
	}
}
