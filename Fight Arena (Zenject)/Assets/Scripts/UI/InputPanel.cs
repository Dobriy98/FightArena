using System;
using Inputs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class InputPanel: MonoBehaviour, IMouseService, IPointerDownHandler
    {
        public event Action<Vector3> OnEnvironmentRightClick;
        public event Action OnEnvironmentLeftClick;

        private Camera _mainCamera;

        private const int Rightclickkey = 1;
        private const int Leftclickkey = 0;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetMouseButtonDown(Rightclickkey))
            {
                RayCastHittable(OnEnvironmentRightClick);
            }
            if (Input.GetMouseButtonDown(Leftclickkey))
            {
                OnEnvironmentLeftClick?.Invoke();
            }
        }

        private void RayCastHittable(Action<Vector3> action)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent<IMouseRightClickHittable>(out var hitObject))
                {
                    hitObject.MouseRightClickHit(hit.point);
                    action?.Invoke(hit.point);
                }
            }
        }
    }
}