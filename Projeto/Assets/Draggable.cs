using System;
using System.Collections.Generic;
using UnityEngine;

public class Draggable: MonoBehaviour
{
    private List<AudioClip> _clickSound = new List<AudioClip>();
    private AudioSource _audioSource;
    private Transform _transform;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _transform = GetComponent<Transform>();
    }

    private void OnMouseDrag()
    {
        _transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0,0,-10);
        print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void OnMouseUp()
    {
        throw new NotImplementedException();
    }

    private void OnMouseDown()
    {
        _audioSource.Play();
    }

    private void OnMouseEnter()
    {
print("ativa borda");

    }

    private void OnMouseExit()
    {
        print("desativa borda");
    }
}