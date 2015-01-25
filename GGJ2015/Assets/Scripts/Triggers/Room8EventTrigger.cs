using UnityEngine;
using System.Collections;

public class Room8EventTrigger : MonoBehaviour
{
	public GameObject rookieU;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(!hasRun){
				HintMgr.getInstance().showHint("Someone seems need help ... Some..one?");
				rookieU.SetActive(true);
				RookieU rookieScript = rookieU.GetComponent<RookieU>();
				rookieScript.startWalk();
				CameraMgr.getInstance().cameraStatus=CameraStatus.FollowRookie;
				hasRun=true;
			}
		}
	}

	bool hasRun=false;

	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			Destroy(gameObject);
		}
	}
}

