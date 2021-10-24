using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private List<GateController> gates;
    [SerializeField] private List<MeshRenderer> wires;
    [SerializeField] private Color Activated = Color.blue;
    [SerializeField] private Color DeActivated = Color.red;
    [SerializeField] private Material wireMaterial;
    

    private Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
        foreach (MeshRenderer wire in wires)
        {
            wireMaterial.color = DeActivated;
        }
    }

    private void OnMouseDown()
    {
        OnInteract();
        buttonAnimator.Play("ButtonPress", -1, 0f);
        AudioManager.PlaySound(Sound.ButtonPress);
    }

    public void OnInteract()
    {
        foreach(GateController gate in gates)
            gate.FlipState();
        if (wires != null)
        {
            StartCoroutine(ChangeWireColor());
        }
    }

    public IEnumerator ChangeWireColor()
    {
        foreach (MeshRenderer wire in wires)
        {
            wireMaterial.color = Activated;
        }
        yield return new WaitForSeconds(1f);

    }
}
