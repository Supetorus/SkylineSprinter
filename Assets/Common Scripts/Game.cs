using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Singleton<Game>
{
	enum State
	{
		TITLE,
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER
	}

	[SerializeField] ScreenFade screenFade;
	[SerializeField] SceneLoader sceneLoader;
	public GameData gameData;

	State state = State.TITLE;

	int highScore;

	private void Start()
	{
		highScore = PlayerPrefs.GetInt("highscore", 0);

		InitScene();

		SceneManager.activeSceneChanged += OnSceneWasLoaded;
	}
	void InitScene()
	{
		SceneDescriptor sceneDescriptor = FindObjectOfType<SceneDescriptor>();
		if (sceneDescriptor != null) Instantiate(sceneDescriptor.player, sceneDescriptor.playerSpawn.position, sceneDescriptor.playerSpawn.rotation);
	}

	internal void PlayerStart()
	{
		state = State.PLAYER_START;
	}

	internal void StartGame()
	{
		state = State.GAME;
	}

	private void Update()
	{
		switch (state)
		{
			case State.TITLE:
				break;
			case State.PLAYER_START:
				gameData.intData["Multiplier"] = 0;
				state = State.GAME;
				break;
			case State.GAME:
				gameData.floatData["Score"] += Time.deltaTime * gameData.intData["Multiplier"];
				break;
			case State.PLAYER_DEAD:
				break;
			case State.GAME_OVER:
				break;
			default:
				break;
		}
	}

	public void OnLoadScene(string sceneName)
	{
		sceneLoader.Load(sceneName);
	}

	internal void AddMultiplier(int increase)
	{
		gameData.intData["Multiplier"] += increase;
	}


	private void OnSceneWasLoaded(Scene current, Scene next)
	{
		InitScene();
	}


	public void OnPlayerDead()
	{
		//gameData.intData["Lives"]--;
		//gameData.intData["Lives"] = 3;

		if (gameData.intData["Score"] > highScore) PlayerPrefs.SetInt("highscore", highScore);

		OnLoadScene("MainMenu");

		//if (gameData.intData["Lives"] == 0)
		//{
		//}
		//else
		//{
		//	OnLoadScene(SceneManager.GetActiveScene().name);
		//}
	}
}
