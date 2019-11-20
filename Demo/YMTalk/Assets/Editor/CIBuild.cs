using UnityEditor;
using System.IO;
using UnityEngine;
using System.Linq;


public static class CIBuild
{

    /// <summary>
    /// 构建测试版,适合给测试同学
    /// </summary>
    [MenuItem("打包/TestServer", false, 1)]
    public static void BuildTestVersion()
    {
        ReplaceConfigThenBuild();
    }

    /// <summary>
    /// 构建正式版，适合给客户
    /// </summary>
    [MenuItem("打包/OnlineServer", false, 3)]
    public static void BuildReleaseVersion()
    {
        ReplaceConfigThenBuild();
    }

    public static void ReplaceConfigThenBuild()
    {

#if UNITY_ANDROID
        PlayerSettings.Android.bundleVersionCode = PlayerSettings.Android.bundleVersionCode + 1;
#elif UNITY_IOS
        PlayerSettings.iOS.buildNumber = string.Format("{0}", int.Parse(PlayerSettings.iOS.buildNumber) + 1);
#endif

        string version = PlayerSettings.bundleVersion;
        string[] splitVersion = version.Split('.');
        if (splitVersion.Length == 2)
        {
            int intVersion = int.Parse(splitVersion[1]);
            ++intVersion;

            PlayerSettings.bundleVersion = splitVersion[0] + "." + intVersion.ToString("D4");
            Debug.LogError(PlayerSettings.bundleVersion);

        }

        if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
        {
            CommandLineBuildiOS();
        }
        else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
        {
            CommandLineBuildAndroid();
        }
        else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows)
        {
            CommandLineBuildWindows();
        }
        else
        {
            Debug.LogError("暂时不支持的平台");
        }
    }

    static string GetiOSBuildPath()
    {
        string dirPath = Application.dataPath + "/../Build";
        Debug.LogWarning("DirPath:" + dirPath);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        return Path.GetFullPath(dirPath);
    }

    public static void CommandLineBuildiOS()
    {

        Debug.Log("Command line build ios version\n------------------\n------------------");

        string[] scenes = BuildScenes();
        string path = GetiOSBuildPath();
        if (scenes == null || scenes.Length == 0 || path == null)
            return;

        Debug.Log(string.Format("Path: \"{0}\"", path));
        for (int i = 0; i < scenes.Length; ++i)
        {
            Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));
        }

        Debug.Log("Starting Build!");
#if UNITY_5
        BuildPipeline.BuildPlayer(scenes, path, BuildTarget.iOS, BuildOptions.None);
#else
            BuildPipeline.BuildPlayer(scenes, path, BuildTarget.iOS, BuildOptions.None);
#endif

    }

    static string GetAndroidBuildPath()
    {
        string dirPath = Application.dataPath + "/../BuildAndroid";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        return Path.GetFullPath(dirPath);
    }


    public static void CommandLineBuildAndroid()
    {

        Debug.Log("Command line build android version\n------------------\n------------------");

        string[] scenes = BuildScenes();
        string path = GetAndroidBuildPath();
        if (scenes == null || scenes.Length == 0 || path == null)
            return;

        Debug.Log(string.Format("Path: \"{0}\"", path));
        for (int i = 0; i < scenes.Length; ++i)
        {
            Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));
        }

        Debug.Log("Starting Android Build!");
        string finalPath = path + "/Demo_video_test_" + System.DateTime.Now.ToString("yyMMddHHmm") + ".apk";

        BuildPipeline.BuildPlayer(scenes, finalPath, BuildTarget.Android, BuildOptions.None);

    }

    static string GetWindowsBuildPath()
    {
        string dirPath = Application.dataPath + "/../BuildWindows";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        return Path.GetFullPath(dirPath);
    }

    public static void CommandLineBuildWindows()
    {

        Debug.Log("Command line build ios version\n------------------\n------------------");

        string[] scenes = BuildScenes();
        string path = GetWindowsBuildPath();
        if (scenes == null || scenes.Length == 0 || path == null)
        {
            Debug.LogError("build scenes is null or empty");
        }

        Debug.Log(string.Format("Path: \"{0}\"", path));
        for (int i = 0; i < scenes.Length; ++i)
        {
            Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));
        }
        string finalPath = path + "/" + System.DateTime.Now.ToString("yyMMddHHmm") + ".exe";

        Debug.Log("Starting Build!");
        BuildPipeline.BuildPlayer(scenes, finalPath, BuildTarget.StandaloneWindows, BuildOptions.None);

    }

    public static string[] BuildScenes()
    {
        return (from scene in EditorBuildSettings.scenes
                where scene.enabled
                select scene.path).ToArray();
    }

}
