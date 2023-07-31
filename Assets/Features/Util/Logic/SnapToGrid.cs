using UnityEngine;

namespace Features.Util.Logic
{
    [ExecuteInEditMode]
    public class SnapToGrid : MonoBehaviour
    {
        [SerializeField] private float gridSize = 1; 
        void Update()
        {
            Vector3 position = transform.position;

            int columnNumber = Mathf.RoundToInt(position.x / gridSize + 0.5f);
            int rowNumber = Mathf.RoundToInt(position.z / gridSize + 0.5f);

            position = new Vector3(columnNumber * gridSize, 0f, rowNumber * gridSize);
            transform.position = position;
        }
    }
}