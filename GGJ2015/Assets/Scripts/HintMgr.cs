using UnityEngine;
using System.Collections;

public class HintMgr : MonoBehaviour
{
		public UILabel m_hintLabel;

		private static HintMgr _instance;
		private HintMgr(){
		}
		public static HintMgr getInstance(){
			if(_instance==null){
				_instance=GameObject.Find("HintMgr").GetComponent<HintMgr>();
			}
			return _instance;
		}

		public void showHint(string label){
			m_hintLabel.text=label;
			TweenAlpha alphaTween = m_hintLabel.transform.GetComponent<TweenAlpha>();
			alphaTween.from = 0.0f;
			alphaTween.to=1.0f;
			alphaTween.duration=1.0f;
			alphaTween.ResetToBeginning();
			alphaTween.gameObject.SetActive(true);
			alphaTween.PlayForward();
		}

		public void showHint(int id){
			m_hintLabel.text=getStringFromId(id);
			TweenAlpha alphaTween = m_hintLabel.transform.GetComponent<TweenAlpha>();
			alphaTween.from = 0.0f;
			alphaTween.to=1.0f;
			alphaTween.duration=1.0f;
			alphaTween.ResetToBeginning();
			alphaTween.gameObject.SetActive(true);
			alphaTween.PlayForward();
		}
		
		public void hideHint(){
			TweenAlpha alphaTween = m_hintLabel.transform.GetComponent<TweenAlpha>();
			alphaTween.from = 1.0f;
			alphaTween.to=0.0f;
			alphaTween.duration=1.0f;
			alphaTween.ResetToBeginning();
			alphaTween.gameObject.SetActive(true);
			alphaTween.PlayForward();
		}
	
	private string getStringFromId(int id){
			return "Get String From Id";
		}
}

