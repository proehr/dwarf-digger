using System;
using UnityEngine;

namespace Features.PlayerControl.Logic
{
    
    public class CabinetProjection : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        // Start is called before the first frame update
        void Start()
        {
            var alpha = 55.0f;
            camera.projectionMatrix = new Matrix4x4(
                new Vector4(1.0f, 0.0f, (float)(-Math.Cos(alpha) / 2.0f), 0.0f), 
                new Vector4(0.0f, 1.0f, (float)(Math.Sin(alpha) / 2.0f), 0.0f), 
                new Vector4(0.0f, 0.0f, 0.0f, 0.0f), 
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
