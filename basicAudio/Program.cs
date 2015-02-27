using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
// using MonoMac;
// using MonoMac.Foundation;
// using MonoMac.AppKit;
// using MonoMac.AVFoundation;
// using MonoMac.AudioUnit;
// using MonoMac.AudioToolbox;
// using MonoMac.AudioUnitWrapper;

using BasicAudio;


class MForm : Form {
	public AudioInterface _audioDevice = new AudioInterface();
	public int _audioError;

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
		_audioError = _audioDevice.Record();
		if (_audioError != 0) {
			MessageBox.Show ("Recording error is: " + _audioError.ToString ());
		}
		return; // right for now ignore all the real code which doesn't even work on Mac OSX 10.6!

	}

	void OnClickStop(object sender, EventArgs e) {
		_audioError = _audioDevice.Stop();
		if (_audioError != 0) {
			MessageBox.Show ("Stop recording error is: " + _audioError.ToString ());
		}
		return; // right for now ignore all the real code which doesn't even work on Mac OSX 10.6!

	}

	void OnClickPlay(object sender, EventArgs e) {
		_audioError = _audioDevice.Play();
		if (_audioError != 0) {
			MessageBox.Show ("Playing error is: " + _audioError.ToString ());
		}
		return; // right for now ignore all the real code which doesn't even work on Mac OSX 10.6!

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
