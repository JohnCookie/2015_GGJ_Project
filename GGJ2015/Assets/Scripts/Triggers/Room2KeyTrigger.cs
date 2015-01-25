using UnityEngine;
using System.Collections;

public class Room2KeyTrigger : MonoBehaviour
{
	public GameObject trip;

	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().showHint("Got the key! I shape is the same as what on door!");
			ItemMgr.getInstance().getItem(0,"runes_1_light");
			PlayerInfo.getInstance().hasRoom3Key=true;

			AudioControler.getInstance().playPick();
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			Destroy(gameObject,3);
			Destroy(trip , 1);
		}
	}
}

