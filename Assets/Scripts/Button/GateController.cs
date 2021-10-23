using System;
using System.Collections;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private Transform[] locationsDoorLeft;
    [SerializeField] private Transform[] locationsDoorRight;
    [SerializeField] private float time;
    [Range(0,1)]
    [SerializeField] private int state = 0;
    [SerializeField] private LeanTweenType leanTweenType;

    private bool canFlip=true;

    public void FlipState()
    {
        if (!canFlip) return;
        LeanTween.move(leftDoor, locationsDoorLeft[state].position, time * Time.deltaTime / 10f).setEase(leanTweenType);
        LeanTween.move(rightDoor, locationsDoorRight[state].position, time * Time.deltaTime / 10f).setEase(leanTweenType);
        state = 1 - state;
        canFlip = false;
        StartCoroutine(DoorStateFlipCooldown());
    }

    private IEnumerator DoorStateFlipCooldown()
    {
        yield return new WaitForSeconds(time * Time.deltaTime / 10f);
        canFlip = true;
    }
}