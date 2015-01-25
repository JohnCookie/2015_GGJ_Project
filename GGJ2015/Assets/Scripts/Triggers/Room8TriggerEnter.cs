using UnityEngine;
using System.Collections;

public class Room8TriggerEnter : MonoBehaviour
{
	public GameObject secretDoor;
	public GameObject closeDoor;
	public GameObject openedDoor;
	public GameObject eventTrigger;
	public GameObject helpTrigger;

	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().showHint("You feel familiar with this place");
			secretDoor.SetActive(true);
			eventTrigger.SetActive(true);
			helpTrigger.SetActive(true);
			openedDoor.SetActive(true);
			closeDoor.SetActive(false);
			Destroy(closeDoor);
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			Destroy(gameObject);
		}
	}
}

