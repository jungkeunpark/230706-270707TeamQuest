using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public static partial class GFunc
{
    //����׸���϶��� ������ �����ϰ� �ٲ۴�.
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        //Debug.Log�� ���� ���������.
        //���İ����� �����Ҷ� �N���� �ε��� ���� �ʿ��Ҷ����� ����ҷ��� �غ��ϴ°͵�.
        //EX)C++���� ����ϴ°͵���  C#���� ����Ϸ��� ������
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

    //! GameObject �޾Ƽ� Text ������Ʈ ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;
    }


    //! LoadScene �Լ� ����
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}