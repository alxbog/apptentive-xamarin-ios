using System;
using ObjCRuntime;

[assembly: LinkWith ("libApptentiveConnect.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
    SmartLink = true, ForceLoad = true,
    Frameworks = "Foundation SystemConfiguration CoreTelephony Accelerate CoreGraphics QuartzCore AssetsLibrary CoreData CoreText",
    WeakFrameworks = "UIKit StoreKit",
    LinkerFlags="-ObjC -all_load")]
