using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemMgr : MonoBehaviour
{
	public UISprite[] item_arr = new UISprite[5];
	public GameObject m_objWarning;

	private static ItemMgr _instance;
	private ItemMgr(){
	}
	public static ItemMgr getInstance(){
		if(_instance==null){
			_instance=GameObject.Find("ItemMgr").GetComponent<ItemMgr>();
		}
		return _instance;
	}

	void Awake(){
		for(int i=0;i<item_arr.Length;i++){
			item_arr[i].gameObject.SetActive(false);
		}
		m_objWarning.SetActive(false);
	}

	public void getItem(int index, string name){
		item_arr[index].spriteName=name;
		item_arr[index].gameObject.SetActive(true);
	}

	public void showWarning(){
		TweenAlpha ta = m_objWarning.GetComponent<TweenAlpha>();
		m_objWarning.SetActive(true);
		ta.enabled=true;
		ta.ResetToBeginning();
		ta.PlayForward();
	}

	public void stopWarning(){
		TweenAlpha ta = m_objWarning.GetComponent<TweenAlpha>();
		ta.enabled=false;
		m_objWarning.SetActive(false);
	}
}

