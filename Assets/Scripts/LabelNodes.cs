using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelNodes : MonoBehaviour
{
    [SerializeField] private float textSize = 0.02f;
    private GameObject player;

    public void ShowLabel(GameObject node)
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        // add child gameobject for textmesh
        GameObject textLabel = new GameObject();
        textLabel.transform.SetParent(node.transform);
        TextMesh t = textLabel.AddComponent<TextMesh>();
        t.text = node.name;
        t.fontSize = 48;

        // text looks at player
        textLabel.transform.LookAt(this.player.transform.rotation * Vector3.forward);
        textLabel.transform.position = node.transform.position;
        textLabel.transform.localScale *= this.textSize;
    }

    public void HideLabel(GameObject node)
    {
        if(node.GetComponent<Transform>().childCount > 0)
        {
            Destroy(node.GetComponent<Transform>().GetChild(0).gameObject);
        }
    }

}
