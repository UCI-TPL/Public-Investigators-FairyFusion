﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonHandler : MonoBehaviour {


	public void StartGame(){
		SceneManager.LoadScene (1);
	}

	public void Quit(){
		Application.Quit ();
	}
}
