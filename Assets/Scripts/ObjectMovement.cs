using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ObjectMovement : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Transform objectTransform;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectTransform = transform;
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        StartCoroutine(TrackObject(args.interactorObject.transform));
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        StopAllCoroutines();
    }

    private IEnumerator TrackObject(Transform interactorTransform)
    {
        while (interactorTransform != null)
        {
            objectTransform.position = interactorTransform.position;
            yield return null;
        }
    }
}
