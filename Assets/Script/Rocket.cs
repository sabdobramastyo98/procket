using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject panelHeader;
	private Text ScoreText;
  private Text ScoreText2;
  private Text TheLevel;
    private void Start()
    {
        panelGameOver.SetActive(false);

        ScoreText = GameManager.gm.GameplayUI.Find ("Header").Find ("ScorePlaceholder").Find ("Score").GetComponent<Text> ();
        ScoreText2 = GameManager.gm.GameplayUI.Find ("GameOver").Find ("Panel").Find ("Score").GetComponent<Text> ();
        TheLevel = GameManager.gm.GameplayUI.Find ("Header").Find ("LevelPlaceholder").Find ("Level").GetComponent<Text> ();
    }

    private void Update()
    {
		ScoreText.text = Mathf.Max (0, Mathf.FloorToInt (transform.position.y)).ToString ();
    ScoreText2.text = Mathf.Max (0, Mathf.FloorToInt (transform.position.y)).ToString ();
    TheLevel.text = Mathf.Max (0, Mathf.FloorToInt (((transform.position.y)-25)/50)+1).ToString ();
    }

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Obastacle") {
			print ("GAME OVER!");
        panelGameOver.SetActive(true);
        panelHeader.SetActive(false);
        Time.timeScale=0;

		}
		else if (other.tag == "LevelEnd") {
			other.tag = "Untagged";
			GameManager.gm.lm.SpawnLevel ();
		}
	}

}
