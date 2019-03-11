﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    // Stage 0 = controls screen
    // Stage 1 = 
    private int stage = 0;

    UIManager uiManager;
    GameObject tutorialPlayer;
    TutorialPlayerController tutorialPC;

    GameObject controlsUI;
    GameObject sticksUI1;
    GameObject sticksUI2;
    GameObject bumpersUI1;
    GameObject triggersUI1;
    GameObject bumpersUI2;
    GameObject triggersUI2;
    GameObject playerUI;

    private bool A_Button;
    private bool B_Button;

    private float RS_Horizontal;
    private float RS_Vertical;
    private float LS_Horizontal;
    private float LS_Vertical;

    private bool RS_Click;

    private bool startedCoroutine = false;

    private bool LB = false;
    private bool LT = false;

    private bool RB = false;
    private bool RT = false;


    public void InitTutorialMenu(UIManager uim, LevelManager lm)
    {
        uiManager = uim;
        tutorialPlayer = Instantiate(Resources.Load<GameObject>("Player/TutorialPlayer"));
        tutorialPC = tutorialPlayer.GetComponent<TutorialPlayerController>();
        tutorialPC.InitTutorialController();
        controlsUI = transform.GetChild(0).gameObject;
        sticksUI1 = transform.GetChild(1).gameObject;
        sticksUI2 = transform.GetChild(2).gameObject;
        bumpersUI1 = transform.GetChild(3).gameObject;
        triggersUI1 = transform.GetChild(4).gameObject;
        bumpersUI2 = transform.GetChild(5).gameObject;
        triggersUI2 = transform.GetChild(6).gameObject;
        playerUI = transform.GetChild(7).gameObject;
    }


    public void HandleInput(ControllerInputs c)
    {
        // Get controls; check stage; call function

        A_Button = c.A_Button;
        B_Button = c.B_Button;

        RS_Horizontal = c.Right_Stick_Horizontal;
        RS_Vertical = c.Right_Stick_Vertical;
        LS_Horizontal = c.Left_Stick_Horizontal;
        LS_Vertical = c.Left_Stick_Vertical;

        RS_Click = c.Right_Stick_Click;

        LB = c.Left_Bumper;
        LT = c.Left_Trigger > 0;

        RB = c.Right_Bumper;
        RT = c.Right_Trigger > 0;

        switch(stage)
        {
            case 0:
                ControlStage(A_Button, B_Button);
                return;
            case 1:
                tutorialPC.HandleStage(1, LS_Horizontal, LS_Vertical, RS_Horizontal, RS_Vertical, false, false, false, false, false);
                if (controlsUI.activeSelf)
                {
                    controlsUI.SetActive(false);
                    sticksUI1.SetActive(true);
                }

                if (tutorialPC.hasAimed && tutorialPC.hasMoved && !startedCoroutine)
                {
                    StartCoroutine("SetStage", 2);
                }
                break;
            case 2:
                tutorialPC.HandleStage(2, LS_Horizontal, LS_Vertical, RS_Horizontal, RS_Vertical, RS_Click, false, false, false, false);
                if (sticksUI1.activeSelf)
                {
                    sticksUI1.SetActive(false);
                    sticksUI2.SetActive(true);
                }

                if (tutorialPC.hasDashed && !startedCoroutine) StartCoroutine("SetStage", 3);
                break;
            case 3:
                tutorialPC.HandleStage(3, LS_Horizontal, LS_Vertical, RS_Horizontal, RS_Vertical, RS_Click, LB, false, false, false);
                if (sticksUI2.activeSelf)
                {
                    sticksUI2.SetActive(false);
                    bumpersUI1.SetActive(true);
                }

                if (tutorialPC.hasHarnessedLeft && !startedCoroutine) StartCoroutine("SetStage", 4);
                break;
            case 4:
                tutorialPC.HandleStage(4, LS_Horizontal, LS_Vertical, RS_Horizontal, RS_Vertical, RS_Click, LB, LT, false, false);
                if (bumpersUI1.activeSelf)
                {
                    bumpersUI1.SetActive(false);
                    triggersUI1.SetActive(true);
                }

                if (tutorialPC.hasCastedLeft && !startedCoroutine) StartCoroutine("SetStage", 5);
                break;
            case 5:
                tutorialPC.HandleStage(5, LS_Horizontal, LS_Vertical, RS_Horizontal, RS_Vertical, RS_Click, LB, LT, RB, false);
                if (triggersUI1.activeSelf)
                {
                    triggersUI1.SetActive(false);
                    bumpersUI2.SetActive(true);
                }

                if (tutorialPC.hasHarnessedRight && !startedCoroutine) StartCoroutine("SetStage", 6);
                break;
            case 6:
                tutorialPC.HandleStage(6, LS_Horizontal, LS_Vertical, RS_Horizontal, RS_Vertical, RS_Click, LB, LT, RB, RT);
                if (bumpersUI2.activeSelf)
                {
                    bumpersUI2.SetActive(false);
                    triggersUI2.SetActive(true);
                }

                if (tutorialPC.hasCastedCombo && !startedCoroutine) StartCoroutine("SetStage", 7);
                break;
            case 7:
                if (triggersUI2.activeSelf)
                {
                    triggersUI2.SetActive(false);
                    playerUI.SetActive(true);
                }
                break;
        }
    }

    public void ControlStage(bool a, bool b)
    {
        if (b)
        {
            uiManager.ToMainMenu();
            return;
        }
        else if (a)
        {
            stage = 1;
        }
    }


    public void ResetTutorialMenu()
    {
        stage = 0;
        controlsUI.SetActive(true);
        sticksUI1.SetActive(false);
        sticksUI2.SetActive(false);
        bumpersUI1.SetActive(false);
        triggersUI1.SetActive(false);
    }

    private IEnumerator SetStage(int i)
    {
        startedCoroutine = true;
        yield return new WaitForSeconds(0.5f);
        stage = i;
        startedCoroutine = false;
    }
}
