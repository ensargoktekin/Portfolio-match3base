using RoyalKingdom.Block;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace RoyalKingdom.InputSystem
{
    public class InputController : MonoBehaviour
    {
        public static event System.Action<Slot, SwapDirection> UserSwappedObject;

        private Camera _mainCam;
        private Slot _hitSlot;
        private State _state;
        private bool _checkPointer;
        private string _targetLayer;
        private float _initialX, _initialY;

        public enum SwapDirection
        {
            None,
            Left,
            Right,
            Up,
            Down
        }

        private enum State
        {
            None,
            WaitingHit,
            WaitingMove,
            WaitingTouchEnd
        }

        private void Start()
        {
            _mainCam = Camera.main;
            _checkPointer = true;
            _targetLayer = "Slot";
            _state = State.WaitingHit;
        }

        private void Update()
        {
            if (_checkPointer)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began && _state == State.WaitingHit)
                    {
                        GetPointedObject(Input.touches[0].position); //Get the position of the first touch}
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Moved && _state == State.WaitingMove)
                    {
                        GetMoveDirection(Input.touches[0].position);

                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        TouchEnded();
                    }
                }
            }
        }

        private void GetPointedObject(Vector2 pointerPos)
        {
            Ray ray = _mainCam.ScreenPointToRay(pointerPos);
            LayerMask mask = LayerMask.GetMask(_targetLayer);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, ray.direction.magnitude, mask);
            //Debug.DrawRay(ray.origin, ray.direction * 10);
            if (hit)
            {
                _hitSlot = hit.transform.GetComponent<Slot>();
                _initialX = pointerPos.x;
                _initialY = pointerPos.y;
                _state = State.WaitingMove;
            }
        }

        private void GetMoveDirection(Vector2 pointerPos)
        {
            float deltaX = pointerPos.x - _initialX;
            float deltaY = pointerPos.y - _initialY;

            // prevent unintentionally movement
            if (Mathf.Abs(deltaX) < 50 && Mathf.Abs(deltaY) < 50)
            {
                return;
            }
            
            if (deltaY == 0 || Mathf.Abs(deltaX)/Mathf.Abs(deltaY) > 4) // horizontal movement
            {
                if (deltaX > 0) UserSwappedObject?.Invoke(_hitSlot, SwapDirection.Right);
                else if (deltaX < 0) UserSwappedObject?.Invoke(_hitSlot, SwapDirection.Left);
            }
            else if (deltaX == 0 || Mathf.Abs(deltaY)/Mathf.Abs(deltaX) > 4) // vertical movement
            {
                if (deltaY > 0) UserSwappedObject?.Invoke(_hitSlot, SwapDirection.Up);
                else if (deltaY < 0) UserSwappedObject?.Invoke(_hitSlot, SwapDirection.Down);
            }
            else
            {
                return; // no state change
            }
            _state = State.WaitingTouchEnd;
        }

        private void TouchEnded()
        {
            _state = State.WaitingHit;
            _hitSlot = null;
        }
    }
}
