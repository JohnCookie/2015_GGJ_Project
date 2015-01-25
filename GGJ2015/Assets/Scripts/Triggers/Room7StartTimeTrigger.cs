using UnityEngine;
using System.Collections;

public class Room7StartTimeTrigger : MonoBehaviour
{
	public GameObject m_warningTimeObj;
	public UILabel m_timeMin;
	public UILabel m_timeSec;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(!timeStart){
				HintMgr.getInstance().showHint("Holy S**t ! ! !");
				ItemMgr.getInstance().showWarning();
				m_warningTimeObj.SetActive(true);
				timeStart=true;
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
		}
	}
	
	private float m_time=300.0f;
	bool timeStart=false;
	bool hasRun=false;
	void Update(){
		if(timeStart){
			m_time-=Time.deltaTime;
			if(m_time<0){
				HintMgr.getInstance().showHint("Game Over!");
			}
			showTheTime(m_time);
		}
	}
	
	void showTheTime(float second){
		int showMin = (int)(second/60);
		int showSecond = (int)(second - (showMin*60));
		
		m_timeMin.text="0"+showMin;
		if(showSecond>=10){
			m_timeSec.text=showSecond.ToString();
		}else{
			m_timeSec.text="0"+showSecond;
		}
	}
}

