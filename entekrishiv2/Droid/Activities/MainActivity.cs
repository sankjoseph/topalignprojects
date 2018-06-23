using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Webkit;
//test//test2
namespace entekrishiv2.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@mipmap/icon",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    {
        protected override int LayoutResource => Resource.Layout.activity_main;

        ViewPager pager;
        TabsAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            adapter = new TabsAdapter(this, SupportFragmentManager);
            var tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            WebView webView1 = FindViewById<WebView>(Resource.Id.webView1);

            WebSettings websettings = webView1.Settings;

            websettings.JavaScriptEnabled = true;

            webView1.LoadUrl("http://jasminbooks.com/test/entekrishi/entekrishi_05_06_2018/");
      
            //webView1.LoadUrl("http://entekrishi.com/");



            webView1.SetWebViewClient(new WebViewClientClass());  

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }


    }

    class TabsAdapter : FragmentStatePagerAdapter
    {
        string[] titles;

        public override int Count => titles.Length;

        public TabsAdapter(Context context, Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
            titles = context.Resources.GetTextArray(Resource.Array.sections);
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position) =>
                            new Java.Lang.String(titles[position]);

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0: return BrowseFragment.NewInstance();
                case 1: return AboutFragment.NewInstance();
            }
            return null;
        }

        public override int GetItemPosition(Java.Lang.Object frag) => PositionNone;
    }


    internal class WebViewClientClass : WebViewClient  
    {  
        //Give the host application a chance to take over the control when a new URL is about to be loaded in the current WebView.  
        public override bool ShouldOverrideUrlLoading(WebView view, string url)  
        {  
            view.LoadUrl(url);  
            return true;  
        }  
    }  
}
