using System.Collections;
using UnityEngine;

namespace Features.Digging.Logic
{
    public class DiggableObject : MonoBehaviour
    {
        [SerializeField] private DiggableObjectData diggableObjectData;

        internal void OnHit(Vector3 hitPosition, Quaternion hitRotation)
        {
            Instantiate(diggableObjectData.HitFx, hitPosition, Quaternion.Inverse(hitRotation));
            StartCoroutine(DestroyAfterTime());
        }

        private IEnumerator DestroyAfterTime()
        {
            yield return new WaitForSeconds(diggableObjectData.DestructionTimeInSeconds);
            Destroy(gameObject);
        }
    }
}