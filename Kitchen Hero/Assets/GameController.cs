using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public GameObject scoreListPanel;
	public GameObject[] QuestionPanel;
	public GameObject[] OptionsPanel;
	public GameObject[] BlinkBars;
	public GameObject ResultPanel;
	public GameObject[] Ticks;
	public GameObject ExitPanel;


	public int[] Answers;
	public int[] QuestionVisited;
	public int[] TotalPoints;

	public UnityEngine.UI.Text ResultText;
	public UnityEngine.UI.Text ScoreText;
	public UnityEngine.UI.Text resultPanel_NextBtn_text;
	public UnityEngine.UI.Text TimeText;


	int RandomQuestionNumber;
	int LevelNumber;
	int score;
	bool GameOver;
	int startTime;
	int timeLeft;


	void Start () {
		startTime = 999;

	}
	
	// Update is called once per frame
	void Update () {
		timeLeft = Mathf.CeilToInt(45-(Time.time - startTime));
		if (timeLeft <= 0) {
			GameOver = true;
			ResultPanel.gameObject.SetActive (true);
			resultPanel_NextBtn_text.text = "New Game";
			ResultText.text = "Oops!! Out of time, Final Score: " + TotalPoints [LevelNumber] + " points.";
		}
		TimeText.text = timeLeft.ToString ()+" Sec";



		if (Input.GetKeyDown (KeyCode.Escape)) {
			ExitPanel.gameObject.SetActive (true);
		}
	}

	public void StartClicked()
	{
		scoreListPanel.gameObject.SetActive (false);
		RandomQuestionNumber = Random.Range (0, 25);

		while(QuestionVisited[RandomQuestionNumber]!=0){
			RandomQuestionNumber = Random.Range (0, 25);
		}
		for (int i = 0; i < QuestionPanel.Length; i++) {
			QuestionPanel [i].gameObject.SetActive (false);
			OptionsPanel [i].gameObject.SetActive (false);
		}
		QuestionPanel [RandomQuestionNumber].gameObject.SetActive (true);
		OptionsPanel [RandomQuestionNumber].gameObject.SetActive (true);
		QuestionVisited [RandomQuestionNumber] = 1;
		startTime = Mathf.CeilToInt(Time.time);
		//var temp = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		//Debug.Log (temp);
		//Debug.Log (RandomQuestionNumber);

	}

	public void CheckAnswer()
	{
		var temp = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		startTime = 999;
		ResultPanel.gameObject.SetActive (true);
		if (temp == "Correct") {
			Debug.Log ("Correct Answer");
			LevelNumber++;
			ResultText.text = "Congrats, Your score is: " + TotalPoints [LevelNumber] + " points";
			if (LevelNumber == 15) {
				resultPanel_NextBtn_text.text = "New Game";
				ResultText.text = "Awesome, you have a total of: " + TotalPoints [LevelNumber] + "points";
				GameOver = true;
			}
		} else {
			Debug.Log ("WrongAnswer");
			GameOver = true;
			resultPanel_NextBtn_text.text = "New Game";
			ResultText.text = "Final Score: " + TotalPoints [LevelNumber] + " points";
		}
	}


	public void nextClickedAfterResult()
	{
		if (!GameOver) {
			ResultPanel.gameObject.SetActive (false);
			startTime = 999;
			scoreListPanel.gameObject.SetActive (true);
			for (int i = 0; i < BlinkBars.Length; i++) {
				BlinkBars [i].gameObject.SetActive (false);
			}
			BlinkBars [LevelNumber].gameObject.SetActive (true);
			Ticks [LevelNumber - 1].gameObject.SetActive (true);
			ScoreText.text = "Next Level :" + TotalPoints [LevelNumber + 1] + " P0ints";
		} else {
			Application.LoadLevel (0);
		}
	}

	public void GotoMenu()
	{
		Application.LoadLevel (0);
	}

	public void quitgame()
	{
		Application.Quit ();
	}




}
