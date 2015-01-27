using UnityEngine;
using System.Collections;

public class PasswordBoard : MonoBehaviour
{
	public UILabel label1;
	public UILabel label2;
	public UILabel label3;
	public UILabel label4;

	public void CheckIsCorrect(){
		string result = label1.text+label2.text+label3.text+label4.text;
		Debug.Log(result);
		if(result.Equals("0125")){
			Debug.Log("Correct");
			HintMgr.getInstance().hideHint();
			gameObject.SetActive(false);
			CameraMgr.getInstance().cameraStatus=CameraStatus.FullLook;
		}
	}	
}

