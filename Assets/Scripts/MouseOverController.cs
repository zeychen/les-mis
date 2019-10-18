using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverController : MonoBehaviour
{
    [SerializeField] private Color hoverColor = Color.black;
    private Color originalColor;

    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        this.originalColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // changes color to red if hit by ray
            if(hit.collider.name == this.gameObject.name)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", this.hoverColor);
                //print(this.gameObject.name);
                this.gameObject.GetComponent<LabelNodes>().ShowLabel(this.gameObject);
                
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", this.originalColor);
                this.gameObject.GetComponent<LabelNodes>().HideLabel(this.gameObject);
            }
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", this.originalColor);
            this.gameObject.GetComponent<LabelNodes>().HideLabel(this.gameObject);
        }
    }

}
