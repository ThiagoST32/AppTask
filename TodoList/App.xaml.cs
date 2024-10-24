using Microsoft.Maui.Platform;
using TodoList.Views;

namespace TodoList
{
    public partial class App : Application
    {
        public App()
        {

            CustomHandler(); 

            InitializeComponent();

            MainPage = new NavigationPage (new StartPage());
            
        }

        private void CustomHandler()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
                Colors.AliceBlue.ToPlatform();
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#endif


#if IOS || MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif


#if WINDOWS
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
                });
            
        }
    }
}
