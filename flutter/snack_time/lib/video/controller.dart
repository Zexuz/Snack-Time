import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:video_player/video_player.dart';

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
          this.widget.controller.seekTo(Duration(seconds: (this.widget.controller.value.duration.inSeconds * percentage).toInt()));
        });
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
