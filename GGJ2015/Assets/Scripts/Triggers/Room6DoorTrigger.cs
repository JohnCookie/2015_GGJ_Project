using UnityEngine;
using System.Collections;

public class Room6DoorTrigger : MonoBehaviour
{
	public GameObject door;
	public GameObject prefabParticle;
	public GameObject particleRoot;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom6Key1 && PlayerInfo.getInstance().hasRoom6Key2 && PlayerInfo.getInstance().hasRoom6Key3 && PlayerInfo.getInstance().hasRoom6Key4){
				Destroy(door,2);
				GameObject particle = (GameObject) Instantiate(prefabParticle);
				particle.transform.parent=particleRoot.transform;
				particle.transform.localPosition=new Vector3(8254,0,1995);
				particle.transform.localRotation= Quaternion.Euler(90,-90,0);
				particle.transform.localScale=new Vector3(360,360,360);
				ParticleSystem system = particle.GetComponent<ParticleSystem>();
				system.Play(true);

				PlayerInfo.getInstance().changePlayerMat(5);
				AudioControler.getInstance().playOpenDoor();
			}else{
				HintMgr.getInstance().showHint("You Can't Exit...");
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom6Key1 && PlayerInfo.getInstance().hasRoom6Key2 && PlayerInfo.getInstance().hasRoom6Key3 && PlayerInfo.getInstance().hasRoom6Key4){
				Destroy(gameObject);
			}
			HintMgr.getInstance().hideHint();
		}
	}
}

