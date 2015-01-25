using UnityEngine;
using System.Collections;

public class Room8HelpTrigger : MonoBehaviour
{
	public GameObject PasswordBoard;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(!hasRun){
				PasswordBoard.SetActive(true);
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

