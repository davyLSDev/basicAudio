using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using MonoMac;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.AVFoundation;
using MonoMac.AudioUnit;
using MonoMac.AudioUnitWrapper;

// using MonoMac.AudioUnit;
// using MonoMac.AudioToolbox;

class MForm : Form {
	public MForm() {
		Text = "MacOSX Audio {record/play}er";
		Size = new System.Drawing.Size(350, 150);

		System.Windows.Forms.Button recordButton = new System.Windows.Forms.Button();
		recordButton.Location = new System.Drawing.Point(20, 50);
		recordButton.Text = "Record";
		recordButton.Click += new EventHandler(OnClickRecord);
		Controls.Add(recordButton);

		System.Windows.Forms.Button stopButton = new System.Windows.Forms.Button();
		stopButton.Location = new System.Drawing.Point(100, 50);
		stopButton.Text = "Stop";
		stopButton.Click += new EventHandler(OnClickStop);
		Controls.Add(stopButton);

		System.Windows.Forms.Button playButton = new System.Windows.Forms.Button();
		playButton.Location = new System.Drawing.Point(170, 50);
		playButton.Text = "Play";
		playButton.Click += new EventHandler(OnClickPlay);
		Controls.Add(playButton);

		System.Windows.Forms.Button quitButton = new System.Windows.Forms.Button();
		quitButton.Location = new System.Drawing.Point(240, 50);
		quitButton.Text = "Close";
		quitButton.Click += new EventHandler(OnClickQuit);
		Controls.Add(quitButton);

		CenterToScreen();
	}

	void OnClickRecord(object sender, EventArgs e) {
		// MessageBox.Show ("Recording");

		/* string recordingPath;
		recordingPath = "test.wav";
		double recordingTime = 1000; // RecordFor (double Duration) ... not sure what 1 Sec. looks like: 1000?
		NSUrl recordingURL = new NSUrl (recordingPath);
		NSError errorRecording = new NSError ();
		NSDictionary recordingSettings = new NSDictionary ();
		AVAudioRecorder myAudioRecorder = new AVAudioRecorder (); 
		/* ? putting this in (recordingURL, recordingSettings, errorRecording) requires using a static ;
		 * Not quite sure how to do that, but this is Obsolete, and for that matter, so is
		 * the Playback instantiation I've chosen. So how do you get all this stuff in that is needed? 
		maybe with an initWithURL ... however you do that */

		/* string debugMSG;
		debugMSG = myAudioRecorder.DebugDescription;
		MessageBox.Show ("Debug info for recording; " + debugMSG);
		if (myAudioRecorder.PrepareToRecord ()) { 
			myAudioRecorder.Record (); 
			myAudioRecorder.RecordFor (recordingTime);
		} */
		NSApplication.Init ();
		string recordingPath;
		recordingPath = "/Users/davy/test.wav";
		double recordingTime = 5000; // RecordFor (double Duration) ... not sure what 1 Sec. looks like: 1000?
		NSUrl recordingURL = new NSUrl (recordingPath);
		NSError errorRecording = new NSError ();
		// This next bit comes from a C# example here:
		// http://macapi.xamarin.com/index.aspx?link=T%3AMonoMac.AVFoundation.AVAudioRecorder 
		var settings = new AudioSettings {
		// var settings = new AVAudioRecorderSettings () {
		// var settings = new 
			// Audio
			Format = MonoMac.AudioToolbox.AudioFormatType.LinearPCM, //not sure this is the same, but all I could match with.
				// AudioFormatType.LinearPCM,
			AudioQuality = AVAudioQuality.High,
			SampleRate = 44100f,
			NumberChannels = 1
		};
		MessageBox.Show ("Debug MSSG before setting up recorder");

		try
		{
			// seems BROKEN: 
			// var recorder = AVAudioRecorder.ToUrl (recordingURL, settings, out errorRecording);
			var recorder = AVAudioRecorder.Create (recordingURL, settings, out errorRecording);

			if (recorder == null){
				MessageBox.Show (errorRecording.ToString());
				return;
			}


			if (recorder.PrepareToRecord ()) {
				MessageBox.Show ("Recorder is prepared");
			} else {
				MessageBox.Show ("Recorder is not prepared");
			}

			if (recorder.RecordFor (recordingTime)) {
				MessageBox.Show ("Recording now");
			} else {
				MessageBox.Show ("Not recording for some reason");
			}
		}
		finally {
			MessageBox.Show ("The recording error is: " + errorRecording.ToString ());
		}

		// I never see the ff message:
		MessageBox.Show ("Debug MSSG after setting up the recorder");

		MessageBox.Show ("Should have recorded");

	}

	void OnClickStop(object sender, EventArgs e) {

		MessageBox.Show ("Stop ... a place to check code.");
	}

	void OnClickPlay(object sender, EventArgs e) {
		// MessageBox.Show ("Playing");
		string mediaPath;
		mediaPath = "../../media/applause_y.wav";
		NSUrl mediaURL = new NSUrl (mediaPath);
		NSError error = new NSError ();
		AVAudioPlayer myAudioPlayer = new AVAudioPlayer (mediaURL, error);
		myAudioPlayer.PrepareToPlay ();
		myAudioPlayer.Play ();
	}

	void OnClickQuit(object sender, EventArgs e) {
		Close ();
	}
		
}

class MApplication {
	public static void Main() {
		System.Windows.Forms.Application.Run(new MForm());
	}
}
