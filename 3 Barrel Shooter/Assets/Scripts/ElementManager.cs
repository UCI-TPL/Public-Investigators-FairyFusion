﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager
{
    //declare ElementManager variables
    private ElementInfo[] elements;

    public void initElementManager(){
        //assign ElementManager variables
        elements = new ElementInfo[6];

        //declare temp loading variables
        int tID;
        float tDamage;
        float tFireRate;
        float tRange;
        int tCapacity;
        char tAmountType;



        //LOAD INFORMATION FROM RESOURCES "elements.txt"
        string elementPath = "elements";
        //Debug.Log("Loading " + elementPath);
        TextAsset elementFile = Resources.Load(elementPath) as TextAsset;
        string[] wordList = elementFile.text.Split(new char[] { '\n', '\r' });
        foreach (string s in wordList)
        {
            if (s[0] != '#')
            {
                //Assign values to temp loading variables
                string[] lineList = s.Split(';');
                tID = int.Parse(lineList[0]);
                tDamage = float.Parse(lineList[1]);
                tFireRate = float.Parse(lineList[2]);
                tRange = float.Parse(lineList[3]);
                tCapacity = int.Parse(lineList[4]);
                tAmountType = lineList[5][0];


                elements[tID - 1] = new ElementInfo(tID, tDamage, tFireRate, tRange, tCapacity, tAmountType);
                //elements[tID-1].debugElement();
            }
        }
    }

    //Gets the capacity of an element given its ID
    public int GetCapacityByID(int id)
    {
        return elements[id - 1].GetCapacity();
    }

    public ElementInfo GetElementByID(int id){
        return elements[id - 1];
    }

    public float GetDamageByID(int id){
        return elements[id - 1].GetDamage();
    }
}