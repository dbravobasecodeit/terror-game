using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabPickup : MonoBehaviour
{
    AudioSource gameOver;

    bool isOver;

    public void Awake()
    {
        gameOver = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Pickup")
        {
            StartCoroutine(LoadTitleScene(hit.gameObject.GetComponent<AudioSource>()));
        }
        else if (hit.gameObject.tag == "ai")
        {
            if(!isOver)
            {
                isOver = true;
                StartCoroutine(LoadTitleScene());
            }
        }
    }

    IEnumerator LoadTitleScene(AudioSource audioSource)
    {
        audioSource.PlayOneShot(audioSource.clip);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Title");
    }

    IEnumerator LoadTitleScene()
    {
        gameOver.PlayOneShot(gameOver.clip);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Title");
    }
}
