using UnityEngine;
using System.Collections;

public class FogFade : MonoBehaviour {
    private UnityStandardAssets.ImageEffects.GlobalFog _globalFog;
    private float height;
	// Use this for initialization
	void Awake () {
        height = 20.0f;
        _globalFog = gameObject.GetComponent<UnityStandardAssets.ImageEffects.GlobalFog>();
	}
	
	// Update is called once per frame
	void Update () {
        if(height >= 0.0f)
        {
            height -= (4.0f * Time.deltaTime);
            _globalFog.height = height;
        }
        else
        {
            this.enabled = false;
        }
    }
}
