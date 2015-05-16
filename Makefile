BUILD_DIR=Build
XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=XCodeProject/apptentive-ios/ApptentiveConnect
PROJECT=$(PROJECT_ROOT)/ApptentiveConnect.xcodeproj
TARGET=ApptentiveConnect
TARGET_BUNDLE=ApptentiveResources
XAMARIN_BUILD=/Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
BINDING_PROJECT_ROOT=BindingProject

all: ApptentiveConnect.dll

libApptentiveConnect-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $(BUILD_DIR)/$@

libApptentiveConnect-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $(BUILD_DIR)/$@

libApptentiveConnect-armv7s.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $(BUILD_DIR)/$@

libApptentiveConnect-arm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $(BUILD_DIR)/$@
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/$(TARGET_BUNDLE).bundle $(BUILD_DIR)/$(TARGET_BUNDLE).bundle

libApptentiveConnect.a: libApptentiveConnect-i386.a libApptentiveConnect-armv7.a libApptentiveConnect-armv7s.a libApptentiveConnect-arm64.a
	lipo -create -output $(BUILD_DIR)/$@ $(addprefix $(BUILD_DIR)/,$^)

ApptentiveConnect.dll: libApptentiveConnect.a
	-cp $(BUILD_DIR)/libApptentiveConnect.a $(BINDING_PROJECT_ROOT)/libApptentiveConnect.a
	-cp -r $(BUILD_DIR)/ApptentiveResources.bundle $(BINDING_PROJECT_ROOT)/Resources/ApptentiveResources.bundle
	$(XAMARIN_BUILD) -v build "--configuration:Release" $(BINDING_PROJECT_ROOT)/ApptentiveConnect.sln
	-cp $(BINDING_PROJECT_ROOT)/bin/Release/ApptentiveConnect.dll $(BUILD_DIR)/ApptentiveConnect.dll

clean:
	-rm -f *.a *.dll
