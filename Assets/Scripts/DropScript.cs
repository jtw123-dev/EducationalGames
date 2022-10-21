using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropScript : MonoBehaviour,IDropHandler
{
    [SerializeField] private GameObject[] _startingPoint;
    private int _score;
    [SerializeField] Text _scoreText;
    private DragScript _drag;

    private void Start()
    {
        _drag = GameObject.Find("SpaceShipImage").GetComponent<DragScript>();
    }

    public void OnDrop(PointerEventData eventData)
    {    
            eventData.pointerDrag.transform.position = transform.position;
            Debug.Log(eventData.pointerDrag);

            if (eventData.pointerDrag.name == "SpaceShipImage")
            {
            _drag.dragScore++;
            _score++;
            eventData.pointerDrag.transform.position = _startingPoint[Random.Range(0, _startingPoint.Length)].transform.position;
            }
            else if (eventData.pointerDrag.name != "SpaceShipImage")
            {
            _score--;
           
                eventData.pointerDrag.transform.position = _startingPoint[Random.Range(0, _startingPoint.Length)].transform.position;
        }
        _scoreText.text = _score.ToString();
       
    }



}
