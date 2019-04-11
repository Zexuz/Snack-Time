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

class StartRoute extends StatelessWidget {
  StartRoute() {
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
        body: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              RaisedButton(
                  child: Text("Start video"),
                  onPressed: () => Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => VideoRoute()),
                      )),
              RaisedButton(
                  child: Text("Playground"),
                  onPressed: () => Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => PlaygroundRoute()),
                      )),
            ],
          ),
        ));
  }
}

class PlaygroundRoute extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _PlaygroundRoute();
}

class _PlaygroundRoute extends State<PlaygroundRoute> {
  static const platform = const MethodChannel('com.zexuz.device/battery');

  static const suffix = {
    0: "Bytes",
    1: "KB",
    2: "MB",
    3: "GB",
  };

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Column(mainAxisAlignment: MainAxisAlignment.center, crossAxisAlignment: CrossAxisAlignment.center, children: [
          RaisedButton(
            onPressed: _isExternalMemoryAvailable,
            child: Text("Get battery level"),
          ),
          Text(_batteryLevel),
          RaisedButton(
            onPressed: _getAvailableInternalMemorySize,
            child: Text("Get internal"),
          ),
          Text(_getSizeAsString(_availableInternalMemory)),
          RaisedButton(
            onPressed: _getTotalInternalMemorySize,
            child: Text("Get total internal"),
          ),
          Text(_getSizeAsString(_totalInternalMemory)),
          RaisedButton(
            onPressed: _getAvailableExternalMemory,
            child: Text("Get extrnal"),
          ),
          Text(_getSizeAsString(_availableExternalMemory)),
          RaisedButton(
            onPressed: _getTotalExternalMemorySize,
            child: Text("Get external total"),
          ),
          Text(_getSizeAsString(_totalExternalMemorySize)),
        ]),
      ),
    );
  }

  String _batteryLevel = 'Unknown battery level.';

  Future<void> _isExternalMemoryAvailable() async {
    String batteryLevel;
    try {
      batteryLevel = (await platform.invokeMethod('isExternalMemoryAvailable')).toString();
    } on PlatformException catch (e) {
      batteryLevel = "Failed to get battery level: '${e.message}'.";
    }

    setState(() {
      _batteryLevel = batteryLevel;
    });
  }

  double _availableInternalMemory = 0;
  Future<void> _getAvailableInternalMemorySize() async {
    int spaceLeft = await platform.invokeMethod('getAvailableInternalMemorySize');
    setState(() {
      _availableInternalMemory = spaceLeft.toDouble();
    });
  }

  double _totalInternalMemory = 0;
  Future<void> _getTotalInternalMemorySize() async {
    int spaceLeft = await platform.invokeMethod('getTotalInternalMemorySize');
    setState(() {
      _totalInternalMemory = spaceLeft.toDouble();
    });
  }

  double _availableExternalMemory = 0;
  Future<void> _getAvailableExternalMemory() async {
    int spaceLeft = await platform.invokeMethod('getAvailableExternalMemorySize');
    setState(() {
      _availableExternalMemory = spaceLeft.toDouble();
    });
  }
  double _totalExternalMemorySize= 0;
  Future<void> _getTotalExternalMemorySize() async {
    int spaceLeft = await platform.invokeMethod('getTotalExternalMemorySize');
    setState(() {
      _totalExternalMemorySize = spaceLeft.toDouble();
    });
  }

  String _getSizeAsString(double size) {
    int i = 0;
    while (size > 1024) {
      i++;
      size /= 1024;
    }

    return "${suffix[i]} ${size.toStringAsPrecision(4)}";
  }
}
