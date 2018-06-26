<?xml version="1.0" encoding="UTF-8"?> 
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/">
<html>
	<head>
		<meta content="text/html;charset=utf-8" />
		<title>Book List</title>
	    <link href="export_style.css" rel="stylesheet" type="text/css" />
	</head>
<body>
  <table width="800" border="0" cellpadding="10" cellspacing="0">
<tr bgcolor="#003399">
					<th width="150"><font  color="white">Format</font></th>
		<th><font  color="white">Title</font></th>
					<th width="200"><font  color="white">Author</font></th>
	  </tr>
      <xsl:for-each select="BK/Book">
      <tr>
        <td><xsl:value-of select="Book"/></td>
        <td><xsl:value-of select="productname"/></td>
        <td><xsl:value-of select="artistlastname"/></td>
       </tr>
      </xsl:for-each>
		</table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>
