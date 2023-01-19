using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBehaviour : MonoBehaviour
{
    public GameObject LoadingScreen;

    private int ID;

    public void LoadScene(int sceneID)
    {
        SoundManager.Instance.StopSounds();
        SoundManager.Instance.PlayeSound("Loading", true);
        ID = sceneID;
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync());      
    }

    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation loadingoperation = SceneManager.LoadSceneAsync(ID);

        while (!loadingoperation.isDone)
        {
            SoundManager.Instance.StopSounds();
            yield return null;
        }

    }
}
