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
  VideoPlayerController _controller;

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
    _controller = VideoPlayerController.network('https://www.sample-videos.com/video123/mp4/720/big_buck_bunny_720p_20mb.mp4')
      ..initialize().then((_) {
        // Ensure the first frame is shown after the video is initialized, even before the play button has been pressed.
        setState(() {});
      });
    _controller.setVolume(1.0);
    _controller.addListener(listener);
  }

  @override
  Widget build(BuildContext context) {
    final List<Widget> children = <Widget>[
      Center(
        child: GestureDetector(
          child: _controller.value.initialized
              ? AspectRatio(
                  aspectRatio: _controller.value.aspectRatio,
                  child: VideoPlayer(_controller),
                )
              : Container(),
          onTap: () {
            if (_controller.value.isPlaying) {
              imageFadeAnim = FadeAnimation(child: const Icon(Icons.pause, size: 100.0));
              _controller.pause();
            } else {
              imageFadeAnim = FadeAnimation(child: const Icon(Icons.play_arrow, size: 100.0));
              _controller.play();
            }
          },
          onVerticalDragStart: (DragStartDetails details) {
            print("Drag stated");
          },
        ),
      ),
      Center(
        child: imageFadeAnim,
      )
    ];

    return Scaffold(
      appBar: AppBar(
        title: Text("SomeTitle"),
      ),
      body: Stack(
        fit: StackFit.passthrough,
        children: children,
      ),
    );
  }

  @override
  void dispose() {
    super.dispose();
    _controller.dispose();
  }
}
