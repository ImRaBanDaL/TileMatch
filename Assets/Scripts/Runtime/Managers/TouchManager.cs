using System;
using System.Collections;
using UnityEngine;



public static class TouchEvents
{
    public static Action<ITouchable> OnElementTapped;
    public static Action OnEmptyTapped;
}

public interface ITouchable
{
    GameObject gameObject { get; }
}

public class TouchManager : MonoBehaviour
{
    [SerializeField] Camera cam;

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

    void GetTouch(Vector3 pos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(pos));

            if (CanTouch(hit))
            {             
                if (hit.gameObject.TryGetComponent(out ITouchable selectedElement))
                {
                    TouchEvents.OnElementTapped?.Invoke(selectedElement);
                }
            }
            else
            {
                TouchEvents.OnEmptyTapped?.Invoke();
            }
        }
    }

    bool CanTouch(Collider2D hit)
    {
        return hit != null;
    }

    IEnumerator WaitForTouch_Cor()
    {
        yield return new WaitForSeconds(1.5f);
        _canTouch = true;
    }

}
