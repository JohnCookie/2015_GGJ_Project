using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{
	public bool hasRoom3Key=false;

	public bool hasRoom4Key1=false;
	public bool hasRoom4Key2=false;

	public bool hasRoom5KeyRed=false;
	public bool hasRoom5KeyYellow=false;
	public bool hasRoom5KeyBlue=false;

	public bool hasRoom6Key1=false;
	public bool hasRoom6Key2=false;
	public bool hasRoom6Key3=false;
	public bool hasRoom6Key4=false;

	public bool hasRoom7Key1=false;
	public bool hasRoom7Key2=false;
	public bool hasRoom7Key3=false;
	public bool hasRoom7Key4=false;

	public GameObject reset5Position;
	public GameObject reset7Position;

	public GameObject m_player;

	public Material mat_actor1;
	public Material mat_actor2;
	public Material mat_actor3;
	public Material mat_actor4;
	public Material mat_actor5;
	public Material mat_actor6;

	private static PlayerInfo _instance;
	private PlayerInfo(){
	}
	public static PlayerInfo getInstance(){
		if(_instance==null){
			_instance=GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
		}
		return _instance;
	}
	
	public void changePlayerMat(int i){
		switch(i){
		case 1:
			m_player.renderer.material=mat_actor1;
			break;
		case 2:
			m_player.renderer.material=mat_actor2;
			break;
		case 3:
			m_player.renderer.material=mat_actor3;
			break;
		case 4:
			m_player.renderer.material=mat_actor4;
			break;
		case 5:
			m_player.renderer.material=mat_actor5;
			break;
		case 6:
			m_player.renderer.material=mat_actor6;
			break;
		}
	}
}

