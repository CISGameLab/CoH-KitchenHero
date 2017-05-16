using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMain : MonoBehaviour {

	// Use this for initialization
	public GameObject ExitPanel;



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ExitPanel.gameObject.SetActive (true);
		}
	}

	public void YesClicked(){
		Application.Quit ();
	}
	public void NoClicked(){
		ExitPanel.gameObject.SetActive (false);
	}

	public void LoadLevel1()
	{
		Application.LoadLevel (1);
	}
}
