macroScript turnMapsOnOFF
category:"Daves Tools"
tooltip:"Turn Viewport Maps on/off"
buttontext:"Turn Viewport Maps on/off"
silentErrors:True
(
	on execute do ( -- run script
		local scriptfile = "\\turnViewPortMapsOn.ms"
		filein ((getdir #scripts) + scriptfile)
	)
)