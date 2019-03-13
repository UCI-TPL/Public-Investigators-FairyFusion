﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private GameObject left;
    private GameObject right;
    private float speed = 1002f;
    public bool isOpen;

    private void Start()
    {
        left = transform.GetChild(0).gameObject;
        right = transform.GetChild(1).gameObject;
        left.GetComponent<RectTransform>().localPosition = new Vector2(-760f, 0f);
        right.GetComponent<RectTransform>().localPosition = new Vector2(760f, 0f);
        isOpen = true;

        //Close();
        StartCoroutine("Close");
    }


    public IEnumerator Open()
    {
        while (!isOpen)
        {
            if (left.transform.localPosition.x >= -760) left.transform.localPosition += Vector3.left * speed * Time.deltaTime;
            if (right.transform.localPosition.x <= 760) right.transform.localPosition += Vector3.right * speed * Time.deltaTime;
            if ((int)left.transform.localPosition.x <= -760 && (int)right.transform.localPosition.x >= 760) isOpen = true;
            yield return new WaitForEndOfFrame();
        }
        isOpen = true;
    }

    public IEnumerator Close()
    {
        while (isOpen)
        {
            if ((int) left.transform.localPosition.x <= -3) left.transform.localPosition += Vector3.right * speed * Time.deltaTime;
            if ((int) right.transform.localPosition.x >= 3) right.transform.localPosition += Vector3.left * speed * Time.deltaTime;
            if ((int) left.transform.localPosition.x >= 1 && (int)right.transform.localPosition.x <= -1) isOpen = false;
            yield return new WaitForEndOfFrame();
        }
        isOpen = false;
    }
}
