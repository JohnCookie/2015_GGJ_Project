using UnityEngine;
using System.Collections;

public class HelperController : MonoBehaviour
{
	public TweenPosition tp;
	public TweenRotation tr;
	public GameObject passwordDoor;
	public GameObject entranceDoor;

	public void startHelp(){
		tp.gameObject.SetActive(true);
		tp.enabled=true;
		tp.ResetToBeginning();
		tp.PlayForward();
	}

	public void tpEnd(){
		tp.enabled=false;
		tr.gameObject.SetActive(true);
		tr.enabled=true;
		tr.ResetToBeginning();
		tr.PlayForward();
	}

	public void trEnd(){
		timeStart=true;
	}

	float m_time=0.0f;
	bool timeStart=false;
	bool hasRun=false;
	void Update(){
		if(timeStart){
			m_time+=Time.deltaTime;
		}
		if(m_time>2 && !hasRun){
			passwordDoor.SetActive(false);
			entranceDoor.SetActive(false);
			CameraMgr.getInstance().cameraStatus=CameraStatus.FollowPlayer;
			HintMgr.getInstance().hideHint();
			ItemMgr.getInstance().stopWarning();
			hasRun=true;
			Destroy(gameObject,2);
		}
	}
}

