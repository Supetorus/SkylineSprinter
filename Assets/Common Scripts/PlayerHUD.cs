using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] Slider multiplierUI;
	//[SerializeField] TMP_Text livesUI;
	//[SerializeField] TMP_Text timeUI;
	//[SerializeField] Slider healthUI;
	[SerializeField] GameData gameData;

	public int Score { set { if (scoreUI == null) return; scoreUI.text = value.ToString("D6"); } }
	public int Multiplier { set { if (multiplierUI == null) return; multiplierUI.value = value; } }

	//public int lives { set { if (livesUI == null) return; livesUI.text = value.ToString(); } }
	//public float time { set { if (timeUI == null) return; timeUI.text = "<mspace=mspace=36>" + value.ToString("0.0") + "</mspace>"; } }
	//public float health { set { if (healthUI == null) return; healthUI.value = value; } }

	private void Update()
	{
		//float healthValue = 0;
		//gameData.Load("Health", ref healthValue);
		//health = healthValue;

		float scoreValue = 0;
		gameData.Load("Score", ref scoreValue);
		Score = Mathf.FloorToInt(scoreValue);

		int multiplierValue = 0;
		gameData.Load("Multiplier", ref multiplierValue);
		Multiplier = multiplierValue;

		//int livesValue = 0;
		//gameData.Load("Lives", ref livesValue);
		//lives = livesValue;
	}
}
