



  



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head><script type="text/javascript">var NREUMQ=NREUMQ||[];NREUMQ.push(["mark","firstbyte",new Date().getTime()]);</script>
    <title>GmailHelper/GmailHelper.Data.Linq/GmailHelperLinq.designer.cs | Source/SVN | Assembla</title>
    <link href="http://assets2.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="shortcut icon" />
    <link href="http://assets0.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="icon" />
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
  <h1 class="icon-breadcrumb-path"><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=11" class="root">root</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper?rev=11">GmailHelper</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.Data.Linq?rev=11">GmailHelper.Data.Linq</a>/<span>GmailHelperLinq.designer.cs</span><span>    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
            width="110"
            height="14"
            id="clippy" >
    <param name="movie" value="/clippy.swf"/>
    <param name="allowScriptAccess" value="always" />
    <param name="quality" value="high" />
    <param name="scale" value="noscale" />
    <param NAME="FlashVars" value="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.Data.Linq/GmailHelperLinq.designer.cs/" />
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
           FlashVars="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.Data.Linq/GmailHelperLinq.designer.cs/"
           bgcolor="#FFFFFF"
           wmode="transparent"
    />
    </object>
</span></h1>
  
<div class="commit-infobox">
  <div class="commit-options">
    <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/logs/GmailHelper/GmailHelper.Data.Linq/GmailHelperLinq.designer.cs?rev=11" class="revision-log" rel="nofollow">Revision log</a>
      <div style="margin-right: 10px;" class="small-icon-button">
        <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/live/11/GmailHelper/GmailHelper.Data.Linq/GmailHelperLinq.designer.cs" class="view-icon" rel="nofollow">View as a web page</a>
      </div>

        <div style="margin-right: 10px;" class="small-icon-button">
    <a class="download-icon" href="#" onclick="nobotGoto('!/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.Data.Linq/GmailHelperLinq.designer.cs?_format=raw&amp;rev=11'); return false;">Download</a>
  </div>


  </div>

  <div class="committer-pic">
    <img alt="User picture" src="http://assets1.assembla.com/images/no-picture.png?1340419163" />
  </div>

  
<div class="commit-info">

    <p class="committer-info"><span>Author:</span> <a href="/profile/kazazic" tabindex="-1" target="_blank" title="Show Profile">kazazic</a></p>

  <p class="committer-info"><span>Revision:</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/changesets/6">11</a> (<span>«<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=10">Previous</a></span> <span><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=12">Next</a>»</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes">Latest</a>)</p><br />
    <p class="commit-size">
      <span>File Size:</span>
      31.6 KB
    </p>
  <p class="commit-date">(December 31, 2009 12:32 UTC) Over 2 years ago</p>
</div>



  <p class="commit-description">
    <pre>
</pre>
  </p>
</div>

