using UnityEngine;
using System.Collections;

public class Room7Trigger3 : MonoBehaviour
{
	public GameObject trip1;
	public GameObject trip2;
	public GameObject trip3;
	public GameObject trip4;
	
	public GameObject trigger1;
	public GameObject trigger2;
	public GameObject trigger3;
	public GameObject trigger4;

	public GameObject mPlayer;

	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom7Key1 && PlayerInfo.getInstance().hasRoom7Key2){
				//ok
				HintMgr.getInstance().showHint("You Got It!");
				PlayerInfo.getInstance().hasRoom7Key3=true;
				AudioControler.getInstance().playPick();
			}else{
				HintMgr.getInstance().showHint("Watch your item, you should notice it.");
				PlayerInfo.getInstance().hasRoom7Key1=false;
				PlayerInfo.getInstance().hasRoom7Key2=false;
				PlayerInfo.getInstance().hasRoom7Key3=false;
				PlayerInfo.getInstance().hasRoom7Key4=false;
				
				trip1.SetActive(true);
				trip2.SetActive(true);
				trip3.SetActive(true);
				trip4.SetActive(true);
				trigger1.SetActive(true);
				trigger2.SetActive(true);
				trigger3.SetActive(true);
				trigger4.SetActive(true);

				mPlayer.transform.localPosition=PlayerInfo.getInstance().reset7Position.transform.localPosition;
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			if(PlayerInfo.getInstance().hasRoom7Key1 && PlayerInfo.getInstance().hasRoom7Key2 && PlayerInfo.getInstance().hasRoom7Key3){
				trip3.SetActive(false);
				trigger3.SetActive(false);
			}
		}
	}
}

