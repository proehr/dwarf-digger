using Common.Logic.Variables;
using UnityEngine;

namespace Features.Digging.Logic
{
    public class DiggingTool : MonoBehaviour
    {
        [SerializeField] private BoolVariable isDigging;

        private void OnTriggerEnter(Collider other)
        {
            if (isDigging.Get() && other.CompareTag("Diggable"))
            {
                isDigging.Set(false);
                DiggableObject diggableObject = other.GetComponent<DiggableObject>();
                diggableObject.OnHit(other.ClosestPointOnBounds(transform.position), transform.rotation);
            }
        }
    }
}