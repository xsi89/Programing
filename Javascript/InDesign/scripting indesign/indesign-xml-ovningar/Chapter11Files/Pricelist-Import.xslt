<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/">
 <BKP>
      <xsl:for-each select="BK/Book">
      <xsl:sort select="artistlastname"/>
		<Blist>
		<format><xsl:value-of select="producttype"/></format>
        <title><xsl:value-of select="productname"/></title>
        <lastname><xsl:value-of select="artistlastname"/></lastname>
        <firstname><xsl:value-of select="artistfirstname"/></firstname>
        <released><xsl:value-of select="year"/></released>
        <sku><xsl:value-of select="productid"/></sku>
        <srp><xsl:value-of select="price"/></srp>
   		</Blist>	  
      </xsl:for-each>
  </BKP>
</xsl:template>
</xsl:stylesheet>
