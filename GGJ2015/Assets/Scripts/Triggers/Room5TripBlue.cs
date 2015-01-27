using UnityEngine;
using System.Collections;

public class Room5TripBlue : MonoBehaviour
{
	public GameObject tripBlue;
	public GameObject tripRed;
	public GameObject tripYellow;

	public GameObject triggerBlue;
	public GameObject triggerRed;
	public GameObject triggerYellow;

	public GameObject mPlayer;

	public GameObject triggerHint;

	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom5KeyRed && PlayerInfo.getInstance().hasRoom5KeyYellow){
				//ok
				HintMgr.getInstance().showHint("Yeah, You can go now!");
				ItemMgr.getInstance().getItem(2,"runes_3_light");
				PlayerInfo.getInstance().hasRoom5KeyBlue=true;
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
			if(PlayerInfo.getInstance().hasRoom5KeyRed && PlayerInfo.getInstance().hasRoom5KeyYellow && PlayerInfo.getInstance().hasRoom5KeyBlue){
				Destroy (tripBlue,1);
				Destroy(tripRed,1);
				Destroy(tripYellow,1);
				Destroy (triggerBlue,2);
				Destroy (triggerYellow,2);
				Destroy(triggerRed,2);

				Destroy(triggerHint,1);
			}
		}
	}
}

