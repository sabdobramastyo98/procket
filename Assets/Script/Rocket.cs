using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
	private Text ScoreText;
    // Start is called before the first frame update
    private void Start()
    {
        ScoreText = GameManager.gm.GameplayUI.Find ("Header").Find ("ScorePlaceholder").Find ("Score").GetComponent<Text> ();
    }

    // Update is called once per frame
    private void Update()
    {
		ScoreText.text = Mathf.Max (0, Mathf.FloorToInt (transform.position.y)).ToString ();
        
    }

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Obastacle") {
			print ("GAME OVER!");
			SceneManager.LoadScene ("Gameplay");
		}
	}

}
