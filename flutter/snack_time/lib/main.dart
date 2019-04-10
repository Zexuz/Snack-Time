import 'package:snack_time/fadeAnimation.dart';
import 'package:video_player/video_player.dart';
import 'package:flutter/material.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(title: 'Name generator', home: VideoApp());
  }
}

class VideoApp extends StatefulWidget {
  @override
  _VideoAppState createState() => _VideoAppState();
}

class _VideoAppState extends State<VideoApp> {
  VideoPlayerController _player;

  _VideoAppState() {
    listener = () {
      setState(() {});
    };
  }

  VoidCallback listener;
  FadeAnimation imageFadeAnim = FadeAnimation(child: const Icon(Icons.play_arrow, size: 100.0));

  @override
  void initState() {
    super.initState();
    _player = VideoPlayerController.network('https://www.sample-videos.com/video123/mp4/720/big_buck_bunny_720p_20mb.mp4')
      ..initialize().then((_) {
        // Ensure the first frame is shown after the video is initialized, even before the play button has been pressed.
        setState(() {});
      });
    _player.setVolume(1.0);
    _player.addListener(listener);
  }

  bool _visible = true;

  @override
  Widget build(BuildContext context) {
    final List<Widget> playAndPause = <Widget>[
      Center(
        child: GestureDetector(
          child: _player.value.initialized
              ? AspectRatio(
            aspectRatio: _player.value.aspectRatio,
            child: VideoPlayer(_player),
          )
              : Container(),
          onTap: () {
            if (_player.value.isPlaying) {
              imageFadeAnim = FadeAnimation(child: const Icon(Icons.pause, size: 100.0));
              _player.pause();
            } else {
              imageFadeAnim = FadeAnimation(child: const Icon(Icons.play_arrow, size: 100.0));
              _player.play();
            }
          },
          onVerticalDragEnd: (DragEndDetails details){
            if(details.primaryVelocity == 0)
              return;

            if(details.primaryVelocity > 0)
              _visible = false;
            if(details.primaryVelocity < 0){
              _visible = true;
            }
            setState(() {});
          },
        ),
      ),
      Center(
        child: imageFadeAnim,
      ),
    ];


    return Scaffold(
      appBar: AppBar(
        title: Text("SomeTitle"),
      ),
      body: Column(
        children: <Widget>[
          Stack(
            alignment: const Alignment(0.0, 1.0),
            children: <Widget>[
              Stack(
                alignment: const Alignment(0.0, 0.0),
                fit: StackFit.passthrough,
                children: playAndPause,
              ),
              Center(
                child: AnimatedOpacity(
                  opacity: _visible ? 1.0 : 0.0,
                  duration: Duration(milliseconds: 500),
                  child: Controller(this._player),
                ),
              ),
            ],
          ),
          Center(
            child: FloatingActionButton(
              child: new Icon(Icons.settings_backup_restore),
              onPressed: () {
                _player.seekTo(
                  Duration(seconds: 0),
                );
              },
            ),
          ),
          Center(
            child: FloatingActionButton(
              child: new Icon(Icons.add),
              onPressed: () {
                setState(() {
                  _visible = !_visible;
                });
              },
            ),
          ),
        ],
      ),
    );
  }

  @override
  void dispose() {
    super.dispose();
    _player.dispose();
  }
}

class Controller extends StatefulWidget {
  Controller(this.controller);

  final VideoPlayerController controller;

  @override
  _ControllerState createState() => _ControllerState();
}

class _ControllerState extends State<Controller> {
  double percentage = 0;
  double size = 20;

  @override
  Widget build(BuildContext context) {
    if (!this.widget.controller.value.initialized) {
      return Center(child: Text("Loadning"));
    }
    var percentageLeft = (this.widget.controller.value.position.inSeconds / this.widget.controller.value.duration.inSeconds);

    var width = MediaQuery.of(context).size.width;
    RenderBox getBox = context.findRenderObject();

    return Center(
        child: GestureDetector(
      onPanUpdate: (DragUpdateDetails details) {
        var local = getBox.globalToLocal(details.globalPosition);
        setState(() {
          percentage = local.dx / width;
        });
      },
      onPanEnd: (DragEndDetails details) {
        this.widget.controller.seekTo(Duration(seconds: (this.widget.controller.value.duration.inSeconds * percentage).toInt()));
      },
      child: Column(
        children: <Widget>[
          SizedBox(
            height: size,
            child: LinearProgressIndicator(
              backgroundColor: Colors.grey,
              value: percentageLeft,
            ),
          ),
        ],
      ),
    ));
  }
}
