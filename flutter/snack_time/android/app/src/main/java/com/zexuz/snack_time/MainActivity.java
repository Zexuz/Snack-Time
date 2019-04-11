package com.zexuz.snack_time;

import android.os.Bundle;
import android.os.Environment;
import android.os.StatFs;

import java.io.File;

import io.flutter.app.FlutterActivity;
import io.flutter.plugins.GeneratedPluginRegistrant;
import io.flutter.plugin.common.MethodCall;
import io.flutter.plugin.common.MethodChannel;
import io.flutter.plugin.common.MethodChannel.MethodCallHandler;
import io.flutter.plugin.common.MethodChannel.Result;

public class MainActivity extends FlutterActivity {
    private static final String CHANNEL = "com.zexuz.device/battery";

    @Override
    public void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        GeneratedPluginRegistrant.registerWith(this);

        new MethodChannel(getFlutterView(), CHANNEL).setMethodCallHandler(
                new MethodCallHandler() {
                    @Override
                    public void onMethodCall(MethodCall call, Result result) {

                        switch (call.method){
                            case "isExternalMemoryAvailable": result.success(isExternalMemoryAvailable());
                            case "getAvailableInternalMemorySize": result.success(getAvailableInternalMemorySize());
                            case "getTotalInternalMemorySize": result.success(getTotalInternalMemorySize());
                            case "getAvailableExternalMemorySize": result.success(getAvailableExternalMemorySize());
                            case "getTotalExternalMemorySize": result.success(getTotalExternalMemorySize());
                            default:
                                result.notImplemented();
                        }
                    }
                });
    }

    public static boolean isExternalMemoryAvailable() {
        return !Environment.getExternalStorageState().equals(Environment.MEDIA_MOUNTED);
    }

    public static Long getAvailableInternalMemorySize() {
        File path = Environment.getDataDirectory();
        StatFs stat = new StatFs(path.getPath());
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.JELLY_BEAN_MR2) {
            long blockSize = stat.getBlockSizeLong();
            long availableBlocks = stat.getAvailableBlocksLong();
            return availableBlocks * blockSize;
        }
        return 0L;
    }

    public static Long getTotalInternalMemorySize() {
        File path = Environment.getDataDirectory();
        StatFs stat = new StatFs(path.getPath());
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.JELLY_BEAN_MR2) {
            long blockSize = stat.getBlockSizeLong();
            long totalBlocks = stat.getBlockCountLong();
            return totalBlocks * blockSize;
        }
        return 0L;
    }

    public static Long getAvailableExternalMemorySize() {
        if (!isExternalMemoryAvailable()) {
            return 0L;
        }
        File path = Environment.getExternalStorageDirectory();
        StatFs stat = new StatFs(path.getPath());
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.JELLY_BEAN_MR2) {
            long blockSize = stat.getBlockSizeLong();
            long availableBlocks = stat.getAvailableBlocksLong();
            return availableBlocks * blockSize;
        }
        return 0L;
    }

    public static Long getTotalExternalMemorySize() {
        if (!isExternalMemoryAvailable()) {
            return 0L;
        }
        File path = Environment.getExternalStorageDirectory();
        StatFs stat = new StatFs(path.getPath());

        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.JELLY_BEAN_MR2) {
            long blockSize = stat.getBlockSizeLong();
            long totalBlocks = stat.getBlockCountLong();
            return totalBlocks * blockSize;
        }
        return 0L;
    }
}
