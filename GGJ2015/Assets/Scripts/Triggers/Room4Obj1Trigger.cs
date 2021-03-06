using UnityEngine;
using System.Collections;

public class Room4Obj1Trigger : MonoBehaviour
{
	public GameObject trip;
	bool isTrigger=false;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer") && !isTrigger){
			if(PlayerInfo.getInstance().hasRoom4Key1){
				//ok
				HintMgr.getInstance().showHint("Seems You Can Go Now!");
				ItemMgr.getInstance().getItem(1,"runes_2_light");
			}else{
				HintMgr.getInstance().showHint("Not enough to open the door!");
			}
			PlayerInfo.getInstance().hasRoom4Key2=true;
			AudioControler.getInstance().playPick();
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer") && !isTrigger){
			isTrigger=true;
			HintMgr.getInstance().hideHint();
			Destroy(gameObject,2);
			Destroy(trip , 1);
		}
	}
}

