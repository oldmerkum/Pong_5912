using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://forum.unity.com/threads/activate-gameobject-after-4-minutes.297137/#post-1958045 */
public class DelayedSetActive : MonoBehaviour
{
    public int delaySeconds;
    void Start()
    {
        StartCoroutine(ActivateRoutine());
    }

    private IEnumerator ActivateRoutine()
    {

        // make a list of all children
        Transform[] ChildrenTransforms = this.gameObject.GetComponentsInChildren<Transform>();
        // the gameObjects have to be enabled, otherwise they will not be found ...
        foreach (Transform t in ChildrenTransforms)
            if (0 == t.childCount)                // skip the parent, probably the first one. Sorry: no children in the child-objects !
                t.gameObject.SetActive(false); // disable the children

        yield return new WaitForSeconds(delaySeconds);    // and now we wait !

        foreach (Transform t in ChildrenTransforms)
            t.gameObject.SetActive(true);      // restore all the disabled objects in the list (even the parent)

    }
}

