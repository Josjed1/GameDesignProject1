using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;

    public GameObject rottenPrefab;

    public Basket addedScore;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float changeDirChance = 0.1f;

    public float appleDropDelay = 1f;

    public float rottenDropDelay = 1f;
    
    void Start()
    {
        Invoke("DropApple", 2f);
        Invoke("DropRotten", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void DropRotten()
    {
        GameObject rottenApple = Instantiate<GameObject>(rottenPrefab);
        rottenApple.transform.position = transform.position;
        Invoke("DropRotten", rottenDropDelay);


    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Change Directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
