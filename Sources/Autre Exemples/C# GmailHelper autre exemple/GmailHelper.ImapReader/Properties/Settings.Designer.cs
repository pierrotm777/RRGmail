



  



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head><script type="text/javascript">var NREUMQ=NREUMQ||[];NREUMQ.push(["mark","firstbyte",new Date().getTime()]);</script>
    <title>GmailHelper/GmailHelper.ImapReader/Properties/Settings.Designer.cs | Source/SVN | Assembla</title>
    <link href="http://assets2.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="shortcut icon" />
    <link href="http://assets2.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="icon" />
    <link href="http://assets0.assembla.com/favicon.gif?1327583367" type="image/gif" rel="icon" />
    <meta name="csrf-param" content="authenticity_token"/>
<meta name="csrf-token" content="GZx56cbO63qFw4BGzaFwkPBWGjSVpnVxZYtx&#47;Xqkj40="/>
    <link href="http://www.assembla.com/assets/base_app_and_alerts.css?1340419163" media="all" rel="stylesheet" type="text/css" />
    
    
    <link href="http://www.assembla.com/assets/code.css?1340419163" media="all" rel="stylesheet" type="text/css" />  

    
    <!--[if IE 7]>
      <link href="http://www.assembla.com/assets/ie7.css?1340419163" media="all" rel="stylesheet" type="text/css" />
    <![endif]-->
    <!--[if lte IE 8]>
      <link href="http://www.assembla.com/assets/ie8.css?1340419163" media="all" rel="stylesheet" type="text/css" />
    <![endif]-->
    <link href="http://www.assembla.com/assets/print.css?1340419163" media="print" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
      if(!Breakout){var Breakout = {};}
          Breakout.space_wiki_name = "bniEmC9p0r3P96eJe5aVNr";
          Breakout.space_id = "bniEmC9p0r3P96eJe5aVNr";
        Breakout.controller_name = "spaces/nodes"
        Breakout.action_name = "show"
    </script>
    
    <script src="http://www.assembla.com/assets/base.js?1340419226" type="text/javascript"></script>
    <script src="http://www.assembla.com/assets/code.js?1340419163" type="text/javascript"></script>
    
    
      

      
  
  


    <!-- prevents swf file caching -->
    <meta http-equiv="PRAGMA" content="NO-CACHE" />
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    
  </head>

  <body class="locale_en" data-locale="en">
    
    <!--[if IE 6]>
      <div class="browser-ie6" style="display: none;"><div>
    <![endif]-->
    <div class="b-wrapper ">
      <a name="pagetop"></a>
        <script type="text/javascript">
    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-2641193-1']);
    _gaq.push(['_setDomainName', 'assembla.com']);
    _gaq.push(['_setCustomVar', 1, 'Logged', 'false', 1]);
    
    _gaq.push(['_trackPageview']);

    (function() {
      var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
      ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
      (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(ga);
    })();
  
  </script>


      <div class="hidden">
        <a href="#content">Skip to contents</a>
      </div>

      
        

<div id="header-w">
  <div id="header" class="_">
    <div id="header-links">
        <div id="user-box">
                <a href="/features/compare" class="try-assembla">Try Assembla</a>
  <a href="/login" class="login">Login</a>

        </div>
      <div class=""><span id="space-role">Free/Public Space</span></div>
    </div>
    <div id="logo">
      <div >
        <h1 class="header-w clear-float">
            <a href="/">
              <img src="/images/assembla-logo-small.png" alt="Go to Assembla" title="Go to Assembla" />
            </a>

            <span>mejl pomocnik</span>
        </h1>
      </div>
    </div>

    <div class="cut">&nbsp;</div>

  </div><!-- /header -->
</div><!-- /header-w -->

      
      <div id="main-menu-w">
        <ul class='clear-float' id='main-menu'><li class="current"><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes" class="icon-source">Source/SVN</a></li><li class=""><a href="/spaces/bniEmC9p0r3P96eJe5aVNr/wiki" class="icon-wiki">Wiki</a></li><li class=""><a href="/spaces/bniEmC9p0r3P96eJe5aVNr/team" class="icon-team">Team</a></li><li class=""><a href="/spaces/bniEmC9p0r3P96eJe5aVNr/stream" class="icon-stream">Stream</a></li><li class=""><a href="/spaces/bniEmC9p0r3P96eJe5aVNr/tickets" class="icon-ticket">Tickets</a></li><li class=""><a href="/spaces/bniEmC9p0r3P96eJe5aVNr/milestones" class="icon-milestone">Milestones</a></li><li class=""><a href="/spaces/bniEmC9p0r3P96eJe5aVNr/messages" class="icon-messages">Messages</a></li><li class="search-field"><form accept-charset="UTF-8" action="/spaces/bniEmC9p0r3P96eJe5aVNr/search" id="search-form" method="get"><div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="&#x2713;" /></div><input id="object_scope_top_right" name="object_scope" type="hidden" value="10" />
<input class="main-search" id="q" name="q" onfocus="this.value == 'Search this space' ? this.value = '' : true" size="15" type="text" value="Search this space" />
</form></li></ul>
      </div><!-- /main-menu-w -->

      <ul class='menu-submenu'><li><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes" class="first selected">Browse</a></li><li><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/changesets" class="">Changesets</a></li><li><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/sites" class="">Sites</a></li><li><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/repo/instructions" class=" last">Instructions</a></li></ul><div class='cut'></div>

      

      <div id="content" class="">
        
        
        
        
          <div class="repository-browser">
  <h1 class="icon-breadcrumb-path"><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=11" class="root">root</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper?rev=11">GmailHelper</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.ImapReader?rev=11">GmailHelper.ImapReader</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.ImapReader/Properties?rev=11">Properties</a>/<span>Settings.Designer.cs</span><span>    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
            width="110"
            height="14"
            id="clippy" >
    <param name="movie" value="/clippy.swf"/>
    <param name="allowScriptAccess" value="always" />
    <param name="quality" value="high" />
    <param name="scale" value="noscale" />
    <param NAME="FlashVars" value="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.ImapReader/Properties/Settings.Designer.cs/" />
    <param name="bgcolor" value="#FFFFFF" />
    <param name="wmode" value="transparent" />
    <embed src="/clippy.swf"
           width="110"
           height="14"
           name="clippy"
           quality="high"
           allowScriptAccess="always"
           type="application/x-shockwave-flash"
           pluginspage="http://www.macromedia.com/go/getflashplayer"
           FlashVars="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.ImapReader/Properties/Settings.Designer.cs/"
           bgcolor="#FFFFFF"
           wmode="transparent"
    />
    </object>
</span></h1>
  
<div class="commit-infobox">
  <div class="commit-options">
    <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/logs/GmailHelper/GmailHelper.ImapReader/Properties/Settings.Designer.cs?rev=11" class="revision-log" rel="nofollow">Revision log</a>
      <div style="margin-right: 10px;" class="small-icon-button">
        <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/live/11/GmailHelper/GmailHelper.ImapReader/Properties/Settings.Designer.cs" class="view-icon" rel="nofollow">View as a web page</a>
      </div>

        <div style="margin-right: 10px;" class="small-icon-button">
    <a class="download-icon" href="#" onclick="nobotGoto('!/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.ImapReader/Properties/Settings.Designer.cs?_format=raw&amp;rev=11'); return false;">Download</a>
  </div>


  </div>

  <div class="committer-pic">
    <img alt="User picture" src="http://assets0.assembla.com/images/no-picture.png?1340419163" />
  </div>

  
<div class="commit-info">

    <p class="committer-info"><span>Author:</span> <a href="/profile/kazazic" tabindex="-1" target="_blank" title="Show Profile">kazazic</a></p>

  <p class="committer-info"><span>Revision:</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/changesets/3">11</a> (<span>«<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=10">Previous</a></span> <span><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=12">Next</a>»</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes">Latest</a>)</p><br />
    <p class="commit-size">
      <span>File Size:</span>
      2.36 KB
    </p>
  <p class="commit-date">(December 30, 2009 04:42 UTC) Over 2 years ago</p>
