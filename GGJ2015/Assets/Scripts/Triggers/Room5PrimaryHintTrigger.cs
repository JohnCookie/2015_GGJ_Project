using UnityEngine;
using System.Collections;

public class Room5PrimaryHintTrigger : MonoBehaviour
{
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().showHint("Remember the primary...");
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
		}
	}
}

