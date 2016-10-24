using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	Text textObj;
	public string[] dialogueList;
	int d= 0;
	float timer = 0.0f;
	// Use this for initialization
	void Start () {
		textObj = GetComponent<Text> ();
		textObj.text = dialogueList [d];
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 3.0f) {
			d++;
			timer = 0.0f;
			if (d >= dialogueList.Length) {
				d = 0;
			}
			textObj.text = dialogueList [d];
		}
	
	}
}
