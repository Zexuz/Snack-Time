import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:snack_time/video/videoRoute.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(title: 'SnackTime', home: StartRoute());
  }
}

class StartRoute extends StatelessWidget{

  StartRoute(){
    SystemChrome.setEnabledSystemUIOverlays([
      SystemUiOverlay.bottom,
      SystemUiOverlay.top,
    ]);
    SystemChrome.setPreferredOrientations([
      DeviceOrientation.portraitUp,
    ]);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('First Route'),
      ),
      body: RaisedButton(
          child: Text("Start video"),
          onPressed: () => Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => VideoRoute()),
              )),
    );
  }
}
