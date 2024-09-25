using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject basketPrefab;

    public ButtonReset buttonReset;

    public StartButton buttonStart;

    public Round roundCounter;

    public int rounds;

    public int numBaskets = 3;

    public float basketBottomY = -14f;

    public float basketSpacingY = 2f;

    public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
        buttonStart.ShowStartButton();

        basketList = new List<GameObject>();

        rounds = numBaskets;

        for (int i=0; i < numBaskets; i++)
            {
                GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
                Vector3 pos = Vector3.zero;
                pos.y = basketBottomY + (basketSpacingY * i);
                tBasketGO.transform.position = pos;
                basketList.Add(tBasketGO);
            }
    }
    

    public void AppleMissed()
    {
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        int basketIndex = basketList.Count -1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);


        if (basketList.Count == 0)
        {
            //SceneManager.LoadScene("_Scene_0");

            //Time.timeScale = 0;
            buttonReset.ShowResetButton();  
        }

        foreach(GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }
        roundNeedsUpdate();

    }

    void roundNeedsUpdate()
    {
        roundCounter.UpdateRound(roundCounter.round + 1); // Update round through the method

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
