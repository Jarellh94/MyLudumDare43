using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldPosition : MonoBehaviour {

    public Canvas canvas;

    public Transform targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = WorldToUISpace(canvas, targetPos.position);
	}

    public Vector3 WorldToUISpace(Canvas myCanvas, Vector3 worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, screenPos, myCanvas.worldCamera, out movePos);

        return myCanvas.transform.TransformPoint(movePos);
    }
}
