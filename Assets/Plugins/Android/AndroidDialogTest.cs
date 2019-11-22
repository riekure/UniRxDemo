using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDialogTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
#if UNITY_ANDROID
        var nativeDialog = new AndroidJavaClass("com.example.unitynativepluginlibrary.NativeDialog");
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        
        context.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            nativeDialog.CallStatic(
                "showMessage",
                context,
                "テスト",
                "ほげ"
            );
        }));
#endif
    }
}
