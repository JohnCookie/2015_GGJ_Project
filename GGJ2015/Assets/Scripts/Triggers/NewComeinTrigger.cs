using UnityEngine;
using System.Collections;

public class NewComeinTrigger : MonoBehaviour
{
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().showHint("Press UP,DOWN,LEFT,RIGHT to move");
			//CameraMgr.getInstance().cameraStatus=CameraStatus.FullLook;
			AudioControler.getInstance().playBGM();
		}
	}

	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			Destroy(gameObject);
		}
	}
}

