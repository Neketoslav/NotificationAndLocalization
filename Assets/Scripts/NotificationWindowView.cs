using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;


public class NotificationWindowView : MonoBehaviour
{
    private const string AndroidChannelID = "android_id";
    private const string IOSChannelID = "IOS_id";
    [SerializeField]
    private Button _showNotificationButton;
    private void Start()
    {
        _showNotificationButton.onClick.AddListener(CreateNotificator);
    }

    private void OnDestroy()
    {
        _showNotificationButton.onClick.RemoveAllListeners();
    }
    private void CreateNotificator()
    {
#if UNITY_ANDROID
        NotificationAndroid();
#elif UNITY_IOS
        NotificationsIOS();
#endif
    }

    private void NotificationAndroid()
    {
        var androidSettingsChannel = new AndroidNotificationChannel()
        {
            Id = AndroidChannelID,
            Name = "Notification",
            Description = "Description",
            CanBypassDnd = true,
            EnableVibration = true
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChannel);

        var androidNotification = new AndroidNotification()
        {
            Color = Color.white,
            RepeatInterval = TimeSpan.FromSeconds(2000),
            FireTime = DateTime.Now + TimeSpan.FromSeconds(2000),
        };

        AndroidNotificationCenter.SendNotification(androidNotification, AndroidChannelID);
    }

    private void NotificationsIOS()
    {
        var iosNotification = new iOSNotification
        {
            Identifier = IOSChannelID,
            Title = "Title",
            Body = "Body",
            ForegroundPresentationOption = PresentationOption.Alert | PresentationOption.Sound,
            Data = "31/01/2022",
            ShowInForeground = false
        };

        iOSNotificationCenter.ScheduleNotification(iosNotification);
    }
}
