using System.Collections;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
using TMPro;  
  
public class Health : MonoBehaviour  
{  
    private int health = 3;  
    [SerializeField] private TextMeshProUGUI HealthText;  
    [SerializeField] private GameObject LooserScreen;  
    private AudioSource bombAudioSource; 
    private AudioSource endAudioSource;  
    private float restartDelay = 5f;  
  
    void Start()  
    {  
        GameObject boomaudioGameObject = GameObject.Find("boomaudio");  
        AudioSource[] audioSources = boomaudioGameObject.GetComponents<AudioSource>();
        bombAudioSource = audioSources[0];
        endAudioSource = audioSources[1];
    }  
  
    private void OnTriggerEnter(Collider other)  
    {  
        if (other.CompareTag("Bomb"))  
        {  
            if (bombAudioSource != null)  
            {  
                bombAudioSource.Play();
            }  
  
            health--;  
            HealthText.text = "Health: " + health;  
  
            if (health <= 0)  
            {  
                LooserScreen.SetActive(true);  
                if(endAudioSource != null)  
                {  
                    endAudioSource.Play();  
                }
                Time.timeScale = 0;  
                StartCoroutine(RestartGameAfterDelay(restartDelay));  
            }   
            Destroy(other.gameObject);  
        }  
    }  
  
    private IEnumerator RestartGameAfterDelay(float delay)  
    {  
        yield return new WaitForSecondsRealtime(delay);  
        Time.timeScale = 1;  
        SceneManager.LoadScene("MainMenu");  
    }  
}