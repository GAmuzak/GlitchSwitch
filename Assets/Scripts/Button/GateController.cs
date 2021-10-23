using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private Transform[] locations;
    [SerializeField] private float time;

    [SerializeField] private int state = 0;

    public void FlipState()
    {
        LeanTween.move(gameObject, locations[state].position, time * Time.deltaTime / 10f);
        state = 1 - state;
    }
}