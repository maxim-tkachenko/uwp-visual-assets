using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

namespace VisualAssetsApp
{
    /// <summary>
    /// Main page for the visual assets example app
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SendBadgeNotification_Click(object sender, RoutedEventArgs e)
        {
            string xmlContent = "<badge version='1' value='64'/>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            BadgeNotification notification = new BadgeNotification(xmlDoc);

            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(notification);
        }

        private void ClearBadgeNotification_Click(object sender, RoutedEventArgs e)
        {
            string xmlContent = "<badge version='1' value='0'/>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            BadgeNotification notification = new BadgeNotification(xmlDoc);

            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(notification);
        }

        private void SendToastNotification_Click(object sender, RoutedEventArgs e)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Toast notification"));

            var toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", "Assets/Square44x44Logo.png");
            //((XmlElement)toastImageAttributes[0]).SetAttribute("src", "https://i.stack.imgur.com/wzdIt.jpg");

            ToastNotification toast = new ToastNotification(toastXml);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
