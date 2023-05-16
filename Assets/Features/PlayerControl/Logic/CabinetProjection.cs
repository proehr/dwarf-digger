using System;
using UnityEngine;

namespace Features.PlayerControl.Logic
{
    public class CabinetProjection : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] public float angle = 45.0f;
        [SerializeField] public float zScale = 0.5f;
        [SerializeField] public float zOffset = 0.0f;

        public float viewDistance = 1000;

        // Start is called before the first frame update
        private void Start()
        {
            camera.orthographic = true;
            var orthoHeight = camera.orthographicSize;
            var orthoWidth = camera.aspect * orthoHeight;
            var m = Matrix4x4.Ortho(-orthoWidth, orthoWidth, -orthoHeight, orthoHeight, camera.nearClipPlane,
                camera.farClipPlane);
            var s = zScale / orthoHeight;
            m[0, 2] = +s * Mathf.Sin(Mathf.Deg2Rad * -angle);
            m[1, 2] = +s * Mathf.Cos(Mathf.Deg2Rad * -angle);
            m[0, 3] = -zOffset * m[0, 2];
            m[1, 3] = -zOffset * m[1, 2];
            camera.projectionMatrix = m;

            // Apply the projection matrix to the camera
            // camera.projectionMatrix = projectionMatrix;
            // var alpha = 55.0f;
            // camera.projectionMatrix = new Matrix4x4(
            //     new Vector4(1.0f, 0.0f, (float)(-Math.Cos(alpha) / 2.0f), 0.0f),
            //     new Vector4(0.0f, 1.0f, (float)(Math.Sin(alpha) / 2.0f), 0.0f),
            //     new Vector4(0.0f, 0.0f, 0.0f, 0.0f),
            //     new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            // );
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}