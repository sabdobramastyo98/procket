using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	public int currentLevel;
	public float levelSizeY;
	private Vector2 nextLevelPos;

	public GameObject [] levelPrefabs;
	private GameObject newLevel;
	private GameObject curLevel;
	private GameObject oldLevel;

	private void Start () {
		nextLevelPos = new Vector2 (nextLevelPos.x, nextLevelPos.y + levelSizeY);
		SpawnLevel ();
	}
	
	public void SpawnLevel () {
		currentLevel++;

		Destroy (oldLevel);
		if (currentLevel == 2) { oldLevel = GameObject.Find ("Level_Start"); }
		else { oldLevel = curLevel; }
		SetOrderLayer (oldLevel, "OldLevel");

		curLevel = newLevel;
		SetOrderLayer (newLevel, "CurrentLevel");

		int randomLvl = Random.Range (0, levelPrefabs.Length);
		newLevel = Instantiate (levelPrefabs [randomLvl], nextLevelPos, Quaternion.identity);
		SetOrderLayer (newLevel, "NewLevel");

		nextLevelPos = new Vector2 (nextLevelPos.x, nextLevelPos.y + levelSizeY);
	}

	private void SetOrderLayer (GameObject parentObject, string sortingLayerName) {
		if (parentObject) {
			for (int child = 0; child < parentObject.transform.childCount; child++) {
				if (parentObject.transform.GetChild (child).GetComponent<SpriteRenderer> ()) {
					parentObject.transform.GetChild (child).GetComponent<SpriteRenderer> ().sortingLayerName = sortingLayerName;
				}

				for (int subChild = 0; subChild < parentObject.transform.GetChild (child).childCount; subChild++) {
					if (parentObject.transform.GetChild (child).GetChild(subChild).GetComponent<SpriteRenderer> ()) {
						parentObject.transform.GetChild (child).GetChild (subChild).GetComponent<SpriteRenderer> ().sortingLayerName = sortingLayerName;
					}

					for (int subSubChild = 0; subSubChild < parentObject.transform.GetChild (child).GetChild (subChild).childCount; subSubChild++) {
						if (parentObject.transform.GetChild (child).GetChild (subChild).GetChild (subSubChild).GetComponent<SpriteRenderer> ()) {
							parentObject.transform.GetChild (child).GetChild (subChild).GetChild (subSubChild).GetComponent<SpriteRenderer> ().sortingLayerName = sortingLayerName;
						}
					}
				}
			}
		}
	}
}
