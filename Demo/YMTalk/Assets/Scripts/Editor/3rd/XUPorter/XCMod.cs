using UnityEngine;
using System.Collections;
using System.IO;

namespace UnityEditor.XCodeEditor 
{
	public class XCMod 
	{
		private Hashtable _datastore = new Hashtable();
		private ArrayList _libs = null;
	    private ArrayList _files = null;
		private ArrayList _folders = null;
		
		public string name { get; private set; }
		public string path { get; private set; }
		
		public string group {
			get {
				if (_datastore != null && _datastore.Contains("group"))
					return (string)_datastore["group"];
				return string.Empty;
			}
		}
		
		public ArrayList patches {
			get {
				return (ArrayList)_datastore["patches"];
			}
		}
		
		public ArrayList libs
        {
			get
            {
				if( _libs == null )
				{
				    if (_datastore["libs"] != null)
				    {
                        _libs = new ArrayList(((ArrayList) _datastore["libs"]).Count);
                        foreach (string fileRef in (ArrayList) _datastore["libs"])
				        {
				            Debug.Log("Adding to Libs: " + fileRef);
				            _libs.Add(new XCModFile(fileRef));
				        }
				    }
				}
				return _libs;
			}
		}
		
		public ArrayList frameworks {
			get {
				return (ArrayList)_datastore["frameworks"];
			}
		}
		
		public ArrayList headerpaths {
			get {
				return (ArrayList)_datastore["headerpaths"];
			}
		}

        public ArrayList files
        {
            get
            {
                if (_files == null)
                {
                    if (_datastore["files"] != null)
                    {
                        _files = new ArrayList(((ArrayList)_datastore["files"]).Count);
                        foreach (string fileRef in (ArrayList)_datastore["files"])
                        {
                            _files.Add(new XCModFile(fileRef));
                        }
                    }
                }
                return _files;
            }
        }

		public ArrayList folders {
			get 
			{
				if (_folders == null)
				{
					if (_datastore["folders"] != null)
					{
						_folders = new ArrayList(((ArrayList)_datastore["folders"]).Count);
						foreach (string folderString in (ArrayList)_datastore["folders"])
						{
							_folders.Add(new XCModFolder(folderString));
						}
					}
				}
				return _folders;
			}
		}
		
		public ArrayList excludes {
			get {
				return (ArrayList)_datastore["excludes"];
			}
		}

		public ArrayList compiler_flags {
			get {
				return (ArrayList)_datastore["compiler_flags"];
			}
		}

		public ArrayList linker_flags {
			get {
				return (ArrayList)_datastore["linker_flags"];
			}
		}
		
		public XCMod( string filename )
		{	
			FileInfo projectFileInfo = new FileInfo( filename );
			if( !projectFileInfo.Exists ) {
				Debug.LogWarning( "File does not exist." );
			}
			
			name = System.IO.Path.GetFileNameWithoutExtension( filename );
			path = System.IO.Path.GetDirectoryName( filename );
			
			// string contents = projectFileInfo.OpenText().ReadToEnd();
			StreamReader sr = projectFileInfo.OpenText();
			string contents = sr.ReadToEnd();
			sr.Close ();
			Debug.Log (contents);
			_datastore = (Hashtable)XUPorterJSON.MiniJSON.jsonDecode( contents );
			if (_datastore == null || _datastore.Count == 0) {
				Debug.Log (contents);
				throw new UnityException("Parse error in file " + System.IO.Path.GetFileName(filename) + "! Check for typos such as unbalanced quotation marks, etc.");
			}
		}
	}

	public class XCModFile
	{

        public string fileFlags { get; private set; }
		public bool isWeak { get; private set; }

		private string _filePath;
		public string filePath { 
            get{
            	bool xcodeIsUperTo7=false;
            	if(File.Exists("/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild")){
            		var r = ExcuteShellAndGetResult("/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild", "-version");
            		if(r.ToLower().Contains("Xcode 6".ToLower())|| r.ToLower().Contains("Xcode 5".ToLower())||r.ToLower().Contains("Xcode 4".ToLower())){
            			xcodeIsUperTo7 = false;
            		}else{
            			xcodeIsUperTo7 = true;
            		}
            	}

                var ext = Path.GetExtension(_filePath);
                if(xcodeIsUperTo7 && ext.ToLower().Equals(".dylib")){
                    Debug.LogWarning("for support xcode 7 ,replace "+_filePath+"  extension to tbd.");
                    return _filePath.Replace(".dylib",".tbd");
                }else{
                    return _filePath;
                }
            }
            private set{
                _filePath = value;
            }
        }
		
		public XCModFile( string inputString )
		{
			isWeak = false;
			
			if( inputString.Contains( ":" ) ) {
				string[] parts = inputString.Split( ':' );
				filePath = parts[0];
                fileFlags = parts[1];
                isWeak = ( parts[1].CompareTo( "weak" ) == 0 );	
			}
			else {
				filePath = inputString;
			}
		}

		public static string ExcuteShellAndGetResult(string shellPath,string shellArguments){

			var proc = new System.Diagnostics.Process();
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.CreateNoWindow = true;
			
			proc.StartInfo.RedirectStandardError = true;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.EnableRaisingEvents=false; 
			proc.StartInfo.FileName = shellPath;
			proc.StartInfo.Arguments = shellArguments;
			proc.Start();
			
			var err = proc.StandardError.ReadToEnd();
			var result = proc.StandardOutput.ReadToEnd();
			proc.WaitForExit();
			EditorUtility.ClearProgressBar ();
	        if (proc.ExitCode != 0) {
	            UnityEngine.Debug.LogError ("error: " + err + "   code: " + proc.ExitCode);
	            return "error: " + err + "   code: " + proc.ExitCode;
	        } else {
	            return result;
	        }
		}
	}
	
	public class XCModFolder
	{
		public string folderPath { get; private set; }
		public string folderFlags { get; private set; }
		
		public XCModFolder( string inputString )
		{
			if( inputString.Contains( ":" ) ) {
				string[] parts = inputString.Split( ':' );
				folderPath = parts[0];
				folderFlags = parts[1];
			}
			else {
				folderPath = inputString;
			}
		}
	}

}
