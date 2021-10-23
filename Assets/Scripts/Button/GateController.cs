using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private Transform[] locationsDoorLeft;
    [SerializeField] private Transform[] locationsDoorRight;
    [SerializeField] private float time;

    [SerializeField] private int state = 0;

    public void FlipState()
    {
        LeanTween.move(leftDoor, locationsDoorLeft[state].position, time * Time.deltaTime / 10f);
        LeanTween.move(rightDoor, locationsDoorRight[state].position, time * Time.deltaTime / 10f);
        state = 1 - state;
    }
}