</div>



  <p class="commit-description">
    <pre>
</pre>
  </p>
</div>

<div class="cut">&nbsp;</div>




      <a href="#" onclick="$(&quot;ln-num&quot;).toggle(); return false;">Show/hide line numbers</a>

      <table class="ln-code">
        <tbody class="full-width">
          <tr>
            <th id="ln-num" style="display: none;">
              <pre><a href="#ln1" class="block" id="ln1">1</a>
<a href="#ln2" class="block" id="ln2">2</a>
<a href="#ln3" class="block" id="ln3">3</a>
<a href="#ln4" class="block" id="ln4">4</a>
<a href="#ln5" class="block" id="ln5">5</a>
<a href="#ln6" class="block" id="ln6">6</a>
<a href="#ln7" class="block" id="ln7">7</a>
<a href="#ln8" class="block" id="ln8">8</a>
<a href="#ln9" class="block" id="ln9">9</a>
<a href="#ln10" class="block" id="ln10">10</a>
<a href="#ln11" class="block" id="ln11">11</a>
<a href="#ln12" class="block" id="ln12">12</a>
<a href="#ln13" class="block" id="ln13">13</a>
<a href="#ln14" class="block" id="ln14">14</a>
<a href="#ln15" class="block" id="ln15">15</a>
<a href="#ln16" class="block" id="ln16">16</a>
<a href="#ln17" class="block" id="ln17">17</a>
<a href="#ln18" class="block" id="ln18">18</a>
<a href="#ln19" class="block" id="ln19">19</a>
<a href="#ln20" class="block" id="ln20">20</a>
<a href="#ln21" class="block" id="ln21">21</a>
<a href="#ln22" class="block" id="ln22">22</a>
<a href="#ln23" class="block" id="ln23">23</a>
<a href="#ln24" class="block" id="ln24">24</a>
<a href="#ln25" class="block" id="ln25">25</a>
<a href="#ln26" class="block" id="ln26">26</a>
<a href="#ln27" class="block" id="ln27">27</a>
<a href="#ln28" class="block" id="ln28">28</a>
<a href="#ln29" class="block" id="ln29">29</a>
<a href="#ln30" class="block" id="ln30">30</a>
<a href="#ln31" class="block" id="ln31">31</a>
<a href="#ln32" class="block" id="ln32">32</a>
<a href="#ln33" class="block" id="ln33">33</a>
<a href="#ln34" class="block" id="ln34">34</a>
<a href="#ln35" class="block" id="ln35">35</a>
<a href="#ln36" class="block" id="ln36">36</a>
<a href="#ln37" class="block" id="ln37">37</a>
<a href="#ln38" class="block" id="ln38">38</a>
<a href="#ln39" class="block" id="ln39">39</a>
<a href="#ln40" class="block" id="ln40">40</a>
<a href="#ln41" class="block" id="ln41">41</a>
<a href="#ln42" class="block" id="ln42">42</a>
<a href="#ln43" class="block" id="ln43">43</a>
<a href="#ln44" class="block" id="ln44">44</a>
<a href="#ln45" class="block" id="ln45">45</a>
<a href="#ln46" class="block" id="ln46">46</a>
<a href="#ln47" class="block" id="ln47">47</a>
<a href="#ln48" class="block" id="ln48">48</a>
<a href="#ln49" class="block" id="ln49">49</a>
<a href="#ln50" class="block" id="ln50">50</a>
<a href="#ln51" class="block" id="ln51">51</a>
<a href="#ln52" class="block" id="ln52">52</a>
<a href="#ln53" class="block" id="ln53">53</a>
<a href="#ln54" class="block" id="ln54">54</a>
<a href="#ln55" class="block" id="ln55">55</a>
<a href="#ln56" class="block" id="ln56">56</a>
<a href="#ln57" class="block" id="ln57">57</a>
<a href="#ln58" class="block" id="ln58">58</a>
<a href="#ln59" class="block" id="ln59">59</a>
<a href="#ln60" class="block" id="ln60">60</a>
<a href="#ln61" class="block" id="ln61">61</a>
<a href="#ln62" class="block" id="ln62">62</a></pre></th>
            <td><pre class="prettyprint lang-cs">﻿//------------------------------------------------------------------------------
