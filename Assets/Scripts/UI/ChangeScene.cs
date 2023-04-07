using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChangeToAdditiveScene(string scene)
    {
        SceneManager.LoadScene(scene,LoadSceneMode.Additive);
    }

    public void UnloadAdditiveScene(string sceneActuelle)
    {
        SceneManager.UnloadSceneAsync(sceneActuelle);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