<div class="cut">&nbsp;</div>



        <p class="panel-info" id="code-highlight-control">Showing without highlighting since it looks like a big file and may slow your browser - <a href="#" onclick="prettyPrint(); return false;">show with highlighting</a></p>

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
<a href="#ln62" class="block" id="ln62">62</a>
<a href="#ln63" class="block" id="ln63">63</a>
<a href="#ln64" class="block" id="ln64">64</a>
<a href="#ln65" class="block" id="ln65">65</a>
<a href="#ln66" class="block" id="ln66">66</a>
<a href="#ln67" class="block" id="ln67">67</a>
<a href="#ln68" class="block" id="ln68">68</a>
<a href="#ln69" class="block" id="ln69">69</a>
<a href="#ln70" class="block" id="ln70">70</a>
<a href="#ln71" class="block" id="ln71">71</a>
<a href="#ln72" class="block" id="ln72">72</a>
<a href="#ln73" class="block" id="ln73">73</a>
<a href="#ln74" class="block" id="ln74">74</a>
<a href="#ln75" class="block" id="ln75">75</a>
<a href="#ln76" class="block" id="ln76">76</a>
<a href="#ln77" class="block" id="ln77">77</a>
<a href="#ln78" class="block" id="ln78">78</a>
<a href="#ln79" class="block" id="ln79">79</a>
<a href="#ln80" class="block" id="ln80">80</a>
<a href="#ln81" class="block" id="ln81">81</a>
<a href="#ln82" class="block" id="ln82">82</a>
<a href="#ln83" class="block" id="ln83">83</a>
<a href="#ln84" class="block" id="ln84">84</a>
<a href="#ln85" class="block" id="ln85">85</a>
<a href="#ln86" class="block" id="ln86">86</a>
<a href="#ln87" class="block" id="ln87">87</a>
<a href="#ln88" class="block" id="ln88">88</a>
<a href="#ln89" class="block" id="ln89">89</a>
<a href="#ln90" class="block" id="ln90">90</a>
<a href="#ln91" class="block" id="ln91">91</a>
<a href="#ln92" class="block" id="ln92">92</a>
<a href="#ln93" class="block" id="ln93">93</a>
<a href="#ln94" class="block" id="ln94">94</a>
<a href="#ln95" class="block" id="ln95">95</a>
<a href="#ln96" class="block" id="ln96">96</a>
<a href="#ln97" class="block" id="ln97">97</a>
<a href="#ln98" class="block" id="ln98">98</a>
<a href="#ln99" class="block" id="ln99">99</a>
<a href="#ln100" class="block" id="ln100">100</a>
<a href="#ln101" class="block" id="ln101">101</a>
<a href="#ln102" class="block" id="ln102">102</a>
<a href="#ln103" class="block" id="ln103">103</a>
<a href="#ln104" class="block" id="ln104">104</a>
<a href="#ln105" class="block" id="ln105">105</a>
<a href="#ln106" class="block" id="ln106">106</a>
<a href="#ln107" class="block" id="ln107">107</a>
<a href="#ln108" class="block" id="ln108">108</a>
<a href="#ln109" class="block" id="ln109">109</a>
<a href="#ln110" class="block" id="ln110">110</a>
<a href="#ln111" class="block" id="ln111">111</a>
<a href="#ln112" class="block" id="ln112">112</a>
<a href="#ln113" class="block" id="ln113">113</a>
<a href="#ln114" class="block" id="ln114">114</a>
<a href="#ln115" class="block" id="ln115">115</a>
<a href="#ln116" class="block" id="ln116">116</a>
<a href="#ln117" class="block" id="ln117">117</a>
<a href="#ln118" class="block" id="ln118">118</a>
<a href="#ln119" class="block" id="ln119">119</a>
<a href="#ln120" class="block" id="ln120">120</a>
<a href="#ln121" class="block" id="ln121">121</a>
<a href="#ln122" class="block" id="ln122">122</a>
<a href="#ln123" class="block" id="ln123">123</a>
<a href="#ln124" class="block" id="ln124">124</a>
<a href="#ln125" class="block" id="ln125">125</a>
<a href="#ln126" class="block" id="ln126">126</a>
<a href="#ln127" class="block" id="ln127">127</a>
<a href="#ln128" class="block" id="ln128">128</a>
<a href="#ln129" class="block" id="ln129">129</a>
<a href="#ln130" class="block" id="ln130">130</a>
<a href="#ln131" class="block" id="ln131">131</a>
<a href="#ln132" class="block" id="ln132">132</a>
<a href="#ln133" class="block" id="ln133">133</a>
<a href="#ln134" class="block" id="ln134">134</a>
<a href="#ln135" class="block" id="ln135">135</a>
<a href="#ln136" class="block" id="ln136">136</a>
<a href="#ln137" class="block" id="ln137">137</a>
<a href="#ln138" class="block" id="ln138">138</a>
<a href="#ln139" class="block" id="ln139">139</a>
<a href="#ln140" class="block" id="ln140">140</a>
<a href="#ln141" class="block" id="ln141">141</a>
<a href="#ln142" class="block" id="ln142">142</a>
<a href="#ln143" class="block" id="ln143">143</a>
<a href="#ln144" class="block" id="ln144">144</a>
<a href="#ln145" class="block" id="ln145">145</a>
<a href="#ln146" class="block" id="ln146">146</a>
<a href="#ln147" class="block" id="ln147">147</a>
<a href="#ln148" class="block" id="ln148">148</a>
<a href="#ln149" class="block" id="ln149">149</a>
<a href="#ln150" class="block" id="ln150">150</a>
<a href="#ln151" class="block" id="ln151">151</a>
<a href="#ln152" class="block" id="ln152">152</a>
<a href="#ln153" class="block" id="ln153">153</a>
<a href="#ln154" class="block" id="ln154">154</a>
<a href="#ln155" class="block" id="ln155">155</a>
<a href="#ln156" class="block" id="ln156">156</a>
<a href="#ln157" class="block" id="ln157">157</a>
<a href="#ln158" class="block" id="ln158">158</a>
<a href="#ln159" class="block" id="ln159">159</a>
<a href="#ln160" class="block" id="ln160">160</a>
<a href="#ln161" class="block" id="ln161">161</a>
<a href="#ln162" class="block" id="ln162">162</a>
<a href="#ln163" class="block" id="ln163">163</a>
<a href="#ln164" class="block" id="ln164">164</a>
<a href="#ln165" class="block" id="ln165">165</a>
<a href="#ln166" class="block" id="ln166">166</a>
<a href="#ln167" class="block" id="ln167">167</a>
<a href="#ln168" class="block" id="ln168">168</a>
<a href="#ln169" class="block" id="ln169">169</a>
<a href="#ln170" class="block" id="ln170">170</a>
<a href="#ln171" class="block" id="ln171">171</a>
<a href="#ln172" class="block" id="ln172">172</a>
<a href="#ln173" class="block" id="ln173">173</a>
<a href="#ln174" class="block" id="ln174">174</a>
<a href="#ln175" class="block" id="ln175">175</a>
<a href="#ln176" class="block" id="ln176">176</a>
<a href="#ln177" class="block" id="ln177">177</a>
<a href="#ln178" class="block" id="ln178">178</a>
<a href="#ln179" class="block" id="ln179">179</a>
<a href="#ln180" class="block" id="ln180">180</a>
<a href="#ln181" class="block" id="ln181">181</a>
<a href="#ln182" class="block" id="ln182">182</a>
<a href="#ln183" class="block" id="ln183">183</a>
<a href="#ln184" class="block" id="ln184">184</a>
<a href="#ln185" class="block" id="ln185">185</a>
<a href="#ln186" class="block" id="ln186">186</a>
<a href="#ln187" class="block" id="ln187">187</a>
<a href="#ln188" class="block" id="ln188">188</a>
<a href="#ln189" class="block" id="ln189">189</a>
<a href="#ln190" class="block" id="ln190">190</a>
<a href="#ln191" class="block" id="ln191">191</a>
<a href="#ln192" class="block" id="ln192">192</a>
<a href="#ln193" class="block" id="ln193">193</a>
<a href="#ln194" class="block" id="ln194">194</a>
<a href="#ln195" class="block" id="ln195">195</a>
<a href="#ln196" class="block" id="ln196">196</a>
<a href="#ln197" class="block" id="ln197">197</a>
<a href="#ln198" class="block" id="ln198">198</a>
<a href="#ln199" class="block" id="ln199">199</a>
<a href="#ln200" class="block" id="ln200">200</a>
<a href="#ln201" class="block" id="ln201">201</a>
<a href="#ln202" class="block" id="ln202">202</a>
<a href="#ln203" class="block" id="ln203">203</a>
<a href="#ln204" class="block" id="ln204">204</a>
<a href="#ln205" class="block" id="ln205">205</a>
<a href="#ln206" class="block" id="ln206">206</a>
<a href="#ln207" class="block" id="ln207">207</a>
<a href="#ln208" class="block" id="ln208">208</a>
<a href="#ln209" class="block" id="ln209">209</a>
<a href="#ln210" class="block" id="ln210">210</a>
<a href="#ln211" class="block" id="ln211">211</a>
<a href="#ln212" class="block" id="ln212">212</a>
<a href="#ln213" class="block" id="ln213">213</a>
<a href="#ln214" class="block" id="ln214">214</a>
<a href="#ln215" class="block" id="ln215">215</a>
<a href="#ln216" class="block" id="ln216">216</a>
<a href="#ln217" class="block" id="ln217">217</a>
<a href="#ln218" class="block" id="ln218">218</a>
<a href="#ln219" class="block" id="ln219">219</a>
<a href="#ln220" class="block" id="ln220">220</a>
<a href="#ln221" class="block" id="ln221">221</a>
<a href="#ln222" class="block" id="ln222">222</a>
<a href="#ln223" class="block" id="ln223">223</a>
<a href="#ln224" class="block" id="ln224">224</a>
<a href="#ln225" class="block" id="ln225">225</a>
<a href="#ln226" class="block" id="ln226">226</a>
<a href="#ln227" class="block" id="ln227">227</a>
<a href="#ln228" class="block" id="ln228">228</a>
<a href="#ln229" class="block" id="ln229">229</a>
<a href="#ln230" class="block" id="ln230">230</a>
<a href="#ln231" class="block" id="ln231">231</a>
<a href="#ln232" class="block" id="ln232">232</a>
<a href="#ln233" class="block" id="ln233">233</a>
<a href="#ln234" class="block" id="ln234">234</a>
<a href="#ln235" class="block" id="ln235">235</a>
<a href="#ln236" class="block" id="ln236">236</a>
<a href="#ln237" class="block" id="ln237">237</a>
<a href="#ln238" class="block" id="ln238">238</a>
<a href="#ln239" class="block" id="ln239">239</a>
<a href="#ln240" class="block" id="ln240">240</a>
<a href="#ln241" class="block" id="ln241">241</a>
<a href="#ln242" class="block" id="ln242">242</a>
<a href="#ln243" class="block" id="ln243">243</a>
<a href="#ln244" class="block" id="ln244">244</a>
<a href="#ln245" class="block" id="ln245">245</a>
<a href="#ln246" class="block" id="ln246">246</a>
<a href="#ln247" class="block" id="ln247">247</a>
<a href="#ln248" class="block" id="ln248">248</a>
<a href="#ln249" class="block" id="ln249">249</a>
<a href="#ln250" class="block" id="ln250">250</a>
<a href="#ln251" class="block" id="ln251">251</a>
<a href="#ln252" class="block" id="ln252">252</a>
<a href="#ln253" class="block" id="ln253">253</a>
<a href="#ln254" class="block" id="ln254">254</a>
<a href="#ln255" class="block" id="ln255">255</a>
<a href="#ln256" class="block" id="ln256">256</a>
<a href="#ln257" class="block" id="ln257">257</a>
<a href="#ln258" class="block" id="ln258">258</a>
<a href="#ln259" class="block" id="ln259">259</a>
<a href="#ln260" class="block" id="ln260">260</a>
<a href="#ln261" class="block" id="ln261">261</a>
<a href="#ln262" class="block" id="ln262">262</a>
<a href="#ln263" class="block" id="ln263">263</a>
<a href="#ln264" class="block" id="ln264">264</a>
<a href="#ln265" class="block" id="ln265">265</a>
<a href="#ln266" class="block" id="ln266">266</a>
<a href="#ln267" class="block" id="ln267">267</a>
<a href="#ln268" class="block" id="ln268">268</a>
<a href="#ln269" class="block" id="ln269">269</a>
<a href="#ln270" class="block" id="ln270">270</a>
<a href="#ln271" class="block" id="ln271">271</a>
<a href="#ln272" class="block" id="ln272">272</a>
<a href="#ln273" class="block" id="ln273">273</a>
<a href="#ln274" class="block" id="ln274">274</a>
<a href="#ln275" class="block" id="ln275">275</a>
<a href="#ln276" class="block" id="ln276">276</a>
<a href="#ln277" class="block" id="ln277">277</a>
<a href="#ln278" class="block" id="ln278">278</a>
<a href="#ln279" class="block" id="ln279">279</a>
<a href="#ln280" class="block" id="ln280">280</a>
<a href="#ln281" class="block" id="ln281">281</a>
<a href="#ln282" class="block" id="ln282">282</a>
<a href="#ln283" class="block" id="ln283">283</a>
<a href="#ln284" class="block" id="ln284">284</a>
<a href="#ln285" class="block" id="ln285">285</a>
<a href="#ln286" class="block" id="ln286">286</a>
<a href="#ln287" class="block" id="ln287">287</a>
<a href="#ln288" class="block" id="ln288">288</a>
<a href="#ln289" class="block" id="ln289">289</a>
<a href="#ln290" class="block" id="ln290">290</a>
<a href="#ln291" class="block" id="ln291">291</a>
<a href="#ln292" class="block" id="ln292">292</a>
<a href="#ln293" class="block" id="ln293">293</a>
<a href="#ln294" class="block" id="ln294">294</a>
<a href="#ln295" class="block" id="ln295">295</a>
<a href="#ln296" class="block" id="ln296">296</a>
<a href="#ln297" class="block" id="ln297">297</a>
<a href="#ln298" class="block" id="ln298">298</a>
<a href="#ln299" class="block" id="ln299">299</a>
<a href="#ln300" class="block" id="ln300">300</a>
<a href="#ln301" class="block" id="ln301">301</a>
<a href="#ln302" class="block" id="ln302">302</a>
<a href="#ln303" class="block" id="ln303">303</a>
<a href="#ln304" class="block" id="ln304">304</a>
<a href="#ln305" class="block" id="ln305">305</a>
<a href="#ln306" class="block" id="ln306">306</a>
<a href="#ln307" class="block" id="ln307">307</a>
<a href="#ln308" class="block" id="ln308">308</a>
<a href="#ln309" class="block" id="ln309">309</a>
<a href="#ln310" class="block" id="ln310">310</a>
<a href="#ln311" class="block" id="ln311">311</a>
<a href="#ln312" class="block" id="ln312">312</a>
<a href="#ln313" class="block" id="ln313">313</a>
<a href="#ln314" class="block" id="ln314">314</a>
<a href="#ln315" class="block" id="ln315">315</a>
<a href="#ln316" class="block" id="ln316">316</a>
<a href="#ln317" class="block" id="ln317">317</a>
<a href="#ln318" class="block" id="ln318">318</a>
<a href="#ln319" class="block" id="ln319">319</a>
<a href="#ln320" class="block" id="ln320">320</a>
<a href="#ln321" class="block" id="ln321">321</a>
<a href="#ln322" class="block" id="ln322">322</a>
<a href="#ln323" class="block" id="ln323">323</a>
<a href="#ln324" class="block" id="ln324">324</a>
<a href="#ln325" class="block" id="ln325">325</a>
<a href="#ln326" class="block" id="ln326">326</a>
<a href="#ln327" class="block" id="ln327">327</a>
<a href="#ln328" class="block" id="ln328">328</a>
<a href="#ln329" class="block" id="ln329">329</a>
<a href="#ln330" class="block" id="ln330">330</a>
<a href="#ln331" class="block" id="ln331">331</a>
<a href="#ln332" class="block" id="ln332">332</a>
<a href="#ln333" class="block" id="ln333">333</a>
<a href="#ln334" class="block" id="ln334">334</a>
<a href="#ln335" class="block" id="ln335">335</a>
<a href="#ln336" class="block" id="ln336">336</a>
<a href="#ln337" class="block" id="ln337">337</a>
<a href="#ln338" class="block" id="ln338">338</a>
<a href="#ln339" class="block" id="ln339">339</a>
<a href="#ln340" class="block" id="ln340">340</a>
<a href="#ln341" class="block" id="ln341">341</a>
<a href="#ln342" class="block" id="ln342">342</a>
<a href="#ln343" class="block" id="ln343">343</a>
<a href="#ln344" class="block" id="ln344">344</a>
<a href="#ln345" class="block" id="ln345">345</a>
<a href="#ln346" class="block" id="ln346">346</a>
<a href="#ln347" class="block" id="ln347">347</a>
<a href="#ln348" class="block" id="ln348">348</a>
<a href="#ln349" class="block" id="ln349">349</a>
<a href="#ln350" class="block" id="ln350">350</a>
<a href="#ln351" class="block" id="ln351">351</a>
<a href="#ln352" class="block" id="ln352">352</a>
<a href="#ln353" class="block" id="ln353">353</a>
<a href="#ln354" class="block" id="ln354">354</a>
<a href="#ln355" class="block" id="ln355">355</a>
<a href="#ln356" class="block" id="ln356">356</a>
<a href="#ln357" class="block" id="ln357">357</a>
<a href="#ln358" class="block" id="ln358">358</a>
<a href="#ln359" class="block" id="ln359">359</a>
<a href="#ln360" class="block" id="ln360">360</a>
<a href="#ln361" class="block" id="ln361">361</a>
<a href="#ln362" class="block" id="ln362">362</a>
<a href="#ln363" class="block" id="ln363">363</a>
<a href="#ln364" class="block" id="ln364">364</a>
<a href="#ln365" class="block" id="ln365">365</a>
<a href="#ln366" class="block" id="ln366">366</a>
<a href="#ln367" class="block" id="ln367">367</a>
<a href="#ln368" class="block" id="ln368">368</a>
<a href="#ln369" class="block" id="ln369">369</a>
<a href="#ln370" class="block" id="ln370">370</a>
<a href="#ln371" class="block" id="ln371">371</a>
<a href="#ln372" class="block" id="ln372">372</a>
<a href="#ln373" class="block" id="ln373">373</a>
<a href="#ln374" class="block" id="ln374">374</a>
<a href="#ln375" class="block" id="ln375">375</a>
<a href="#ln376" class="block" id="ln376">376</a>
<a href="#ln377" class="block" id="ln377">377</a>
<a href="#ln378" class="block" id="ln378">378</a>
<a href="#ln379" class="block" id="ln379">379</a>
<a href="#ln380" class="block" id="ln380">380</a>
<a href="#ln381" class="block" id="ln381">381</a>
<a href="#ln382" class="block" id="ln382">382</a>
<a href="#ln383" class="block" id="ln383">383</a>
<a href="#ln384" class="block" id="ln384">384</a>
<a href="#ln385" class="block" id="ln385">385</a>
<a href="#ln386" class="block" id="ln386">386</a>
<a href="#ln387" class="block" id="ln387">387</a>
<a href="#ln388" class="block" id="ln388">388</a>
<a href="#ln389" class="block" id="ln389">389</a>
<a href="#ln390" class="block" id="ln390">390</a>
<a href="#ln391" class="block" id="ln391">391</a>
<a href="#ln392" class="block" id="ln392">392</a>
<a href="#ln393" class="block" id="ln393">393</a>
<a href="#ln394" class="block" id="ln394">394</a>
<a href="#ln395" class="block" id="ln395">395</a>
<a href="#ln396" class="block" id="ln396">396</a>
<a href="#ln397" class="block" id="ln397">397</a>
<a href="#ln398" class="block" id="ln398">398</a>
<a href="#ln399" class="block" id="ln399">399</a>
<a href="#ln400" class="block" id="ln400">400</a>
<a href="#ln401" class="block" id="ln401">401</a>
<a href="#ln402" class="block" id="ln402">402</a>
<a href="#ln403" class="block" id="ln403">403</a>
<a href="#ln404" class="block" id="ln404">404</a>
<a href="#ln405" class="block" id="ln405">405</a>
<a href="#ln406" class="block" id="ln406">406</a>
<a href="#ln407" class="block" id="ln407">407</a>
<a href="#ln408" class="block" id="ln408">408</a>
<a href="#ln409" class="block" id="ln409">409</a>
<a href="#ln410" class="block" id="ln410">410</a>
<a href="#ln411" class="block" id="ln411">411</a>
<a href="#ln412" class="block" id="ln412">412</a>
<a href="#ln413" class="block" id="ln413">413</a>
<a href="#ln414" class="block" id="ln414">414</a>
<a href="#ln415" class="block" id="ln415">415</a>
<a href="#ln416" class="block" id="ln416">416</a>
<a href="#ln417" class="block" id="ln417">417</a>
<a href="#ln418" class="block" id="ln418">418</a>
<a href="#ln419" class="block" id="ln419">419</a>
<a href="#ln420" class="block" id="ln420">420</a>
<a href="#ln421" class="block" id="ln421">421</a>
<a href="#ln422" class="block" id="ln422">422</a>
<a href="#ln423" class="block" id="ln423">423</a>
<a href="#ln424" class="block" id="ln424">424</a>
<a href="#ln425" class="block" id="ln425">425</a>
<a href="#ln426" class="block" id="ln426">426</a>
<a href="#ln427" class="block" id="ln427">427</a>
<a href="#ln428" class="block" id="ln428">428</a>
<a href="#ln429" class="block" id="ln429">429</a>
<a href="#ln430" class="block" id="ln430">430</a>
<a href="#ln431" class="block" id="ln431">431</a>
<a href="#ln432" class="block" id="ln432">432</a>
<a href="#ln433" class="block" id="ln433">433</a>
<a href="#ln434" class="block" id="ln434">434</a>
<a href="#ln435" class="block" id="ln435">435</a>
<a href="#ln436" class="block" id="ln436">436</a>
<a href="#ln437" class="block" id="ln437">437</a>
<a href="#ln438" class="block" id="ln438">438</a>
<a href="#ln439" class="block" id="ln439">439</a>
<a href="#ln440" class="block" id="ln440">440</a>
<a href="#ln441" class="block" id="ln441">441</a>
<a href="#ln442" class="block" id="ln442">442</a>
<a href="#ln443" class="block" id="ln443">443</a>
<a href="#ln444" class="block" id="ln444">444</a>
<a href="#ln445" class="block" id="ln445">445</a>
<a href="#ln446" class="block" id="ln446">446</a>
<a href="#ln447" class="block" id="ln447">447</a>
<a href="#ln448" class="block" id="ln448">448</a>
<a href="#ln449" class="block" id="ln449">449</a>
<a href="#ln450" class="block" id="ln450">450</a>
<a href="#ln451" class="block" id="ln451">451</a>
<a href="#ln452" class="block" id="ln452">452</a>
<a href="#ln453" class="block" id="ln453">453</a>
<a href="#ln454" class="block" id="ln454">454</a>
<a href="#ln455" class="block" id="ln455">455</a>
<a href="#ln456" class="block" id="ln456">456</a>
<a href="#ln457" class="block" id="ln457">457</a>
<a href="#ln458" class="block" id="ln458">458</a>
<a href="#ln459" class="block" id="ln459">459</a>
<a href="#ln460" class="block" id="ln460">460</a>
<a href="#ln461" class="block" id="ln461">461</a>
<a href="#ln462" class="block" id="ln462">462</a>
<a href="#ln463" class="block" id="ln463">463</a>
<a href="#ln464" class="block" id="ln464">464</a>
<a href="#ln465" class="block" id="ln465">465</a>
<a href="#ln466" class="block" id="ln466">466</a>
<a href="#ln467" class="block" id="ln467">467</a>
<a href="#ln468" class="block" id="ln468">468</a>
<a href="#ln469" class="block" id="ln469">469</a>
<a href="#ln470" class="block" id="ln470">470</a>
<a href="#ln471" class="block" id="ln471">471</a>
<a href="#ln472" class="block" id="ln472">472</a>
<a href="#ln473" class="block" id="ln473">473</a>
<a href="#ln474" class="block" id="ln474">474</a>
<a href="#ln475" class="block" id="ln475">475</a>
<a href="#ln476" class="block" id="ln476">476</a>
<a href="#ln477" class="block" id="ln477">477</a>
<a href="#ln478" class="block" id="ln478">478</a>
<a href="#ln479" class="block" id="ln479">479</a>
<a href="#ln480" class="block" id="ln480">480</a>
<a href="#ln481" class="block" id="ln481">481</a>
<a href="#ln482" class="block" id="ln482">482</a>
<a href="#ln483" class="block" id="ln483">483</a>
<a href="#ln484" class="block" id="ln484">484</a>
<a href="#ln485" class="block" id="ln485">485</a>
<a href="#ln486" class="block" id="ln486">486</a>
<a href="#ln487" class="block" id="ln487">487</a>
<a href="#ln488" class="block" id="ln488">488</a>
<a href="#ln489" class="block" id="ln489">489</a>
<a href="#ln490" class="block" id="ln490">490</a>
<a href="#ln491" class="block" id="ln491">491</a>
<a href="#ln492" class="block" id="ln492">492</a>
<a href="#ln493" class="block" id="ln493">493</a>
<a href="#ln494" class="block" id="ln494">494</a>
<a href="#ln495" class="block" id="ln495">495</a>
<a href="#ln496" class="block" id="ln496">496</a>
<a href="#ln497" class="block" id="ln497">497</a>
<a href="#ln498" class="block" id="ln498">498</a>
<a href="#ln499" class="block" id="ln499">499</a>
<a href="#ln500" class="block" id="ln500">500</a>
<a href="#ln501" class="block" id="ln501">501</a>
<a href="#ln502" class="block" id="ln502">502</a>
<a href="#ln503" class="block" id="ln503">503</a>
<a href="#ln504" class="block" id="ln504">504</a>
<a href="#ln505" class="block" id="ln505">505</a>
<a href="#ln506" class="block" id="ln506">506</a>
<a href="#ln507" class="block" id="ln507">507</a>
<a href="#ln508" class="block" id="ln508">508</a>
<a href="#ln509" class="block" id="ln509">509</a>
<a href="#ln510" class="block" id="ln510">510</a>
<a href="#ln511" class="block" id="ln511">511</a>
<a href="#ln512" class="block" id="ln512">512</a>
<a href="#ln513" class="block" id="ln513">513</a>
<a href="#ln514" class="block" id="ln514">514</a>
<a href="#ln515" class="block" id="ln515">515</a>
<a href="#ln516" class="block" id="ln516">516</a>
<a href="#ln517" class="block" id="ln517">517</a>
<a href="#ln518" class="block" id="ln518">518</a>
<a href="#ln519" class="block" id="ln519">519</a>
<a href="#ln520" class="block" id="ln520">520</a>
<a href="#ln521" class="block" id="ln521">521</a>
<a href="#ln522" class="block" id="ln522">522</a>
<a href="#ln523" class="block" id="ln523">523</a>
<a href="#ln524" class="block" id="ln524">524</a>
<a href="#ln525" class="block" id="ln525">525</a>
<a href="#ln526" class="block" id="ln526">526</a>
<a href="#ln527" class="block" id="ln527">527</a>
<a href="#ln528" class="block" id="ln528">528</a>
<a href="#ln529" class="block" id="ln529">529</a>
<a href="#ln530" class="block" id="ln530">530</a>
<a href="#ln531" class="block" id="ln531">531</a>
<a href="#ln532" class="block" id="ln532">532</a>
<a href="#ln533" class="block" id="ln533">533</a>
<a href="#ln534" class="block" id="ln534">534</a>
<a href="#ln535" class="block" id="ln535">535</a>
<a href="#ln536" class="block" id="ln536">536</a>
<a href="#ln537" class="block" id="ln537">537</a>
<a href="#ln538" class="block" id="ln538">538</a>
<a href="#ln539" class="block" id="ln539">539</a>
<a href="#ln540" class="block" id="ln540">540</a>
<a href="#ln541" class="block" id="ln541">541</a>
<a href="#ln542" class="block" id="ln542">542</a>
<a href="#ln543" class="block" id="ln543">543</a>
<a href="#ln544" class="block" id="ln544">544</a>
<a href="#ln545" class="block" id="ln545">545</a>
<a href="#ln546" class="block" id="ln546">546</a>
<a href="#ln547" class="block" id="ln547">547</a>
<a href="#ln548" class="block" id="ln548">548</a>
<a href="#ln549" class="block" id="ln549">549</a>
<a href="#ln550" class="block" id="ln550">550</a>
<a href="#ln551" class="block" id="ln551">551</a>
<a href="#ln552" class="block" id="ln552">552</a>
<a href="#ln553" class="block" id="ln553">553</a>
<a href="#ln554" class="block" id="ln554">554</a>
<a href="#ln555" class="block" id="ln555">555</a>
<a href="#ln556" class="block" id="ln556">556</a>
<a href="#ln557" class="block" id="ln557">557</a>
<a href="#ln558" class="block" id="ln558">558</a>
<a href="#ln559" class="block" id="ln559">559</a>
<a href="#ln560" class="block" id="ln560">560</a>
<a href="#ln561" class="block" id="ln561">561</a>
<a href="#ln562" class="block" id="ln562">562</a>
<a href="#ln563" class="block" id="ln563">563</a>
<a href="#ln564" class="block" id="ln564">564</a>
<a href="#ln565" class="block" id="ln565">565</a>
<a href="#ln566" class="block" id="ln566">566</a>
<a href="#ln567" class="block" id="ln567">567</a>
<a href="#ln568" class="block" id="ln568">568</a>
<a href="#ln569" class="block" id="ln569">569</a>
<a href="#ln570" class="block" id="ln570">570</a>
<a href="#ln571" class="block" id="ln571">571</a>
<a href="#ln572" class="block" id="ln572">572</a>
<a href="#ln573" class="block" id="ln573">573</a>
<a href="#ln574" class="block" id="ln574">574</a>
<a href="#ln575" class="block" id="ln575">575</a>
<a href="#ln576" class="block" id="ln576">576</a>
<a href="#ln577" class="block" id="ln577">577</a>
<a href="#ln578" class="block" id="ln578">578</a>
<a href="#ln579" class="block" id="ln579">579</a>
<a href="#ln580" class="block" id="ln580">580</a>
<a href="#ln581" class="block" id="ln581">581</a>
<a href="#ln582" class="block" id="ln582">582</a>
<a href="#ln583" class="block" id="ln583">583</a>
<a href="#ln584" class="block" id="ln584">584</a>
<a href="#ln585" class="block" id="ln585">585</a>
<a href="#ln586" class="block" id="ln586">586</a>
<a href="#ln587" class="block" id="ln587">587</a>
<a href="#ln588" class="block" id="ln588">588</a>
<a href="#ln589" class="block" id="ln589">589</a>
<a href="#ln590" class="block" id="ln590">590</a>
<a href="#ln591" class="block" id="ln591">591</a>
<a href="#ln592" class="block" id="ln592">592</a>
<a href="#ln593" class="block" id="ln593">593</a>
<a href="#ln594" class="block" id="ln594">594</a>
<a href="#ln595" class="block" id="ln595">595</a>
<a href="#ln596" class="block" id="ln596">596</a>
<a href="#ln597" class="block" id="ln597">597</a>
<a href="#ln598" class="block" id="ln598">598</a>
<a href="#ln599" class="block" id="ln599">599</a>
<a href="#ln600" class="block" id="ln600">600</a>
<a href="#ln601" class="block" id="ln601">601</a>
<a href="#ln602" class="block" id="ln602">602</a>
<a href="#ln603" class="block" id="ln603">603</a>
<a href="#ln604" class="block" id="ln604">604</a>
<a href="#ln605" class="block" id="ln605">605</a>
<a href="#ln606" class="block" id="ln606">606</a>
<a href="#ln607" class="block" id="ln607">607</a>
<a href="#ln608" class="block" id="ln608">608</a>
<a href="#ln609" class="block" id="ln609">609</a>
<a href="#ln610" class="block" id="ln610">610</a>
<a href="#ln611" class="block" id="ln611">611</a>
<a href="#ln612" class="block" id="ln612">612</a>
<a href="#ln613" class="block" id="ln613">613</a>
<a href="#ln614" class="block" id="ln614">614</a>
<a href="#ln615" class="block" id="ln615">615</a>
<a href="#ln616" class="block" id="ln616">616</a>
<a href="#ln617" class="block" id="ln617">617</a>
<a href="#ln618" class="block" id="ln618">618</a>
<a href="#ln619" class="block" id="ln619">619</a>
<a href="#ln620" class="block" id="ln620">620</a>
<a href="#ln621" class="block" id="ln621">621</a>
<a href="#ln622" class="block" id="ln622">622</a>
<a href="#ln623" class="block" id="ln623">623</a>
<a href="#ln624" class="block" id="ln624">624</a>
<a href="#ln625" class="block" id="ln625">625</a>
<a href="#ln626" class="block" id="ln626">626</a>
<a href="#ln627" class="block" id="ln627">627</a>
<a href="#ln628" class="block" id="ln628">628</a>
<a href="#ln629" class="block" id="ln629">629</a>
<a href="#ln630" class="block" id="ln630">630</a>
<a href="#ln631" class="block" id="ln631">631</a>
<a href="#ln632" class="block" id="ln632">632</a>
<a href="#ln633" class="block" id="ln633">633</a>
<a href="#ln634" class="block" id="ln634">634</a>
<a href="#ln635" class="block" id="ln635">635</a>
<a href="#ln636" class="block" id="ln636">636</a>
<a href="#ln637" class="block" id="ln637">637</a>
<a href="#ln638" class="block" id="ln638">638</a>
<a href="#ln639" class="block" id="ln639">639</a>
<a href="#ln640" class="block" id="ln640">640</a>
<a href="#ln641" class="block" id="ln641">641</a>
<a href="#ln642" class="block" id="ln642">642</a>
<a href="#ln643" class="block" id="ln643">643</a>
<a href="#ln644" class="block" id="ln644">644</a>
<a href="#ln645" class="block" id="ln645">645</a>
<a href="#ln646" class="block" id="ln646">646</a>
<a href="#ln647" class="block" id="ln647">647</a>
<a href="#ln648" class="block" id="ln648">648</a>
<a href="#ln649" class="block" id="ln649">649</a>
<a href="#ln650" class="block" id="ln650">650</a>
<a href="#ln651" class="block" id="ln651">651</a>
<a href="#ln652" class="block" id="ln652">652</a>
<a href="#ln653" class="block" id="ln653">653</a>
<a href="#ln654" class="block" id="ln654">654</a>
<a href="#ln655" class="block" id="ln655">655</a>
<a href="#ln656" class="block" id="ln656">656</a>
<a href="#ln657" class="block" id="ln657">657</a>
<a href="#ln658" class="block" id="ln658">658</a>
<a href="#ln659" class="block" id="ln659">659</a>
<a href="#ln660" class="block" id="ln660">660</a>
<a href="#ln661" class="block" id="ln661">661</a>
<a href="#ln662" class="block" id="ln662">662</a>
<a href="#ln663" class="block" id="ln663">663</a>
<a href="#ln664" class="block" id="ln664">664</a>
<a href="#ln665" class="block" id="ln665">665</a>
<a href="#ln666" class="block" id="ln666">666</a>
<a href="#ln667" class="block" id="ln667">667</a>
<a href="#ln668" class="block" id="ln668">668</a>
<a href="#ln669" class="block" id="ln669">669</a>
<a href="#ln670" class="block" id="ln670">670</a>
<a href="#ln671" class="block" id="ln671">671</a>
<a href="#ln672" class="block" id="ln672">672</a>
<a href="#ln673" class="block" id="ln673">673</a>
<a href="#ln674" class="block" id="ln674">674</a>
<a href="#ln675" class="block" id="ln675">675</a>
<a href="#ln676" class="block" id="ln676">676</a>
<a href="#ln677" class="block" id="ln677">677</a>
<a href="#ln678" class="block" id="ln678">678</a>
<a href="#ln679" class="block" id="ln679">679</a>
<a href="#ln680" class="block" id="ln680">680</a>
<a href="#ln681" class="block" id="ln681">681</a>
<a href="#ln682" class="block" id="ln682">682</a>
<a href="#ln683" class="block" id="ln683">683</a>
<a href="#ln684" class="block" id="ln684">684</a>
<a href="#ln685" class="block" id="ln685">685</a>
<a href="#ln686" class="block" id="ln686">686</a>
<a href="#ln687" class="block" id="ln687">687</a>
<a href="#ln688" class="block" id="ln688">688</a>
<a href="#ln689" class="block" id="ln689">689</a>
<a href="#ln690" class="block" id="ln690">690</a>
<a href="#ln691" class="block" id="ln691">691</a>
<a href="#ln692" class="block" id="ln692">692</a>
<a href="#ln693" class="block" id="ln693">693</a>
<a href="#ln694" class="block" id="ln694">694</a>
<a href="#ln695" class="block" id="ln695">695</a>
<a href="#ln696" class="block" id="ln696">696</a>
<a href="#ln697" class="block" id="ln697">697</a>
<a href="#ln698" class="block" id="ln698">698</a>
<a href="#ln699" class="block" id="ln699">699</a>
<a href="#ln700" class="block" id="ln700">700</a>
<a href="#ln701" class="block" id="ln701">701</a>
<a href="#ln702" class="block" id="ln702">702</a>
<a href="#ln703" class="block" id="ln703">703</a>
<a href="#ln704" class="block" id="ln704">704</a>
<a href="#ln705" class="block" id="ln705">705</a>
<a href="#ln706" class="block" id="ln706">706</a>
<a href="#ln707" class="block" id="ln707">707</a>
<a href="#ln708" class="block" id="ln708">708</a>
<a href="#ln709" class="block" id="ln709">709</a>
<a href="#ln710" class="block" id="ln710">710</a>
<a href="#ln711" class="block" id="ln711">711</a>
<a href="#ln712" class="block" id="ln712">712</a>
<a href="#ln713" class="block" id="ln713">713</a>
<a href="#ln714" class="block" id="ln714">714</a>
<a href="#ln715" class="block" id="ln715">715</a>
<a href="#ln716" class="block" id="ln716">716</a>
<a href="#ln717" class="block" id="ln717">717</a>
<a href="#ln718" class="block" id="ln718">718</a>
<a href="#ln719" class="block" id="ln719">719</a>
<a href="#ln720" class="block" id="ln720">720</a>
<a href="#ln721" class="block" id="ln721">721</a>
<a href="#ln722" class="block" id="ln722">722</a>
<a href="#ln723" class="block" id="ln723">723</a>
<a href="#ln724" class="block" id="ln724">724</a>
<a href="#ln725" class="block" id="ln725">725</a>
<a href="#ln726" class="block" id="ln726">726</a>
<a href="#ln727" class="block" id="ln727">727</a>
<a href="#ln728" class="block" id="ln728">728</a>
<a href="#ln729" class="block" id="ln729">729</a>
<a href="#ln730" class="block" id="ln730">730</a>
<a href="#ln731" class="block" id="ln731">731</a>
<a href="#ln732" class="block" id="ln732">732</a>
<a href="#ln733" class="block" id="ln733">733</a>
<a href="#ln734" class="block" id="ln734">734</a>
<a href="#ln735" class="block" id="ln735">735</a>
<a href="#ln736" class="block" id="ln736">736</a>
<a href="#ln737" class="block" id="ln737">737</a>
<a href="#ln738" class="block" id="ln738">738</a>
<a href="#ln739" class="block" id="ln739">739</a>
<a href="#ln740" class="block" id="ln740">740</a>
<a href="#ln741" class="block" id="ln741">741</a>
<a href="#ln742" class="block" id="ln742">742</a>
<a href="#ln743" class="block" id="ln743">743</a>
<a href="#ln744" class="block" id="ln744">744</a>
<a href="#ln745" class="block" id="ln745">745</a>
<a href="#ln746" class="block" id="ln746">746</a>
<a href="#ln747" class="block" id="ln747">747</a>
<a href="#ln748" class="block" id="ln748">748</a>
<a href="#ln749" class="block" id="ln749">749</a>
<a href="#ln750" class="block" id="ln750">750</a>
<a href="#ln751" class="block" id="ln751">751</a>
<a href="#ln752" class="block" id="ln752">752</a>
<a href="#ln753" class="block" id="ln753">753</a>
<a href="#ln754" class="block" id="ln754">754</a>
<a href="#ln755" class="block" id="ln755">755</a>
<a href="#ln756" class="block" id="ln756">756</a>
<a href="#ln757" class="block" id="ln757">757</a>
<a href="#ln758" class="block" id="ln758">758</a>
<a href="#ln759" class="block" id="ln759">759</a>
<a href="#ln760" class="block" id="ln760">760</a>
<a href="#ln761" class="block" id="ln761">761</a>
<a href="#ln762" class="block" id="ln762">762</a>
<a href="#ln763" class="block" id="ln763">763</a>
<a href="#ln764" class="block" id="ln764">764</a>
<a href="#ln765" class="block" id="ln765">765</a>
<a href="#ln766" class="block" id="ln766">766</a>
<a href="#ln767" class="block" id="ln767">767</a>
<a href="#ln768" class="block" id="ln768">768</a>
<a href="#ln769" class="block" id="ln769">769</a>
<a href="#ln770" class="block" id="ln770">770</a>
<a href="#ln771" class="block" id="ln771">771</a>
<a href="#ln772" class="block" id="ln772">772</a>
<a href="#ln773" class="block" id="ln773">773</a>
<a href="#ln774" class="block" id="ln774">774</a>
<a href="#ln775" class="block" id="ln775">775</a>
<a href="#ln776" class="block" id="ln776">776</a>
<a href="#ln777" class="block" id="ln777">777</a>
<a href="#ln778" class="block" id="ln778">778</a>
<a href="#ln779" class="block" id="ln779">779</a>
<a href="#ln780" class="block" id="ln780">780</a>
<a href="#ln781" class="block" id="ln781">781</a>
<a href="#ln782" class="block" id="ln782">782</a>
<a href="#ln783" class="block" id="ln783">783</a>
<a href="#ln784" class="block" id="ln784">784</a>
<a href="#ln785" class="block" id="ln785">785</a>
<a href="#ln786" class="block" id="ln786">786</a>
<a href="#ln787" class="block" id="ln787">787</a>
<a href="#ln788" class="block" id="ln788">788</a>
<a href="#ln789" class="block" id="ln789">789</a>
<a href="#ln790" class="block" id="ln790">790</a>
<a href="#ln791" class="block" id="ln791">791</a>
<a href="#ln792" class="block" id="ln792">792</a>
<a href="#ln793" class="block" id="ln793">793</a>
<a href="#ln794" class="block" id="ln794">794</a>
<a href="#ln795" class="block" id="ln795">795</a>
<a href="#ln796" class="block" id="ln796">796</a>
<a href="#ln797" class="block" id="ln797">797</a>
<a href="#ln798" class="block" id="ln798">798</a>
<a href="#ln799" class="block" id="ln799">799</a>
<a href="#ln800" class="block" id="ln800">800</a>
<a href="#ln801" class="block" id="ln801">801</a>
<a href="#ln802" class="block" id="ln802">802</a>
<a href="#ln803" class="block" id="ln803">803</a>
<a href="#ln804" class="block" id="ln804">804</a>
<a href="#ln805" class="block" id="ln805">805</a>
<a href="#ln806" class="block" id="ln806">806</a>
<a href="#ln807" class="block" id="ln807">807</a>
<a href="#ln808" class="block" id="ln808">808</a>
<a href="#ln809" class="block" id="ln809">809</a>
<a href="#ln810" class="block" id="ln810">810</a>
<a href="#ln811" class="block" id="ln811">811</a>
<a href="#ln812" class="block" id="ln812">812</a>
<a href="#ln813" class="block" id="ln813">813</a>
<a href="#ln814" class="block" id="ln814">814</a>
<a href="#ln815" class="block" id="ln815">815</a>
<a href="#ln816" class="block" id="ln816">816</a>
<a href="#ln817" class="block" id="ln817">817</a>
<a href="#ln818" class="block" id="ln818">818</a>
<a href="#ln819" class="block" id="ln819">819</a>
<a href="#ln820" class="block" id="ln820">820</a>
<a href="#ln821" class="block" id="ln821">821</a>
<a href="#ln822" class="block" id="ln822">822</a>
<a href="#ln823" class="block" id="ln823">823</a>
<a href="#ln824" class="block" id="ln824">824</a>
<a href="#ln825" class="block" id="ln825">825</a>
<a href="#ln826" class="block" id="ln826">826</a>
<a href="#ln827" class="block" id="ln827">827</a>
<a href="#ln828" class="block" id="ln828">828</a>
<a href="#ln829" class="block" id="ln829">829</a>
<a href="#ln830" class="block" id="ln830">830</a>
<a href="#ln831" class="block" id="ln831">831</a>
<a href="#ln832" class="block" id="ln832">832</a>
<a href="#ln833" class="block" id="ln833">833</a>
<a href="#ln834" class="block" id="ln834">834</a>
<a href="#ln835" class="block" id="ln835">835</a>
<a href="#ln836" class="block" id="ln836">836</a>
<a href="#ln837" class="block" id="ln837">837</a>
<a href="#ln838" class="block" id="ln838">838</a>
<a href="#ln839" class="block" id="ln839">839</a>
<a href="#ln840" class="block" id="ln840">840</a>
<a href="#ln841" class="block" id="ln841">841</a>
<a href="#ln842" class="block" id="ln842">842</a>
<a href="#ln843" class="block" id="ln843">843</a>
<a href="#ln844" class="block" id="ln844">844</a>
<a href="#ln845" class="block" id="ln845">845</a>
<a href="#ln846" class="block" id="ln846">846</a>
<a href="#ln847" class="block" id="ln847">847</a>
<a href="#ln848" class="block" id="ln848">848</a>
<a href="#ln849" class="block" id="ln849">849</a>
<a href="#ln850" class="block" id="ln850">850</a>
<a href="#ln851" class="block" id="ln851">851</a>
<a href="#ln852" class="block" id="ln852">852</a>
<a href="#ln853" class="block" id="ln853">853</a>
<a href="#ln854" class="block" id="ln854">854</a>
<a href="#ln855" class="block" id="ln855">855</a>
<a href="#ln856" class="block" id="ln856">856</a>
<a href="#ln857" class="block" id="ln857">857</a>
<a href="#ln858" class="block" id="ln858">858</a>
<a href="#ln859" class="block" id="ln859">859</a>
<a href="#ln860" class="block" id="ln860">860</a>
<a href="#ln861" class="block" id="ln861">861</a>
<a href="#ln862" class="block" id="ln862">862</a>
<a href="#ln863" class="block" id="ln863">863</a>
<a href="#ln864" class="block" id="ln864">864</a>
<a href="#ln865" class="block" id="ln865">865</a>
<a href="#ln866" class="block" id="ln866">866</a>
<a href="#ln867" class="block" id="ln867">867</a>
<a href="#ln868" class="block" id="ln868">868</a>
<a href="#ln869" class="block" id="ln869">869</a>
<a href="#ln870" class="block" id="ln870">870</a>
<a href="#ln871" class="block" id="ln871">871</a>
<a href="#ln872" class="block" id="ln872">872</a>
<a href="#ln873" class="block" id="ln873">873</a>
<a href="#ln874" class="block" id="ln874">874</a>
<a href="#ln875" class="block" id="ln875">875</a>
<a href="#ln876" class="block" id="ln876">876</a>
<a href="#ln877" class="block" id="ln877">877</a>
<a href="#ln878" class="block" id="ln878">878</a>
<a href="#ln879" class="block" id="ln879">879</a>
<a href="#ln880" class="block" id="ln880">880</a>
<a href="#ln881" class="block" id="ln881">881</a>
<a href="#ln882" class="block" id="ln882">882</a>
<a href="#ln883" class="block" id="ln883">883</a>
<a href="#ln884" class="block" id="ln884">884</a>
<a href="#ln885" class="block" id="ln885">885</a>
<a href="#ln886" class="block" id="ln886">886</a>
<a href="#ln887" class="block" id="ln887">887</a>
<a href="#ln888" class="block" id="ln888">888</a>
<a href="#ln889" class="block" id="ln889">889</a>
<a href="#ln890" class="block" id="ln890">890</a>
<a href="#ln891" class="block" id="ln891">891</a>
<a href="#ln892" class="block" id="ln892">892</a>
<a href="#ln893" class="block" id="ln893">893</a>
<a href="#ln894" class="block" id="ln894">894</a>
<a href="#ln895" class="block" id="ln895">895</a>
<a href="#ln896" class="block" id="ln896">896</a>
<a href="#ln897" class="block" id="ln897">897</a>
<a href="#ln898" class="block" id="ln898">898</a>
<a href="#ln899" class="block" id="ln899">899</a>
<a href="#ln900" class="block" id="ln900">900</a>
<a href="#ln901" class="block" id="ln901">901</a>
<a href="#ln902" class="block" id="ln902">902</a>
<a href="#ln903" class="block" id="ln903">903</a>
<a href="#ln904" class="block" id="ln904">904</a>
<a href="#ln905" class="block" id="ln905">905</a>
<a href="#ln906" class="block" id="ln906">906</a>
<a href="#ln907" class="block" id="ln907">907</a>
<a href="#ln908" class="block" id="ln908">908</a>
<a href="#ln909" class="block" id="ln909">909</a>
<a href="#ln910" class="block" id="ln910">910</a>
<a href="#ln911" class="block" id="ln911">911</a>
<a href="#ln912" class="block" id="ln912">912</a>
<a href="#ln913" class="block" id="ln913">913</a>
<a href="#ln914" class="block" id="ln914">914</a>
<a href="#ln915" class="block" id="ln915">915</a>
<a href="#ln916" class="block" id="ln916">916</a>
<a href="#ln917" class="block" id="ln917">917</a>
<a href="#ln918" class="block" id="ln918">918</a>
<a href="#ln919" class="block" id="ln919">919</a>
<a href="#ln920" class="block" id="ln920">920</a>
<a href="#ln921" class="block" id="ln921">921</a>
<a href="#ln922" class="block" id="ln922">922</a>
<a href="#ln923" class="block" id="ln923">923</a>
<a href="#ln924" class="block" id="ln924">924</a>
<a href="#ln925" class="block" id="ln925">925</a>
<a href="#ln926" class="block" id="ln926">926</a>
<a href="#ln927" class="block" id="ln927">927</a>
<a href="#ln928" class="block" id="ln928">928</a>
<a href="#ln929" class="block" id="ln929">929</a>
<a href="#ln930" class="block" id="ln930">930</a>
<a href="#ln931" class="block" id="ln931">931</a>
<a href="#ln932" class="block" id="ln932">932</a>
<a href="#ln933" class="block" id="ln933">933</a>
<a href="#ln934" class="block" id="ln934">934</a>
<a href="#ln935" class="block" id="ln935">935</a>
<a href="#ln936" class="block" id="ln936">936</a>
<a href="#ln937" class="block" id="ln937">937</a>
<a href="#ln938" class="block" id="ln938">938</a>
<a href="#ln939" class="block" id="ln939">939</a>
<a href="#ln940" class="block" id="ln940">940</a>
<a href="#ln941" class="block" id="ln941">941</a>
<a href="#ln942" class="block" id="ln942">942</a>
<a href="#ln943" class="block" id="ln943">943</a>
<a href="#ln944" class="block" id="ln944">944</a>
<a href="#ln945" class="block" id="ln945">945</a>
<a href="#ln946" class="block" id="ln946">946</a>
<a href="#ln947" class="block" id="ln947">947</a>
<a href="#ln948" class="block" id="ln948">948</a>
<a href="#ln949" class="block" id="ln949">949</a>
<a href="#ln950" class="block" id="ln950">950</a>
<a href="#ln951" class="block" id="ln951">951</a>
<a href="#ln952" class="block" id="ln952">952</a>
<a href="#ln953" class="block" id="ln953">953</a>
<a href="#ln954" class="block" id="ln954">954</a>
<a href="#ln955" class="block" id="ln955">955</a>
<a href="#ln956" class="block" id="ln956">956</a>
<a href="#ln957" class="block" id="ln957">957</a>
<a href="#ln958" class="block" id="ln958">958</a>
<a href="#ln959" class="block" id="ln959">959</a>
<a href="#ln960" class="block" id="ln960">960</a>
<a href="#ln961" class="block" id="ln961">961</a>
<a href="#ln962" class="block" id="ln962">962</a>
<a href="#ln963" class="block" id="ln963">963</a>
<a href="#ln964" class="block" id="ln964">964</a>
<a href="#ln965" class="block" id="ln965">965</a>
<a href="#ln966" class="block" id="ln966">966</a>
<a href="#ln967" class="block" id="ln967">967</a>
<a href="#ln968" class="block" id="ln968">968</a>
<a href="#ln969" class="block" id="ln969">969</a>
<a href="#ln970" class="block" id="ln970">970</a>
<a href="#ln971" class="block" id="ln971">971</a>
<a href="#ln972" class="block" id="ln972">972</a>
<a href="#ln973" class="block" id="ln973">973</a>
<a href="#ln974" class="block" id="ln974">974</a>
<a href="#ln975" class="block" id="ln975">975</a>
<a href="#ln976" class="block" id="ln976">976</a>
<a href="#ln977" class="block" id="ln977">977</a>
<a href="#ln978" class="block" id="ln978">978</a>
<a href="#ln979" class="block" id="ln979">979</a>
<a href="#ln980" class="block" id="ln980">980</a>
<a href="#ln981" class="block" id="ln981">981</a>
<a href="#ln982" class="block" id="ln982">982</a>
<a href="#ln983" class="block" id="ln983">983</a>
<a href="#ln984" class="block" id="ln984">984</a>
<a href="#ln985" class="block" id="ln985">985</a>
<a href="#ln986" class="block" id="ln986">986</a>
<a href="#ln987" class="block" id="ln987">987</a>
<a href="#ln988" class="block" id="ln988">988</a>
<a href="#ln989" class="block" id="ln989">989</a>
<a href="#ln990" class="block" id="ln990">990</a>
<a href="#ln991" class="block" id="ln991">991</a>
<a href="#ln992" class="block" id="ln992">992</a>
<a href="#ln993" class="block" id="ln993">993</a>
<a href="#ln994" class="block" id="ln994">994</a>
<a href="#ln995" class="block" id="ln995">995</a>
<a href="#ln996" class="block" id="ln996">996</a>
<a href="#ln997" class="block" id="ln997">997</a>
<a href="#ln998" class="block" id="ln998">998</a>
<a href="#ln999" class="block" id="ln999">999</a>
<a href="#ln1000" class="block" id="ln1000">1000</a>
<a href="#ln1001" class="block" id="ln1001">1001</a>
<a href="#ln1002" class="block" id="ln1002">1002</a>
<a href="#ln1003" class="block" id="ln1003">1003</a>
<a href="#ln1004" class="block" id="ln1004">1004</a>
<a href="#ln1005" class="block" id="ln1005">1005</a>
<a href="#ln1006" class="block" id="ln1006">1006</a>
<a href="#ln1007" class="block" id="ln1007">1007</a>
<a href="#ln1008" class="block" id="ln1008">1008</a>
<a href="#ln1009" class="block" id="ln1009">1009</a>
<a href="#ln1010" class="block" id="ln1010">1010</a>
<a href="#ln1011" class="block" id="ln1011">1011</a>
<a href="#ln1012" class="block" id="ln1012">1012</a>
<a href="#ln1013" class="block" id="ln1013">1013</a>
<a href="#ln1014" class="block" id="ln1014">1014</a>
<a href="#ln1015" class="block" id="ln1015">1015</a>
<a href="#ln1016" class="block" id="ln1016">1016</a>
<a href="#ln1017" class="block" id="ln1017">1017</a>
<a href="#ln1018" class="block" id="ln1018">1018</a>
<a href="#ln1019" class="block" id="ln1019">1019</a>
<a href="#ln1020" class="block" id="ln1020">1020</a>
<a href="#ln1021" class="block" id="ln1021">1021</a>
<a href="#ln1022" class="block" id="ln1022">1022</a>
<a href="#ln1023" class="block" id="ln1023">1023</a>
<a href="#ln1024" class="block" id="ln1024">1024</a>
<a href="#ln1025" class="block" id="ln1025">1025</a>
<a href="#ln1026" class="block" id="ln1026">1026</a>
<a href="#ln1027" class="block" id="ln1027">1027</a>
<a href="#ln1028" class="block" id="ln1028">1028</a>
<a href="#ln1029" class="block" id="ln1029">1029</a>
<a href="#ln1030" class="block" id="ln1030">1030</a>
<a href="#ln1031" class="block" id="ln1031">1031</a>
<a href="#ln1032" class="block" id="ln1032">1032</a>
<a href="#ln1033" class="block" id="ln1033">1033</a>
<a href="#ln1034" class="block" id="ln1034">1034</a>
<a href="#ln1035" class="block" id="ln1035">1035</a>
<a href="#ln1036" class="block" id="ln1036">1036</a>
<a href="#ln1037" class="block" id="ln1037">1037</a>
<a href="#ln1038" class="block" id="ln1038">1038</a>
<a href="#ln1039" class="block" id="ln1039">1039</a>
<a href="#ln1040" class="block" id="ln1040">1040</a>
<a href="#ln1041" class="block" id="ln1041">1041</a>
<a href="#ln1042" class="block" id="ln1042">1042</a>
<a href="#ln1043" class="block" id="ln1043">1043</a>
<a href="#ln1044" class="block" id="ln1044">1044</a>
<a href="#ln1045" class="block" id="ln1045">1045</a>
<a href="#ln1046" class="block" id="ln1046">1046</a>
<a href="#ln1047" class="block" id="ln1047">1047</a>
<a href="#ln1048" class="block" id="ln1048">1048</a>
<a href="#ln1049" class="block" id="ln1049">1049</a>
<a href="#ln1050" class="block" id="ln1050">1050</a>
<a href="#ln1051" class="block" id="ln1051">1051</a>
<a href="#ln1052" class="block" id="ln1052">1052</a>
<a href="#ln1053" class="block" id="ln1053">1053</a>
<a href="#ln1054" class="block" id="ln1054">1054</a>
<a href="#ln1055" class="block" id="ln1055">1055</a>
<a href="#ln1056" class="block" id="ln1056">1056</a>
<a href="#ln1057" class="block" id="ln1057">1057</a>
<a href="#ln1058" class="block" id="ln1058">1058</a>
<a href="#ln1059" class="block" id="ln1059">1059</a>
<a href="#ln1060" class="block" id="ln1060">1060</a>
<a href="#ln1061" class="block" id="ln1061">1061</a>
<a href="#ln1062" class="block" id="ln1062">1062</a>
<a href="#ln1063" class="block" id="ln1063">1063</a>
<a href="#ln1064" class="block" id="ln1064">1064</a>
<a href="#ln1065" class="block" id="ln1065">1065</a>
<a href="#ln1066" class="block" id="ln1066">1066</a>
<a href="#ln1067" class="block" id="ln1067">1067</a>
<a href="#ln1068" class="block" id="ln1068">1068</a>
<a href="#ln1069" class="block" id="ln1069">1069</a>
<a href="#ln1070" class="block" id="ln1070">1070</a>
<a href="#ln1071" class="block" id="ln1071">1071</a>
<a href="#ln1072" class="block" id="ln1072">1072</a>
<a href="#ln1073" class="block" id="ln1073">1073</a>
<a href="#ln1074" class="block" id="ln1074">1074</a>
<a href="#ln1075" class="block" id="ln1075">1075</a>
<a href="#ln1076" class="block" id="ln1076">1076</a>
<a href="#ln1077" class="block" id="ln1077">1077</a>
<a href="#ln1078" class="block" id="ln1078">1078</a>
<a href="#ln1079" class="block" id="ln1079">1079</a>
<a href="#ln1080" class="block" id="ln1080">1080</a>
<a href="#ln1081" class="block" id="ln1081">1081</a>
<a href="#ln1082" class="block" id="ln1082">1082</a>
<a href="#ln1083" class="block" id="ln1083">1083</a>
<a href="#ln1084" class="block" id="ln1084">1084</a>
<a href="#ln1085" class="block" id="ln1085">1085</a>
<a href="#ln1086" class="block" id="ln1086">1086</a>
<a href="#ln1087" class="block" id="ln1087">1087</a>
<a href="#ln1088" class="block" id="ln1088">1088</a>
<a href="#ln1089" class="block" id="ln1089">1089</a>
<a href="#ln1090" class="block" id="ln1090">1090</a>
<a href="#ln1091" class="block" id="ln1091">1091</a>
<a href="#ln1092" class="block" id="ln1092">1092</a>
<a href="#ln1093" class="block" id="ln1093">1093</a>
<a href="#ln1094" class="block" id="ln1094">1094</a>
<a href="#ln1095" class="block" id="ln1095">1095</a>
<a href="#ln1096" class="block" id="ln1096">1096</a>
<a href="#ln1097" class="block" id="ln1097">1097</a>
<a href="#ln1098" class="block" id="ln1098">1098</a>
<a href="#ln1099" class="block" id="ln1099">1099</a>
<a href="#ln1100" class="block" id="ln1100">1100</a>
<a href="#ln1101" class="block" id="ln1101">1101</a>
<a href="#ln1102" class="block" id="ln1102">1102</a>
<a href="#ln1103" class="block" id="ln1103">1103</a>
<a href="#ln1104" class="block" id="ln1104">1104</a>
<a href="#ln1105" class="block" id="ln1105">1105</a>
<a href="#ln1106" class="block" id="ln1106">1106</a>
<a href="#ln1107" class="block" id="ln1107">1107</a>
<a href="#ln1108" class="block" id="ln1108">1108</a>
<a href="#ln1109" class="block" id="ln1109">1109</a>
<a href="#ln1110" class="block" id="ln1110">1110</a>
<a href="#ln1111" class="block" id="ln1111">1111</a>
<a href="#ln1112" class="block" id="ln1112">1112</a>
<a href="#ln1113" class="block" id="ln1113">1113</a>
<a href="#ln1114" class="block" id="ln1114">1114</a>
<a href="#ln1115" class="block" id="ln1115">1115</a>
<a href="#ln1116" class="block" id="ln1116">1116</a>
<a href="#ln1117" class="block" id="ln1117">1117</a>
<a href="#ln1118" class="block" id="ln1118">1118</a>
<a href="#ln1119" class="block" id="ln1119">1119</a>
<a href="#ln1120" class="block" id="ln1120">1120</a>
<a href="#ln1121" class="block" id="ln1121">1121</a>
<a href="#ln1122" class="block" id="ln1122">1122</a>
<a href="#ln1123" class="block" id="ln1123">1123</a>
<a href="#ln1124" class="block" id="ln1124">1124</a>
<a href="#ln1125" class="block" id="ln1125">1125</a>
<a href="#ln1126" class="block" id="ln1126">1126</a>
<a href="#ln1127" class="block" id="ln1127">1127</a>
<a href="#ln1128" class="block" id="ln1128">1128</a>
<a href="#ln1129" class="block" id="ln1129">1129</a>
<a href="#ln1130" class="block" id="ln1130">1130</a>
<a href="#ln1131" class="block" id="ln1131">1131</a>
<a href="#ln1132" class="block" id="ln1132">1132</a>
<a href="#ln1133" class="block" id="ln1133">1133</a>
<a href="#ln1134" class="block" id="ln1134">1134</a>
<a href="#ln1135" class="block" id="ln1135">1135</a>
<a href="#ln1136" class="block" id="ln1136">1136</a>
<a href="#ln1137" class="block" id="ln1137">1137</a>
<a href="#ln1138" class="block" id="ln1138">1138</a>
<a href="#ln1139" class="block" id="ln1139">1139</a>
<a href="#ln1140" class="block" id="ln1140">1140</a>
<a href="#ln1141" class="block" id="ln1141">1141</a>
<a href="#ln1142" class="block" id="ln1142">1142</a>
<a href="#ln1143" class="block" id="ln1143">1143</a>
<a href="#ln1144" class="block" id="ln1144">1144</a>
<a href="#ln1145" class="block" id="ln1145">1145</a>
<a href="#ln1146" class="block" id="ln1146">1146</a>
<a href="#ln1147" class="block" id="ln1147">1147</a>
<a href="#ln1148" class="block" id="ln1148">1148</a>
<a href="#ln1149" class="block" id="ln1149">1149</a>
<a href="#ln1150" class="block" id="ln1150">1150</a>
<a href="#ln1151" class="block" id="ln1151">1151</a>
<a href="#ln1152" class="block" id="ln1152">1152</a>
<a href="#ln1153" class="block" id="ln1153">1153</a>
<a href="#ln1154" class="block" id="ln1154">1154</a>
<a href="#ln1155" class="block" id="ln1155">1155</a>
<a href="#ln1156" class="block" id="ln1156">1156</a>
<a href="#ln1157" class="block" id="ln1157">1157</a>
<a href="#ln1158" class="block" id="ln1158">1158</a>
<a href="#ln1159" class="block" id="ln1159">1159</a>
<a href="#ln1160" class="block" id="ln1160">1160</a>
<a href="#ln1161" class="block" id="ln1161">1161</a>
<a href="#ln1162" class="block" id="ln1162">1162</a>
<a href="#ln1163" class="block" id="ln1163">1163</a>
<a href="#ln1164" class="block" id="ln1164">1164</a>
<a href="#ln1165" class="block" id="ln1165">1165</a>
<a href="#ln1166" class="block" id="ln1166">1166</a>
<a href="#ln1167" class="block" id="ln1167">1167</a>
<a href="#ln1168" class="block" id="ln1168">1168</a>
<a href="#ln1169" class="block" id="ln1169">1169</a>
<a href="#ln1170" class="block" id="ln1170">1170</a>
<a href="#ln1171" class="block" id="ln1171">1171</a>
<a href="#ln1172" class="block" id="ln1172">1172</a>
<a href="#ln1173" class="block" id="ln1173">1173</a>
<a href="#ln1174" class="block" id="ln1174">1174</a>
<a href="#ln1175" class="block" id="ln1175">1175</a>
<a href="#ln1176" class="block" id="ln1176">1176</a>
<a href="#ln1177" class="block" id="ln1177">1177</a>
<a href="#ln1178" class="block" id="ln1178">1178</a>
<a href="#ln1179" class="block" id="ln1179">1179</a>
<a href="#ln1180" class="block" id="ln1180">1180</a>
<a href="#ln1181" class="block" id="ln1181">1181</a>
<a href="#ln1182" class="block" id="ln1182">1182</a>
<a href="#ln1183" class="block" id="ln1183">1183</a>
<a href="#ln1184" class="block" id="ln1184">1184</a>
<a href="#ln1185" class="block" id="ln1185">1185</a>
<a href="#ln1186" class="block" id="ln1186">1186</a>
<a href="#ln1187" class="block" id="ln1187">1187</a>
<a href="#ln1188" class="block" id="ln1188">1188</a>
<a href="#ln1189" class="block" id="ln1189">1189</a>
<a href="#ln1190" class="block" id="ln1190">1190</a>
<a href="#ln1191" class="block" id="ln1191">1191</a>
<a href="#ln1192" class="block" id="ln1192">1192</a>
<a href="#ln1193" class="block" id="ln1193">1193</a>
<a href="#ln1194" class="block" id="ln1194">1194</a>
<a href="#ln1195" class="block" id="ln1195">1195</a>
<a href="#ln1196" class="block" id="ln1196">1196</a>
<a href="#ln1197" class="block" id="ln1197">1197</a>
<a href="#ln1198" class="block" id="ln1198">1198</a>
<a href="#ln1199" class="block" id="ln1199">1199</a>
<a href="#ln1200" class="block" id="ln1200">1200</a>
<a href="#ln1201" class="block" id="ln1201">1201</a>
<a href="#ln1202" class="block" id="ln1202">1202</a>
<a href="#ln1203" class="block" id="ln1203">1203</a>
<a href="#ln1204" class="block" id="ln1204">1204</a>
<a href="#ln1205" class="block" id="ln1205">1205</a>
<a href="#ln1206" class="block" id="ln1206">1206</a>
<a href="#ln1207" class="block" id="ln1207">1207</a>
<a href="#ln1208" class="block" id="ln1208">1208</a>
<a href="#ln1209" class="block" id="ln1209">1209</a>
<a href="#ln1210" class="block" id="ln1210">1210</a>
<a href="#ln1211" class="block" id="ln1211">1211</a>
<a href="#ln1212" class="block" id="ln1212">1212</a>
<a href="#ln1213" class="block" id="ln1213">1213</a>
<a href="#ln1214" class="block" id="ln1214">1214</a>
<a href="#ln1215" class="block" id="ln1215">1215</a>
<a href="#ln1216" class="block" id="ln1216">1216</a>
<a href="#ln1217" class="block" id="ln1217">1217</a>
<a href="#ln1218" class="block" id="ln1218">1218</a>
<a href="#ln1219" class="block" id="ln1219">1219</a>
<a href="#ln1220" class="block" id="ln1220">1220</a>
<a href="#ln1221" class="block" id="ln1221">1221</a>
<a href="#ln1222" class="block" id="ln1222">1222</a>
<a href="#ln1223" class="block" id="ln1223">1223</a>
<a href="#ln1224" class="block" id="ln1224">1224</a>
<a href="#ln1225" class="block" id="ln1225">1225</a>
<a href="#ln1226" class="block" id="ln1226">1226</a>
<a href="#ln1227" class="block" id="ln1227">1227</a>
<a href="#ln1228" class="block" id="ln1228">1228</a>
<a href="#ln1229" class="block" id="ln1229">1229</a>
<a href="#ln1230" class="block" id="ln1230">1230</a>
<a href="#ln1231" class="block" id="ln1231">1231</a>
<a href="#ln1232" class="block" id="ln1232">1232</a>
<a href="#ln1233" class="block" id="ln1233">1233</a>
<a href="#ln1234" class="block" id="ln1234">1234</a>
<a href="#ln1235" class="block" id="ln1235">1235</a>
<a href="#ln1236" class="block" id="ln1236">1236</a>
<a href="#ln1237" class="block" id="ln1237">1237</a>
<a href="#ln1238" class="block" id="ln1238">1238</a>
<a href="#ln1239" class="block" id="ln1239">1239</a>
<a href="#ln1240" class="block" id="ln1240">1240</a>
<a href="#ln1241" class="block" id="ln1241">1241</a>
<a href="#ln1242" class="block" id="ln1242">1242</a>
<a href="#ln1243" class="block" id="ln1243">1243</a>
<a href="#ln1244" class="block" id="ln1244">1244</a>
<a href="#ln1245" class="block" id="ln1245">1245</a>
<a href="#ln1246" class="block" id="ln1246">1246</a>
<a href="#ln1247" class="block" id="ln1247">1247</a>
<a href="#ln1248" class="block" id="ln1248">1248</a>
<a href="#ln1249" class="block" id="ln1249">1249</a>
<a href="#ln1250" class="block" id="ln1250">1250</a>
<a href="#ln1251" class="block" id="ln1251">1251</a>
<a href="#ln1252" class="block" id="ln1252">1252</a>
<a href="#ln1253" class="block" id="ln1253">1253</a>
<a href="#ln1254" class="block" id="ln1254">1254</a>
<a href="#ln1255" class="block" id="ln1255">1255</a>
<a href="#ln1256" class="block" id="ln1256">1256</a>
<a href="#ln1257" class="block" id="ln1257">1257</a>
<a href="#ln1258" class="block" id="ln1258">1258</a>
<a href="#ln1259" class="block" id="ln1259">1259</a>
<a href="#ln1260" class="block" id="ln1260">1260</a>
<a href="#ln1261" class="block" id="ln1261">1261</a>
<a href="#ln1262" class="block" id="ln1262">1262</a>
<a href="#ln1263" class="block" id="ln1263">1263</a>
<a href="#ln1264" class="block" id="ln1264">1264</a>
<a href="#ln1265" class="block" id="ln1265">1265</a>
<a href="#ln1266" class="block" id="ln1266">1266</a>
<a href="#ln1267" class="block" id="ln1267">1267</a>
<a href="#ln1268" class="block" id="ln1268">1268</a>
<a href="#ln1269" class="block" id="ln1269">1269</a>
<a href="#ln1270" class="block" id="ln1270">1270</a>
<a href="#ln1271" class="block" id="ln1271">1271</a>
<a href="#ln1272" class="block" id="ln1272">1272</a>
<a href="#ln1273" class="block" id="ln1273">1273</a>
<a href="#ln1274" class="block" id="ln1274">1274</a>
<a href="#ln1275" class="block" id="ln1275">1275</a>
<a href="#ln1276" class="block" id="ln1276">1276</a>
<a href="#ln1277" class="block" id="ln1277">1277</a>
<a href="#ln1278" class="block" id="ln1278">1278</a>
<a href="#ln1279" class="block" id="ln1279">1279</a>
<a href="#ln1280" class="block" id="ln1280">1280</a>
<a href="#ln1281" class="block" id="ln1281">1281</a>
<a href="#ln1282" class="block" id="ln1282">1282</a>
<a href="#ln1283" class="block" id="ln1283">1283</a>
<a href="#ln1284" class="block" id="ln1284">1284</a>
<a href="#ln1285" class="block" id="ln1285">1285</a>
<a href="#ln1286" class="block" id="ln1286">1286</a>
<a href="#ln1287" class="block" id="ln1287">1287</a>
<a href="#ln1288" class="block" id="ln1288">1288</a>
<a href="#ln1289" class="block" id="ln1289">1289</a>
<a href="#ln1290" class="block" id="ln1290">1290</a>
<a href="#ln1291" class="block" id="ln1291">1291</a>
<a href="#ln1292" class="block" id="ln1292">1292</a>
<a href="#ln1293" class="block" id="ln1293">1293</a>
<a href="#ln1294" class="block" id="ln1294">1294</a>
<a href="#ln1295" class="block" id="ln1295">1295</a>
<a href="#ln1296" class="block" id="ln1296">1296</a>
<a href="#ln1297" class="block" id="ln1297">1297</a>
<a href="#ln1298" class="block" id="ln1298">1298</a>
<a href="#ln1299" class="block" id="ln1299">1299</a>
<a href="#ln1300" class="block" id="ln1300">1300</a>
<a href="#ln1301" class="block" id="ln1301">1301</a>
<a href="#ln1302" class="block" id="ln1302">1302</a>
<a href="#ln1303" class="block" id="ln1303">1303</a>
<a href="#ln1304" class="block" id="ln1304">1304</a>
<a href="#ln1305" class="block" id="ln1305">1305</a>
<a href="#ln1306" class="block" id="ln1306">1306</a>
<a href="#ln1307" class="block" id="ln1307">1307</a>
<a href="#ln1308" class="block" id="ln1308">1308</a>
<a href="#ln1309" class="block" id="ln1309">1309</a>
<a href="#ln1310" class="block" id="ln1310">1310</a>
<a href="#ln1311" class="block" id="ln1311">1311</a>
<a href="#ln1312" class="block" id="ln1312">1312</a>
<a href="#ln1313" class="block" id="ln1313">1313</a>
<a href="#ln1314" class="block" id="ln1314">1314</a>
<a href="#ln1315" class="block" id="ln1315">1315</a>
<a href="#ln1316" class="block" id="ln1316">1316</a>
<a href="#ln1317" class="block" id="ln1317">1317</a>
<a href="#ln1318" class="block" id="ln1318">1318</a>
<a href="#ln1319" class="block" id="ln1319">1319</a>
<a href="#ln1320" class="block" id="ln1320">1320</a>
<a href="#ln1321" class="block" id="ln1321">1321</a>
<a href="#ln1322" class="block" id="ln1322">1322</a>
<a href="#ln1323" class="block" id="ln1323">1323</a>
<a href="#ln1324" class="block" id="ln1324">1324</a>
<a href="#ln1325" class="block" id="ln1325">1325</a>
<a href="#ln1326" class="block" id="ln1326">1326</a>
<a href="#ln1327" class="block" id="ln1327">1327</a>
<a href="#ln1328" class="block" id="ln1328">1328</a>
<a href="#ln1329" class="block" id="ln1329">1329</a>
<a href="#ln1330" class="block" id="ln1330">1330</a>
<a href="#ln1331" class="block" id="ln1331">1331</a>
<a href="#ln1332" class="block" id="ln1332">1332</a>
<a href="#ln1333" class="block" id="ln1333">1333</a>
<a href="#ln1334" class="block" id="ln1334">1334</a>
<a href="#ln1335" class="block" id="ln1335">1335</a>
<a href="#ln1336" class="block" id="ln1336">1336</a>
<a href="#ln1337" class="block" id="ln1337">1337</a>
<a href="#ln1338" class="block" id="ln1338">1338</a>
<a href="#ln1339" class="block" id="ln1339">1339</a>
<a href="#ln1340" class="block" id="ln1340">1340</a>
<a href="#ln1341" class="block" id="ln1341">1341</a>
<a href="#ln1342" class="block" id="ln1342">1342</a>
<a href="#ln1343" class="block" id="ln1343">1343</a>
<a href="#ln1344" class="block" id="ln1344">1344</a>
<a href="#ln1345" class="block" id="ln1345">1345</a>
<a href="#ln1346" class="block" id="ln1346">1346</a>
<a href="#ln1347" class="block" id="ln1347">1347</a>
<a href="#ln1348" class="block" id="ln1348">1348</a>
<a href="#ln1349" class="block" id="ln1349">1349</a>
<a href="#ln1350" class="block" id="ln1350">1350</a>
<a href="#ln1351" class="block" id="ln1351">1351</a>
<a href="#ln1352" class="block" id="ln1352">1352</a>
<a href="#ln1353" class="block" id="ln1353">1353</a></pre></th>
            <td><pre class="prettyprint lang-cs">﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// &lt;auto-generated&gt;
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// &lt;/auto-generated&gt;
//------------------------------------------------------------------------------

