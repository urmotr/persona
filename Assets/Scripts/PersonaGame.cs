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
    public GameObject goal;
    public GameObject interest;
    public GameObject painPoint;
    public GameObject Motivation;

    public void ChangeScene(string target)
    {
        SceneManager.LoadScene(target);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        position = transform.position;
        Debug.Log("OnBeginDrag: " + position);
    }

    public void OnDrag(PointerEventData data)
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

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log("OnEndDrag: " + position);
        goal.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }

}
