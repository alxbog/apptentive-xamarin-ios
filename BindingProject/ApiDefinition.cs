using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace ApptentiveConnect {

    // @interface ATConnect : NSObject
    [BaseType (typeof (NSObject))]
    interface ATConnect {

        // @property (copy, nonatomic) NSString * apiKey;
        [Export ("apiKey")]
        string ApiKey { get; set; }

        // @property (copy, nonatomic) NSString * appID;
        [Export ("appID")]
        string AppID { get; set; }

        // @property (assign, nonatomic) BOOL showEmailField;
        [Export ("showEmailField", ArgumentSemantic.UnsafeUnretained)]
        bool ShowEmailField { get; set; }

        // @property (copy, nonatomic) NSString * customPlaceholderText;
        [Export ("customPlaceholderText")]
        string CustomPlaceholderText { get; set; }

        // @property (assign, nonatomic) BOOL useMessageCenter;
        [Availability (Deprecated = Platform.iOS_7_0 | Platform.Mac_10_10)]
        [Export ("useMessageCenter", ArgumentSemantic.UnsafeUnretained)]
        bool UseMessageCenter { get; set; }

        // @property (assign, nonatomic) BOOL initiallyUseMessageCenter;
        [Export ("initiallyUseMessageCenter", ArgumentSemantic.UnsafeUnretained)]
        bool InitiallyUseMessageCenter { get; set; }

        // @property (assign, nonatomic) BOOL initiallyHideBranding;
        [Export ("initiallyHideBranding", ArgumentSemantic.UnsafeUnretained)]
        bool InitiallyHideBranding { get; set; }

        // @property (retain, nonatomic) UIColor * tintColor;
        [Export ("tintColor", ArgumentSemantic.Retain)]
        UIColor TintColor { get; set; }

        // @property (copy, nonatomic) NSString * initialUserName;
        [Export ("initialUserName")]
        string InitialUserName { get; set; }

        // @property (copy, nonatomic) NSString * initialUserEmailAddress;
        [Export ("initialUserEmailAddress")]
        string InitialUserEmailAddress { get; set; }

        // +(ATConnect *)sharedConnection;
        [Static, Export ("sharedConnection")]
        ATConnect SharedConnection ();

        // -(void)presentMessageCenterFromViewController:(UIViewController *)viewController;
        [Export ("presentMessageCenterFromViewController:")]
        void PresentMessageCenterFromViewController (UIViewController viewController);

        // -(void)presentMessageCenterFromViewController:(UIViewController *)viewController withCustomData:(NSDictionary *)customData;
        [Export ("presentMessageCenterFromViewController:withCustomData:")]
        void PresentMessageCenterFromViewController (UIViewController viewController, NSDictionary customData);

        // -(NSUInteger)unreadMessageCount;
        [Export ("unreadMessageCount")]
        nuint UnreadMessageCount ();

        // -(void)didReceiveRemoteNotification:(NSDictionary *)userInfo fromViewController:(UIViewController *)viewController;
        [Export ("didReceiveRemoteNotification:fromViewController:")]
        void DidReceiveRemoteNotification (NSDictionary userInfo, UIViewController viewController);

        // -(BOOL)willShowInteractionForEvent:(NSString *)event;
        [Export ("willShowInteractionForEvent:")]
        bool WillShowInteractionForEvent (string ev);

        // -(BOOL)engage:(NSString *)event fromViewController:(UIViewController *)viewController;
        [Export ("engage:fromViewController:")]
        bool Engage (string ev, UIViewController viewController);

        // -(BOOL)engage:(NSString *)event withCustomData:(NSDictionary *)customData fromViewController:(UIViewController *)viewController;
        [Export ("engage:withCustomData:fromViewController:")]
        bool Engage (string ev, NSDictionary customData, UIViewController viewController);

        // -(BOOL)engage:(NSString *)event withCustomData:(NSDictionary *)customData withExtendedData:(NSArray *)extendedData fromViewController:(UIViewController *)viewController;
        [Export ("engage:withCustomData:withExtendedData:fromViewController:")]
        bool Engage (string ev, NSDictionary customData, NSObject [] extendedData, UIViewController viewController);

        // -(void)dismissMessageCenterAnimated:(BOOL)animated completion:(void (^)(void))completion;
        [Export ("dismissMessageCenterAnimated:completion:")]
        void DismissMessageCenterAnimated (bool animated, Action completion);

        // +(NSDictionary *)extendedDataDate:(NSDate *)date;
        [Static, Export ("extendedDataDate:")]
        NSDictionary ExtendedDataDate (NSDate date);

        // +(NSDictionary *)extendedDataLocationForLatitude:(double)latitude longitude:(double)longitude;
        [Static, Export ("extendedDataLocationForLatitude:longitude:")]
        NSDictionary ExtendedDataLocationForLatitude (double latitude, double longitude);

        // +(NSDictionary *)extendedDataCommerceWithTransactionID:(NSString *)transactionID affiliation:(NSString *)affiliation revenue:(NSNumber *)revenue shipping:(NSNumber *)shipping tax:(NSNumber *)tax currency:(NSString *)currency commerceItems:(NSArray *)commerceItems;
        [Static, Export ("extendedDataCommerceWithTransactionID:affiliation:revenue:shipping:tax:currency:commerceItems:")]
        NSDictionary ExtendedDataCommerceWithTransactionID (string transactionID, string affiliation, NSNumber revenue, NSNumber shipping, NSNumber tax, string currency, NSObject [] commerceItems);

        // +(NSDictionary *)extendedDataCommerceItemWithItemID:(NSString *)itemID name:(NSString *)name category:(NSString *)category price:(NSNumber *)price quantity:(NSNumber *)quantity currency:(NSString *)currency;
        [Static, Export ("extendedDataCommerceItemWithItemID:name:category:price:quantity:currency:")]
        NSDictionary ExtendedDataCommerceItemWithItemID (string itemID, string name, string category, NSNumber price, NSNumber quantity, string currency);

        // -(void)sendAttachmentText:(NSString *)text;
        [Export ("sendAttachmentText:")]
        void SendAttachmentText (string text);

        // -(void)sendAttachmentImage:(UIImage *)image;
        [Export ("sendAttachmentImage:")]
        void SendAttachmentImage (UIImage image);

        // -(void)sendAttachmentFile:(NSData *)fileData withMimeType:(NSString *)mimeType;
        [Export ("sendAttachmentFile:withMimeType:")]
        void SendAttachmentFile (NSData fileData, string mimeType);

        // -(void)addCustomPersonData:(NSObject<NSCoding> *)object withKey:(NSString *)key;
        [Export ("addCustomPersonData:withKey:")]
        void AddCustomPersonData (NSObject obj, string key);

        // -(void)addCustomDeviceData:(NSObject<NSCoding> *)object withKey:(NSString *)key;
        [Export ("addCustomDeviceData:withKey:")]
        void AddCustomDeviceData (NSObject obj, string key);

        // -(void)removeCustomPersonDataWithKey:(NSString *)key;
        [Export ("removeCustomPersonDataWithKey:")]
        void RemoveCustomPersonDataWithKey (string key);

        // -(void)removeCustomDeviceDataWithKey:(NSString *)key;
        [Export ("removeCustomDeviceDataWithKey:")]
        void RemoveCustomDeviceDataWithKey (string key);

        // -(void)addCustomData:(NSObject<NSCoding> *)object withKey:(NSString *)key;
        [Availability (Deprecated = Platform.iOS_7_0 | Platform.Mac_10_10)]
        [Export ("addCustomData:withKey:")]
        void AddCustomData (NSObject obj, string key);

        // -(void)removeCustomDataWithKey:(NSString *)key;
        [Availability (Deprecated = Platform.iOS_7_0 | Platform.Mac_10_10)]
        [Export ("removeCustomDataWithKey:")]
        void RemoveCustomDataWithKey (string key);

        // -(void)openAppStore;
        [Export ("openAppStore")]
        void OpenAppStore ();

        // -(void)addIntegration:(NSString *)integration withConfiguration:(NSDictionary *)configuration;
        [Export ("addIntegration:withConfiguration:")]
        void AddIntegration (string integration, NSDictionary configuration);

        // -(void)addIntegration:(NSString *)integration withDeviceToken:(NSData *)deviceToken;
        [Export ("addIntegration:withDeviceToken:")]
        void AddIntegration (string integration, NSData deviceToken);

        // -(void)removeIntegration:(NSString *)integration;
        [Export ("removeIntegration:")]
        void RemoveIntegration (string integration);

        // -(void)addUrbanAirshipIntegrationWithDeviceToken:(NSData *)deviceToken;
        [Export ("addUrbanAirshipIntegrationWithDeviceToken:")]
        void AddUrbanAirshipIntegrationWithDeviceToken (NSData deviceToken);

        // -(void)addAmazonSNSIntegrationWithDeviceToken:(NSData *)deviceToken;
        [Export ("addAmazonSNSIntegrationWithDeviceToken:")]
        void AddAmazonSNSIntegrationWithDeviceToken (NSData deviceToken);

        // -(void)addParseIntegrationWithDeviceToken:(NSData *)deviceToken;
        [Export ("addParseIntegrationWithDeviceToken:")]
        void AddParseIntegrationWithDeviceToken (NSData deviceToken);
    }
}


