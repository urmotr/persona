using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject playerA;
    public GameObject playerB;

    static string selectedPlayer = "";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Selected: " + selectedPlayer);
        if(selectedPlayer != "") SelectCharacter(selectedPlayer);
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SelectCharacter(string character)
    {
        selectedPlayer = character;
        if (character == "PlayerA")
        {
            playerA.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            playerB.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        } else
        {
            playerA.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            playerB.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        Debug.Log(character);
    }

}
