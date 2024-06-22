using TMPro;  
using UnityEngine;  
  
public class Score : MonoBehaviour  
{  
    private int score = 0;  
    public TextMeshProUGUI scoreText;  
  

    private AudioSource fruitSound;  
    private AudioSource scoreFruitSound;  
  
    void Start()  
    {  
        // 在Start方法中查找并获取AudioSource组件  
        GameObject scoreAudioGameObject = GameObject.Find("scoreaudio");  
        if (scoreAudioGameObject != null)  
        {  
            AudioSource[] audioSources = scoreAudioGameObject.GetComponents<AudioSource>();  
            if (audioSources.Length >= 2)  
            {  
                fruitSound = audioSources[0]; // 假设第一个AudioSource是水果音效  
                scoreFruitSound = audioSources[1]; // 假设第二个AudioSource是得分水果音效  
            }  
            else  
            {  
                Debug.LogError("Not enough AudioSources found on 'scoreaudio' GameObject.");  
            }  
        }  
        else  
        {  
            Debug.LogError("'scoreaudio' GameObject not found.");  
        }  
    }  
  
    private void OnTriggerEnter(Collider other)  
    {  
        if (other.CompareTag("Fruit"))  
        {  
            score++;  
            PlaySound(fruitSound);  
            UpdateScoreText();  
            Destroy(other.gameObject);  
        }  
        else if (other.CompareTag("ScoreFruit"))  
        {  
            score += 2;  
            PlaySound(scoreFruitSound);  
            UpdateScoreText();  
            Destroy(other.gameObject);  
        }  
    }  
  
    private void PlaySound(AudioSource audioSource)  
    {  
        if (audioSource != null && !audioSource.isPlaying)  
        {  
            audioSource.Play();  
        }  
    }  
  
    private void UpdateScoreText()  
    {  
        scoreText.text = "Score: " + score;  
    }  
}