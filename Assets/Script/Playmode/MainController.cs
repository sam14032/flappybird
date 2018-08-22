using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    private static bool IsSceneLoaded(string name)
    {
        for (var i = 0; i < SceneManager.sceneCount; i++)
            if (SceneManager.GetSceneAt(i).name == name) return true;

        return false;
    }
    
    private static IEnumerator LoadGame()
    {
        if (!IsSceneLoaded(Scenes.Game))
            yield return SceneManager.LoadSceneAsync(Scenes.Game, LoadSceneMode.Additive);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes.Game));
    }

    private static IEnumerator UnloadGame()
    {
        if (IsSceneLoaded(Scenes.Game))
            yield return SceneManager.UnloadSceneAsync(Scenes.Game);
    }

    private static IEnumerator ReloadGame()
    {
        yield return UnloadGame();
        yield return LoadGame();
    }

    private void Start()
    {
        StartCoroutine(LoadGame());
    }

    public void RestartGame()
    {
        StartCoroutine(ReloadGame());
    }
}

