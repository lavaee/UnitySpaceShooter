using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public bool LoadOnStart;
    public string StartUpLevel;
    public Slider LoadingSlider;
    public int WaitTime;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        if (LoadOnStart)
        {
            StartCoroutine(LoadLevelAsync(StartUpLevel));
        }
    }

    public void LoadLevel(string _levelName)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadLevelAsync(_levelName));
    }

    IEnumerator LoadLevelAsync(string _levelName)
    {
        yield return new WaitForSeconds(WaitTime);

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(_levelName);
        LoadingSlider.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);

        while (!loadingOperation.isDone)
        {
            LoadingSlider.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }
    }
}
