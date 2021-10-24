using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private List<GateController> gates;
    [SerializeField] private MeshRenderer wire;
    [SerializeField] private Material Activated;
    [SerializeField] private Material DeActivated;
    

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
        if (wire != null)
        {
            wire.material = Activated;
        }
    }
}
