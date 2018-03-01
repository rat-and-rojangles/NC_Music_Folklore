// -------------------------------------------------------------------
// - A custom asset importer for Unity 3D game engine by Sarper Soher-
// - http://www.sarpersoher.com                                      -
// -------------------------------------------------------------------
// - This script utilizes the file names of the imported assets      -
// - to change the import settings automatically as described        -
// - in this script                                                  -
// -------------------------------------------------------------------


using UnityEngine;
using UnityEditor;  // Most of the utilities we are going to use are contained in the UnityEditor namespace

// We inherit from the AssetPostProcessor class which contains all the exposed variables and event triggers for asset importing pipeline
internal sealed class DefaultSpriteImport : AssetPostprocessor {
	private void OnPreprocessTexture () {
		var importer = assetImporter as TextureImporter;
		importer.textureType = TextureImporterType.Sprite;

		importer.spriteImportMode = SpriteImportMode.Single;
		// importer.spritePixelsPerUnit = 100f;
		importer.wrapMode = TextureWrapMode.Repeat;


		// // Below line may cause problems with systems and plugins that utilize the textures (read/write them) like NGUI so comment it out based on your use-case
		// importer.isReadable = false;
		// importer.filterMode = FilterMode.Trilinear;
		// importer.anisoLevel = 9;

		// importer.compressionQuality = 100;

		// // If you are only using the alpha channel for transparency, uncomment the below line. I commented it out because I use the alpha channel for various shaders (e.g. specular map or various other masks)
		// importer.alphaIsTransparency = importer.DoesSourceTextureHaveAlpha ();
	}
}