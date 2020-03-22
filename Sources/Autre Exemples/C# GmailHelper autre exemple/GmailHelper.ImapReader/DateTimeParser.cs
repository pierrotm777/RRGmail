



  



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head><script type="text/javascript">var NREUMQ=NREUMQ||[];NREUMQ.push(["mark","firstbyte",new Date().getTime()]);</script>
    <title>GmailHelper/GmailHelper.ImapReader/DateTimeParser.cs | Source/SVN | Assembla</title>
    <link href="http://assets1.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="shortcut icon" />
    <link href="http://assets1.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="icon" />
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
  <h1 class="icon-breadcrumb-path"><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=11" class="root">root</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper?rev=11">GmailHelper</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.ImapReader?rev=11">GmailHelper.ImapReader</a>/<span>DateTimeParser.cs</span><span>    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
            width="110"
            height="14"
            id="clippy" >
    <param name="movie" value="/clippy.swf"/>
    <param name="allowScriptAccess" value="always" />
    <param name="quality" value="high" />
    <param name="scale" value="noscale" />
    <param NAME="FlashVars" value="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.ImapReader/DateTimeParser.cs/" />
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
           FlashVars="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.ImapReader/DateTimeParser.cs/"
           bgcolor="#FFFFFF"
           wmode="transparent"
    />
    </object>
</span></h1>
  
<div class="commit-infobox">
  <div class="commit-options">
    <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/logs/GmailHelper/GmailHelper.ImapReader/DateTimeParser.cs?rev=11" class="revision-log" rel="nofollow">Revision log</a>
      <div style="margin-right: 10px;" class="small-icon-button">
        <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/live/11/GmailHelper/GmailHelper.ImapReader/DateTimeParser.cs" class="view-icon" rel="nofollow">View as a web page</a>
      </div>

        <div style="margin-right: 10px;" class="small-icon-button">
    <a class="download-icon" href="#" onclick="nobotGoto('!/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.ImapReader/DateTimeParser.cs?_format=raw&amp;rev=11'); return false;">Download</a>
  </div>


  </div>

  <div class="committer-pic">
    <img alt="User picture" src="http://assets1.assembla.com/images/no-picture.png?1340419163" />
  </div>

  
