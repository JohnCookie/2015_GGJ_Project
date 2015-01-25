using UnityEngine;
using System.Collections;

public class Room7Trigger1 : MonoBehaviour
{
	public GameObject trip1;
	public GameObject trip2;
	public GameObject trip3;
	public GameObject trip4;

	public GameObject trigger1;
	public GameObject trigger2;
	public GameObject trigger3;
	public GameObject trigger4;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().showHint("You Got It!");
			PlayerInfo.getInstance().hasRoom7Key1=true;
			AudioControler.getInstance().playPick();
			/*
			if(PlayerInfo.getInstance().hasRoom5KeyRed){
				//ok
				HintMgr.getInstance().showHint("Go ahead!");
				PlayerInfo.getInstance().hasRoom5KeyYellow=true;
			}else{
				HintMgr.getInstance().showHint("Remember the primary");
				PlayerInfo.getInstance().hasRoom5KeyRed=false;
				PlayerInfo.getInstance().hasRoom5KeyYellow=false;
				PlayerInfo.getInstance().hasRoom5KeyBlue=false;
				
				trip1.SetActive(true);
				trip2.SetActive(true);
				trip3.SetActive(true);
				trip4.SetActive(true);
				trigger1.SetActive(true);
				trigger2.SetActive(true);
				trigger3.SetActive(true);
				trigger4.SetActive(true);
			}
			*/
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			trip1.SetActive(false);
			trigger1.SetActive(false);
		}
	}
}

