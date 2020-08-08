using UnityEngine;

namespace Sweet_And_Salty_Studios.Inputs
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private BallEngine ballEngine = default;
        [SerializeField] private LineRenderer lineRenderer = default;
        [SerializeField] private Camera mainCamera = default;

        private Vector2 pointerStartDragPosition = default;
        private Vector2 pointerEndDragPosition = default;

        private float dragDistance = default;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                pointerStartDragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                lineRenderer.SetPosition(0, new Vector3(pointerStartDragPosition.x, 0, pointerStartDragPosition.y));
            }

            if(Input.GetMouseButton(0))
            {
                pointerEndDragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                dragDistance = (pointerEndDragPosition - pointerStartDragPosition).magnitude;

                lineRenderer.SetPosition(1, new Vector3(pointerEndDragPosition.x, 0, pointerEndDragPosition.y));
            }

            if(Input.GetMouseButtonUp(0))
            {
                if(ballEngine != null)
                {
                    ballEngine.Shoot(dragDistance);
                }

                pointerStartDragPosition = default;
                pointerEndDragPosition = default;
            }
        }
    }
}
