﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ItemsSystem
{
    public abstract class Draggable : MonoBehaviour, ISelectable
    {
        private static Draggable _selection;
        private static List<Draggable> _mouseOnSelections = new List<Draggable>();
        private static Draggable _dragging;
    
        private void OnMouseDrag()
        {
            if (_dragging == this) Drag();
        }

        private void OnMouseUp()
        {
            if (_dragging == this)
            {
                Drop();
                _dragging = null;
            }
        }

        private void OnMouseDown()
        {
            if (_selection == this)
            {
                _dragging = this;
                StartDragging();
            }
        }

        private void OnMouseEnter()
        {
            _mouseOnSelections.Add(this);
            if (!(_selection is null)) _selection.UnSelect();

            _selection = this;

            _selection.Select();
        }

        
        private void OnMouseExit()
        {
            

            if (_selection == this && _dragging != this)
            {
                // if (_dragging)
                // {
                //     Drop();
                //     _dragging = null;
                // }
                
                _mouseOnSelections.Remove(this);
                _selection.UnSelect();
                if (_mouseOnSelections.Count > 1)
                {
                    _selection = _mouseOnSelections.ElementAt(_mouseOnSelections.Count - 1);
                    _selection.Select();
                }
                else
                {
                    _selection = null;
                }
            }

            // if (_dragging == this)
            // {
            //     Drop();
            //     _dragging = null;
            // }
        }

        protected SpriteRenderer spriteRenderer;
        protected Material material;

        protected Vector3 worldPos;
        protected Vector3 delta;


        protected FixedSizedQueue<Vector3> DeltaQueue = new FixedSizedQueue<Vector3>() {Limit = 4};

        protected Vector3 QueueMedia()
        {
            var sum = Vector3.zero;
            for (var i = 0; i < DeltaQueue.Limit; i++) sum += DeltaQueue.GetElementAt(i);

            return sum / (float) DeltaQueue.Limit;
        }

        private void OnEnable()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            material = spriteRenderer.material;
        }

        public virtual void Select()
        {
            material.SetFloat("_OutlineEnabled", 1);
        }

        public virtual void StartDragging()
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public virtual void Drag()
        {
            var lastFrame = worldPos;
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            delta = worldPos - lastFrame;
            //print(delta);
            //GetComponent<Rigidbody2D>().position += (Vector2) delta;
            GetComponent<Rigidbody2D>().position = worldPos;
            DeltaQueue.Enqueue(delta);
        }

        public virtual void Drop()
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().velocity = (Vector2) (QueueMedia() / Time.deltaTime);
        }

        public virtual void UnSelect()
        {
            material.SetFloat("_OutlineEnabled", 0);
        }
    }
}

