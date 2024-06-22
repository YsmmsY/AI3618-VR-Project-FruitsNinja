using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string gameSceneName = "FruitsNinja";
    private AudioSource backgroundMusicSource;
    private AudioSource buttonClickSource;

    public AudioClip buttonClickClip; // 拖入音效文件

    void Start()
    {
        // 获取AudioManager的Audio Source组件
        AudioSource[] audioSources = GameObject.Find("AudioManager").GetComponents<AudioSource>();
        backgroundMusicSource = audioSources[0];
        buttonClickSource = audioSources[1];

        if (!backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
    }

    public void StartGame()
    {
        buttonClickSource.PlayOneShot(buttonClickClip);
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(buttonClickClip.length); // 等待音效播放完毕
        backgroundMusicSource.Stop();
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        buttonClickSource.PlayOneShot(buttonClickClip);
        StartCoroutine(ExitGameWithDelay());
    }

    private IEnumerator ExitGameWithDelay()
    {
        yield return new WaitForSeconds(buttonClickClip.length); // 等待音效播放完毕
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
