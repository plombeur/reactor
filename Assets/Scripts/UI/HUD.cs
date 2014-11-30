using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HUD : MonoBehaviour
{
    public UserActionWindow userActionWindow;
    public Living target;

    public ProgressBar lifeBar;
    public ProgressBar MoralBar;

    void Start()
    {
        
    }

    void Update()
    {
        lifeBar.progress = target.hp / target.maxHP * 100;
        /*
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            UserActionContainer container = hit.collider.GetComponent<UserActionContainer>();

            if (container != null)
            {
               
            }
            else
            {
              
            }
        }*/
    }
}
