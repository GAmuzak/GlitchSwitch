using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private List<GateController> gates;

    private Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();        
    }

    private void OnMouseDown()
    {
        OnInteract();
        buttonAnimator.Play("ButtonPress", -1, 0f);
    }

    public void OnInteract()
    {
        foreach(GateController gate in gates)
            gate.FlipState();
    }
}
