using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelNodes : MonoBehaviour
{

    public void ShowLabel(GameObject node)
    {
        // add child gameobject for textmesh
        GameObject textLabel = new GameObject();
        textLabel.transform.SetParent(node.transform);
        TextMesh t = textLabel.AddComponent<TextMesh>();
        t.text = node.name;
        t.fontSize = 1;
        textLabel.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        textLabel.transform.position = node.transform.position;
        textLabel.transform.LookAt(Camera.main.transform);
    }

    public void HideLabel(GameObject node)
    {
        if(node.GetComponent<Transform>().childCount > 0)
        {
            Destroy(node.GetComponent<Transform>().GetChild(0).gameObject);
        }
    }

}
