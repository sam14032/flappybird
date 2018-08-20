using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadGame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private static bool IsSceneLoaded(string name)
    {
        for (var i = 0; i < SceneManager.sceneCount; i++)
            if (SceneManager.GetSceneAt(i).name == name) return true;

        return false;
    }

    private static void LoadGame()
    {
        if (!IsSceneLoaded(Scenes.Game))
        {
            SceneManager.LoadSceneAsync(Scenes.Game, LoadSceneMode.Additive);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes.Game));
    }
}
