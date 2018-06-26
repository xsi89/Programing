<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet  [
	<!ENTITY nbsp   "&#160;">
	<!ENTITY copy   "&#169;">
	<!ENTITY reg    "&#174;">
	<!ENTITY trade  "&#8482;">
	<!ENTITY mdash  "&#8212;">
	<!ENTITY ldquo  "&#8220;">
	<!ENTITY rdquo  "&#8221;"> 
	<!ENTITY pound  "&#163;">
	<!ENTITY yen    "&#165;">
	<!ENTITY euro   "&#8364;">
]>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="utf-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

<xsl:template match="/">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<!-- This text is within a comment area. It does not format or affect the file in any way. Insert the link to the external CSS file in the blank line below -->
<link href="newsletterstyle.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

</head>
<body>

<div id="wrapper">
<div id="issue-id"><h4><xsl:apply-templates select="GreenStartNews/Issue-id"/></h4>
</div>
	<div id="left">
		<div id="events">
    		<xsl:apply-templates select="GreenStartNews/Events"/>
		</div>

<div id="greenthumb">
    		<xsl:apply-templates select="GreenStartNews/Greenthumb"/>

</div>

</div>

<div id="main">
    		<xsl:apply-templates select="GreenStartNews/news"/>

</div>

<div id="right">
<div id="toc">
    		<xsl:apply-templates select="GreenStartNews/TOC"/>

</div>
<div id="toptips">
    		<xsl:apply-templates select="GreenStartNews/Toptips"/>

</div>
</div>
</div>
</body>
</html>
</xsl:template>

	<xsl:template match="Event">
		<p class="event"><xsl:apply-templates/></p>
	</xsl:template>

	<xsl:template match="Eventdate">
		<p class="eventdate"><xsl:apply-templates/></p>
	</xsl:template>

    <xsl:template match="Heading1">
		<h1><xsl:apply-templates/></h1>
	</xsl:template>

   	<xsl:template match="Heading2">
		<h2><xsl:apply-templates/></h2>
	</xsl:template>

	<xsl:template match="Heading3">
		<h3><xsl:apply-templates/></h3>
	</xsl:template>

	<xsl:template match="Body-cal">
		<p class="bodycal"><xsl:apply-templates/></p>
	</xsl:template>

   	<xsl:template match="Body-tips">
		<p class="bodytips"><xsl:apply-templates/></p>
	</xsl:template>

   	<xsl:template match="TOCItem">
		<p class="tocitem"><xsl:apply-templates/></p>
	</xsl:template>

   	<xsl:template match="bold">
		<span class="bold"><xsl:apply-templates/></span>
	</xsl:template>
	
   	<xsl:template match="boldblue">
		<span class="boldblue"><xsl:apply-templates/></span>
	</xsl:template>
	
   	<xsl:template match="pgnumber">
		<span class="pgnumber"><xsl:apply-templates/></span>
	</xsl:template>
    
   	<xsl:template match="green">
		<span class="green"><xsl:apply-templates/></span>
	</xsl:template>

   	<xsl:template match="blue">
		<span class="blue"><xsl:apply-templates/></span>
	</xsl:template>

   	<xsl:template match="volume_no">
		<span class="volume_no"><xsl:apply-templates/></span>
	</xsl:template>
    
   	<xsl:template match="issue_no">
		<span class="issue_no"><xsl:apply-templates/></span>
	</xsl:template>
    
   	<xsl:template match="issue_month">
		<span class="issue_month"><xsl:apply-templates/></span>
	</xsl:template>
    

    
</xsl:stylesheet>
