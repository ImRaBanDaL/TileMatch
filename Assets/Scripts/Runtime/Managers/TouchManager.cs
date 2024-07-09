using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;


public static class TouchEvents
{
    public static Action <ITouchable>OnElementTapped;
    public static Action OnEmptyTapped;
}

public interface ITouchable
{

}

public class TouchManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] string collisionTag;
    bool _canTouch;

    private void Start()
    {
        _canTouch = false;
    }

    


    private void Update()
    {
        if (_canTouch)
        {
            GetTouch(Input.mousePosition);
        }
    }

    private void GetTouch(Vector3 pos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(pos));

            if (CanTouch(hit))
            {
                //var selectedCard = hit.gameObject.GetComponent<Card>();
                
            }
        }
    }

    bool CanTouch(Collider2D hit)
    {
        return hit != null && hit.CompareTag(collisionTag);
    }

    IEnumerator WaitForTouch_Cor()
    {
        yield return new WaitForSeconds(1.5f);

        _canTouch = true;
    }

}
