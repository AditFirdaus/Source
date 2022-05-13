using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssemblyComponentProperties : MonoBehaviour
{
    public static AssemblyComponent component;
    public static ComponentGroup group => AssemblyComponentGroup.selectedGroup;

    public CanvasGroup canvasGroup;
    public TMP_Text componentName;
    public TMP_Text componentType;
    public TMP_Text componentDescription;
    public Image componentPreview;

    public Coroutine nameCoroutine;
    public Coroutine typeCoroutine;
    public Coroutine descriptionCoroutine;

    private void Start()
    {
        AssemblyComponentCollections.OnSelect.AddListener(Display);
    }

    public void Display(AssemblyComponent newComponent)
    {
        component = newComponent;

        canvasGroup.alpha = 0;

        string _name = component.name;
        string _group = group ? group.name : "";
        string _description = component.description;

        componentPreview.sprite = component.sprite;

        PlayAnimation(_name, _group, _description);
    }

    public void PlayAnimation(string _name, string _group, string _description)
    {
        if (nameCoroutine != null) StopCoroutine(nameCoroutine);
        if (typeCoroutine != null) StopCoroutine(typeCoroutine);
        if (descriptionCoroutine != null) StopCoroutine(descriptionCoroutine);

        nameCoroutine = StartCoroutine(TextWriteCoroutine(componentName, _name, 0.025f));
        typeCoroutine = StartCoroutine(TextWriteCoroutine(componentType, _group, 0.025f));
        descriptionCoroutine = StartCoroutine(TextWriteCoroutine(componentDescription, _description, 0.01f));
    }

    public IEnumerator TextWriteCoroutine(TMP_Text tmpText, string newText, float time = 0.025f)
    {
        tmpText.text = "";
        for (int i = 0; i < newText.Length; i++)
        {
            tmpText.text += newText[i];
            yield return new WaitForSeconds(time);
        }
    }
}

