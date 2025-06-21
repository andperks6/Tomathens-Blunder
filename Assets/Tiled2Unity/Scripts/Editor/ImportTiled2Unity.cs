using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Tiled2Unity
{
    partial class ImportTiled2Unity : IDisposable
    {
        private string fullPathToFile = "";
        private string pathToTiled2UnityRoot = "";
        private string assetPathToTiled2UnityRoot = "";

        public ImportTiled2Unity(string file)
        {
            fullPathToFile = Path.GetFullPath(file);

            // Discover the root of the Tiled2Unity scripts and assets
            pathToTiled2UnityRoot = Path.GetDirectoryName(fullPathToFile);
            int index = pathToTiled2UnityRoot.LastIndexOf("Tiled2Unity", StringComparison.InvariantCultureIgnoreCase);
            if (index == -1)
            {
                Debug.LogError(String.Format("There is an error with your Tiled2Unity install. Could not find Tiled2Unity folder in {0}", file));
            }
            else
            {
                pathToTiled2UnityRoot = pathToTiled2UnityRoot.Remove(index + "Tiled2Unity".Length);
            }

            fullPathToFile = fullPathToFile.Replace(Path.DirectorySeparatorChar, '/');
            pathToTiled2UnityRoot = pathToTiled2UnityRoot.Replace(Path.DirectorySeparatorChar, '/');

            // Figure out the path from "Assets" to "Tiled2Unity" root folder
            assetPathToTiled2UnityRoot = pathToTiled2UnityRoot.Remove(0, Application.dataPath.Count());
            assetPathToTiled2UnityRoot = "Assets" + assetPathToTiled2UnityRoot;
        }

        public bool IsTiled2UnityFile()
        {
            return fullPathToFile.EndsWith(".tiled2unity.xml");
        }

        public bool IsTiled2UnityTexture()
        {
            bool startsWith = fullPathToFile.Contains("/Tiled2Unity/Textures/");
            bool endsWithTxt = fullPathToFile.EndsWith(".txt");
            return startsWith && !endsWithTxt;
        }

        public bool IsTiled2UnityMaterial()
        {
            bool startsWith = fullPathToFile.Contains("/Tiled2Unity/Materials/");
            bool endsWith = fullPathToFile.EndsWith(".mat");
            return startsWith && endsWith;
        }

        public bool IsTiled2UnityWavefrontObj()
        {
            bool contains = fullPathToFile.Contains("/Tiled2Unity/Meshes/");
            bool endsWith = fullPathToFile.EndsWith(".obj");
            return contains && endsWith;
        }

        public bool IsTiled2UnityPrefab()
        {
            bool startsWith = fullPathToFile.Contains("/Tiled2Unity/Prefabs/");
            bool endsWith = fullPathToFile.EndsWith(".prefab");
            return startsWith && endsWith;
        }

        public string GetMeshAssetPath(string mapName, string meshName)
        {
            string meshAsset = String.Format("{0}/Meshes/{1}/{2}.obj", assetPathToTiled2UnityRoot, mapName, meshName);
            return meshAsset;
        }

        public string MakeMaterialAssetPath(string file, bool isResource)
        {
            string name = Path.GetFileNameWithoutExtension(file);
            if (isResource)
            {
                return String.Format("{0}/Materials/Resources/{1}.mat", assetPathToTiled2UnityRoot, name);
            }

            // If we're here then the material is not a resource to be loaded at runtime
            return String.Format("{0}/Materials/{1}.mat", assetPathToTiled2UnityRoot, name);
        }

        public string GetExistingMaterialAssetPath(string file)
        {
            // The named material may be in a Ressources folder or not so we use the asset database to search
            string name = Path.GetFileNameWithoutExtension(file);
            string filter = String.Format("t:material {0}", name);
            string folder = assetPathToTiled2UnityRoot + "/Materials";
            string[] files = AssetDatabase.FindAssets(filter, new[] { folder });
            foreach (var f in files)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(f);
                if (String.Compare(Path.GetFileNameWithoutExtension(assetPath), name, true) == 0)
                {
                    return assetPath;
                }
            }
            return "";
        }

        public TextAsset GetTiled2UnityTextAsset()
        {
            string file = assetPathToTiled2UnityRoot + "/Tiled2Unity.export.txt";
            return AssetDatabase.LoadAssetAtPath(file, typeof(TextAsset)) as TextAsset;
        }

        public string GetTextureAssetPath(string filename)
        {
            // Keep the extention given (png, tga, etc.)
            filename = Path.GetFileName(filename);
            string textureAsset = String.Format("{0}/Textures/{1}", assetPathToTiled2UnityRoot, filename);
            return textureAsset;
        }

        public string GetPrefabAssetPath(string name, bool isResource, string extraPath)
        {
            string prefabAsset = "";
            if (isResource)
            {
                if (String.IsNullOrEmpty(extraPath))
                {
                    // Put the prefab into a "Resources" folder so it can be instantiated through script
                    prefabAsset = String.Format("{0}/Prefabs/Resources/{1}.prefab", assetPathToTiled2UnityRoot, name);
                }
                else
                {
                    // Put the prefab into a "Resources/extraPath" folder so it can be instantiated through script
                    prefabAsset = String.Format("{0}/Prefabs/Resources/{1}/{2}.prefab", assetPathToTiled2UnityRoot, extraPath, name);
                }
            }
            else
            {
                prefabAsset = String.Format("{0}/Prefabs/{1}.prefab", assetPathToTiled2UnityRoot, name);
            }

            return prefabAsset;
        }

        public void Dispose()
        {
        }
    }
}
