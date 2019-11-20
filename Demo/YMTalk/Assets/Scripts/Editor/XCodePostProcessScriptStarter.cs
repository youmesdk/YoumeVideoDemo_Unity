using UnityEngine;

#if UNITY_EDITOR
using System.Collections;
using UnityEditor.Callbacks;
//using UnityEditor.iOS.Xcode;
using UnityEditor.XCodeEditor;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Text;
#endif

namespace JDK.EditorUtils
{
	public class XCodePostProcessScriptStarter : MonoBehaviour {

		[PostProcessBuild(255)]
		public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
	#if UNITY_IOS

			//set a flag, next time biuld process if the flag exist, rebuild
			string flagPath = System.IO.Path.Combine(pathToBuiltProject, "unity_built_flag");



			if (!System.IO.File.Exists(flagPath))
			{
				System.IO.File.WriteAllText(flagPath, "built_time:" + System.DateTime.Now);
			}
			else
			{
				//adjusted the proj file, ignore
				return;
			}


            UnityEditor.XCodeEditor.XCProject project = new UnityEditor.XCodeEditor.XCProject(pathToBuiltProject);
			
			// Find and run through all projmods files to patch the project
			string projModPath = System.IO.Path.Combine(Application.dataPath, "Scripts/Editor");
			project.ApplyMod(Path.Combine(projModPath, "YoumeTalk.projmods"));
		//	project.overwriteBuildSetting("CODE_SIGN_IDENTITY[sdk=iphoneos*]", "iPhone Distribution", "Release");
			project.overwriteBuildSetting("ENABLE_BITCODE", "NO", "Release");
			project.overwriteBuildSetting("ENABLE_BITCODE", "NO", "Debug");
			Debug.Log("saving modified xcode proj file");
			project.Save();

			// const string fileName = "Info.plist";
			// string plistFilePath = System.IO.Path.Combine(pathToBuiltProject, fileName);
			//scheme is a string like: "wx|sdf3423sdfiopf"
			// InfoPlistEditor plistEditor = new InfoPlistEditor();
			// plistEditor.ReadFile(plistFilePath);
			//string[] tokens = s.Split('|');
			// string id = tokens[0];
			// string url = tokens[1];
			// plistEditor.AppendUrlScheme(id, url);
            // plistEditor.AppendKeyValue(key,value);
			// plistEditor.Save(plistFilePath);

	#endif
		}		

	}
}
