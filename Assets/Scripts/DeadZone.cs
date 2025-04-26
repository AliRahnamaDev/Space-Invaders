using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(2);
    }
}
