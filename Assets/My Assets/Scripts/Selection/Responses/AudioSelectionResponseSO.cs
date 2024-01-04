using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSelectionResponseSO", menuName = "Responses/Audio")]
[Serializable]
public class AudioSelectionResponseSO : ScriptableGameObject, ISelectionResponse
{
    [SerializeField] private AudioClip selectedAudioClip;

    private Transform currentTransform = null;

    public void OnDeselect(Transform transform)
    {
    }

    public void OnSelect(Transform transform)
    {
        // Check if there's a previous selection and it's not the same as the current one
        if (currentTransform != null && currentTransform != transform)
            AudioSource.PlayClipAtPoint(selectedAudioClip, transform.position);
        currentTransform = transform;
    }
}