using System;
using UnityEngine;

namespace GD.Selection
{
    [CreateAssetMenu(fileName = "AudioSelectionResponseSO", menuName = "Responses/Audio")]
    [Serializable]
    public class AudioSelectionResponseSO : ScriptableGameObject, ISelectionResponse
    {
        [SerializeField]
        private AudioClip selectedAudioClip;

        private Transform currentTransform = null;

        public void OnDeselect(Transform transform)
        {
        }

        public void OnSelect(Transform transform)
        {
            if (currentTransform != null && currentTransform != transform)
                AudioSource.PlayClipAtPoint(selectedAudioClip, transform.position);
            currentTransform = transform;
        }
    }
}