namespace GmailHelper.Data.Linq
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name=&quot;GmailHelper&quot;)]
	public partial class GmailHelperLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLabel(Label instance);
    partial void UpdateLabel(Label instance);
    partial void DeleteLabel(Label instance);
    partial void InsertMailLabel(MailLabel instance);
    partial void UpdateMailLabel(MailLabel instance);
    partial void DeleteMailLabel(MailLabel instance);
    partial void InsertMailWord(MailWord instance);
    partial void UpdateMailWord(MailWord instance);
    partial void DeleteMailWord(MailWord instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertMail(Mail instance);
    partial void UpdateMail(Mail instance);
    partial void DeleteMail(Mail instance);
    partial void InsertError(Error instance);
    partial void UpdateError(Error instance);
    partial void DeleteError(Error instance);
    #endregion
		
		public GmailHelperLinqDataContext() : 
				base(global::GmailHelper.Data.Linq.Properties.Settings.Default.GmailHelperConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public GmailHelperLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GmailHelperLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GmailHelperLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GmailHelperLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table&lt;Label&gt; Labels
		{
			get
			{
				return this.GetTable&lt;Label&gt;();
			}
		}
		
		public System.Data.Linq.Table&lt;MailLabel&gt; MailLabels
		{
			get
			{
				return this.GetTable&lt;MailLabel&gt;();
			}
		}
		
		public System.Data.Linq.Table&lt;MailWord&gt; MailWords
		{
			get
			{
				return this.GetTable&lt;MailWord&gt;();
			}
		}
		
		public System.Data.Linq.Table&lt;User&gt; Users
		{
			get
			{
				return this.GetTable&lt;User&gt;();
			}
		}
		
		public System.Data.Linq.Table&lt;Mail&gt; Mails
		{
			get
			{
				return this.GetTable&lt;Mail&gt;();
			}
		}
		
		public System.Data.Linq.Table&lt;Error&gt; Errors
		{
			get
			{
				return this.GetTable&lt;Error&gt;();
			}
		}
	}
	
	[Table(Name=&quot;dbo.Label&quot;)]
	public partial class Label : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _LabelId;
		
		private int _UserId;
		
		private string _Name;
		
		private EntitySet&lt;MailLabel&gt; _MailLabels;
		
		private EntityRef&lt;User&gt; _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLabelIdChanging(int value);
    partial void OnLabelIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Label()
		{
			this._MailLabels = new EntitySet&lt;MailLabel&gt;(new Action&lt;MailLabel&gt;(this.attach_MailLabels), new Action&lt;MailLabel&gt;(this.detach_MailLabels));
			this._User = default(EntityRef&lt;User&gt;);
			OnCreated();
		}
		
		[Column(Storage=&quot;_LabelId&quot;, DbType=&quot;Int NOT NULL&quot;, IsPrimaryKey=true)]
		public int LabelId
		{
			get
			{
				return this._LabelId;
			}
			set
			{
				if ((this._LabelId != value))
				{
					this.OnLabelIdChanging(value);
					this.SendPropertyChanging();
					this._LabelId = value;
					this.SendPropertyChanged(&quot;LabelId&quot;);
					this.OnLabelIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_UserId&quot;, DbType=&quot;Int NOT NULL&quot;)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged(&quot;UserId&quot;);
					this.OnUserIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Name&quot;, DbType=&quot;NVarChar(50) NOT NULL&quot;, CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged(&quot;Name&quot;);
					this.OnNameChanged();
				}
			}
		}
		
		[Association(Name=&quot;Label_MailLabel&quot;, Storage=&quot;_MailLabels&quot;, ThisKey=&quot;LabelId&quot;, OtherKey=&quot;LabelId&quot;)]
		public EntitySet&lt;MailLabel&gt; MailLabels
		{
			get
			{
				return this._MailLabels;
			}
			set
			{
				this._MailLabels.Assign(value);
			}
		}
		
		[Association(Name=&quot;User_Label&quot;, Storage=&quot;_User&quot;, ThisKey=&quot;UserId&quot;, OtherKey=&quot;UserId&quot;, IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Labels.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Labels.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged(&quot;User&quot;);
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_MailLabels(MailLabel entity)
		{
			this.SendPropertyChanging();
			entity.Label = this;
		}
		
		private void detach_MailLabels(MailLabel entity)
		{
			this.SendPropertyChanging();
			entity.Label = null;
		}
	}
	
	[Table(Name=&quot;dbo.MailLabels&quot;)]
	public partial class MailLabel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MailId;
		
		private int _LabelId;
		
		private long _ImapId;
		
		private EntityRef&lt;Label&gt; _Label;
		
		private EntityRef&lt;Mail&gt; _Mail;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMailIdChanging(int value);
    partial void OnMailIdChanged();
    partial void OnLabelIdChanging(int value);
    partial void OnLabelIdChanged();
    partial void OnImapIdChanging(long value);
    partial void OnImapIdChanged();
    #endregion
		
		public MailLabel()
		{
			this._Label = default(EntityRef&lt;Label&gt;);
			this._Mail = default(EntityRef&lt;Mail&gt;);
			OnCreated();
		}
		
		[Column(Storage=&quot;_MailId&quot;, DbType=&quot;Int NOT NULL&quot;, IsPrimaryKey=true)]
		public int MailId
		{
			get
			{
				return this._MailId;
			}
			set
			{
				if ((this._MailId != value))
				{
					if (this._Mail.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMailIdChanging(value);
					this.SendPropertyChanging();
					this._MailId = value;
					this.SendPropertyChanged(&quot;MailId&quot;);
					this.OnMailIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_LabelId&quot;, DbType=&quot;Int NOT NULL&quot;, IsPrimaryKey=true)]
		public int LabelId
		{
			get
			{
				return this._LabelId;
			}
			set
			{
				if ((this._LabelId != value))
				{
					if (this._Label.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLabelIdChanging(value);
					this.SendPropertyChanging();
					this._LabelId = value;
					this.SendPropertyChanged(&quot;LabelId&quot;);
					this.OnLabelIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_ImapId&quot;, DbType=&quot;BigInt NOT NULL&quot;)]
		public long ImapId
		{
			get
			{
				return this._ImapId;
			}
			set
			{
				if ((this._ImapId != value))
				{
					this.OnImapIdChanging(value);
					this.SendPropertyChanging();
					this._ImapId = value;
					this.SendPropertyChanged(&quot;ImapId&quot;);
					this.OnImapIdChanged();
				}
			}
		}
		
		[Association(Name=&quot;Label_MailLabel&quot;, Storage=&quot;_Label&quot;, ThisKey=&quot;LabelId&quot;, OtherKey=&quot;LabelId&quot;, IsForeignKey=true)]
		public Label Label
		{
			get
			{
				return this._Label.Entity;
			}
			set
			{
				Label previousValue = this._Label.Entity;
				if (((previousValue != value) 
							|| (this._Label.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Label.Entity = null;
						previousValue.MailLabels.Remove(this);
					}
					this._Label.Entity = value;
					if ((value != null))
					{
						value.MailLabels.Add(this);
						this._LabelId = value.LabelId;
					}
					else
					{
						this._LabelId = default(int);
					}
					this.SendPropertyChanged(&quot;Label&quot;);
				}
			}
		}
		
		[Association(Name=&quot;Mail_MailLabel&quot;, Storage=&quot;_Mail&quot;, ThisKey=&quot;MailId&quot;, OtherKey=&quot;MailId&quot;, IsForeignKey=true)]
		public Mail Mail
		{
			get
			{
				return this._Mail.Entity;
			}
			set
			{
				Mail previousValue = this._Mail.Entity;
				if (((previousValue != value) 
							|| (this._Mail.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Mail.Entity = null;
						previousValue.MailLabels.Remove(this);
					}
					this._Mail.Entity = value;
					if ((value != null))
					{
						value.MailLabels.Add(this);
						this._MailId = value.MailId;
					}
					else
					{
						this._MailId = default(int);
					}
					this.SendPropertyChanged(&quot;Mail&quot;);
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name=&quot;dbo.MailWord&quot;)]
	public partial class MailWord : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MailId;
		
		private string _Word;
		
		private int _BodyFrequency;
		
		private int _SubjectFrequency;
		
		private EntityRef&lt;Mail&gt; _Mail;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMailIdChanging(int value);
    partial void OnMailIdChanged();
    partial void OnWordChanging(string value);
    partial void OnWordChanged();
    partial void OnBodyFrequencyChanging(int value);
    partial void OnBodyFrequencyChanged();
    partial void OnSubjectFrequencyChanging(int value);
    partial void OnSubjectFrequencyChanged();
    #endregion
		
		public MailWord()
		{
			this._Mail = default(EntityRef&lt;Mail&gt;);
			OnCreated();
		}
		
		[Column(Storage=&quot;_MailId&quot;, DbType=&quot;Int NOT NULL&quot;, IsPrimaryKey=true)]
		public int MailId
		{
			get
			{
				return this._MailId;
			}
			set
			{
				if ((this._MailId != value))
				{
					if (this._Mail.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMailIdChanging(value);
					this.SendPropertyChanging();
					this._MailId = value;
					this.SendPropertyChanged(&quot;MailId&quot;);
					this.OnMailIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Word&quot;, DbType=&quot;NVarChar(250) NOT NULL&quot;, CanBeNull=false, IsPrimaryKey=true)]
		public string Word
		{
			get
			{
				return this._Word;
			}
			set
			{
				if ((this._Word != value))
				{
					this.OnWordChanging(value);
					this.SendPropertyChanging();
					this._Word = value;
					this.SendPropertyChanged(&quot;Word&quot;);
					this.OnWordChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_BodyFrequency&quot;, DbType=&quot;Int NOT NULL&quot;)]
		public int BodyFrequency
		{
			get
			{
				return this._BodyFrequency;
			}
			set
			{
				if ((this._BodyFrequency != value))
				{
					this.OnBodyFrequencyChanging(value);
					this.SendPropertyChanging();
					this._BodyFrequency = value;
					this.SendPropertyChanged(&quot;BodyFrequency&quot;);
					this.OnBodyFrequencyChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_SubjectFrequency&quot;, DbType=&quot;Int NOT NULL&quot;)]
		public int SubjectFrequency
		{
			get
			{
				return this._SubjectFrequency;
			}
			set
			{
				if ((this._SubjectFrequency != value))
				{
					this.OnSubjectFrequencyChanging(value);
					this.SendPropertyChanging();
					this._SubjectFrequency = value;
					this.SendPropertyChanged(&quot;SubjectFrequency&quot;);
					this.OnSubjectFrequencyChanged();
				}
			}
		}
		
		[Association(Name=&quot;Mail_MailWord&quot;, Storage=&quot;_Mail&quot;, ThisKey=&quot;MailId&quot;, OtherKey=&quot;MailId&quot;, IsForeignKey=true, DeleteOnNull=true, DeleteRule=&quot;CASCADE&quot;)]
		public Mail Mail
		{
			get
			{
				return this._Mail.Entity;
			}
			set
			{
				Mail previousValue = this._Mail.Entity;
				if (((previousValue != value) 
							|| (this._Mail.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Mail.Entity = null;
						previousValue.MailWords.Remove(this);
					}
					this._Mail.Entity = value;
					if ((value != null))
					{
						value.MailWords.Add(this);
						this._MailId = value.MailId;
					}
					else
					{
						this._MailId = default(int);
					}
					this.SendPropertyChanged(&quot;Mail&quot;);
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name=&quot;dbo.[User]&quot;)]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _Email;
		
		private EntitySet&lt;Label&gt; _Labels;
		
		private EntitySet&lt;Mail&gt; _Mails;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public User()
		{
			this._Labels = new EntitySet&lt;Label&gt;(new Action&lt;Label&gt;(this.attach_Labels), new Action&lt;Label&gt;(this.detach_Labels));
			this._Mails = new EntitySet&lt;Mail&gt;(new Action&lt;Mail&gt;(this.attach_Mails), new Action&lt;Mail&gt;(this.detach_Mails));
			OnCreated();
		}
		
		[Column(Storage=&quot;_UserId&quot;, AutoSync=AutoSync.OnInsert, DbType=&quot;Int NOT NULL IDENTITY&quot;, IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged(&quot;UserId&quot;);
					this.OnUserIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Email&quot;, DbType=&quot;VarChar(255) NOT NULL&quot;, CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged(&quot;Email&quot;);
					this.OnEmailChanged();
				}
			}
		}
		
		[Association(Name=&quot;User_Label&quot;, Storage=&quot;_Labels&quot;, ThisKey=&quot;UserId&quot;, OtherKey=&quot;UserId&quot;)]
		public EntitySet&lt;Label&gt; Labels
		{
			get
			{
				return this._Labels;
			}
			set
			{
				this._Labels.Assign(value);
			}
		}
		
		[Association(Name=&quot;User_Mail&quot;, Storage=&quot;_Mails&quot;, ThisKey=&quot;UserId&quot;, OtherKey=&quot;UserId&quot;)]
		public EntitySet&lt;Mail&gt; Mails
		{
			get
			{
				return this._Mails;
			}
			set
			{
				this._Mails.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Labels(Label entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Labels(Label entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_Mails(Mail entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Mails(Mail entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[Table(Name=&quot;dbo.Mail&quot;)]
	public partial class Mail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MailId;
		
		private string _Subject;
		
		private string _Body;
		
		private System.Nullable&lt;System.DateTime&gt; _Sent;
		
		private System.Nullable&lt;System.DateTime&gt; _Received;
		
		private System.Nullable&lt;int&gt; _ImapId;
		
		private string _MessageId;
		
		private string _InReplyToId;
		
		private string _GmailThreadId;
		
		private int _UserId;
		
		private string _DateString;
		
		private EntitySet&lt;MailLabel&gt; _MailLabels;
		
		private EntitySet&lt;MailWord&gt; _MailWords;
		
		private EntityRef&lt;User&gt; _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMailIdChanging(int value);
    partial void OnMailIdChanged();
    partial void OnSubjectChanging(string value);
    partial void OnSubjectChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnSentChanging(System.Nullable&lt;System.DateTime&gt; value);
    partial void OnSentChanged();
    partial void OnReceivedChanging(System.Nullable&lt;System.DateTime&gt; value);
    partial void OnReceivedChanged();
    partial void OnImapIdChanging(System.Nullable&lt;int&gt; value);
    partial void OnImapIdChanged();
    partial void OnMessageIdChanging(string value);
    partial void OnMessageIdChanged();
    partial void OnInReplyToIdChanging(string value);
    partial void OnInReplyToIdChanged();
    partial void OnGmailThreadIdChanging(string value);
    partial void OnGmailThreadIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnDateStringChanging(string value);
    partial void OnDateStringChanged();
    #endregion
		
		public Mail()
		{
			this._MailLabels = new EntitySet&lt;MailLabel&gt;(new Action&lt;MailLabel&gt;(this.attach_MailLabels), new Action&lt;MailLabel&gt;(this.detach_MailLabels));
			this._MailWords = new EntitySet&lt;MailWord&gt;(new Action&lt;MailWord&gt;(this.attach_MailWords), new Action&lt;MailWord&gt;(this.detach_MailWords));
			this._User = default(EntityRef&lt;User&gt;);
			OnCreated();
		}
		
		[Column(Storage=&quot;_MailId&quot;, AutoSync=AutoSync.OnInsert, DbType=&quot;Int NOT NULL IDENTITY&quot;, IsPrimaryKey=true, IsDbGenerated=true)]
		public int MailId
		{
			get
			{
				return this._MailId;
			}
			set
			{
				if ((this._MailId != value))
				{
					this.OnMailIdChanging(value);
					this.SendPropertyChanging();
					this._MailId = value;
					this.SendPropertyChanged(&quot;MailId&quot;);
					this.OnMailIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Subject&quot;, DbType=&quot;NVarChar(2000)&quot;)]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this.OnSubjectChanging(value);
					this.SendPropertyChanging();
					this._Subject = value;
					this.SendPropertyChanged(&quot;Subject&quot;);
					this.OnSubjectChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Body&quot;, DbType=&quot;NText&quot;, UpdateCheck=UpdateCheck.Never)]
		public string Body
		{
			get
			{
				return this._Body;
			}
			set
			{
				if ((this._Body != value))
				{
					this.OnBodyChanging(value);
					this.SendPropertyChanging();
					this._Body = value;
					this.SendPropertyChanged(&quot;Body&quot;);
					this.OnBodyChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Sent&quot;, DbType=&quot;SmallDateTime&quot;)]
		public System.Nullable&lt;System.DateTime&gt; Sent
		{
			get
			{
				return this._Sent;
			}
			set
			{
				if ((this._Sent != value))
				{
					this.OnSentChanging(value);
					this.SendPropertyChanging();
					this._Sent = value;
					this.SendPropertyChanged(&quot;Sent&quot;);
					this.OnSentChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Received&quot;, DbType=&quot;SmallDateTime&quot;)]
		public System.Nullable&lt;System.DateTime&gt; Received
		{
			get
			{
				return this._Received;
			}
			set
			{
				if ((this._Received != value))
				{
					this.OnReceivedChanging(value);
					this.SendPropertyChanging();
					this._Received = value;
					this.SendPropertyChanged(&quot;Received&quot;);
					this.OnReceivedChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_ImapId&quot;, DbType=&quot;Int&quot;)]
		public System.Nullable&lt;int&gt; ImapId
		{
			get
			{
				return this._ImapId;
			}
			set
			{
				if ((this._ImapId != value))
				{
					this.OnImapIdChanging(value);
					this.SendPropertyChanging();
					this._ImapId = value;
					this.SendPropertyChanged(&quot;ImapId&quot;);
					this.OnImapIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_MessageId&quot;, DbType=&quot;VarChar(500)&quot;)]
		public string MessageId
		{
			get
			{
				return this._MessageId;
			}
			set
			{
				if ((this._MessageId != value))
				{
					this.OnMessageIdChanging(value);
					this.SendPropertyChanging();
					this._MessageId = value;
					this.SendPropertyChanged(&quot;MessageId&quot;);
					this.OnMessageIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_InReplyToId&quot;, DbType=&quot;VarChar(500)&quot;)]
		public string InReplyToId
		{
			get
			{
				return this._InReplyToId;
			}
			set
			{
				if ((this._InReplyToId != value))
				{
					this.OnInReplyToIdChanging(value);
					this.SendPropertyChanging();
					this._InReplyToId = value;
					this.SendPropertyChanged(&quot;InReplyToId&quot;);
					this.OnInReplyToIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_GmailThreadId&quot;, DbType=&quot;VarChar(50)&quot;)]
		public string GmailThreadId
		{
			get
			{
				return this._GmailThreadId;
			}
			set
			{
				if ((this._GmailThreadId != value))
				{
					this.OnGmailThreadIdChanging(value);
					this.SendPropertyChanging();
					this._GmailThreadId = value;
					this.SendPropertyChanged(&quot;GmailThreadId&quot;);
					this.OnGmailThreadIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_UserId&quot;, DbType=&quot;Int NOT NULL&quot;)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged(&quot;UserId&quot;);
					this.OnUserIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_DateString&quot;, DbType=&quot;VarChar(255)&quot;)]
		public string DateString
		{
			get
			{
				return this._DateString;
			}
			set
			{
				if ((this._DateString != value))
				{
					this.OnDateStringChanging(value);
					this.SendPropertyChanging();
					this._DateString = value;
					this.SendPropertyChanged(&quot;DateString&quot;);
					this.OnDateStringChanged();
				}
			}
		}
		
		[Association(Name=&quot;Mail_MailLabel&quot;, Storage=&quot;_MailLabels&quot;, ThisKey=&quot;MailId&quot;, OtherKey=&quot;MailId&quot;)]
		public EntitySet&lt;MailLabel&gt; MailLabels
		{
			get
			{
				return this._MailLabels;
			}
			set
			{
				this._MailLabels.Assign(value);
			}
		}
		
		[Association(Name=&quot;Mail_MailWord&quot;, Storage=&quot;_MailWords&quot;, ThisKey=&quot;MailId&quot;, OtherKey=&quot;MailId&quot;)]
		public EntitySet&lt;MailWord&gt; MailWords
		{
			get
			{
				return this._MailWords;
			}
			set
			{
				this._MailWords.Assign(value);
			}
		}
		
		[Association(Name=&quot;User_Mail&quot;, Storage=&quot;_User&quot;, ThisKey=&quot;UserId&quot;, OtherKey=&quot;UserId&quot;, IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Mails.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Mails.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged(&quot;User&quot;);
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_MailLabels(MailLabel entity)
		{
			this.SendPropertyChanging();
			entity.Mail = this;
		}
		
		private void detach_MailLabels(MailLabel entity)
		{
			this.SendPropertyChanging();
			entity.Mail = null;
		}
		
		private void attach_MailWords(MailWord entity)
		{
			this.SendPropertyChanging();
			entity.Mail = this;
		}
		
		private void detach_MailWords(MailWord entity)
		{
			this.SendPropertyChanging();
			entity.Mail = null;
		}
	}
	
	[Table(Name=&quot;dbo.Errors&quot;)]
	public partial class Error : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ErrorId;
		
		private string _Exception;
		
		private string _CallsStack;
		
		private string _Context;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnErrorIdChanging(int value);
    partial void OnErrorIdChanged();
    partial void OnExceptionChanging(string value);
    partial void OnExceptionChanged();
    partial void OnCallsStackChanging(string value);
    partial void OnCallsStackChanged();
    partial void OnContextChanging(string value);
    partial void OnContextChanged();
    #endregion
		
		public Error()
		{
			OnCreated();
		}
		
		[Column(Storage=&quot;_ErrorId&quot;, AutoSync=AutoSync.OnInsert, DbType=&quot;Int NOT NULL IDENTITY&quot;, IsPrimaryKey=true, IsDbGenerated=true)]
		public int ErrorId
		{
			get
			{
				return this._ErrorId;
			}
			set
			{
				if ((this._ErrorId != value))
				{
					this.OnErrorIdChanging(value);
					this.SendPropertyChanging();
					this._ErrorId = value;
					this.SendPropertyChanged(&quot;ErrorId&quot;);
					this.OnErrorIdChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Exception&quot;, DbType=&quot;VarChar(50)&quot;)]
		public string Exception
		{
			get
			{
				return this._Exception;
			}
			set
			{
				if ((this._Exception != value))
				{
					this.OnExceptionChanging(value);
					this.SendPropertyChanging();
					this._Exception = value;
					this.SendPropertyChanged(&quot;Exception&quot;);
					this.OnExceptionChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_CallsStack&quot;, DbType=&quot;Text&quot;, UpdateCheck=UpdateCheck.Never)]
		public string CallsStack
		{
			get
			{
				return this._CallsStack;
			}
			set
			{
				if ((this._CallsStack != value))
				{
					this.OnCallsStackChanging(value);
					this.SendPropertyChanging();
					this._CallsStack = value;
					this.SendPropertyChanged(&quot;CallsStack&quot;);
					this.OnCallsStackChanged();
				}
			}
		}
		
		[Column(Storage=&quot;_Context&quot;, DbType=&quot;NText&quot;, UpdateCheck=UpdateCheck.Never)]
		public string Context
		{
			get
			{
				return this._Context;
			}
			set
			{
				if ((this._Context != value))
				{
					this.OnContextChanging(value);
					this.SendPropertyChanging();
					this._Context = value;
					this.SendPropertyChanged(&quot;Context&quot;);
					this.OnContextChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591</pre></td>
          </tr>
        </tbody>
      </table>
</div>

<script type="text/javascript">
//<![CDATA[
if (window.location.href.split("#").length != 1) { $("ln-num").show(); }
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
NREUMQ.push(["nrfj","beacon-1.newrelic.com","9dfe439095",8763,"Il9dRhNbCVtVQhgXQgBTVkFOWgpTVUMYF1oORw==",0.0,84,new Date().getTime(),"","","","",""])</script></body>
</html>




