



  



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head><script type="text/javascript">var NREUMQ=NREUMQ||[];NREUMQ.push(["mark","firstbyte",new Date().getTime()]);</script>
    <title>GmailHelper/GmailHelper.Data.Linq/AutoCompleteResuts.cs | Source/SVN | Assembla</title>
    <link href="http://assets1.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="shortcut icon" />
    <link href="http://assets2.assembla.com/favicon.ico?1327583367" type="image/x-icon" rel="icon" />
    <link href="http://assets2.assembla.com/favicon.gif?1327583367" type="image/gif" rel="icon" />
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
  <h1 class="icon-breadcrumb-path"><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=11" class="root">root</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper?rev=11">GmailHelper</a>/<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.Data.Linq?rev=11">GmailHelper.Data.Linq</a>/<span>AutoCompleteResuts.cs</span><span>    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
            width="110"
            height="14"
            id="clippy" >
    <param name="movie" value="/clippy.swf"/>
    <param name="allowScriptAccess" value="always" />
    <param name="quality" value="high" />
    <param name="scale" value="noscale" />
    <param NAME="FlashVars" value="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.Data.Linq/AutoCompleteResuts.cs/" />
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
           FlashVars="text=http://subversion.assembla.com/svn/bniEmC9p0r3P96eJe5aVNr/GmailHelper/GmailHelper.Data.Linq/AutoCompleteResuts.cs/"
           bgcolor="#FFFFFF"
           wmode="transparent"
    />
    </object>
</span></h1>
  
<div class="commit-infobox">
  <div class="commit-options">
    <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/logs/GmailHelper/GmailHelper.Data.Linq/AutoCompleteResuts.cs?rev=11" class="revision-log" rel="nofollow">Revision log</a>
      <div style="margin-right: 10px;" class="small-icon-button">
        <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/node/live/11/GmailHelper/GmailHelper.Data.Linq/AutoCompleteResuts.cs" class="view-icon" rel="nofollow">View as a web page</a>
      </div>

        <div style="margin-right: 10px;" class="small-icon-button">
    <a class="download-icon" href="#" onclick="nobotGoto('!/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes/GmailHelper/GmailHelper.Data.Linq/AutoCompleteResuts.cs?_format=raw&amp;rev=11'); return false;">Download</a>
  </div>


  </div>

  <div class="committer-pic">
    <img alt="User picture" src="http://assets1.assembla.com/images/no-picture.png?1340419163" />
  </div>

  
<div class="commit-info">

    <p class="committer-info"><span>Author:</span> <a href="/profile/kazazic" tabindex="-1" target="_blank" title="Show Profile">kazazic</a></p>

  <p class="committer-info"><span>Revision:</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/changesets/9">11</a> (<span>«<a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=10">Previous</a></span> <span><a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes?rev=12">Next</a>»</span> <a href="/code/bniEmC9p0r3P96eJe5aVNr/subversion/nodes">Latest</a>)</p><br />
    <p class="commit-size">
      <span>File Size:</span>
      4.44 KB
    </p>
  <p class="commit-date">(January 02, 2010 14:00 UTC) Over 2 years ago</p>
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
<a href="#ln145" class="block" id="ln145">145</a></pre></th>
            <td><pre class="prettyprint lang-cs">﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GmailHelper.Data.Linq
{
    public class WordFreq  // the type for the results
    {
        public string Word { get; set; }
        public int NrMails { get; set; }

        public int SubjectFreq { get; set; }
        public int BodyFreq { get; set; }
        public DateTime? UsedDate { get; set; }
    }

    public class AutoCompleteResuts
    {
        private  string _input;
        private int _nrResults;
        private string[] _tokens;
        private void  InitValues(string input, int nrResults)
        {
            _input = input;
            _nrResults = nrResults;
            _tokens = input.Split(&quot; &quot;.ToCharArray());
        }

        private string SelectTableName
        {
            get
            {
                //we are zer based ant lenght is not
                return &quot;mw&quot; + (_tokens.Length-1);
            }
        }
        private string GroupBy
        {
            get
            {
                return &quot; group by &quot; + SelectTableName + &quot;.Word &quot;+Environment.NewLine;
            }
        }
        private string Select
        {
            get
            {
               string reuslt= &quot;select top &quot; + _nrResults +
                @&quot; {TN}.Word, count(distinct ({TN}.MailId)) as NrMails, sum({TN}.SubjectFrequency) as SubjectFreq, 
                    SUM ({TN}.BodyFrequency) as BodyFreq , MAX(m.Sent)as UsedDate&quot; + Environment.NewLine;
                return reuslt.Replace(&quot;{TN}&quot;, SelectTableName);
            }
        }

        private string FromAndJoin
        {
            get
            {
                
                //from Mail m
                //inner join  MailWord mw on m.MailId=mw.MailId
                //inner join  MailWord mw2 on mw.MailId=mw2.MailId
                var result = new StringBuilder(&quot; from Mail m &quot;+ Environment.NewLine);
                string prevousTableName = &quot;m&quot;;
                for (int i = 0; i &lt; _tokens.Length; i++)
                {
                    string join=&quot;inner join MailWord mw&quot;+i+&quot; on &quot; + prevousTableName + &quot;.MailId=mw&quot; + i + &quot;.MailId&quot;;
                    prevousTableName = &quot;mw&quot; + i;
                    result.AppendLine(join);

                }
                return result.ToString();

            }
        }

        private string Where
        {
            
            get
            {
                // where 1=1 
                // and mw.word like'almir%'
                //and mw2.Word like 't%'
                StringBuilder  sb = new StringBuilder(&quot; where 1=1 &quot;);
                string notLike = &quot;&quot;;
                for (int i = 0; i &lt; _tokens.Length; i++)
                {
                    string line = &quot; AND mw&quot; + i + &quot;.Word like '&quot; + _tokens[i] + &quot;%'&quot;;
                    
                    sb.AppendLine( line + notLike );
                    //next not like this one
                    notLike = Environment.NewLine + &quot; and mw&quot; + (i+1) + &quot;.Word not like '&quot; + _tokens[i] + &quot;%'&quot;;
                }
                return sb.ToString();

            }
        }

        private string OrderBy
        {

            get
            {
                //order by SubjectFreq desc, BodyFreq desc
                return &quot; order by SubjectFreq desc, BodyFreq desc &quot;+Environment.NewLine;
            }
        }

        public string PrevousWords
        {
            get { 
                if(_tokens.Length==1)
                {
                    return string.Empty;
                }
                List&lt;string&gt; words = new List&lt;string&gt;(_tokens);
                words.RemoveAt(words.Count-1);
                return string.Join(&quot; &quot;, words.ToArray());

            }
        }

        public  IList&lt;WordFreq&gt; GetResults(string input, int nr)
        {
            InitValues(input,nr);
            
            var sb = new StringBuilder();
            sb.AppendLine(Select);
            sb.AppendLine(FromAndJoin);
            sb.AppendLine(Where);
            sb.AppendLine(GroupBy);
            sb.AppendLine(OrderBy);
            string query = sb.ToString();

            Console.WriteLine(query);
            using( GmailHelperLinqDataContext ctx = new GmailHelperLinqDataContext())
            {
                var results = ctx.ExecuteQuery&lt;WordFreq&gt;(query);
                return results.ToList();
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
NREUMQ.push(["nrfj","beacon-1.newrelic.com","9dfe439095",8763,"Il9dRhNbCVtVQhgXQgBTVkFOWgpTVUMYF1oORw==",0.0,72,new Date().getTime(),"","","","",""])</script></body>
</html>




