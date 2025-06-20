﻿#if !UNITY_WEBPLAYER
// Note: This parital class is not compiled in for WebPlayer builds.
// The Unity Webplayer is deprecated. If you *must* use it then make sure Tiled2Unity assets are imported via another build target first.
using System;
using System.Xml.Linq;
using UnityEngine;

namespace Tiled2Unity
{
    // Concentrates on the Xml file being imported
    partial class ImportTiled2Unity
    {

        // Called when Unity detects the *.tiled2unity.xml file needs to be (re)imported
        public void ImportBegin(string xmlPath, ImportTiled2Unity importTiled2Unity)
        {
            // Create a (tempoary) gameobject in the scene hierarchy that can manage state of the import process
            GameObject t2uImporter = new GameObject("__tiled2unity_importer");
#if !UNITY_4_0 && !UNITY_4_0_1 && !UNITY_4_2 && !UNITY_4_3
            t2uImporter.gameObject.transform.SetAsFirstSibling();
#endif
            // Add the ImportBehaviour component. This will track the state of the importer and get everything to happen in the right order.
            var importComponent = t2uImporter.AddComponent<ImportBehaviour>();

            // Load the XML and start the importing process
            if (LoadTiled2UnityXml(importComponent, xmlPath))
            {
                CheckVersion(importComponent, importTiled2Unity);
                CheckSettings(importComponent);

                // Start the import process by importing all our textures
                ImportAllTextures(importComponent);
            }
        }

        private bool LoadTiled2UnityXml(ImportBehaviour importComponent, string xmlPath)
        {
            try
            {
                var xml = XDocument.Load(xmlPath);
                importComponent.XmlDocument = xml;

                var xmlTiled2Unity = xml.Element("Tiled2Unity");
                importComponent.Tiled2UnityXmlPath = xmlPath;
                importComponent.ExporterTiled2UnityVersion = ImportUtils.GetAttributeAsString(xmlTiled2Unity, "version");
                return true;
            }
            catch (Exception e)
            {
                string msg = String.Format("Error importing Tiled2Unity xml file '{0}': {1}", xmlPath, e.Message);
                Debug.LogError(msg);
                importComponent.DestroyImportBehaviour();
            }

            return false;
        }

        private void CheckVersion(ImportBehaviour importComponent, ImportTiled2Unity importTiled2Unity)
        {
            try
            {
                // Get the version from our Tiled2Unity.export.txt library data file
                TextAsset textAsset = importTiled2Unity.GetTiled2UnityTextAsset();
                XDocument xml = XDocument.Parse(textAsset.text);
                string importerTiled2UnityVersion = xml.Element("Tiled2UnityImporter").Element("Header").Attribute("version").Value;

                if (importComponent.ExporterTiled2UnityVersion != importerTiled2UnityVersion)
                {
                    importComponent.RecordWarning("Imported Tiled2Unity file '{0}' was exported with version {1}. We are expecting version {2}", importComponent.Tiled2UnityXmlPath, importComponent.ExporterTiled2UnityVersion, importerTiled2UnityVersion);
                }
            }
            catch (Exception e)
            {
                importComponent.RecordError("Failed to read Tiled2Unity import version from '{0}': {1}", importComponent.Tiled2UnityXmlPath, e.Message);
            }
        }

        private void CheckSettings(ImportBehaviour importComponent)
        {
            // Check anti-aliasing
            if (QualitySettings.antiAliasing != 0)
            {
                importComponent.RecordWarning("Anti-aliasing is enabled and may cause seams. See Edit->Project Settings->Quality to disable.");
            }
        }

        private Material CreateMaterialFromXml(XElement xml, ImportBehaviour importComponent)
        {
            // Does this material support alpha color key?
            bool useColorKey = xml.Attribute("alphaColorKey") != null;
            bool usesDepthShader = ImportUtils.GetAttributeAsBoolean(xml, "usesDepthShaders", false);

            // Determine which shader we sould be using
            string shaderName = "Tiled2Unity/";

            // Are we using depth shaders?
            if (usesDepthShader)
            {
                shaderName += "Depth";
            }
            else
            {
                shaderName += "Default";
            }

            // Are we using color key shaders?
            Color keyColor = Color.black;
            if (useColorKey)
            {
                keyColor = ImportUtils.GetAttributeAsColor(xml, "alphaColorKey");
                shaderName += " Color Key";
            }

            // Are we using instanced shaders?
#if UNITY_5_6_OR_NEWER
            shaderName += " (Instanced)";
#endif

            // Try creating the material with the right shader. Fall back to the built-in Sprites/Default shader if there's a problem.
            Material material = null;
            try
            {
                material = new Material(Shader.Find(shaderName));
            }
            catch (Exception e)
            {
                importComponent.RecordError("Error creating material with shader '{0}'. {1}", shaderName, e.Message);
            }

            if (material == null)
            {
                importComponent.RecordWarning("Using default sprite shader for material");
                material = new Material(Shader.Find("Sprites/Default"));
            }

            if (useColorKey)
            {
                material.SetColor("_AlphaColorKey", keyColor);
            }

#if UNITY_5_6_OR_NEWER
            material.enableInstancing = true;
#endif

            return material;
        }
    }
}
#endif