using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraScript : MonoBehaviour 
{
	public Material mat;
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		Graphics.Blit (src, dst, mat);
	}

	void Update()
	{
		mat.SetVector ("playerPosition", PlayerControlScript.PlayerPosition);

		if(Input.GetKey(KeyCode.K))
		{
				Application.CaptureScreenshot("E:\\Gamedev_projects\\Unity\\Hack n Slash\\Hack-n-Slash\\Screen.jpg");		
		}
	}
}
