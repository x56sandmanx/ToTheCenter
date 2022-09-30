using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMScript : MonoBehaviour
{
    public static BgMScript BgMInstance;
    
    private void Awake()
    {
		if(BgMInstance != null && BgMInstance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		
		BgMInstance = this;
		DontDestroyOnLoad(this);
	}
}
