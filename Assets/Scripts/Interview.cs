using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Interview : MonoBehaviour
{
    static string[] questions = new string[5] {
        "Are you satisfied with your romantic life?",
        "Could you describe how you get to know and contact with new people?",
        "What are your motivations and interests using a dating app?",
        "What are those features in dating app that you dislike so much?",
        "What are your wishes/desires when you meet new people on the dating app?"
        };
    static string[] answers1 = new string[5] {
        "...",
        "I like online game so I make new friends there.",
        "",
        "",
        ""
        };
    static string[] answers2 = new string[5] {
        "No",
        "I meet new people often when I go to the party.",
        "",
        "",
        ""
        };
    static string[] answers3 = new string[5] {
        "No",
        "I don't have chance to see new people so often... but I sometimes join a board game event and I can see new people there.",
        "",
        "",
        ""
        };
    static string[] answers4 = new string[5] {
        "Yes",
        "My friends often have a home party, whenever I join the party, I can see new people.",
        "",
        "",
        ""
        };
    static string[] answers5 = new string[5] {
        "Yes",
        "I don't know...I don't remember",
        "",
        "",
        ""
        };
    static int questionNr = 0;
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text answer5;
    public Button back;
    public Button next;

    // Start is called before the first frame update
    void Start()
    {
        question.text = questions[questionNr];
        answer1.text = answers1[questionNr];
        answer2.text = answers2[questionNr];
        answer3.text = answers3[questionNr];
        answer4.text = answers4[questionNr];
        answer5.text = answers5[questionNr];
        if(questionNr == 0)
        {
            back.interactable = false;
        } 
        else if (questionNr == 4)
        {
            next.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Proceed(bool status)
    {
        if (!status)
        {
            questionNr--;
        } else
        {
            questionNr++;
        }
    } 
}
