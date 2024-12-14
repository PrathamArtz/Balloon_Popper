using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.1f;

    private UiManager uiManager;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UiManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void speed()
    {
        _speed = 0.1f;
    }
    private void Update()
    {
        transform.Translate(0, _speed, 0 * Time.deltaTime);
        CheckOutOfBounds();
        DeleteBubble();
    }

    private void OnMouseDown()
    {
        audioSource.Play();
        uiManager.scoreCount++;
        uiManager.score.text = uiManager.scoreCount.ToString();
        animator.SetTrigger("Blue_Pop");
        animator.SetTrigger("Green_Pop");
        animator.SetTrigger("Orange_Pop");
        animator.SetTrigger("Pink_Pop");
        animator.SetTrigger("Purple_Pop");
        animator.SetTrigger("Red_Pop");
        animator.SetTrigger("Yellow_Pop");
        Destroy(gameObject, 0.5f);
    }

    private void DeleteBubble()
    {
        if (transform.position.y > 16)
        {
            Destroy(gameObject);
        }
    }


    private void CheckOutOfBounds()
    {
        if (transform.position.y > 15)
        {
            // Increment bubbles out of bounds
            uiManager.bubblesOutOfBounds++;
            Destroy(gameObject); // Destroy this bubble
            uiManager.Life.text = "Life: 5/"+ uiManager.bubblesOutOfBounds.ToString();

            // Check if game over condition is met
            if (uiManager.bubblesOutOfBounds >= 5)
            {
                SceneManager.LoadScene(2);
                Time.timeScale = 0; // Stop the game
                Debug.Log("Game Over: Too many bubbles escaped!");
            }
        }
    }
}
