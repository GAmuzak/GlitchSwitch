using UnityEngine;

public class TriggerObjects : MonoBehaviour
{
    [SerializeField] private Transform newPosition;
    [SerializeField] private float time;

    public void PerformAction()
    {
        LeanTween.move(gameObject, newPosition.position, time * Time.deltaTime / 10f);
    }
}