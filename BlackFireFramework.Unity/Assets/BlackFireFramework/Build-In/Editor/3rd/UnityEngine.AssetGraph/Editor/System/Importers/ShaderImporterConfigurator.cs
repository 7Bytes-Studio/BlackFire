using UnityEngine;
using UnityEditor;

using System;
using System.Linq;
using System.Collections.Generic;

using Model = UnityEngine.AssetGraph.DataModel.Version2;

namespace UnityEngine.AssetGraph
{
    [Serializable] 
    [CustomAssetImporterConfigurator(typeof(ShaderImporter), "Shader", "setting.shader")]
    public class ShaderImportSettingsConfigurator : IAssetImporterConfigurator
    {
        public void Initialize (ConfigurationOption option)
        {
        }

        public bool IsModified (AssetImporter referenceImporter, AssetImporter importer, BuildTarget target, string group)
        {
            var r = referenceImporter as ShaderImporter;
            var t = importer as ShaderImporter;
            if (r == null || t == null) {
                throw new AssetGraphException (string.Format ("Invalid AssetImporter assigned for {0}", importer.assetPath));
            }
            return !IsEqual (t, r);
        }

        public void Configure (AssetImporter referenceImporter, AssetImporter importer, BuildTarget target, string group)
        {
            var r = referenceImporter as ShaderImporter;
            var t = importer as ShaderImporter;
            if (r == null || t == null) {
                throw new AssetGraphException (string.Format ("Invalid AssetImporter assigned for {0}", importer.assetPath));
            }
            OverwriteImportSettings (t, r);
        }

        public void OnInspectorGUI (AssetImporter referenceImporter, BuildTargetGroup target, Action onValueChanged)
        {
        }

        private void OverwriteImportSettings (ShaderImporter target, ShaderImporter reference)
        {
        }

        private bool IsEqual (ShaderImporter target, ShaderImporter reference)
        {
            return true;
        }
    }
}
