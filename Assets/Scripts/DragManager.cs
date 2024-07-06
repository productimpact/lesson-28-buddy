using UnityEngine;

public class DragManager : MonoBehaviour
{
    private TargetJoint2D targetJoint;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit)
                {
                    targetJoint = hit.collider.gameObject.AddComponent<TargetJoint2D>();
                    targetJoint.autoConfigureTarget = false;
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (targetJoint != null)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    targetJoint.target = touchPos;
                }
            }
        }
        else
        {
            Destroy(targetJoint);
        }

    }
}
