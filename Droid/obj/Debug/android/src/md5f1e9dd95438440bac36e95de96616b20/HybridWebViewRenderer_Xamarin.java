package md5f1e9dd95438440bac36e95de96616b20;


public class HybridWebViewRenderer_Xamarin
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_Call:(Ljava/lang/String;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("XLabs.Forms.Controls.HybridWebViewRenderer+Xamarin, XLabs.Forms.Droid, Version=2.0.5781.14062, Culture=neutral, PublicKeyToken=null", HybridWebViewRenderer_Xamarin.class, __md_methods);
	}


	public HybridWebViewRenderer_Xamarin () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HybridWebViewRenderer_Xamarin.class)
			mono.android.TypeManager.Activate ("XLabs.Forms.Controls.HybridWebViewRenderer+Xamarin, XLabs.Forms.Droid, Version=2.0.5781.14062, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public HybridWebViewRenderer_Xamarin (md5f1e9dd95438440bac36e95de96616b20.HybridWebViewRenderer p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == HybridWebViewRenderer_Xamarin.class)
			mono.android.TypeManager.Activate ("XLabs.Forms.Controls.HybridWebViewRenderer+Xamarin, XLabs.Forms.Droid, Version=2.0.5781.14062, Culture=neutral, PublicKeyToken=null", "XLabs.Forms.Controls.HybridWebViewRenderer, XLabs.Forms.Droid, Version=2.0.5781.14062, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	@android.webkit.JavascriptInterface

	public void call (java.lang.String p0)
	{
		n_Call (p0);
	}

	private native void n_Call (java.lang.String p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
