#if !UNITY_EDITOR

using UnityEngine;
using UnityEngine.Rendering;

//���Ÿ����ﶼ��,�����Ǵ������������ʾunity��logo��������,ֱ�ӽ���Ϸ,�༭ģʽ�¿�����Ч��
[UnityEngine.Scripting.Preserve]
public class SkipUnityLogo
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void BeforeSplashScreeen()
    {
#if UNITY_WEBGL
        Application.focusChanged += Application_focusChanged;
#else
        System.Threading.Tasks.Task.Run(AsyncSkip);
#endif
    }
#if UNITY_WEBGL
    private static void Application_focusChanged(bool obj)
    {
        Application.focusChanged -= Application_focusChanged;
        SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    }
#else
    private static void AsyncSkip()
    {
        SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    }
#endif
}

#endif