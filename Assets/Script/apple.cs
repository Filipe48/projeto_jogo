using UnityEngine;

public class apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    
    public GameObject Collected; 
    public int Score = 1;       
    
    private bool collected = false; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        if (Collected != null)
        {
            Collected.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !collected)
        {
            collected = true; 

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(Score);
            }


            if(sr != null) sr.enabled = false;
            if(circle != null) circle.enabled = false;

            if (Collected != null)
            {
                Collected.SetActive(true);
            }

            Destroy(gameObject, 0.25f);
        }
    }
}