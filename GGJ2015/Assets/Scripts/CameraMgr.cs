using UnityEngine;
using System.Collections;

public enum CameraStatus{
	FollowPlayer,
	FollowHelper,
	FollowRookie,
	FullLook,
	End
}

public enum GameCameraMode{
	FPS_Mode,
	UPDOWN_Mode
}

public class CameraMgr : MonoBehaviour
{
		private static CameraMgr _instance;
		private CameraMgr(){
			}
		public static CameraMgr getInstance(){
				if(_instance==null){
				_instance=GameObject.Find("CameraMgr").GetComponent<CameraMgr>();
				}
				return _instance;
			}
	
	public Camera m_playerCamera;
	public Camera m_uiCamera;
	public GameObject m_objPlayer;
	public GameObject m_helperPlayer;
	public GameObject m_rookieU;

	public GameObject fullView;
	public GameObject fullLight;
		
	public CameraStatus cameraStatus = CameraStatus.FollowPlayer;
	public GameCameraMode gameCameraMode = GameCameraMode.UPDOWN_Mode;

		// Use this for initialization
		void Start ()
		{
		}
		
		// Update is called once per frame
		void Update ()
		{
			switch(cameraStatus){
				case CameraStatus.FollowPlayer:
					if(gameCameraMode==GameCameraMode.UPDOWN_Mode){
						m_playerCamera.transform.localPosition=new Vector3(m_objPlayer.transform.localPosition.x,800,m_objPlayer.transform.localPosition.z);
					}
					if(gameCameraMode==GameCameraMode.FPS_Mode){
						m_playerCamera.transform.localPosition=m_objPlayer.transform.localPosition;
						m_playerCamera.transform.localEulerAngles=m_objPlayer.transform.localEulerAngles;
					}
					break;
				case CameraStatus.FollowHelper:
					m_playerCamera.transform.localRotation=Quaternion.Euler(new Vector3(90,0,0));
					m_playerCamera.transform.localPosition=new Vector3(m_helperPlayer.transform.localPosition.x,800,m_helperPlayer.transform.localPosition.z);
					break;
				case CameraStatus.FollowRookie:
					m_playerCamera.transform.localRotation=Quaternion.Euler(new Vector3(90,0,0));
					m_playerCamera.transform.localPosition=new Vector3(m_rookieU.transform.localPosition.x,800,m_rookieU.transform.localPosition.z);
					break;
				case CameraStatus.FullLook:	
					fullView.SetActive(true);
					fullLight.SetActive(true);
					if(m_playerCamera.transform.localPosition.y<12000){
						m_uiCamera.gameObject.SetActive(false);
						Vector3 currPos=m_playerCamera.transform.localPosition;
						m_playerCamera.transform.localPosition=new Vector3(currPos.x, currPos.y+Time.deltaTime*400, currPos.z);
						m_playerCamera.transform.localRotation=Quaternion.Euler(new Vector3(90,0,0));
						Vector3 currRotate=m_playerCamera.transform.localRotation.eulerAngles;
						m_playerCamera.transform.localRotation=Quaternion.Euler(currRotate.x,currRotate.y+Time.deltaTime*10,currRotate.z);
					}else{
						m_uiCamera.gameObject.SetActive(true);
						ItemMgr.getInstance().getItem(0,"runes_1_light");
						ItemMgr.getInstance().getItem(1,"runes_2_light");
						ItemMgr.getInstance().getItem(2,"runes_3_light");
						ItemMgr.getInstance().getItem(3,"runes_4_light");
						ItemMgr.getInstance().getItem(4,"runes_5_light");
						HintMgr.getInstance().showHint("To help those beginners like WE used to be");
						cameraStatus=CameraStatus.End;
					}
					break;
				default:
					break;
			}
			
		}
}

