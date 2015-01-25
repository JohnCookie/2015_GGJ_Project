using UnityEngine;
using System.Collections;

public class EnterRoom2Trigger : MonoBehaviour
{
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().showHint("Find Your Way");
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			Destroy(gameObject);
		}
	}
}

