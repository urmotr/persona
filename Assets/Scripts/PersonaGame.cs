using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PersonaGame : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 position;
    private float timeCount = 0.0f;
    bool calculated = false;
    public GameObject goal;
    public GameObject interest;
    public GameObject painPoint;
    public GameObject Motivation;
    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;
    public GameObject answer4;
    public GameObject answer5;
    public GameObject answer6;
    private float[] goalLoc;
    private float[] interestLoc;
    private float[] painPointLoc;
    private float[] MotivationLoc;
    private Vector2[] hiddenAnswersPosition;
    private Vector2[] answersPositions;
    private bool[] correctAnswers;
    public Canvas canvas;
    static bool interviewed = false;
    static bool isPersonaPage = false;
    static bool correctAnswer1 = false;
    static bool correctAnswer2 = false;
    static bool correctAnswer3 = false;
    static bool correctAnswer4 = false;

    void Start()
    {
        if(isPersonaPage)
        {
            UpdateAnsersPositions();
        }
        if (calculated)
        {

        }
    }

    public void ChangeScene(string target)
    {
        SceneManager.LoadScene(target);
    }

    public void SetInterviewStarted()
    {
        interviewed = true;
        isPersonaPage = false;
    }

    public void setPersonaPage()
    {
        isPersonaPage = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData data)
    {
        if (transform.name != "Canvas")
        {
            int nr = transform.name[6] - '1';
            if(!correctAnswers[nr] && interviewed)
            {
                if (data.dragging)
                {
                    // Object is being dragged.
                    timeCount += Time.deltaTime;
                    if (timeCount > 0.25f)
                    {
                        timeCount = 0.0f;
                    }
                }
                transform.position = Input.mousePosition;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.name != "Canvas")
        {
            Vector2 mouse = Input.mousePosition;
            if (transform.name == "Answer5" && interviewed && goalLoc[0] < mouse.x && goalLoc[2] < mouse.y && goalLoc[1] > mouse.x && goalLoc[3] > mouse.y)
            {
                goal.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                transform.position = hiddenAnswersPosition[0];
                correctAnswers[4] = true;
                correctAnswer1 = true;
            }
            else if (transform.name == "Answer6" && interviewed && interestLoc[0] < mouse.x && interestLoc[2] < mouse.y && interestLoc[1] > mouse.x && interestLoc[3] > mouse.y)
            {
                interest.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                transform.position = hiddenAnswersPosition[1];
                correctAnswers[5] = true;
                correctAnswer2 = true;
            }
            else if (transform.name == "Answer4" && interviewed && painPointLoc[0] < mouse.x && painPointLoc[2] < mouse.y && painPointLoc[1] > mouse.x && painPointLoc[3] > mouse.y)
            {
                painPoint.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                transform.position = hiddenAnswersPosition[2];
                correctAnswers[3] = true;
                correctAnswer3 = true;
            }
            else if (transform.name == "Answer1" && interviewed && MotivationLoc[0] < mouse.x && MotivationLoc[2] < mouse.y && MotivationLoc[1] > mouse.x && MotivationLoc[3] > mouse.y)
            {
                Motivation.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                transform.position = hiddenAnswersPosition[3];
                correctAnswers[0] = true;
                correctAnswer4 = true;
            } else
            {
                int nr = transform.name[6] - '1';
                Debug.Log(correctAnswers[nr]);
                if (!correctAnswers[nr] && interviewed)
                {
                    transform.position = answersPositions[nr];

                }
            }
        }
    }

    private void UpdateAnsersPositions()
    {
        if (!calculated)
        {
            Vector2 position = goal.GetComponent<RectTransform>().position;
            Vector2 size = goal.GetComponent<RectTransform>().sizeDelta;
            goalLoc = new float[] { 
                position.x - (size.x / 2) * canvas.scaleFactor,
                position.x + (size.x / 2) * canvas.scaleFactor,
                position.y - (size.y / 2) * canvas.scaleFactor,
                position.y + (size.y / 2) * canvas.scaleFactor,
            };
            position = interest.GetComponent<RectTransform>().position;
            size = interest.GetComponent<RectTransform>().sizeDelta;
            interestLoc = new float[] {
                position.x - (size.x / 2) * canvas.scaleFactor,
                position.x + (size.x / 2) * canvas.scaleFactor,
                position.y - (size.y / 2) * canvas.scaleFactor,
                position.y + (size.y / 2) * canvas.scaleFactor,
            };
            position = painPoint.GetComponent<RectTransform>().position;
            size = painPoint.GetComponent<RectTransform>().sizeDelta;
            painPointLoc = new float[] {
                position.x - (size.x / 2) * canvas.scaleFactor,
                position.x + (size.x / 2) * canvas.scaleFactor,
                position.y - (size.y / 2) * canvas.scaleFactor,
                position.y + (size.y / 2) * canvas.scaleFactor,
            };
            position = Motivation.GetComponent<RectTransform>().position;
            size = Motivation.GetComponent<RectTransform>().sizeDelta;
            MotivationLoc = new float[] {
                position.x - (size.x / 2) * canvas.scaleFactor,
                position.x + (size.x / 2) * canvas.scaleFactor,
                position.y - (size.y / 2) * canvas.scaleFactor,
                position.y + (size.y / 2) * canvas.scaleFactor,
            };
            answersPositions = new Vector2[]
            {
                answer1.GetComponent<RectTransform>().position,
                answer2.GetComponent<RectTransform>().position,
                answer3.GetComponent<RectTransform>().position,
                answer4.GetComponent<RectTransform>().position,
                answer5.GetComponent<RectTransform>().position,
                answer6.GetComponent<RectTransform>().position
            };
            hiddenAnswersPosition = new Vector2[]
            {
                goal.GetComponent<RectTransform>().position,
                interest.GetComponent<RectTransform>().position,
                painPoint.GetComponent<RectTransform>().position,
                Motivation.GetComponent<RectTransform>().position,
            };
            correctAnswers = new bool[] { correctAnswer4, false, false, correctAnswer3, correctAnswer1, correctAnswer2 };
            calculated = true;
            SetAnswersPositions();
        }
    }

    private void SetAnswersPositions()
    {
        for(var i = 0; i<6; i++)
        {
            if (correctAnswers[i])
            {
                if(i == 4){
                    answer5.GetComponent<RectTransform>().position = hiddenAnswersPosition[0];
                    goal.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                } else if (i == 5){
                    answer6.GetComponent<RectTransform>().position = hiddenAnswersPosition[1];
                    interest.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                else if (i == 3){
                    answer4.GetComponent<RectTransform>().position = hiddenAnswersPosition[2];
                    painPoint.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                else if (i == 0){
                    answer1.GetComponent<RectTransform>().position = hiddenAnswersPosition[3];
                    Motivation.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
            }
        }
    }

}
