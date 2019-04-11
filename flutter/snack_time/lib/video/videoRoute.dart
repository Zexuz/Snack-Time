import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import 'package:video_player/video_player.dart';

import 'package:snack_time/fadeAnimation.dart';
import 'package:snack_time/video/controller.dart';

class VideoRoute extends StatefulWidget {
  @override
  _VideoRouteState createState() => _VideoRouteState();
}

class _VideoRouteState extends State<VideoRoute> {
  VideoPlayerController _player;

  _VideoRouteState() {
    listener = () {
      setState(() {});
    };
  }

  VoidCallback listener;
  FadeAnimation imageFadeAnim = FadeAnimation(child: const Icon(Icons.play_arrow, size: 100.0));

  @override
  void initState() {
    super.initState();

    SystemChrome.setEnabledSystemUIOverlays([]);
    SystemChrome.setPreferredOrientations([
      DeviceOrientation.landscapeLeft,
      DeviceOrientation.landscapeRight,
    ]);

    _player = VideoPlayerController.asset('media/big_buck_bunny_720p_20mb.mp4')
      ..initialize().then((_) {
        // Ensure the first frame is shown after the video is initialized, even before the play button has been pressed.
        setState(() {});
      });
    _player.setVolume(1.0);
    _player.addListener(listener);
  }

  bool _visible = true;

  double _getScreenRatio([bool fitToScreen = true]){
    MediaQueryData queryData;
    queryData = MediaQuery.of(context);

//    print('screen aspect: ' + screenAspect.toString());
//    print('media aspect: ' + _player.value.aspectRatio.toString());

    if(fitToScreen) {
      var screenAspect = queryData.size.width / queryData.size.height;
      return screenAspect;
    }

    return     _player.value.aspectRatio;
  }

  @override
  Widget build(BuildContext context) {
    final List<Widget> playAndPause = <Widget>[
      Center(
        child: GestureDetector(
          child: _player.value.initialized
              ? AspectRatio(
                  aspectRatio: _getScreenRatio(),
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
          onVerticalDragEnd: (DragEndDetails details) {
            if (details.primaryVelocity == 0) return;

            if (details.primaryVelocity > 0) _visible = false;
            if (details.primaryVelocity < 0) {
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

    return Center(
      child: Column(
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
