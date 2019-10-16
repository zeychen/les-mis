using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverController : MonoBehaviour
{
    [SerializeField] private Color hoverColor = Color.red;
    private Color originalColor;

    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        this.originalColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    void LateUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(this.gameObject.name);
            if(hit.collider.name == this.gameObject.name)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", this.hoverColor);
                print(this.gameObject.name);
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", this.originalColor);
            }
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", this.originalColor);
        }
    }

}
