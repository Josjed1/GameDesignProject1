using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public ApplePicker missedApple;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Current Screen Position of Mouse
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            Debug.Log("Good apple collected. Current score: " + scoreCounter.score);
        }
        if (collidedWith.CompareTag("Rotten"))
        {
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            if (apScript != null)
            {
                apScript.AppleMissed(); // Only call this for rotten apples
                Debug.Log("Rotten apple missed. Basket will be removed.");
            }

            Destroy(collidedWith);
        }
    }

}   
