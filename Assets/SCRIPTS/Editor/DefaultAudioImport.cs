using UnityEngine;
using UnityEditor; 

internal sealed class DefaultAudioImport : AssetPostprocessor {
	private void OnPreprocessAudio () {
		var importer = assetImporter as AudioImporter;
		var settings = importer.defaultSampleSettings;
		settings.loadType = AudioClipLoadType.Streaming;
		importer.defaultSampleSettings = settings;
	}
}