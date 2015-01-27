using UnityEngine;
using System.Collections;

public class Room6Obj2Trigger : MonoBehaviour
{
	public GameObject trip;
	public GameObject startTrigger;
	public GameObject warningTimeObj;

	bool isTrigger=false;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer") && !isTrigger){
			if(PlayerInfo.getInstance().hasRoom6Key1 && PlayerInfo.getInstance().hasRoom6Key3 && PlayerInfo.getInstance().hasRoom6Key4){
				//ok
				HintMgr.getInstance().showHint("Alarm Stoped");
				ItemMgr.getInstance().getItem(3,"runes_4_light");
				ItemMgr.getInstance().stopWarning();
				Destroy(startTrigger);
				warningTimeObj.SetActive(false);
			}else{
				HintMgr.getInstance().showHint("Alarm is still ringing...");
			}
			PlayerInfo.getInstance().hasRoom6Key2=true;
			AudioControler.getInstance().playPick();
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer") && !isTrigger){
			isTrigger=true;
			HintMgr.getInstance().hideHint();
			Destroy(gameObject,3);
			Destroy(trip , 1);
		}
	}
}

