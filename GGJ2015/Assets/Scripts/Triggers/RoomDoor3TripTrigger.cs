using UnityEngine;
using System.Collections;

public class RoomDoor3TripTrigger : MonoBehaviour
{
	public GameObject passwordDoor;
	public GameObject helper;

	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer") && !timeStart){
			HintMgr.getInstance().showHint("Oh You Are Trapped");
			ItemMgr.getInstance().showWarning();
			passwordDoor.SetActive(true);
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			timeStart=true;
			if(m_time>3 && !hasRun){
				HelperController helperScript = helper.GetComponent<HelperController>();
				helperScript.startHelp();
				CameraMgr.getInstance().cameraStatus=CameraStatus.FollowHelper;
				HintMgr.getInstance().showHint("Somebody come to help you");
				Destroy(gameObject);
				hasRun=true;
			}
		}
	}

	private float m_time=0.0f;
	bool timeStart=false;
	bool hasRun=false;
	void Update(){
		if(timeStart){
			m_time+=Time.deltaTime;
		}
	}
}