// &lt;auto-generated&gt;
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// &lt;/auto-generated&gt;
//------------------------------------------------------------------------------

namespace GmailHelper.ImapReader.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute(&quot;Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator&quot;, &quot;9.0.0.0&quot;)]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(&quot;imap.gmail.com&quot;)]
        public string ImapServer {
            get {
                return ((string)(this[&quot;ImapServer&quot;]));
            }
            set {
                this[&quot;ImapServer&quot;] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(&quot;993&quot;)]
        public int ImapPort {
            get {
                return ((int)(this[&quot;ImapPort&quot;]));
            }
            set {
                this[&quot;ImapPort&quot;] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(&quot;True&quot;)]
        public bool ImapUseSsl {
            get {
                return ((bool)(this[&quot;ImapUseSsl&quot;]));
            }
            set {
                this[&quot;ImapUseSsl&quot;] = value;
            }
        }
    }
}</pre></td>
          </tr>
        </tbody>
      </table>
</div>

<script type="text/javascript">
//<![CDATA[
if (window.location.href.split("#").length != 1) { $("ln-num").show(); }
//]]>
</script>

  <script type="text/javascript">
//<![CDATA[
prettyPrint()
//]]>
</script>


      </div><!-- /content -->

        

      <div class="push-app"></div>
    </div><!-- /b-wrapper -->

    <div class="cut">&nbsp;</div>
      <div id="footer-w">
  <div class="tutorial-and-bookmark">
      <div class="video-link" style="text-align: center;"><a href="/features/popup_video?video=12" rel="fancybox">Watch our tutorial video for the Source/SVN Tool</a></div><div class='promotion'>Powered by WANdisco Subversion. Information on WANdisco Subversion for on-site installation <a href='http://www.wandisco.com'>here</a>.</div>
  </div>

  

  <div id="footer">

    <p>
      <a href="/">Home</a>
      / <a href="/community">Community</a>
      / <a href="/features">Tour</a>
      / <a href="/catalog/12">Get a Space</a>
      &nbsp; - &nbsp; Solutions for <a href="/features/bug-tracking">Bug &amp; Issue Tracking</a>, <a href="http://www.assembla.com/features/collaboration">Collaboration Tools</a>, <a href="http://offers.assembla.com/free-subversion-hosting">Free Subversion Hosting</a>, <a href="http://offers.assembla.com/free-git-hosting">Free GIT Hosting</a>

    </p>


    <p id="copyr-contact">
    Mejl pomocnik is powered by Assembla Workspaces. <a href="/">Learn More</a>
</p>

  </div><!-- /footer -->
</div><!-- /footer-w -->



    
  



    
  <script type="text/javascript">if (!NREUMQ.f) { NREUMQ.f=function() {
NREUMQ.push(["load",new Date().getTime()]);
var e=document.createElement("script");
e.type="text/javascript";e.async=true;e.src="https://d1ros97qkrwjf5.cloudfront.net/39/eum/rum.js";
document.body.appendChild(e);
if(NREUMQ.a)NREUMQ.a();
};
NREUMQ.a=window.onload;window.onload=NREUMQ.f;
};
NREUMQ.push(["nrfj","beacon-1.newrelic.com","9dfe439095",8763,"Il9dRhNbCVtVQhgXQgBTVkFOWgpTVUMYF1oORw==",0.0,76,new Date().getTime(),"","","","",""])</script></body>
</html>




