using UnityEngine;
using System.Collections;

public class TriggerDeliver : MonoBehaviour
{
		private static TriggerDeliver _instance;
		private TriggerDeliver(){
			}
		public static TriggerDeliver getInstance(){
			if(_instance==null){
			_instance=GameObject.Find("TriggerDeliver").GetComponent<TriggerDeliver>();
			}
			return _instance;
		}
		
		
}

