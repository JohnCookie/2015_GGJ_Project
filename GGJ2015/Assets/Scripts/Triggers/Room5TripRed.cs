using UnityEngine;
using System.Collections;

public class Room5TripRed : MonoBehaviour
{
	public GameObject tripBlue;
	public GameObject tripRed;
	public GameObject tripYellow;
	
	public GameObject triggerBlue;
	public GameObject triggerRed;
	public GameObject triggerYellow;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().showHint("Go ahead!");
			PlayerInfo.getInstance().hasRoom5KeyRed=true;
			AudioControler.getInstance().playPick();
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			tripRed.SetActive(false);
			triggerRed.SetActive(false);
		}
	}
}

