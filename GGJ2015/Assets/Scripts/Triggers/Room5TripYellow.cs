using UnityEngine;
using System.Collections;

public class Room5TripYellow : MonoBehaviour
{
	public GameObject tripBlue;
	public GameObject tripRed;
	public GameObject tripYellow;
	
	public GameObject triggerBlue;
	public GameObject triggerRed;
	public GameObject triggerYellow;

	public GameObject mPlayer;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom5KeyRed){
				//ok
				HintMgr.getInstance().showHint("Go ahead!");
				PlayerInfo.getInstance().hasRoom5KeyYellow=true;
				AudioControler.getInstance().playPick();
			}else{
				HintMgr.getInstance().showHint("Remember the primary");
				PlayerInfo.getInstance().hasRoom5KeyRed=false;
				PlayerInfo.getInstance().hasRoom5KeyYellow=false;
				PlayerInfo.getInstance().hasRoom5KeyBlue=false;
				
				tripBlue.SetActive(true);
				tripRed.SetActive(true);
				tripYellow.SetActive(true);
				triggerBlue.SetActive(true);
				triggerYellow.SetActive(true);
				triggerRed.SetActive(true);

				mPlayer.transform.localPosition=PlayerInfo.getInstance().reset5Position.transform.localPosition;
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			if(PlayerInfo.getInstance().hasRoom5KeyRed && PlayerInfo.getInstance().hasRoom5KeyYellow){
				tripYellow.SetActive(false);
				triggerYellow.SetActive(false);
			}
		}
	}
}

