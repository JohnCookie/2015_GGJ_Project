using UnityEngine;
using System.Collections;

public class Room8HelpTrigger : MonoBehaviour
{
	public GameObject PasswordBoard;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(!hasRun){
				HintMgr.getInstance().showHint("You need a password to open the door");
				PasswordBoard.SetActive(true);
				hasRun=true;
			}
		}
	}
	
	bool hasRun=false;
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			Destroy(gameObject);
		}
	}
}