<div class="commit-info">

    <p class="committer-info"><span>Author:</span> <a href="/profile/kazazic" tabindex="-1" target="_blank" title="Show Profile">kazazic</a></p>

  <p class="committer-info"><span>Revision:</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/changesets/8">11</a> (<span>«<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=10">Previous</a></span> <span><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=12">Next</a>»</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes">Latest</a>)</p><br />
    <p class="commit-size">
      <span>File Size:</span>
      10.6 KB
    </p>
  <p class="commit-date">(January 01, 2010 14:43 UTC) Over 2 years ago</p>
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
<a href="#ln267" class="block" id="ln267">267</a></pre></th>
            <td><pre class="prettyprint lang-cs">﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GmailHelper.ImapReader
{
    public static class DateTimeParser
    {
        private static string[][] TimeZones = new string[][] {
    new string[] {&quot;ACDT&quot;, &quot;+1030&quot;, &quot;Australian Central Daylight&quot;},
    new string[] {&quot;ACST&quot;, &quot;+0930&quot;, &quot;Australian Central Standard&quot;},
    new string[] {&quot;ADT&quot;, &quot;-0300&quot;, &quot;(US) Atlantic Daylight&quot;},
    new string[] {&quot;AEDT&quot;, &quot;+1100&quot;, &quot;Australian East Daylight&quot;},
    new string[] {&quot;AEST&quot;, &quot;+1000&quot;, &quot;Australian East Standard&quot;},
    new string[] {&quot;AHDT&quot;, &quot;-0900&quot;, &quot;&quot;},
    new string[] {&quot;AHST&quot;, &quot;-1000&quot;, &quot;&quot;},
    new string[] {&quot;AST&quot;, &quot;-0400&quot;, &quot;(US) Atlantic Standard&quot;},
    new string[] {&quot;AT&quot;, &quot;-0200&quot;, &quot;Azores&quot;},
    new string[] {&quot;AWDT&quot;, &quot;+0900&quot;, &quot;Australian West Daylight&quot;},
    new string[] {&quot;AWST&quot;, &quot;+0800&quot;, &quot;Australian West Standard&quot;},
    new string[] {&quot;BAT&quot;, &quot;+0300&quot;, &quot;Bhagdad&quot;},
    new string[] {&quot;BDST&quot;, &quot;+0200&quot;, &quot;British Double Summer&quot;},
    new string[] {&quot;BET&quot;, &quot;-1100&quot;, &quot;Bering Standard&quot;},
    new string[] {&quot;BST&quot;, &quot;-0300&quot;, &quot;Brazil Standard&quot;},
    new string[] {&quot;BT&quot;, &quot;+0300&quot;, &quot;Baghdad&quot;},
    new string[] {&quot;BZT2&quot;, &quot;-0300&quot;, &quot;Brazil Zone 2&quot;},
    new string[] {&quot;CADT&quot;, &quot;+1030&quot;, &quot;Central Australian Daylight&quot;},
    new string[] {&quot;CAST&quot;, &quot;+0930&quot;, &quot;Central Australian Standard&quot;},
    new string[] {&quot;CAT&quot;, &quot;-1000&quot;, &quot;Central Alaska&quot;},
    new string[] {&quot;CCT&quot;, &quot;+0800&quot;, &quot;China Coast&quot;},
    new string[] {&quot;CDT&quot;, &quot;-0500&quot;, &quot;(US) Central Daylight&quot;},
    new string[] {&quot;CED&quot;, &quot;+0200&quot;, &quot;Central European Daylight&quot;},
    new string[] {&quot;CET&quot;, &quot;+0100&quot;, &quot;Central European&quot;},
    new string[] {&quot;CST&quot;, &quot;-0600&quot;, &quot;(US) Central Standard&quot;},
    new string[] {&quot;CENTRAL&quot;, &quot;-0600&quot;, &quot;(US) Central Standard&quot;},
    new string[] {&quot;EAST&quot;, &quot;+1000&quot;, &quot;Eastern Australian Standard&quot;},
    new string[] {&quot;EDT&quot;, &quot;-0400&quot;, &quot;(US) Eastern Daylight&quot;},
    new string[] {&quot;EED&quot;, &quot;+0300&quot;, &quot;Eastern European Daylight&quot;},
    new string[] {&quot;EET&quot;, &quot;+0200&quot;, &quot;Eastern Europe&quot;},
    new string[] {&quot;EEST&quot;, &quot;+0300&quot;, &quot;Eastern Europe Summer&quot;},
    new string[] {&quot;EST&quot;, &quot;-0500&quot;, &quot;(US) Eastern Standard&quot;},
    new string[] {&quot;EASTERN&quot;, &quot;-0500&quot;, &quot;(US) Eastern Standard&quot;},
    new string[] {&quot;FST&quot;, &quot;+0200&quot;, &quot;French Summer&quot;},
    new string[] {&quot;FWT&quot;, &quot;+0100&quot;, &quot;French Winter&quot;},
    new string[] {&quot;GMT&quot;, &quot;-0000&quot;, &quot;Greenwich Mean&quot;},
    new string[] {&quot;GST&quot;, &quot;+1000&quot;, &quot;Guam Standard&quot;},
    new string[] {&quot;HDT&quot;, &quot;-0900&quot;, &quot;Hawaii Daylight&quot;},
    new string[] {&quot;HST&quot;, &quot;-1000&quot;, &quot;Hawaii Standard&quot;},
    new string[] {&quot;IDLE&quot;, &quot;+1200&quot;, &quot;Internation Date Line East&quot;},
    new string[] {&quot;IDLW&quot;, &quot;-1200&quot;, &quot;Internation Date Line West&quot;},
    new string[] {&quot;IST&quot;, &quot;+0530&quot;, &quot;Indian Standard&quot;},
    new string[] {&quot;IT&quot;, &quot;+0330&quot;, &quot;Iran&quot;},
    new string[] {&quot;JST&quot;, &quot;+0900&quot;, &quot;Japan Standard&quot;},
    new string[] {&quot;JT&quot;, &quot;+0700&quot;, &quot;Java&quot;},
    new string[] {&quot;MDT&quot;, &quot;-0600&quot;, &quot;(US) Mountain Daylight&quot;},
    new string[] {&quot;MED&quot;, &quot;+0200&quot;, &quot;Middle European Daylight&quot;},
    new string[] {&quot;MET&quot;, &quot;+0100&quot;, &quot;Middle European&quot;},
    new string[] {&quot;MEST&quot;, &quot;+0200&quot;, &quot;Middle European Summer&quot;},
    new string[] {&quot;MEWT&quot;, &quot;+0100&quot;, &quot;Middle European Winter&quot;},
    new string[] {&quot;MST&quot;, &quot;-0700&quot;, &quot;(US) Mountain Standard&quot;},
    new string[] {&quot;MOUNTAIN&quot;, &quot;-0700&quot;, &quot;(US) Mountain Standard&quot;},
    new string[] {&quot;MT&quot;, &quot;+0800&quot;, &quot;Moluccas&quot;},
    new string[] {&quot;NDT&quot;, &quot;-0230&quot;, &quot;Newfoundland Daylight&quot;},
    new string[] {&quot;NFT&quot;, &quot;-0330&quot;, &quot;Newfoundland&quot;},
    new string[] {&quot;NT&quot;, &quot;-1100&quot;, &quot;Nome&quot;},
    new string[] {&quot;NST&quot;, &quot;+0630&quot;, &quot;North Sumatra&quot;},
    new string[] {&quot;NZ&quot;, &quot;+1100&quot;, &quot;New Zealand &quot;},
    new string[] {&quot;NZST&quot;, &quot;+1200&quot;, &quot;New Zealand Standard&quot;},
    new string[] {&quot;NZDT&quot;, &quot;+1300&quot;, &quot;New Zealand Daylight &quot;},
    new string[] {&quot;NZT&quot;, &quot;+1200&quot;, &quot;New Zealand&quot;},
    new string[] {&quot;PDT&quot;, &quot;-0700&quot;, &quot;(US) Pacific Daylight&quot;},
    new string[] {&quot;PST&quot;, &quot;-0800&quot;, &quot;(US) Pacific Standard&quot;},
    new string[] {&quot;PACIFIC&quot;, &quot;-0800&quot;, &quot;(US) Pacific Standard&quot;},
    new string[] {&quot;ROK&quot;, &quot;+0900&quot;, &quot;Republic of Korea&quot;},
    new string[] {&quot;SAD&quot;, &quot;+1000&quot;, &quot;South Australia Daylight&quot;},
    new string[] {&quot;SAST&quot;, &quot;+0900&quot;, &quot;South Australia Standard&quot;},
    new string[] {&quot;SAT&quot;, &quot;+0900&quot;, &quot;South Australia Standard&quot;},
    new string[] {&quot;SDT&quot;, &quot;+1000&quot;, &quot;South Australia Daylight&quot;},
    new string[] {&quot;SST&quot;, &quot;+0200&quot;, &quot;Swedish Summer&quot;},
    new string[] {&quot;SWT&quot;, &quot;+0100&quot;, &quot;Swedish Winter&quot;},
    new string[] {&quot;USZ3&quot;, &quot;+0400&quot;, &quot;USSR Zone 3&quot;},
    new string[] {&quot;USZ4&quot;, &quot;+0500&quot;, &quot;USSR Zone 4&quot;},
    new string[] {&quot;USZ5&quot;, &quot;+0600&quot;, &quot;USSR Zone 5&quot;},
    new string[] {&quot;USZ6&quot;, &quot;+0700&quot;, &quot;USSR Zone 6&quot;},
    new string[] {&quot;UT&quot;, &quot;-0000&quot;, &quot;Universal Coordinated&quot;},
    new string[] {&quot;UTC&quot;, &quot;-0000&quot;, &quot;Universal Coordinated&quot;},
    new string[] {&quot;UZ10&quot;, &quot;+1100&quot;, &quot;USSR Zone 10&quot;},
    new string[] {&quot;WAT&quot;, &quot;-0100&quot;, &quot;West Africa&quot;},
    new string[] {&quot;WET&quot;, &quot;-0000&quot;, &quot;West European&quot;},
    new string[] {&quot;WST&quot;, &quot;+0800&quot;, &quot;West Australian Standard&quot;},
    new string[] {&quot;YDT&quot;, &quot;-0800&quot;, &quot;Yukon Daylight&quot;},
    new string[] {&quot;YST&quot;, &quot;-0900&quot;, &quot;Yukon Standard&quot;},
    new string[] {&quot;ZP4&quot;, &quot;+0400&quot;, &quot;USSR Zone 3&quot;},
    new string[] {&quot;ZP5&quot;, &quot;+0500&quot;, &quot;USSR Zone 4&quot;},
    new string[] {&quot;ZP6&quot;, &quot;+0600&quot;, &quot;USSR Zone 5&quot;}
};

        private static Hashtable ZoneTable;
        private static Dictionary&lt;string, string&gt; Synonimes;

        static DateTimeParser()
        {
            ZoneTable = new Hashtable(50);
            Synonimes = new Dictionary&lt;string, string&gt;();
            Synonimes[&quot;W. Europe Daylight Time&quot;] = &quot;WET&quot;;
            Synonimes[&quot;W. Europe Standard Time&quot;] = &quot;WET&quot;;
            Synonimes[&quot;Westeuropäische Normalzeit&quot;] = &quot;WET&quot;;
            Synonimes[&quot;Westeurop�ische Normalzeit&quot;] = &quot;WET&quot;;
            Synonimes[&quot;GMT-07:00&quot;] = &quot;GMT&quot;;
            //Synonimes[&quot;XX&quot;] = &quot;XXX&quot;;
            //Synonimes[&quot;XX&quot;] = &quot;XXX&quot;;
            

            
            foreach (string[] TimeZone in TimeZones)
            {
                ZoneTable.Add(TimeZone[0], TimeZone[1]);
            }
        }

        /// &lt;summary&gt;
        /// split it with empty char and try creating it
        /// with less and less parts until we get it right
        /// &lt;/summary&gt;
        private static DateTime TryFindingDate(string date)
        {
            string[] parts = date.Split(&quot; &quot;.ToCharArray());
            int length = parts.Length;
            for (int i = 1; i &lt; length; i++)
            {
                int toTake = length - i;
                string[] partsToTry = parts.Take(toTake).ToArray();
                string toParse = string.Join(&quot; &quot;, partsToTry);
                DateTime result;
                bool isOk = DateTime.TryParse(toParse, out result);
                if(isOk)
                    return result;
            }
            //this will throw proper exception
            return Convert.ToDateTime(date);
        }

        public static DateTime ConvertWithTimezone(string StrDate)
        {
            
            DateTime ConvertedDate;
            StrDate= ReplaceSynonimeValues(StrDate);
            //StrDate = AddColumnIfNeeded(StrDate);
            try
            {
                ConvertedDate = Convert.ToDateTime(StrDate);
                // just a plain date
                return ConvertedDate;
            }
            catch (FormatException fex)
            {
                #region old
                //// try finding a timezone in the date
                //int TZstart = StrDate.LastIndexOf(&quot; &quot;);

                //if (TZstart != -1)
                //{
                //    string TZstr = StrDate.Substring(TZstart + 1); // +1 to avoid the space character
                //    string TZvalue = ZoneTable[TZstr] as string;

                //    // its a timezone problem ...
                //    if (TZvalue != null)
                //    {
                //        // replace timezone name with actual hours (AEST = +1000)
                //        string NewDateStr = StrDate.Replace(TZstr, TZvalue);

                //        try
                //        {
                //            ConvertedDate = Convert.ToDateTime(NewDateStr);

                //            // success this time
                //            return ConvertedDate;
                //        }
                //        catch (FormatException innerfex)
                //        {
                //            // something else wrong, we dont know what to do
                //            throw innerfex;
                //        }
                //    }
                //}

                //throw fex;
#endregion  old
            }

            return TryFindingDate(StrDate);
        }
        /// &lt;summary&gt;
        /// converts this madness 28 Jun 04 1237
        /// into  28 Jun 04 12:37
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;date&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private static string AddColumnIfNeeded(string date)
        {
            string[] parts = date.Split(&quot; &quot;.ToCharArray());
            if(parts.Length&lt;=4)
                return date;

            string hoourMins = parts[3];
            hoourMins = RepairHouMins(hoourMins);
            parts[3] = hoourMins;


            //string jahr = parts[2];
            //jahr = RepairJahr(jahr);
            //parts[2] = jahr;
            return string.Join(&quot; &quot;, parts);

        }

        private static string RepairJahr(string jahr)
        {
            return jahr;
            if(jahr.Length==2)
            {
                try
                {
                    int j = Convert.ToInt32(jahr);
                    if (j &gt; 20)
                        j += 1900;
                    else
                    {
                        j += 2000;
                    }
                    return j.ToString();
                }
                catch (Exception)
                {
                    return jahr;
                    //throw;
                }
            }
            return jahr;
        }

        private static string RepairHouMins(string hoourMins)
        {
            if (hoourMins.Length != 4)
                return hoourMins;


            var chars = hoourMins.ToCharArray().ToList();
            chars.Insert(2, ':');
            hoourMins = new string(chars.ToArray());
            return hoourMins;
        }

        private static string ReplaceSynonimeValues(string date)
        {
            StringBuilder stringBuilder = new StringBuilder(date);
            foreach (KeyValuePair&lt;string, string&gt; pair in Synonimes)
            {
                stringBuilder.Replace(pair.Key, pair.Value);
            }

            return stringBuilder.ToString();
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
NREUMQ.push(["nrfj","beacon-1.newrelic.com","9dfe439095",8763,"Il9dRhNbCVtVQhgXQgBTVkFOWgpTVUMYF1oORw==",0.0,75,new Date().getTime(),"","","","",""])</script></body>
</html>




