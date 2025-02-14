﻿using Functions.API;

namespace Functions;

public class Wiki
{
    /// <summary>
    /// Provides access to the en namespace keys e.g. Category:
    /// </summary>
    public readonly Dictionary<int, string> CanonicalNamespaces = new Dictionary<int, string>(20);

    /// <summary>
    /// Whether the wiki capitalizes first letter of page names (usually yes, e.g. English Wikipedia) or not (e.g. Wiktionary)
    /// This is based on the value of $wgCapitalLinks
    /// No need to provide getters and setters for this since we don't need to private the setter like the others etc.
    /// </summary>
    public bool CapitalizeFirstLetter = true;

    /// <summary>
    /// index.php 
    /// </summary>
    public string IndexPHP { get; private set; } = "index.php";

    /// <summary>
    /// api.php 
    /// </summary>
    public string ApiPHP { get; private set; } = "api.php";

    /// <summary>
    /// An instance of the API client we should use for all requests to the API
    /// Might need to amend this later but generally this sounds sensible to be here
    /// since the API is dependent on the wiki
    /// </summary>
    public ApiClient ApiClient { get; private set; }
    
    /// <summary>
    /// The script path, whether it is /w/ (/w/index.php) or / (/index.php)
    /// </summary>
    public string ScriptPath { get; set; } = "/";
    
    /// <summary>
    /// The edit summary used when fixing typos
    /// Should not start with spaces or commas. Must end with a space
    /// </summary>
    public string TypoSummaryTag { get; private set; } = "typos fixed: ";

    /// <summary>
    /// Localized version of " using " for edit summary tag
    /// Does not need spaces at start or end
    /// </summary>
    private string mSummaryTag = "using ";
    
    /// <summary>
    /// Whether the wiki uses Unicode (uca-) sorting for category sort keys, i.e. the wgCategoryCollation value is a uca-type
    /// </summary>
    public bool UnicodeCategoryCollation = false;
    
    public string WPAWB { get; private set; } = "[https://github.com/OAuthority/AWBv2 AWBv2]";

    /// <summary>
    /// The UserAgent we should use for requests; inspiration taken from WMF user agent policy
    /// see: https://foundation.wikimedia.org/wiki/Policy:Wikimedia_Foundation_User-Agent_Policy
    /// </summary>
    public string UserAgent { get; } = "AWBv2/0.0.0 (https://github.com/OAuthority/AWBv2)";
    
    /// <summary>
    /// The url of the wiki
    /// </summary>
    public string Url { get; private set; }
    
    /// <summary>
    /// localized names of months
    /// </summary>
    public string[] MonthNames;
    
    /// <summary>
    /// Month names for when the user is using English; since this is the most common.
    /// </summary>
    public readonly string[] ENLangMonthNames =
    {
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
    };
    
    /// <summary>
    /// Gets the language code, e.g. "en".
    /// </summary>
    public string LangCode { get; internal set; }
    
    /// <summary>
    /// Private constructor -- call the factory method since constructors CANNOT handle async operations.
    /// </summary>
    /// <param name="url"></param>
    private Wiki(string url)
    {
        // in the event someone gives https://meta.telepedia.net/ we need to remove the trailing
        // slash to ensure we don't end up with ...net//index.php?
        Url = url.TrimEnd('/');
        
        // setup namespaces -- probably cut alot of these down in the future to remove all of the wikipedia 
        // specific stuff. The vision I have for this is that it isn't overly Wikipedia specific, but I guess,
        // there would be no harm in this at present. 
        CanonicalNamespaces[-2] = "Media:";
        CanonicalNamespaces[-1] = "Special:";
        CanonicalNamespaces[1] = "Talk:";
        CanonicalNamespaces[2] = "User:";
        CanonicalNamespaces[3] = "User talk:";
        CanonicalNamespaces[4] = "Project:";
        CanonicalNamespaces[5] = "Project talk:";
        CanonicalNamespaces[6] = "File:";
        CanonicalNamespaces[7] = "File talk:";
        CanonicalNamespaces[8] = "MediaWiki:";
        CanonicalNamespaces[9] = "MediaWiki talk:";
        CanonicalNamespaces[10] = "Template:";
        CanonicalNamespaces[11] = "Template talk:";
        CanonicalNamespaces[12] = "Help:";
        CanonicalNamespaces[13] = "Help talk:";
        CanonicalNamespaces[14] = "Category:";
        CanonicalNamespaces[15] = "Category talk:";
        CanonicalNamespaces[828] = "Module:";
        CanonicalNamespaces[829] = "Module talk:";
    }

    /// <summary>
    /// Factory method for instantiating this class; this allows us to handle async operations
    /// when instantiating the class rather than a sync constructor which blocks the thread.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static async Task<Wiki> CreateAsync(string url)
    {
        Wiki wiki = new Wiki(url);
        wiki.ApiClient = new ApiClient(wiki);
        await wiki.ApiClient.DetermineScriptPathAsync();
        return wiki;
    }
    
}