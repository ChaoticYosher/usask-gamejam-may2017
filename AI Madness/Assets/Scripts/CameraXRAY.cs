using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXRAY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit[] hits;
		RaycastHit[] hitsBack;
		hits = Physics.RaycastAll(transform.position, transform.forward, 10.0F);
		hitsBack = Physics.RaycastAll(transform.position, transform.forward*-1, 1000.0F);

		for (int i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];
			if (hit.transform.gameObject.tag == "XRay") {

				Debug.Log ("XRay" + hit.transform.name);

				Renderer rend = hit.transform.GetComponent<Renderer> ();

				if (rend) {
					// Change the material of all hit colliders
					// to use a transparent shader.
					rend.material.shader = Shader.Find ("Transparent/Diffuse");
					Color tempColor = rend.material.color;
					tempColor.a = 0.3F;
					rend.material.color = tempColor;

					//set tag to GHOST
					hit.transform.gameObject.tag = "GHOST";
				}
				//invoke to reset transparancy later
				if(hit.transform.gameObject.tag == "GHOST")
				{
					StartCoroutine (ResetTransparancy (hit.transform.gameObject));
				}
			}
		}

		for (int i = 0; i < hitsBack.Length; i++) {
			RaycastHit hit = hitsBack [i];
			if (hit.transform.gameObject.tag == "XRay") {

				Debug.Log ("XRay" + hit.transform.name);

				Renderer rend = hit.transform.GetComponent<Renderer> ();

				if (rend) {
					// Change the material of all hit colliders
					// to use a transparent shader.
					rend.material.shader = Shader.Find ("Transparent/Diffuse");
					Color tempColor = rend.material.color;
					tempColor.a = 0.3F;
					rend.material.color = tempColor;

					//set tag to GHOST
					hit.transform.gameObject.tag = "GHOST";
				}
				//invoke to reset transparancy later
				if(hit.transform.gameObject.tag == "GHOST")
				{
					StartCoroutine (ResetTransparancy (hit.transform.gameObject));
				}
			}
		}
	}

	IEnumerator ResetTransparancy(GameObject item)
	{
		yield return new WaitForSeconds (2);
		item.GetComponent<Renderer> ().material.shader = Shader.Find ("Standard");
		item.tag = "XRay";
	}
}
