// #define OLDMAC		// this is OSX 10.6

using System;
using System.Windows.Forms;
using MonoMac;
using MonoMac.Foundation;
using MonoMac.AppKit;

// #if OLDMAC
using MonoMac.QTKit;
// #else
using MonoMac.AVFoundation;
using MonoMac.AudioUnit;
using MonoMac.AudioUnitWrapper;
using MonoMac.AudioToolbox;
// #endif

namespace BasicAudio
{
	public class AudioInterface
	{
		double _recordingTime;
		string _mediaPath;
		NSUrl _recordingURL;
		int _audioError;
		NSError _deviceError;
		AVAudioPlayer _myAudioPlayer;
		AVAudioRecorder _recorder;


		public AudioInterface ()
		{
			NSApplication.Init ();
			_recordingTime = 5000; // RecordFor (double Duration) ... not sure what 1 Sec. looks like: 1000?
			_mediaPath = "test.wav";
			_recordingURL = NSUrl (_mediaPath);
			_deviceError = NSError ();
#if OLDMAC
#else
			var settings = new AudioSettings {
				Format = AudioFormatType.LinearPCM,
				AudioQuality = AVAudioQuality.High,
				SampleRate = 44100f,
				NumberChannels = 1
			};
#endif

		}
		public int Record()
		{
			_audioError = 0;
			// tested this to ensure error message box pops up from caller: audioError = 1;
			MessageBox.Show ("Record from AudioInterface.");
#if OLDMAC
#else
			// var _recorder = AVAudioRecorder.Create (_recordingURL, settings, out _deviceError);
			_recorder = AVAudioRecorder.Create (_recordingURL, settings, out _deviceError);
			
			if (_recorder == null){
				MessageBox.Show (_deviceError.ToString());
				return;
			}

			if (_recorder.PrepareToRecord ()) {
				MessageBox.Show ("Recorder is prepared");
			} else {
				MessageBox.Show ("Recorder is not prepared");
			}

			if (_recorder.RecordFor (_recordingTime)) {
				MessageBox.Show ("Recording now");
			} else {
				MessageBox.Show ("Not recording for some reason");
			}
#endif
			return _audioError;
		}
		public int Stop()
		{
			_audioError = 0;
			// tested this to ensure error message box pops up from caller: audioError = 2;
			MessageBox.Show ("Stop recording from AudioInterface.");
#if OLDMAC
#else
			if(_myAudioPlayer.Playing()) {
				_myAudioPlayer.Stop ();
			}
			else {
				_audioError = _audioError + 1;
			}
			if(_recorder.Recording()) {
				_recorder.Stop ();
			}
			else {
				_audioError = _audioError + 2;
			}
#endif
			return _audioError;
		}
		public int Play()
		{
			_audioError = 0;
			// tested this to ensure error message box pops up from caller: audioError = 3;
			MessageBox.Show ("Play from AudioInterface.");
#if OLDMAC
#else
			// AVAudioPlayer _myAudioPlayer = new AVAudioPlayer (mediaURL, error);
			_myAudioPlayer = AVAudioPlayer (mediaURL, error);
			_myAudioPlayer.PrepareToPlay ();
			myAudioPlayer.Play ();		
#endif
			return _audioError;
		}
	}
}

