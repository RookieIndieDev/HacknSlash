using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandlerScript : MonoBehaviour 
{
	public Button TryAgain;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		if (PlayerControlScript.IsDead) 
		{
			TryAgain.gameObject.SetActive(true);
		}
	
	}

	public void ReloadLevel()
	{
		SceneManager.LoadScene("Main");
	}
}
