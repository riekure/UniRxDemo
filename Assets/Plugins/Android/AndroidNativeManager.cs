using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidNativeManager : MonoBehaviour
{
    [SerializeField] Text androidMessageText;

    public static readonly string ANDROID_NATIVE_PLUGIN_CLASS = "com.example.unitypluginsamplelibrary.HelloAndroidNativePlugin";

    // Start is called before the first frame update
    void Start()
    {
        ResetMessage();
    }

    public void CallAndroidPlugin()
    {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(ANDROID_NATIVE_PLUGIN_CLASS))
        {
            androidJavaClass.CallStatic("Execute");
        }
    }

    public void ResetMessage()
    {
        androidMessageText.text = "";
    }

    public void FromAndroid(string message)
    {
        androidMessageText.text = message;
    }
}
