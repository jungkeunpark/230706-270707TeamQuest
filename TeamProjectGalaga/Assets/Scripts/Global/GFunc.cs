using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public static partial class GFunc
{
    //디버그모드일때만 적용이 가능하게 바꾼다.
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        //Debug.Log에 대해 래핑해줬다.
        //음식같은걸 보관할때 랲으로 싸듯이 내가 필요할때마다 사용할려고 준비하는것들.
        //EX)C++에서 사용하는것들을  C#에서 사용하려고 래핑함
        Debug.Log(message);
#endif
    }
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;
    }


    //! LoadScene 함수 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
